using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace CMSTrainer
{
    public partial class MainForm : Form
    {
        Mem m = new Mem();
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string money = txtcr.Text;
            m.WriteMemory("UnityPlayer.dll+0x019F1170,C60,40,B8,90,38,2D8,D60", "int", money);
            txtcurrent.Text = money;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int PID = m.GetProcIdFromName("Car Mechanic Simulator 2021");
            if (PID > 0)
            {
                m.OpenProcess(PID);
                lblstatus.Text = "Running !";
                lblstatus.ForeColor = Color.Green;
                float memo = m.ReadInt("UnityPlayer.dll+0x019F1170,C60,40,B8,90,38,2D8,D60");
                txtcurrent.Text = memo.ToString();
            }
            else
            {
                lblstatus.Text = "Not Running !";
                lblstatus.ForeColor = Color.Red;
            }
        }
    }
}
