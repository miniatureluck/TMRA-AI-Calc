using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TMRA
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private Form1 mainForm = null;
        public Form3(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonAddTeam1_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonAddTeam2_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddTeam3_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddTeam4_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddEnemy1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddEnemy2_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddEnemy3_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddEnemy4_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddEnemy5_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddBench1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddBench2_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddBench3_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddBench4_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddBench5_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddBench6_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddBench7_Click(object sender, EventArgs e)
        {

        }

        private void buttonResetTeam4_Click(object sender, EventArgs e)
        {

        }

        private void buttonResetTeam3_Click(object sender, EventArgs e)
        {

        }

        private void buttonResetTeam2_Click(object sender, EventArgs e)
        {

        }

        private void buttonResetTeam1_Click(object sender, EventArgs e)
        {
            buttonAddTeam1.Visible = true;
            buttonResetTeam1.Visible = false;
        }

        private void buttonResetEnemy5_Click(object sender, EventArgs e)
        {

        }

        private void buttonResetEnemy4_Click(object sender, EventArgs e)
        {

        }

        private void buttonResetEnemy3_Click(object sender, EventArgs e)
        {

        }

        private void buttonResetEnemy2_Click(object sender, EventArgs e)
        {

        }

        private void buttonResetEnemy1_Click(object sender, EventArgs e)
        {

        }

        private void buttonResetBench7_Click(object sender, EventArgs e)
        {

        }

        private void buttonResetBench5_Click(object sender, EventArgs e)
        {

        }

        private void buttonResetBench6_Click(object sender, EventArgs e)
        {

        }

        private void buttonResetBench4_Click(object sender, EventArgs e)
        {

        }

        private void buttonResetBench3_Click(object sender, EventArgs e)
        {

        }

        private void buttonResetBench2_Click(object sender, EventArgs e)
        {

        }

        private void buttonResetBench1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxTeam4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxTeam3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTeam2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTeam1_TextChanged(object sender, EventArgs e)
        {
            buttonAddTeam1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = ucontrolEnemy1.uTextBoxAtt.ToString();
        }
    }
}
