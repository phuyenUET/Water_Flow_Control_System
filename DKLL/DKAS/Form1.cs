using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.Management;
using System.Web;
namespace DKAS
{
    public partial class Form1 : Form
    {
        float flowValue = 0;
        int State_bt_run = 0;
        int State_bt_mode = 0;
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            flowValue = 0;
            State_bt_mode = 1;
            bt_mode.BackColor = Color.Green;
            bt_mode.Text = "Auto";
            bt_run.Visible = false;

            SerialPort serialPort1 = new SerialPort();
            string[] Baudrate = { "2400", "9600", "115200" };
            cBaud.Items.AddRange(Baudrate);
            string[] nameport = SerialPort.GetPortNames();
            cCOM.Items.AddRange(nameport);
            serialPort1.Parity = Parity.None; // Không có bit kiểm tra chẵn/lẻ
            serialPort1.StopBits = StopBits.One; // Một bit dừng
            serialPort1.DataBits = 8; // 8 bit dữ liệu
            serialPort1.Handshake = Handshake.None; // Không sử dụng kiểm soát luồng


            cBaud.Text = "9600";
            GraphPane bd = zedGraphControl1.GraphPane;
            bd.Title.Text = "Đồ thị";
            bd.YAxis.Title.Text = "Giá trị";
            bd.XAxis.Title.Text = "Thời gian";

            RollingPointPairList list = new RollingPointPairList(500000);
            RollingPointPairList list2 = new RollingPointPairList(500000);
            LineItem line = bd.AddCurve("Cường độ", list, Color.Blue, SymbolType.None);
            LineItem lineSetpoint = bd.AddCurve("Cài đặt", list2, Color.Red, SymbolType.None);
            bd.XAxis.Scale.Min = 0;
            bd.XAxis.Scale.Max = 30;
            bd.XAxis.Scale.MinorStep = 1;
            bd.XAxis.Scale.MajorStep = 5;
            bd.YAxis.Scale.Min = 0;
            bd.YAxis.Scale.Max = 10000;
            bd.YAxis.Scale.MinorStep = 50;
            bd.YAxis.Scale.MajorStep = 100;
            zedGraphControl1.AxisChange();
            receiveflow.Text = "no Data";
        }

        private void bt_run_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1 != null && serialPort1.IsOpen)
                {
                    State_bt_run = (State_bt_run == 0) ? 1 : 0;
                    if (State_bt_run == 1)
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
                    MessageBox.Show("Serial port không mở hoặc không khởi tạo.");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi!");
            }
        }

        private void bt_mode_Click(object sender, EventArgs e)
        {
            try
            {
                State_bt_mode = (State_bt_mode == 0) ? 1 : 0;
                if (State_bt_mode == 0)
                {
                    string dataToSend = "auto\r\n";
                    serialPort1.WriteLine(dataToSend);
                    bt_mode.BackColor = Color.Green;
                    bt_mode.Text = "Auto";
                    bt_run.Visible = false;
                }
                else
                {
                    string dataToSend = "manu\r\n";
                    serialPort1.WriteLine(dataToSend);
                    bt_mode.BackColor = Color.White;
                    bt_mode.Text = "Manual";
                    bt_run.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi gửi dữ liệu!");
            }
        }
        private void label2_Click_1(object sender, EventArgs e)
        {
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private double tong = 0;
        private void draw(double line1,double line2, GraphPane bd)
        {
            if (zedGraphControl1.GraphPane.CurveList.Count > 0)
            {
                LineItem duongline = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
                LineItem duongline1 = zedGraphControl1.GraphPane.CurveList[1] as LineItem;
                if (duongline == null)
                {
                    return;
                }
                IPointListEdit list = duongline.Points as IPointListEdit;
                IPointListEdit list2 = duongline1.Points as IPointListEdit;
                if (list == null)
                {
                    return;
                }
                double maxX = bd.XAxis.Scale.Max;
                double minX = bd.XAxis.Scale.Min;
                double deltaX = 20;
                if (tong > maxX)
                {
                    bd.XAxis.Scale.Max += deltaX;
                    bd.XAxis.Scale.Min += deltaX;
                    maxX = bd.XAxis.Scale.Max;
                    minX = bd.XAxis.Scale.Min;
                }

                list2.Add(tong, line2);
                list.Add(tong, line1);
                if (tong > maxX)
                {
                    zedGraphControl1.GraphPane.XAxis.Scale.Max = maxX;
                    zedGraphControl1.GraphPane.XAxis.Scale.Min = minX;
                }
                tong += 1;
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }

        }
        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void kn_Click(object sender, EventArgs e)
        {
            try
            {
                if (cCOM.Text == "" || cBaud.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin", "Thông báo");
                }
                else if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    kn.ForeColor = Color.Green;
                    kn.Text = "Connect";
                    MessageBox.Show("Đã đóng kết nối!");

                }
                else
                {
                    serialPort1.PortName = cCOM.Text;
                    serialPort1.BaudRate = int.Parse(cBaud.Text);
                    serialPort1.Open();
                    kn.Text = "Disconnect";
                    kn.ForeColor = Color.Red;
                    MessageBox.Show("Đã kết nối");
                    serialPort1.WriteLine("FFFF");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1 != null && serialPort1.IsOpen)
                {
                    float flowValue = Convert.ToSingle(luuluongdat.Text);

                    if (flowValue < 0 || flowValue > 20000)
                    {
                        MessageBox.Show("Giá trị không hợp lệ! Vui lòng nhập giá trị từ 0 đến 20000.");
                        return;
                    }
                    string dataToSend = luuluongdat.Text;
                    serialPort1.WriteLine(dataToSend);
                    serialPort1.WriteLine("\r\n");
                }
                else
                {
                    MessageBox.Show("Không có kết nối nào được mở!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ! " + ex.Message);
            }
        }
        //string parts;

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            try
            {
                string[] parts;
                string alldata = serialPort1.ReadLine();
                parts = alldata.Split('|');
                if (alldata.Length >= 3)
                {
                    
                    Invoke(new MethodInvoker(() => tb_Utra.Text = parts[0]));
                    Invoke(new MethodInvoker(() => receiveflow.Text = parts[1]));
                    Invoke(new MethodInvoker(() => situa.Text = parts[2]));
                    if (situa.Text.Trim() == "ON")
                    {
                        situa.ForeColor = Color.Green;
                        pictureBox1.Image = Properties.Resources.Ảnh_chụp_màn_hình_2024_05_18_102015;
                    }
                    else if (situa.Text.Trim() == "OFF")
                    {
                        situa.ForeColor = Color.Red;
                        pictureBox1.Image = Properties.Resources.Ảnh_chụp_màn_hình_2024_05_18_102627;
                    }
                    double cuongdo1;

                    if (double.TryParse(parts[1], out cuongdo1))
                    {
                        draw(cuongdo1,flowValue, zedGraphControl1.GraphPane);
                    }
                    alldata = "";
                }              
            }
            catch
            {
                return;
            }
        }

        
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private void bt_send_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1 != null && serialPort1.IsOpen)
                {
                     flowValue = Convert.ToSingle(luuluongdat.Text);

                    if (flowValue < 0 || flowValue > 20000)
                    {
                        MessageBox.Show("Giá trị không hợp lệ! Vui lòng nhập giá trị từ 0 đến 20000.");
                        return;
                    }
                    string dataToSend = "F" + luuluongdat.Text + "\r\n";
                    serialPort1.WriteLine(dataToSend);
                }
                else
                {
                    MessageBox.Show("Không có kết nối nào được mở!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ! " + ex.Message);
            }
        }

        private void receiveflow_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tb_Utra_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }
    }
}
