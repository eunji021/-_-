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
    public partial class Form2: Form
    {

        private List<Control> _originalMainControls = new List<Control>();

        private void Form2_Load(object sender, EventArgs e)
        {
            // 장비 상자들이 그려진 Main 폼을 딱 한 번만 만들어서 가방에 넣습니다!
            foreach (Control control in panel1.Controls)
            {
                _originalMainControls.Add(control);
            }
        }





        public Form2()
        {
            InitializeComponent();

            foreach (Control control in panel1.Controls)
            {
                _originalMainControls.Add(control);
            }
        }

        private void ShowFormInPanel(Form targetForm)
        {
            panel1.Controls.Clear();
            targetForm.TopLevel = false;
            targetForm.FormBorderStyle = FormBorderStyle.None;
            targetForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(targetForm);
            targetForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. 현재 열려있던 CONFIG나 RECIPE 창을 깨끗하게 지웁니다.
            panel1.Controls.Clear();

            // 2. 처음에 가방에 소중히 복사해뒀던 원래 panel1의 진짜 알맹이들을 그대로 다시 채워줍니다!
            foreach (Control control in _originalMainControls)
            {
                panel1.Controls.Add(control);
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            // CONFIG 버튼 누르면 폼으로 이동
            ShowFormInPanel(new Config());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // RECIPE 버튼 누르면 폼으로 이동
            ShowFormInPanel(new Recipe());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // FA 버튼 누르면 폼으로 이동
            ShowFormInPanel(new Fa());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // LOG 버튼 누르면 폼으로 이동
            ShowFormInPanel(new Log());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // UTILITY 버튼 누르면 폼으로 이동
            ShowFormInPanel(new Utility());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // MAINT 버튼 누르면 폼으로 이동
            ShowFormInPanel(new Maint());
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void progressBar3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void UpdateSystemTime()
        {
            // label97 칸에는 연도-월-일만 예쁘게 넣기 (예: 2026-07-05)
            label97.Text = DateTime.Now.ToString("yyyy-MM-dd");

            // label99 칸에는 시:분:초만 1초마다 째깍째깍 넣기 (예: 18:30:15)
            label99.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 현제 시간
            UpdateSystemTime();
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            // 타이머 태엽 감아서 시작하기
            statusTimer.Start();

            // 프로그램이 켜지자마자 0초일 때 시간 한번 미리 채워두기
            UpdateSystemTime();
        }
    }
}
