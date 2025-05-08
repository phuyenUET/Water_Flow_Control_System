/*
 * PumpSystem.c
 *
 * Created: 4/10/2025 4:33:08 PM
 * Author : Pham Nhu Nguyen
 */ 

#define F_CPU 8000000UL
#define BAUD 9600
#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>

//------------------------------------BIEN--------------------------------------------------
uint8_t flag = 0; //co bao ngat
int pulse = 0, count = 0;
short SendUartData = 1;
short StatePump = 1;
int duty;
float currentFlow = 0;
char str[20], tmp[8];
char uart_buffer[16]; // Bien tam luu du lieu tu UART
volatile uint8_t uart_index = 0; // chi so cua bien buffer
volatile uint8_t uart_flag = 0; // co hieu nhan duoc du lieu tu usart
volatile uint8_t timer0_ovf_count = 0;
double distance;
char sensor[10];




//-------------------------------------BIEN PID---------------------------------------------
float setPoint = 0, tmpSetPoint;
float previousError = 0;
float integral = 0;






//------------------------------------HANG SO PID va HAM TINH PID-------------------------------------------	
const float Kp = 0.05;
const float Ki = 0.009;
const float Kd = 0.00655;

float calculatePID(float setpoint, float measuredValue)
{
	float error = setpoint - measuredValue;
	integral += error;
	float derivative = error - previousError;
	previousError = error;

	float output = Kp * error + Ki * integral + Kd * derivative;
	return output;
}



//------------------------------------TIMER0_INIT-------------------------------------------
void Timer0_init()
{
	TCCR0 = (1 << CS02) | (1 << CS00); // Prescaler = 1024
	TCNT0 = 0;
	TIMSK |= (1 << TOIE0);             // Enable Timer0 overflow interrupt
}


void enableReadFlow()
{
	TCNT0 = 0;			// Gia tri khoi dau cua Timer0
	count = 0;
}






//--------------------------------TIMER2_INIT--------------------------------------
void enablePump()
{
	// Cau hinh Timer/Counter2
	TCCR2 = (1 << COM21) | (1 << COM20) | (1 << WGM20) | (1 << WGM21) | (1 << CS22);    // Fast PWM, inverting mode,/256
}
void disablePump()
{
	duty = 0; 
	OCR2 = duty;  //tat dong co
}





//-------------------------TINH TOAN FLOWRATE TU PULSE-----------------------------
float FlowRate(int pulse)
{
	float fR = ((float)pulse) / 98*1000;
	return fR;
}






//-----------------------------------USART-----------------------------------------
void UART_Init()
{
	UBRRH = 0;
	UBRRL = (int)(F_CPU/16/BAUD - 1);
	UCSRA = 0x00;
	UCSRC |= (1<<URSEL)|(1<<UCSZ0)|(1<<UCSZ1);	//chon thanh ghi UCSRC ,truyen 8 bit, 1 bit start ,1 bit stop.
	UCSRB |= (1<<RXCIE)|(1<<RXEN)|(1<<TXEN);	//Bat rx-tx, va ngat khi nhan xong du lieu.
}
void UART_putchar(char data)
{
	while(!(UCSRA&(1<<UDRE)));
	UDR = data;
}
void UART_write(char *string)
{
	unsigned char i=0;
	while(string[i]!=0)
	{
		UART_putchar(string[i]);
		i++;
	}
}






//-------------------------------------INTERRUPT---------------------------------------
ISR(TIMER0_OVF_vect)
{
	timer0_ovf_count++;
	if (timer0_ovf_count >= 30) // 1giay
	{
		timer0_ovf_count = 0;
		pulse = count;
		count = 0;
		flag = 1;
	}
}
ISR(INT2_vect)
{
	count++;
}

ISR(USART_RXC_vect)
{
	char buffer = UDR;
	if ((uart_index < 9) && (buffer !='\n') && (buffer !='\r'))		// Only save 9 characters
	{
		uart_buffer[uart_index++] = buffer; // Luu du lieu vao bien tam
	}
	else
	{
		uart_buffer[uart_index]='\0';
		uart_index = 0; // Reset chi so
		uart_flag = 1; // Set the UART flag for data reception completion
	}
}
//--------------------------------------MAIN------------------------------------------
int main(void)
{
	DDRA &= ~(1 << PINA0);
	PORTA = 0x00;
	DDRD |= (1 << PIND7) ; // PD7 dau ra PWM
	
	// Timer(s)/Counter(s) Interrupt(s) initialization
	TIMSK = (0 << OCIE2) | (0 << TOIE2) | (0 << TICIE1) | (0 << OCIE1A) | (0 << OCIE1B) | (1 << TOIE1) | (0 << OCIE0) | (1 << TOIE0);
	
	
	enableReadFlow();
	
	
	//------------------------------INT2------------------------------------------
	DDRB &= ~(1 << PINB2);	//set PB2 is input
	PORTB |= (1 << PINB2); // Kich hoat Pull-up cho PD2
	GICR |= (1<<INT2);
	MCUCSR &= ~(1<<ISC2); // Clear ISC2 bit to trigger interrupt on falling edge
	
	UART_Init();
	Timer0_init();  
	sei();
	
	while (1)
	{	
		if ((PINA & (1 << PINA0))==1)
		{
			StatePump = 0;
			disablePump();
			previousError = 0;
			integral = 0;
			strcpy(sensor, "LOW");
		} else {
			strcpy(sensor, "HIGH");
		}

		
		if (flag)	//doc xong du lieu tu cam bien luu luong
		{
			flag=0;
			//doc du lieu data
			currentFlow = FlowRate(pulse);

			if (StatePump)
			{
				//duty cycle dau ra
				float output = calculatePID(setPoint, currentFlow);

				// Gioi han gia tri dau ra trong khoang tu 0 den 255 (8-bit)
				output = output < 0 ? 0 : (output > 255 ? 255 : output);
				duty = (uint8_t)output;
				// gia tri do rong xung PWM
				OCR2 = duty;
			}
			SendUartData = 1;
		}

		if (SendUartData)
		{
			SendUartData = 0;
			//convert to string for sending
			
			dtostrf(duty, 2, 2, tmp);
			sprintf(str, "%s|", tmp);
			
			UART_write(str);		//send duty
			
			dtostrf(currentFlow, 2, 2, tmp);
			if (StatePump)
			{
				sprintf(str, "%s|ON|", tmp);
			}
			else
			{
				sprintf(str, "%s|OFF|", tmp);
			}
			UART_write(str);		//send flow data
			
			sprintf(str, "%s\r\n",sensor);
			UART_write(str);		//send sensor_state	
		}
		if (uart_flag)	//nhan duoc du lieu
		{
			if (uart_buffer[0] =='C')	//Command turn on/off the pump
			{
				if (uart_buffer[1] =='1')	//received "C1"
				{
					StatePump = 1;
				}
				else if (uart_buffer[1] =='0')	//received "C0"
				{
					StatePump = 0;
				}
			}
			else if (uart_buffer[0] =='F')  //received set point
			{
				strncpy(tmp, uart_buffer+1, strlen(uart_buffer)-1);
				tmpSetPoint = atof(tmp); //convert string to float
					
				if (tmpSetPoint != setPoint)
				{
					setPoint = tmpSetPoint;	//update new set point
					previousError = 0;
					integral = 0;
				}
			}	
			uart_flag = 0;
			if (StatePump){
				enablePump();
			}
			else
			{
				disablePump();
				previousError = 0;
				integral = 0;
			}
		}
	}
}