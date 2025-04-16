using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Web;
using ZedGraph;
using System.IO.Ports;
using System.Collections;

namespace WaterControl
{
    public partial class Form1 : Form
    {
        float flowValue = 0;
        int state_btnRun = 0;
        int state_btnMode = 0;
        private double accumulation = 0;
        private SerialPort serialPort1 = new SerialPort();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Initializing
            flowValue = 0;
            state_btnMode = 1;
            btnMode.BackColor = Color.Green;
            btnMode.Text = "Auto";
            btnRun.Visible = false;

            // set up I/O Port 
            //SerialPort serialPort1 = new SerialPort();
            serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);

            string[] Baudrate = { "2400", "9600", "115200" };
            cBaud.Items.AddRange(Baudrate);
            cBaud.Text = "9600";
            string[] Portname = SerialPort.GetPortNames();
            cCOM.Items.AddRange(Portname);

            // Frame config
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;
            serialPort1.DataBits = 8;
            serialPort1.Handshake = Handshake.None;

            // ZedGraph
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "Water Flow Rate Monitoring";
            myPane.XAxis.Title.Text = "Time";
            myPane.YAxis.Title.Text = "Value";

            RollingPointPairList list_flowRate = new RollingPointPairList(500000);
            RollingPointPairList list_Setpoint = new RollingPointPairList(500000);
            LineItem line_flowRate = myPane.AddCurve("Flow rate", list_flowRate, Color.Blue, SymbolType.None);
            LineItem line_Setpoint = myPane.AddCurve("Setpoint", list_Setpoint, Color.Red, SymbolType.None);

            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 30;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;

            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 10000;
            myPane.YAxis.Scale.MinorStep = 50;
            myPane.YAxis.Scale.MajorStep = 100;

            zedGraphControl1.AxisChange();
            txtReceivedFlow.Text = "No Data";
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (cCOM.Text == "" || cBaud.Text == "")
                {
                    MessageBox.Show("You haven't entered required information!");
                }
                else if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    btnConnect.ForeColor = Color.Green;
                    btnConnect.Text = "Connect";
                    MessageBox.Show("Connection Closed!");
                }
                else
                {
                    serialPort1.PortName = cCOM.Text;
                    serialPort1.BaudRate = int.Parse(cBaud.Text); // *
                    serialPort1.Open();
                    btnConnect.Text = "Disconnect";
                    btnConnect.ForeColor = Color.Red;
                    MessageBox.Show("Connect Successfully!");
                    serialPort1.WriteLine("FFFF");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1 != null && serialPort1.IsOpen)
                {
                    state_btnRun = (state_btnRun == 0) ? 1 : 0;
                    if (state_btnRun == 1)
                    {
                        string dataToSend = "C1\r\n";
                        serialPort1.WriteLine(dataToSend);
                    }
                    else
                    {
                        string dataToSend = "C0\r\n";
                        serialPort1.WriteLine(dataToSend);
                    }
                }
                else
                {
                    MessageBox.Show("There is something wrong with the Seriol Port.");
                }
            }
            catch {
                MessageBox.Show("Error!");
            }
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            try
            {
                state_btnMode = (state_btnMode == 0) ? 1 : 0;
                if (state_btnMode == 0)
                {
                    string dataToSend = "auto\r\n";
                    serialPort1.WriteLine(dataToSend);
                    btnMode.BackColor = Color.Green;
                    btnMode.Text = "Auto";
                    btnRun.Visible = false;
                }
                else
                {
                    string dataToSend = "manu\r\n";
                    serialPort1.WriteLine(dataToSend);
                    btnMode.BackColor = Color.White;
                    btnMode.Text = "Manual";
                    btnRun.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show("Sending Error!");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1 != null && serialPort1.IsOpen)
                {
                    flowValue = Convert.ToSingle(txtFlowRate.Text);
                    if (flowValue < 0 || flowValue > 20000)
                    {
                        MessageBox.Show("Try again! Invalid value.");
                        return;
                    }
                    string dataToSend = "F" + txtFlowRate.Text + "\r\n";
                    serialPort1.WriteLine(dataToSend);
                }
                else
                {
                    MessageBox.Show("Error! No connection.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed bruh! " + ex.Message);
            }
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string[] parts;
                string alldata = serialPort1.ReadLine();
                parts = alldata.Split('|');
                if (alldata.Length >= 3)
                {
                    Invoke(new MethodInvoker(() => txtDuty.Text = parts[0]));
                    Invoke(new MethodInvoker(() => txtReceivedFlow.Text = parts[1]));
                    Invoke(new MethodInvoker(() => stPump.Text = parts[2]));
                }
                if (stPump.Text.Trim() == "ON")
                {
                    stPump.ForeColor = Color.Green;
                }
                else if (stPump.Text.Trim() == "OFF")
                {
                    stPump.ForeColor = Color.Red;
                }
                double f_rate;
                if (double.TryParse(parts[1], out f_rate))
                {
                    draw(f_rate, flowValue, zedGraphControl1.GraphPane);
                }
                alldata = "";
            }
            catch
            {
                return;
            }
        }
        private void draw(double line1,  double line2, GraphPane myPane)
        {
            if (zedGraphControl1.GraphPane.CurveList.Count > 0)
            {
                LineItem flowRateLine = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
                LineItem setpointLine = zedGraphControl1.GraphPane.CurveList[1] as LineItem;
                if (flowRateLine == null)
                {
                    return;
                }
                IPointListEdit list_fr = flowRateLine.Points as IPointListEdit;
                IPointListEdit list_sp = setpointLine.Points as IPointListEdit;
                if(list_fr == null)
                {
                    return;
                }
                double maxX = myPane.XAxis.Scale.Max;
                double minX = myPane.XAxis.Scale.Min;
                double deltaX = 20;
                if (accumulation > maxX)
                {
                    myPane.XAxis.Scale.Max += deltaX;
                    myPane.XAxis.Scale.Min += deltaX;
                    maxX = myPane.XAxis.Scale.Max;
                    minX = myPane.XAxis.Scale.Min;
                }
                list_fr.Add(accumulation, line1);
                list_sp.Add(accumulation, line2);
                if (accumulation > maxX)
                {
                    zedGraphControl1.GraphPane.XAxis.Scale.Max = maxX;
                    zedGraphControl1.GraphPane.XAxis.Scale.Min = minX;
                }
                accumulation += 1;
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
