using IEG3268_Dll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_cotrol1
{
    public partial class Login: Form
    {
        IEG3268 EtherCAT_M = new IEG3268();
       // private bool closeDoor = false;
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {
            
        }

        private void button25_Click(object sender, EventArgs e)
        {
            EtherCAT_M.Digital_Output(14, true);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            EtherCAT_M.Digital_Output(14, false);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            EtherCAT_M.Digital_Output(15, true);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            EtherCAT_M.Digital_Output(15, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EtherCAT_M.CIFX_50RE_Connect() == true)
            {
                label2.Text = "Connect OK";
                EtherCAT_M.ReadData_Send_Start(300); //Timer Interval Set
                EtherCAT_M.ReadData_Timer_Start(); //Timer Start
            }
            else
            {
                label2.Text = "NG";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            EtherCAT_M.CIFX_50RE_Disconnect();
            label2.Text = "Disconnect";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            // 웨이퍼 전진
            EtherCAT_M.Digital_Output(13, false);
            EtherCAT_M.Digital_Output(12, true);



        }

        private void button20_Click(object sender, EventArgs e)
        {
            // 웨이퍼 후진
            EtherCAT_M.Digital_Output(12, false);
            EtherCAT_M.Digital_Output(13, true);



        }

        private void button29_Click(object sender, EventArgs e)
        {
            //Servo ON
            EtherCAT_M.Axis1_ON();//up, down
            EtherCAT_M.Axis2_ON();// left, right
        }

        private void button31_Click(object sender, EventArgs e)
        {
            // 상,하 원점 복귀
            if (label10.Text == "False") // 블레이드 전진 OFF 
            {
                EtherCAT_M.Axis1_UD_Homming();
            }
            else
            {
                MessageBox.Show("웨이퍼 이송 실린더가 전진되어 있습니다." + "WrWn" + " 웨이퍼 이송 실린더를 후진해 주세요");
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            // 좌,우 원점 복귀
            if (label10.Text == "False") // 블레이드 전진 OFF 
            {
                EtherCAT_M.Axis2_LR_Homming();
            }
            else
            {
                MessageBox.Show("웨이퍼 이송 실린더가 전진되어 있습니다." + "WrWn" + " 웨이퍼 이송 실린더를 후진해 주세요");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //적색 ON
            EtherCAT_M.Digital_Output(0, true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //적색 OFF
            EtherCAT_M.Digital_Output(0, false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //황색ON
            EtherCAT_M.Digital_Output(1, true);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //황색 OFF
            EtherCAT_M.Digital_Output(1, false);
        }
        

        private void button7_Click(object sender, EventArgs e)
        {
            //녹색ON
            EtherCAT_M.Digital_Output(2, true);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //녹색OFF
            EtherCAT_M.Digital_Output(2, false);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // 챔버 A 등 ON
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ////챔버 A 등 OFF
            EtherCAT_M.Digital_Output(3, false);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Open
            EtherCAT_M.Digital_Output(4, true);
            EtherCAT_M.Digital_Output(5, false);

            //closeDoor = false;

            // 문이 열리면 램프 OFF
            EtherCAT_M.Digital_Output(3, true);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Close
             EtherCAT_M.Digital_Output(4, false);
             EtherCAT_M.Digital_Output(5, true);

             //closeDoor = true;

            // 문이 닫히면 램프 ON
             EtherCAT_M.Digital_Output(3, false);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //챔버 B 등 ON
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //챔버 B 등 OFF
            EtherCAT_M.Digital_Output(6, false);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //open
            EtherCAT_M.Digital_Output(7, true);
            EtherCAT_M.Digital_Output(8, false);

            // 램프 OFF
            EtherCAT_M.Digital_Output(6, true);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //close
            EtherCAT_M.Digital_Output(7, false);
            EtherCAT_M.Digital_Output(8, true);

            // 램프 ON
            EtherCAT_M.Digital_Output(6, false);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //챔버 C 등 ON
            
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //챔버 C 등 off
            EtherCAT_M.Digital_Output(9, false);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            //open
            EtherCAT_M.Digital_Output(10, true);
            EtherCAT_M.Digital_Output(11, false);

            EtherCAT_M.Digital_Output(9, true);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            //close
            EtherCAT_M.Digital_Output(10, false);
            EtherCAT_M.Digital_Output(11, true);

             EtherCAT_M.Digital_Output(9, false);
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button34_Click(object sender, EventArgs e)
        {
            // 상/하 타겟 위치 이동
            if(label10.Text == "False" || Int64.Parse(label1.Text) < 0)
            {
                EtherCAT_M.Axis1_UD_POS_Update((Int64)numericUpDown1.Value);
                EtherCAT_M.Axis1_UD_Move_Send();
            }
            else
            {
                MessageBox.Show("웨이퍼 이송 실린더가 전진되어 이거나 상하 모션이 0 이하라고 하강 할 수 없습니다.");
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            // 좌/우 타겟 위치 이동
            if (label10.Text == "False" || Int64.Parse(label1.Text) < 0)
            {
                EtherCAT_M.Axis2_LR_POS_Update((Int64)numericUpDown1.Value); 
                EtherCAT_M.Axis2_LR_Move_Send();
            }
            else
            {
                MessageBox.Show("웨이퍼 이송 실린더가 전진되어 이거나 상하 모션이 0 이하라고 하강 할 수 없습니다.");
            }

        }

        private void button33_Click(object sender, EventArgs e)
        {
            // 이송로봇 Parameter
            EtherCAT_M.Axis1_UD_Config_Update((Int64)numericUpDown2.Value, (Int64)numericUpDown3.Value, (Int64)numericUpDown4.Value, (Int64)numericUpDown5.Value);
            EtherCAT_M.Axis2_LR_Config_Update((Int64)numericUpDown2.Value, (Int64)numericUpDown3.Value, (Int64)numericUpDown4.Value, (Int64)numericUpDown5.Value);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            //Servo OFF
            EtherCAT_M.Axis1_OFF();//up, down
            EtherCAT_M.Axis2_OFF();// left, right
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {

        }

        class MainFrom : Form2
        {

        }


        private void button17_Click(object sender, EventArgs e)
        {
            
        }

        private void button36_Click(object sender, EventArgs e)
        {
            //jog 왼쪽
            if(label10.Text == "False")
            {
                Int64 ingpos = Int64.Parse(label48.Text);
                Int64 pos = ingpos + Convert.ToInt64(numericUpDown6.Value);

                EtherCAT_M.Axis2_LR_POS_Update(pos);
                EtherCAT_M.Axis2_LR_Move_Send();
            }
            else
            {
                MessageBox.Show("웨이퍼 이송 실린더가 전진되어 이거나 상하 모션이 0 이하라고 하강 할 수 없습니다.");
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            //오른쪽
            if (label10.Text == "False")
            {
                Int64 ingpos = Int64.Parse(label48.Text);
                Int64 pos = ingpos - Convert.ToInt64(numericUpDown6.Value);

                EtherCAT_M.Axis2_LR_POS_Update(pos);
                EtherCAT_M.Axis2_LR_Move_Send();

            }
            else
            {
                MessageBox.Show("웨이퍼 이송 실린더가 전진되어 이거나 상하 모션이 0 이하라고 하강 할 수 없습니다.");
            }

        }

        private void button38_Click(object sender, EventArgs e)
        {
            //위로

            if (label10.Text == "False")
            {
                Int64 ingpos = Int64.Parse(label47.Text); // 상하 현재 위치 라벨
                Int64 pos = ingpos + Convert.ToInt64(numericUpDown6.Value);

                EtherCAT_M.Axis1_UD_POS_Update(pos);
                EtherCAT_M.Axis1_UD_Move_Send(); // 누락되었던 Send 명령 추가!
            }
            else
            {
                MessageBox.Show("웨이퍼 이송 실린더가 전진되어 있어 상하 이동을 할 수 없습니다.");
            }

        }

        private void button39_Click(object sender, EventArgs e)
        {
            if (label10.Text == "False" || Int64.Parse(label47.Text) < 0)
            {
                Int64 ingpos = Int64.Parse(label47.Text); // label1 대신 정확한 상하 좌표 label47 사용!
                Int64 pos = ingpos - Convert.ToInt64(numericUpDown6.Value); // 하강이므로 빼기 처리

                EtherCAT_M.Axis1_UD_POS_Update(pos);
                EtherCAT_M.Axis1_UD_Move_Send();
            }
            else
            {
                MessageBox.Show("웨이퍼 이송 실린더가 전진되어 있어 상하 이동을 할 수 없습니다.");
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
