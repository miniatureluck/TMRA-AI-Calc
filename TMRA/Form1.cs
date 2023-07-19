using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DataUpdater;
using System.Threading;
using System.Web;

namespace TMRA
{
    public partial class Form1 : Form
    {
        string damageType = "phy", damageType1 = "phy", damageType2 = "phy", damageType3 = "phy", damageType4 = "phy", damageType5 = "phy";
        int currHP1 = 0, currHP2 = 0, currHP3 = 0, currHP4 = 0, currHP5 = 0;
        int maxHP1 = 0, maxHP2 = 0, maxHP3 = 0, maxHP4 = 0, maxHP5 = 0;
        string target1 = null, target2 = null, target3 = null, target4 = null, target5 = null;
        decimal attackResult1 = 0, attackResult2 = 0, attackResult3 = 0, attackResult4 = 0, attackResult5 = 0;
        string wasString = null, wasAttack = null;
        BorderStyle wasBorder = new BorderStyle();
        decimal attackModifier1 = 1, attackModifier2 = 1, attackModifier3 = 1, attackModifier4 = 1, attackModifier5 = 1;
        decimal attack1 = 100, attack2 = 100, attack3 = 100, attack4 = 100, attack5 = 100;
        decimal reduction1 = 1, reduction2 = 1,reduction3 = 1, reduction4 = 1, reduction5 = 1;
        bool allThere1 = false, allThere2 = false, allThere3 = false, allThere4 = false, allThere5 = false;
        Image pbImage1 = Properties.Resources.icon_pdmg_melee, pbImage2 = Properties.Resources.icon_pdmg_ranged, pbImage3 = Properties.Resources.icon_mdmg_melee, pbImage4 = Properties.Resources.icon_mdmg_ranged;
        public static Form2.MonsterDataFromFile holder;
        int indicator;

        public class Score
        {
            public Score(string name, decimal result, int movement, int proximity, int initiative, decimal attack, int points)
            {
                this.Name = name;
                this.Result = result;
                this.Movement = movement;
                this.Proximity = proximity;
                this.Initiative = initiative;
                this.Attack = attack;
                this.Points = points;
            }
            public string Name { get; set; }

            public decimal Result { get; set; }

            public int Movement { get; set; }

            public int Proximity { get; set; }

            public int Initiative { get; set; }

            public decimal Attack { get; set; }

            public decimal Points { get; set; }
        }

        public class ScoreFiltered
        {
            public ScoreFiltered(string name, decimal points)
            {
                this.Name = name;
                this.Points = points;
            }
            public string Name { get; set; }

            public decimal Points { get; set; }

            public override string ToString()
            {
                return Name; //+ " " + Points;
            }

        }

        public Form1()
        {
            InitializeComponent();
            textBoxOrder.CharacterCasing = CharacterCasing.Upper;
            this.buttonReset1.Image = (Image)(new Bitmap(Properties.Resources.icon_x, new Size(22, 22)));
            this.buttonReset2.Image = (Image)(new Bitmap(Properties.Resources.icon_x, new Size(22, 22)));
            this.buttonReset3.Image = (Image)(new Bitmap(Properties.Resources.icon_x, new Size(22, 22)));
            this.buttonReset4.Image = (Image)(new Bitmap(Properties.Resources.icon_x, new Size(22, 22)));
            this.buttonReset5.Image = (Image)(new Bitmap(Properties.Resources.icon_x, new Size(22, 22)));
            this.buttonAdd1.Image = (Image)(new Bitmap(Properties.Resources.icon_plus, new Size(20, 22)));
            this.buttonAdd2.Image = (Image)(new Bitmap(Properties.Resources.icon_plus, new Size(20, 22)));
            this.buttonAdd3.Image = (Image)(new Bitmap(Properties.Resources.icon_plus, new Size(20, 22)));
            this.buttonAdd4.Image = (Image)(new Bitmap(Properties.Resources.icon_plus, new Size(20, 22)));
            this.buttonAdd5.Image = (Image)(new Bitmap(Properties.Resources.icon_plus, new Size(20, 22)));
            this.buttonAdd.Image = (Image)(new Bitmap(Properties.Resources.icon_plus, new Size(16, 16)));
            this.buttonReset.Image = (Image)(new Bitmap(Properties.Resources.icon_x, new Size(16, 16)));
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            if (!File.Exists(ProgramUpd.filePath))
            {
                buttonAdd.Visible = false;
                buttonAdd1.Visible = false;
                buttonAdd2.Visible = false;
                buttonAdd3.Visible = false;
                buttonAdd4.Visible = false;
                buttonAdd5.Visible = false;
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    do
                    {
                    } while (ProgramUpd.updated == false);
                        this.InvokeIfRequired((value) => buttonAdd.Visible = value, true);
                        this.InvokeIfRequired((value) => buttonAdd1.Visible = value, true);
                        this.InvokeIfRequired((value) => buttonAdd2.Visible = value, true);
                        this.InvokeIfRequired((value) => buttonAdd3.Visible = value, true);
                        this.InvokeIfRequired((value) => buttonAdd4.Visible = value, true);
                        this.InvokeIfRequired((value) => buttonAdd5.Visible = value, true);
                }).Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxAttack_TextChanged(object sender, EventArgs e)
        {
            textBoxAttack.Text = Regex.Replace(textBoxAttack.Text, "[^0-9]", "");
            CalculateAttackResult1();
            CalculateAttackResult2();
            CalculateAttackResult3();
            CalculateAttackResult4();
            CalculateAttackResult5();
        }

        public void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.FocusedItem == null) return;
            switch (listView1.FocusedItem.Index)
            {
                case 0:
                    textBox1.BackColor = Color.Orange;
                    break;
                case 1:
                    textBox1.BackColor = Color.DarkOrchid;
                    break;
                case 2:
                    textBox1.BackColor = Color.DodgerBlue;
                    break;
                case 3:
                    textBox1.BackColor = Color.LimeGreen;
                    break;
                case 4:
                    textBox1.BackColor = Color.SlateGray;
                    break;
            }
            textBox1BackColor();
            CalculateAttackResult1();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            target1 = textBox1.Text;
            CalculateAttackResult1();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1BackColor();
            CalculateAttackResult1();
        }
        
        private void textBox1BackColor()
        {
            if (textBox1.BackColor == Color.White || textBox1.BackColor == Color.LimeGreen || textBox1.BackColor == Color.Orange)
            {
                textBox1.ForeColor = Color.Black;
            }
            else
            {
                textBox1.ForeColor = Color.White;
            }
        }

        public void textBoxCurrentHP1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCurrentHP1.Text == "")
            {
                labelHP1.Text = "= %";
                textBoxCurrentHP1.Text = "0";
                return;
            }
            textBoxCurrentHP1.Text = Regex.Replace(textBoxCurrentHP1.Text, "[^0-9]", "");
            if (Regex.Replace(textBoxCurrentHP1.Text, "[^0-9]", "") != "")
            {
                currHP1 = Int32.Parse(Regex.Replace(textBoxCurrentHP1.Text, "[^0-9]", ""));
                textBoxCurrentHP1.Text = currHP1.ToString();
            }
            CalculateHP1();
            CalculateAttackResult1();
        }

        public void textBoxMaxHP1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMaxHP1.Text == "")
            {
                labelHP1.Text = "= %";
                textBoxMaxHP1.Text = "0";
                return;
            }
            textBoxMaxHP1.Text = Regex.Replace(textBoxMaxHP1.Text, "[^0-9]", "");
            if (Regex.Replace(textBoxMaxHP1.Text, "[^0-9]", "") != "")
            {
                maxHP1 = Int32.Parse(Regex.Replace(textBoxMaxHP1.Text, "[^0-9]", ""));
                textBoxMaxHP1.Text = maxHP1.ToString();
            }
            CalculateHP1();
            CalculateAttackResult1();
        }

        public void CalculateHP1()
        {

            if (textBoxCurrentHP1.Text == "" || textBoxMaxHP1.Text == "")
            {
                labelHP1.Text = "= %";
            }
            else
            {
                if (textBoxCurrentHP1.Text == "") currHP1 = 0;
                else currHP1 = Int32.Parse(Regex.Replace(textBoxCurrentHP1.Text, "[^0-9]", ""));
                if (textBoxMaxHP1.Text == "") maxHP1 = 0;
                else maxHP1 = Int32.Parse(Regex.Replace(textBoxMaxHP1.Text, "[^0-9]", ""));
                if (Int32.Parse(textBoxMaxHP1.Text) == 0) return;
                else labelHP1.Text = (Math.Round((Convert.ToDecimal(currHP1)) / (Convert.ToDecimal(maxHP1)) * 100, 2)).ToString() + "%";
            }
        }

        public void CalculateAttackResult1()
        {
            if (String.IsNullOrEmpty(textBoxAttack.Text) || String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBoxCurrentHP1.Text))
            {
                labelResult1.Text = "";
                allThere1 = false;
            }
            else
            {
                int currentHP1 = Int32.Parse(textBoxCurrentHP1.Text);
                if (String.IsNullOrEmpty(textBoxModifier1.Text)) attackModifier1 = 1;
                else attackModifier1 = Decimal.Parse(textBoxModifier1.Text) / 100 + 1;
                decimal damage1 = Decimal.Parse(textBoxAttack.Text) * attackModifier1;
                decimal armor1 = 1;
                string dmgType1="";
                if (String.IsNullOrEmpty(textBoxReduction1.Text)) reduction1 = 1;
                else reduction1 = 1 - (Decimal.Parse(textBoxReduction1.Text) / 100);
                
                if (damageType == "phy")
                {
                    armor1 = 1 - (numericDef1.Value * 2 / 10);
                    dmgType1 = " physical damage.";
                }
                if (damageType == "mag")
                {
                    armor1 = 1 - (numericMDef1.Value * 2 / 10);
                    dmgType1 = " magic damage.";
                }
                if (damageType == "true")
                {
                    armor1 = 1;
                    dmgType1 = " damage.";
                }
                if (checkBoxArmorPenetration.Checked & damageType != "true" & armor1 < 1) armor1 += 0.2M;
                decimal blockedModifier = 1;
                decimal distanceModifier = 1;
                if (checkBoxRanged.Checked)
                {
                    blockedModifier = 0.5M;
                    if (checkBoxCanMelee.Checked || numericProximity1.Value > 1) blockedModifier = 1;
                    if (numericProximity1.Value > 5 & damageType != "true")
                    {
                        distanceModifier = 0.5M;
                    }
                }
                
                attackResult1 = Math.Ceiling(currentHP1 / (blockedModifier * distanceModifier * damage1 * armor1 * reduction1)) ;
                labelResult1.Text = target1 + " will get " + blockedModifier * distanceModifier * damage1 * armor1 * reduction1 + dmgType1;

                allThere1 = true;
                aResultsSort();
            }
        }

        public void textBox1_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text)) textBox1.Text = wasString;
        }

        public void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                wasString = textBox1.Text;
                textBox1.Text = null;
            }
            else
            {
                wasString = null;
            }
        }

        public void pictureBoxDmgType_Click(object sender, EventArgs e)
        {
            if (labelDmgType.Text == "fiz")
            {
                labelDmgType.Text = "mag";
                damageType = "mag";
                if (!checkBoxRanged.Checked) pictureBoxDmgType.Image = Properties.Resources.icon_mdmg_melee;
                else pictureBoxDmgType.Image = Properties.Resources.icon_mdmg_ranged;
            }
            else if (labelDmgType.Text == "mag")
            {
                labelDmgType.Text = "oba";
                damageType = "true";
                pictureBoxDmgType.Image = Properties.Resources.icon_truedmg;
            }
            else
            {
                labelDmgType.Text = "fiz";
                damageType = "phy";
                if (!checkBoxRanged.Checked) pictureBoxDmgType.Image = Properties.Resources.icon_pdmg_melee;
                else pictureBoxDmgType.Image = Properties.Resources.icon_pdmg_ranged;
            }
            CalculateAttackResult1();
            CalculateAttackResult2();
            CalculateAttackResult3();
            CalculateAttackResult4();
            CalculateAttackResult5();
        }

        private void pictureBoxDmgType_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxDmgType.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBoxDmgType_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxDmgType.BorderStyle = BorderStyle.None;
        }

        private void pictureBoxDmgType_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxDmgType.BorderStyle = wasBorder;
        }

        private void pictureBoxDmgType_MouseEnter(object sender, EventArgs e)
        {
            wasBorder = pictureBoxDmgType.BorderStyle;
        }

        private void textBoxAttack_Leave(object sender, EventArgs e)
        {
            if (textBoxAttack.Text == "") textBoxAttack.Text = wasAttack;
        }

        private void textBoxAttack_Enter(object sender, EventArgs e)
        {
            wasAttack = textBoxAttack.Text;
            textBoxAttack.Text = "";
        }

        private void textBoxModifier1_TextChanged(object sender, EventArgs e)
        {
            CalculateAttackResult1();
            textBoxModifier1.Text = Regex.Replace(textBoxModifier1.Text, "[^0-9]", "");
            if (String.IsNullOrEmpty(textBoxModifier1.Text))
            {
                buttonCopyMods.Enabled = false;
            }
            else
            {
                buttonCopyMods.Enabled = true;
            }
        }
        
        private void textBoxModifier2_TextChanged(object sender, EventArgs e)
        {
            textBoxModifier2.Text = Regex.Replace(textBoxModifier2.Text, "[^0-9]", "");
            CalculateAttackResult2();
        }
        
        private void textBoxModifier3_TextChanged(object sender, EventArgs e)
        {
            textBoxModifier3.Text = Regex.Replace(textBoxModifier3.Text, "[^0-9]", "");
            CalculateAttackResult3();
        }
        
        private void textBoxModifier4_TextChanged(object sender, EventArgs e)
        {
            textBoxModifier4.Text = Regex.Replace(textBoxModifier4.Text, "[^0-9]", "");
            CalculateAttackResult4();
        }
        
        private void textBoxModifier5_TextChanged(object sender, EventArgs e)
        {
            textBoxModifier5.Text = Regex.Replace(textBoxModifier5.Text, "[^0-9]", "");
            CalculateAttackResult5();
        }

        private void textBoxReduction1_TextChanged(object sender, EventArgs e)
        {
            textBoxReduction1.Text = Regex.Replace(textBoxReduction1.Text, "[^0-9]", "");
            CalculateAttackResult1();
        }

        private void textBoxReduction2_TextChanged(object sender, EventArgs e)
        {
            textBoxReduction2.Text = Regex.Replace(textBoxReduction2.Text, "[^0-9]", "");
            CalculateAttackResult2();
        }

        private void textBoxReduction3_TextChanged(object sender, EventArgs e)
        {
            textBoxReduction3.Text = Regex.Replace(textBoxReduction3.Text, "[^0-9]", "");
            CalculateAttackResult3();
        }

        private void textBoxReduction4_TextChanged(object sender, EventArgs e)
        {
            textBoxReduction4.Text = Regex.Replace(textBoxReduction4.Text, "[^0-9]", "");
            CalculateAttackResult4();
        }

        private void textBoxReduction5_TextChanged(object sender, EventArgs e)
        {
            textBoxReduction5.Text = Regex.Replace(textBoxReduction5.Text, "[^0-9]", "");
            CalculateAttackResult5();
        }

        private void labelChoices_MouseHover(object sender, EventArgs e)
        {
            toolTipNazwa.SetToolTip(labelChoices, "Provide some data for the unit. The more info you give, the more accurate result you will get.");
        }

        public void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.FocusedItem == null) return;
            switch (listView2.FocusedItem.Index)
            {
                case 0:
                    textBox2.BackColor = Color.Orange;
                    break;
                case 1:
                    textBox2.BackColor = Color.DarkOrchid;
                    break;
                case 2:
                    textBox2.BackColor = Color.DodgerBlue;
                    break;
                case 3:
                    textBox2.BackColor = Color.LimeGreen;
                    break;
                case 4:
                    textBox2.BackColor = Color.SlateGray;
                    break;
            }
            textBox2BackColor();
            CalculateAttackResult2();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            target2 = textBox2.Text;
            CalculateAttackResult2();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2BackColor();
            CalculateAttackResult2();
        }
        
        private void textBox2BackColor()
        {
            if (textBox2.BackColor == Color.White || textBox2.BackColor == Color.LimeGreen || textBox2.BackColor == Color.Orange)
            {
                textBox2.ForeColor = Color.Black;
            }
            else
            {
                textBox2.ForeColor = Color.White;
            }
        }

        public void textBoxCurrentHP2_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCurrentHP2.Text == "")
            {
                labelHP2.Text = "= %";
                textBoxCurrentHP2.Text = "0";
                return;
            }
            textBoxCurrentHP2.Text = Regex.Replace(textBoxCurrentHP2.Text, "[^0-9]", "");
            if (Regex.Replace(textBoxCurrentHP2.Text, "[^0-9]", "") != "")
            {
                currHP2 = Int32.Parse(Regex.Replace(textBoxCurrentHP2.Text, "[^0-9]", ""));
                textBoxCurrentHP2.Text = currHP2.ToString();
            }
            CalculateHP2();
            CalculateAttackResult2();
        }

        public void textBoxMaxHP2_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMaxHP2.Text == "")
            {
                labelHP2.Text = "= %";
                textBoxMaxHP2.Text = "0";
                return;
            }
            textBoxMaxHP2.Text = Regex.Replace(textBoxMaxHP2.Text, "[^0-9]", "");
            if (Regex.Replace(textBoxMaxHP2.Text, "[^0-9]", "") != "")
            {
                maxHP2 = Int32.Parse(Regex.Replace(textBoxMaxHP2.Text, "[^0-9]", ""));
                textBoxMaxHP2.Text = maxHP2.ToString();
            }
            CalculateHP2();
            CalculateAttackResult2();
        }

        public void CalculateHP2()
        {

            if (textBoxCurrentHP2.Text == "" || textBoxMaxHP2.Text == "")
            {
                labelHP2.Text = "= %";
            }
            else
            {
                if (textBoxCurrentHP2.Text == "") currHP2 = 0;
                else currHP2 = Int32.Parse(Regex.Replace(textBoxCurrentHP2.Text, "[^0-9]", ""));
                if (textBoxMaxHP2.Text == "") maxHP2 = 0;
                else maxHP2 = Int32.Parse(Regex.Replace(textBoxMaxHP2.Text, "[^0-9]", ""));
                if (Int32.Parse(textBoxMaxHP2.Text) == 0) return;
                else labelHP2.Text = (Math.Round((Convert.ToDecimal(currHP2)) / (Convert.ToDecimal(maxHP2)) * 100, 2)).ToString() + "%";
            }
        }

        public void CalculateAttackResult2()
        {
            if (String.IsNullOrEmpty(textBoxAttack.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBoxCurrentHP2.Text))
            {
                labelResult2.Text = "";
                allThere2 = false;
            }
            else
            {
                int currentHP2 = Int32.Parse(textBoxCurrentHP2.Text);
                if (String.IsNullOrEmpty(textBoxModifier2.Text)) attackModifier2 = 1;
                else attackModifier2 = Decimal.Parse(textBoxModifier2.Text) / 100 + 1;
                decimal damage2 = Decimal.Parse(textBoxAttack.Text) * attackModifier2;
                decimal armor2 = 1;
                string dmgType2 = "";
                if (String.IsNullOrEmpty(textBoxReduction2.Text)) reduction2 = 1;
                else reduction2 = 1 - (Decimal.Parse(textBoxReduction2.Text) / 100);
                if (damageType == "phy")
                {
                    armor2 = 1 - (numericDef2.Value * 2 / 10);
                    dmgType2 = " physical damage.";
                }
                if (damageType == "mag")
                {
                    armor2 = 1 - (numericMDef2.Value * 2 / 10);
                    dmgType2 = " magic damage.";
                }
                if (damageType == "true")
                {
                    armor2 = 1;
                    dmgType2 = " damage.";
                }
                if (checkBoxArmorPenetration.Checked & damageType != "true" & armor2 < 1) armor2 += 0.2M;
                decimal blockedModifier = 1;
                decimal distanceModifier = 1;
                if (checkBoxRanged.Checked)
                {
                    blockedModifier = 0.5M;
                    if (checkBoxCanMelee.Checked || numericProximity2.Value > 1) blockedModifier = 1;
                    if (numericProximity2.Value > 5 & damageType != "true")
                    {
                        distanceModifier = 0.5M;
                    }
                }

                attackResult2 = Math.Ceiling(currentHP2 / (blockedModifier * distanceModifier * damage2 * armor2 * reduction2));
                labelResult2.Text = target2 + " will get " + blockedModifier * distanceModifier * damage2 * armor2 * reduction2 + dmgType2;

                allThere2 = true;
                aResultsSort();
            }
        }

        public void textBox2_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text)) textBox2.Text = wasString;
        }

        public void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text != null)
            {
                wasString = textBox2.Text;
                textBox2.Text = null;
            }
            else
            {
                wasString = null;
            }
        }
       
        public void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.FocusedItem == null) return;
            switch (listView3.FocusedItem.Index)
            {
                case 0:
                    textBox3.BackColor = Color.Orange;
                    break;
                case 1:
                    textBox3.BackColor = Color.DarkOrchid;
                    break;
                case 2:
                    textBox3.BackColor = Color.DodgerBlue;
                    break;
                case 3:
                    textBox3.BackColor = Color.LimeGreen;
                    break;
                case 4:
                    textBox3.BackColor = Color.SlateGray;
                    break;
            }
            textBox3BackColor();
            CalculateAttackResult3();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            target3 = textBox3.Text;
            CalculateAttackResult3();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3BackColor();
            CalculateAttackResult3();
        }
        
        private void textBox3BackColor()
        {
            if (textBox3.BackColor == Color.White || textBox3.BackColor == Color.LimeGreen || textBox3.BackColor == Color.Orange)
            {
                textBox3.ForeColor = Color.Black;
            }
            else
            {
                textBox3.ForeColor = Color.White;
            }
        }

        public void textBoxCurrentHP3_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCurrentHP3.Text == "")
            {
                labelHP3.Text = "= %";
                textBoxCurrentHP3.Text = "0";
                return;
            }
            textBoxCurrentHP3.Text = Regex.Replace(textBoxCurrentHP3.Text, "[^0-9]", "");
            if (Regex.Replace(textBoxCurrentHP3.Text, "[^0-9]", "") != "")
            {
                currHP3 = Int32.Parse(Regex.Replace(textBoxCurrentHP3.Text, "[^0-9]", ""));
                textBoxCurrentHP3.Text = currHP3.ToString();
            }
            CalculateHP3();
            CalculateAttackResult3();
        }

        public void textBoxMaxHP3_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMaxHP3.Text == "")
            {
                labelHP3.Text = "= %";
                textBoxMaxHP3.Text = "0";
                return;
            }
            textBoxMaxHP3.Text = Regex.Replace(textBoxMaxHP3.Text, "[^0-9]", "");
            if (Regex.Replace(textBoxMaxHP3.Text, "[^0-9]", "") != "")
            {
                maxHP3 = Int32.Parse(Regex.Replace(textBoxMaxHP3.Text, "[^0-9]", ""));
                textBoxMaxHP3.Text = maxHP3.ToString();
            }
            CalculateHP3();
            CalculateAttackResult3();
        }

        public void CalculateHP3()
        {

            if (textBoxCurrentHP3.Text == "" || textBoxMaxHP3.Text == "")
            {
                labelHP3.Text = "= %";
            }
            else
            {
                if (textBoxCurrentHP3.Text == "") currHP3 = 0;
                else currHP3 = Int32.Parse(Regex.Replace(textBoxCurrentHP3.Text, "[^0-9]", ""));
                if (textBoxMaxHP3.Text == "") maxHP3 = 0;
                else maxHP3 = Int32.Parse(Regex.Replace(textBoxMaxHP3.Text, "[^0-9]", ""));
                if (Int32.Parse(textBoxMaxHP3.Text) == 0) return;
                else labelHP3.Text = (Math.Round((Convert.ToDecimal(currHP3)) / (Convert.ToDecimal(maxHP3)) * 100, 2)).ToString() + "%";
            }
        }

        public void CalculateAttackResult3()
        {
            if (String.IsNullOrEmpty(textBoxAttack.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBoxCurrentHP3.Text))
            {
                labelResult3.Text = "";
                allThere3 = false;
            }
            else
            {
                int currentHP3 = Int32.Parse(textBoxCurrentHP3.Text);
                if (String.IsNullOrEmpty(textBoxModifier3.Text)) attackModifier3 = 1;
                else attackModifier3 = Decimal.Parse(textBoxModifier3.Text) / 100 + 1;
                decimal damage3 = Decimal.Parse(textBoxAttack.Text) * attackModifier3;
                decimal armor3 = 1;
                string dmgType3 = "";
                if (String.IsNullOrEmpty(textBoxReduction3.Text)) reduction3 = 1;
                else reduction3 = 1 - (Decimal.Parse(textBoxReduction3.Text) / 100);
                if (damageType == "phy")
                {
                    armor3 = 1 - (numericDef3.Value * 2 / 10);
                    dmgType3 = " physical damage.";
                }
                if (damageType == "mag")
                {
                    armor3 = 1 - (numericMDef3.Value * 2 / 10);
                    dmgType3 = " magic damage.";
                }
                if (damageType == "true")
                {
                    armor3 = 1;
                    dmgType3 = " damage.";
                }
                if (checkBoxArmorPenetration.Checked & damageType != "true" & armor3 < 1) armor3 += 0.2M;
                decimal blockedModifier = 1;
                decimal distanceModifier = 1;
                if (checkBoxRanged.Checked)
                {
                    blockedModifier = 0.5M;
                    if (checkBoxCanMelee.Checked || numericProximity3.Value > 1) blockedModifier = 1;
                    if (numericProximity3.Value > 5 & damageType != "true")
                    {
                        distanceModifier = 0.5M;
                    }
                }

                attackResult3 = Math.Ceiling(currentHP3 / (blockedModifier * distanceModifier * damage3 * armor3 * reduction3));
                labelResult3.Text = target3 + " will get " + blockedModifier * distanceModifier * damage3 * armor3 * reduction3 + dmgType3;
                allThere3 = true;
                aResultsSort();
            }
        }

        public void textBox3_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text)) textBox3.Text = wasString;
        }

        public void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text != null)
            {
                wasString = textBox3.Text;
                textBox3.Text = null;
            }
            else
            {
                wasString = null;
            }
        }

        public void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView4.FocusedItem == null) return;
            switch (listView4.FocusedItem.Index)
            {
                case 0:
                    textBox4.BackColor = Color.Orange;
                    break;
                case 1:
                    textBox4.BackColor = Color.DarkOrchid;
                    break;
                case 2:
                    textBox4.BackColor = Color.DodgerBlue;
                    break;
                case 3:
                    textBox4.BackColor = Color.LimeGreen;
                    break;
                case 4:
                    textBox4.BackColor = Color.SlateGray;
                    break;
            }
            textBox4BackColor();
            CalculateAttackResult4();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            target4 = textBox4.Text;
            CalculateAttackResult4();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4BackColor();
            CalculateAttackResult4();
        }
        
        private void textBox4BackColor()
        {
            if (textBox4.BackColor == Color.White || textBox4.BackColor == Color.LimeGreen || textBox4.BackColor == Color.Orange)
            {
                textBox4.ForeColor = Color.Black;
            }
            else
            {
                textBox4.ForeColor = Color.White;
            }
        }

        public void textBoxCurrentHP4_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCurrentHP4.Text == "")
            {
                labelHP4.Text = "= %";
                textBoxCurrentHP4.Text = "0";
                return;
            }
            textBoxCurrentHP4.Text = Regex.Replace(textBoxCurrentHP4.Text, "[^0-9]", "");
            if (Regex.Replace(textBoxCurrentHP4.Text, "[^0-9]", "") != "")
            {
                currHP4 = Int32.Parse(Regex.Replace(textBoxCurrentHP4.Text, "[^0-9]", ""));
                textBoxCurrentHP4.Text = currHP4.ToString();
            }
            CalculateHP4();
            CalculateAttackResult4();
        }

        public void textBoxMaxHP4_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMaxHP4.Text == "")
            {
                labelHP4.Text = "= %";
                textBoxMaxHP4.Text = "0";
                return;
            }
            textBoxMaxHP4.Text = Regex.Replace(textBoxMaxHP4.Text, "[^0-9]", "");
            if (Regex.Replace(textBoxMaxHP4.Text, "[^0-9]", "") != "")
            {
                maxHP4 = Int32.Parse(Regex.Replace(textBoxMaxHP4.Text, "[^0-9]", ""));
                textBoxMaxHP4.Text = maxHP4.ToString();
            }
            CalculateHP4();
            CalculateAttackResult4();
        }

        public void CalculateHP4()
        {

            if (textBoxCurrentHP4.Text == "" || textBoxMaxHP4.Text == "")
            {
                labelHP4.Text = "= %";
            }
            else
            {
                if (textBoxCurrentHP4.Text == "") currHP4 = 0;
                else currHP4 = Int32.Parse(Regex.Replace(textBoxCurrentHP4.Text, "[^0-9]", ""));
                if (textBoxMaxHP4.Text == "") maxHP4 = 0;
                else maxHP4 = Int32.Parse(Regex.Replace(textBoxMaxHP4.Text, "[^0-9]", ""));
                if (Int32.Parse(textBoxMaxHP4.Text) == 0) return;
                else labelHP4.Text = (Math.Round((Convert.ToDecimal(currHP4)) / (Convert.ToDecimal(maxHP4)) * 100, 2)).ToString() + "%";
            }
        }

        public void CalculateAttackResult4()
        {
            if (String.IsNullOrEmpty(textBoxAttack.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBoxCurrentHP4.Text))
            {
                labelResult4.Text = "";
                allThere4 = false;
            }
            else
            {
                int currentHP4 = Int32.Parse(textBoxCurrentHP4.Text);
                if (String.IsNullOrEmpty(textBoxModifier4.Text)) attackModifier4 = 1;
                else attackModifier4 = Decimal.Parse(textBoxModifier4.Text) / 100 + 1;
                decimal damage4 = Decimal.Parse(textBoxAttack.Text) * attackModifier4;
                decimal armor4 = 1;
                string dmgType4 = "";
                if (String.IsNullOrEmpty(textBoxReduction4.Text)) reduction4 = 1;
                else reduction4 = 1 - (Decimal.Parse(textBoxReduction4.Text) / 100);
                if (damageType == "phy")
                {
                    armor4 = 1 - (numericDef4.Value * 2 / 10);
                    dmgType4 = " physical damage.";
                }
                if (damageType == "mag")
                {
                    armor4 = 1 - (numericMDef4.Value * 2 / 10);
                    dmgType4 = " magic damage.";
                }
                if (damageType == "true")
                {
                    armor4 = 1;
                    dmgType4 = " damage.";
                }
                if (checkBoxArmorPenetration.Checked & damageType != "true" & armor4 < 1) armor4 += 0.2M;
                decimal blockedModifier = 1;
                decimal distanceModifier = 1;
                if (checkBoxRanged.Checked)
                {
                    blockedModifier = 0.5M;
                    if (checkBoxCanMelee.Checked || numericProximity4.Value > 1) blockedModifier = 1;
                    if (numericProximity4.Value > 5 & damageType != "true")
                    {
                        distanceModifier = 0.5M;
                    }
                }

                attackResult4 = Math.Ceiling(currentHP4 / (blockedModifier * distanceModifier * damage4 * armor4 * reduction4));
                labelResult4.Text = target4 + " will get " + blockedModifier * distanceModifier * damage4 * armor4 * reduction4 + dmgType4;
                allThere4 = true;
                aResultsSort();
            }
        }

        public void textBox4_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox4.Text)) textBox4.Text = wasString;
        }

        public void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text != null)
            {
                wasString = textBox4.Text;
                textBox4.Text = null;
            }
            else
            {
                wasString = null;
            }
        }
        
        public void listView5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView5.FocusedItem == null) return;
            switch (listView5.FocusedItem.Index)
            {
                case 0:
                    textBox5.BackColor = Color.Orange;
                    break;
                case 1:
                    textBox5.BackColor = Color.DarkOrchid;
                    break;
                case 2:
                    textBox5.BackColor = Color.DodgerBlue;
                    break;
                case 3:
                    textBox5.BackColor = Color.LimeGreen;
                    break;
                case 4:
                    textBox5.BackColor = Color.SlateGray;
                    break;
            }
            textBox5BackColor();
            CalculateAttackResult5();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            target5 = textBox5.Text;
            CalculateAttackResult5();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5BackColor();
            CalculateAttackResult5();
        }
        
        private void textBox5BackColor()
        {
            if (textBox5.BackColor == Color.White || textBox5.BackColor == Color.LimeGreen || textBox5.BackColor == Color.Orange)
            {
                textBox5.ForeColor = Color.Black;
            }
            else
            {
                textBox5.ForeColor = Color.White;
            }
        }

        public void textBoxCurrentHP5_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCurrentHP5.Text == "")
            {
                labelHP5.Text = "= %";
                textBoxCurrentHP5.Text = "0";
                return;
            }
            textBoxCurrentHP5.Text = Regex.Replace(textBoxCurrentHP5.Text, "[^0-9]", "");
            if (Regex.Replace(textBoxCurrentHP5.Text, "[^0-9]", "") != "")
            {
                currHP5 = Int32.Parse(Regex.Replace(textBoxCurrentHP5.Text, "[^0-9]", ""));
                textBoxCurrentHP5.Text = currHP5.ToString();
            }
            CalculateHP5();
            CalculateAttackResult5();
        }

        public void textBoxMaxHP5_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMaxHP5.Text == "")
            {
                labelHP5.Text = "= %";
                textBoxMaxHP5.Text = "0";
                return;
            }
            textBoxMaxHP5.Text = Regex.Replace(textBoxMaxHP5.Text, "[^0-9]", "");
            if (Regex.Replace(textBoxMaxHP5.Text, "[^0-9]", "") != "")
            {
                maxHP5 = Int32.Parse(Regex.Replace(textBoxMaxHP5.Text, "[^0-9]", ""));
                textBoxMaxHP5.Text = maxHP5.ToString();
            }
            CalculateHP5();
            CalculateAttackResult5();
        }

        public void CalculateHP5()
        {

            if (textBoxCurrentHP5.Text == "" || textBoxMaxHP5.Text == "")
            {
                labelHP5.Text = "= %";
            }
            else
            {
                if (textBoxCurrentHP5.Text == "") currHP5 = 0;
                else currHP5 = Int32.Parse(Regex.Replace(textBoxCurrentHP5.Text, "[^0-9]", ""));
                if (textBoxMaxHP5.Text == "") maxHP5 = 0;
                else maxHP5 = Int32.Parse(Regex.Replace(textBoxMaxHP5.Text, "[^0-9]", ""));
                if (Int32.Parse(textBoxMaxHP5.Text) == 0) return;
                else labelHP5.Text = (Math.Round((Convert.ToDecimal(currHP5)) / (Convert.ToDecimal(maxHP5)) * 100, 2)).ToString() + "%";
            }
        }

        public void CalculateAttackResult5()
        {
            if (String.IsNullOrEmpty(textBoxAttack.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBoxCurrentHP5.Text))
            {
                labelResult5.Text = "";
                allThere5 = false;
            }
            else
            {
                int currentHP5 = Int32.Parse(textBoxCurrentHP5.Text);
                if (String.IsNullOrEmpty(textBoxModifier5.Text)) attackModifier5 = 1;
                else attackModifier5 = Decimal.Parse(textBoxModifier5.Text) / 100 + 1;
                decimal damage5 = Decimal.Parse(textBoxAttack.Text) * attackModifier5;
                decimal armor5 = 1;
                string dmgType5 = "";
                if (String.IsNullOrEmpty(textBoxReduction5.Text)) reduction5 = 1;
                else reduction5 = 1 - (Decimal.Parse(textBoxReduction5.Text) / 100);
                if (damageType == "phy")
                {
                    armor5 = 1 - (numericDef5.Value * 2 / 10);
                    dmgType5 = " physical damage.";
                }
                if (damageType == "mag")
                {
                    armor5 = 1 - (numericMDef5.Value * 2 / 10);
                    dmgType5 = " magic damage.";
                }
                if (damageType == "true")
                {
                    armor5 = 1;
                    dmgType5 = " damage.";
                }
                if (checkBoxArmorPenetration.Checked & damageType != "true" & armor5 < 1) armor5 += 0.2M;
                decimal blockedModifier = 1;
                decimal distanceModifier = 1;
                if (checkBoxRanged.Checked)
                {
                    blockedModifier = 0.5M;
                    if (checkBoxCanMelee.Checked || numericProximity5.Value > 1) blockedModifier = 1;
                    if (numericProximity5.Value > 5 & damageType != "true")
                    {
                        distanceModifier = 0.5M;
                    }
                }

                attackResult5 = Math.Ceiling(currentHP5 / (blockedModifier * distanceModifier * damage5 * armor5 * reduction5));
                labelResult5.Text = target5 + " will get " + blockedModifier * distanceModifier * damage5 * armor5 * reduction5 + dmgType5;

                allThere5 = true;
                aResultsSort();
            }
        }

        public void textBox5_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox5.Text)) textBox5.Text = wasString;
        }

        public void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text != null)
            {
                wasString = textBox5.Text;
                textBox5.Text = null;
            }
            else
            {
                wasString = null;
            }
        }

        private void numericDef1_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult1();
        }

        private void numericMDef1_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult1();
        }

        private void numericDef2_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult2();
        }

        private void numericMDef2_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult2();
        }

        private void numericDef3_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult3();
        }

        private void numericMDef3_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult3();
        }

        private void numericDef4_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult4();
        }

        private void numericMDef4_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult4();
        }

        private void numericDef5_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult5();
        }

        private void numericMDef5_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult5();
        }
    
        public void aResultsSort()
        {
            if (allThere1 == true || allThere2 == true || allThere3 == true || allThere4 == true || allThere5 == true)
            {
                List<Score> ListResults = new List<Score>();
                if (allThere1 == true) ListResults.Add(new Score(textBox1.Text, attackResult1, Convert.ToInt32(numericMob1.Value), Convert.ToInt32(numericProximity1.Value), Convert.ToInt32(numericIni1.Value), attack1, 0));
                if (allThere2 == true) ListResults.Add(new Score(textBox2.Text, attackResult2, Convert.ToInt32(numericMob2.Value), Convert.ToInt32(numericProximity2.Value), Convert.ToInt32(numericIni2.Value), attack2, 0));
                if (allThere3 == true) ListResults.Add(new Score(textBox3.Text, attackResult3, Convert.ToInt32(numericMob3.Value), Convert.ToInt32(numericProximity3.Value), Convert.ToInt32(numericIni3.Value), attack3, 0));
                if (allThere4 == true) ListResults.Add(new Score(textBox4.Text, attackResult4, Convert.ToInt32(numericMob4.Value), Convert.ToInt32(numericProximity4.Value), Convert.ToInt32(numericIni4.Value), attack4, 0));
                if (allThere5 == true) ListResults.Add(new Score(textBox5.Text, attackResult5, Convert.ToInt32(numericMob5.Value), Convert.ToInt32(numericProximity5.Value), Convert.ToInt32(numericIni5.Value), attack5, 0));
                var holderList = new List<ScoreFiltered>();
                foreach (var element in ListResults)
                {
                    if (!checkBoxRanged.Checked) element.Proximity = 0;
                    element.Points = element.Result * 10000 - element.Movement * 1000 + element.Proximity * 100 - element.Initiative * 1 - element.Attack / 1000;
                    holderList.Add(new ScoreFiltered(element.Name, element.Points));
                    holderList.Sort(delegate (ScoreFiltered x, ScoreFiltered y) { return x.Points.CompareTo(y.Points); });
                }
                textBoxOrder.Text = String.Join(Environment.NewLine, holderList);
            }
            else textBoxOrder.Text = "";
        }

        private void numericMob1_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult1();
        }

        private void numericMob2_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult2();
        }

        private void numericMob3_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult3();
        }

        private void numericMob4_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult4();
        }

        private void numericMob5_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult5();
        }

        private void checkBoxBlocked1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateAttackResult1();
        }

        private void textBoxAtt1_TextChanged(object sender, EventArgs e)
        {
            textBoxAtt1.Text = Regex.Replace(textBoxAtt1.Text, "[^0-9]", "");
            if (!String.IsNullOrEmpty(textBoxAtt1.Text)) attack1 = Decimal.Parse(textBoxAtt1.Text);
            CalculateAttackResult1();
        }

        private void textBoxAtt2_TextChanged(object sender, EventArgs e)
        {
            textBoxAtt2.Text = Regex.Replace(textBoxAtt2.Text, "[^0-9]", "");
            if (!String.IsNullOrEmpty(textBoxAtt2.Text)) attack2 = Decimal.Parse(textBoxAtt2.Text);
            CalculateAttackResult2();
        }

        private void textBoxAtt3_TextChanged(object sender, EventArgs e)
        {
            textBoxAtt3.Text = Regex.Replace(textBoxAtt3.Text, "[^0-9]", "");
            if (!String.IsNullOrEmpty(textBoxAtt3.Text)) attack3 = Decimal.Parse(textBoxAtt3.Text);
            CalculateAttackResult1();
        }

        private void textBoxAtt4_TextChanged(object sender, EventArgs e)
        {
            textBoxAtt4.Text = Regex.Replace(textBoxAtt4.Text, "[^0-9]", "");
            if (!String.IsNullOrEmpty(textBoxAtt4.Text)) attack4 = Decimal.Parse(textBoxAtt4.Text);
            CalculateAttackResult1();
        }

        private void textBoxAtt5_TextChanged(object sender, EventArgs e)
        {
            textBoxAtt5.Text = Regex.Replace(textBoxAtt5.Text, "[^0-9]", "");
            if (!String.IsNullOrEmpty(textBoxAtt5.Text)) attack5 = Decimal.Parse(textBoxAtt5.Text);
            CalculateAttackResult1();
        }

        private void numericIni1_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult1();
        }

        private void numericIni2_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult2();
        }

        private void numericIni3_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult3();
        }

        private void numericIni4_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult4();
        }

        private void numericIni5_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult5();
        }

        private void buttonReset1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0) listView1.FocusedItem.Selected = false;
            textBox1.BackColor = Color.White;
            textBox1.ForeColor = Color.Black;
            textBox1.Text = null;
            textBoxAtt1.Text = null;
            textBoxCurrentHP1.Text = null;
            textBoxMaxHP1.Text = null;
            textBoxModifier1.Text = null;
            textBoxReduction1.Text = null;
            numericDef1.Value = 2;
            numericMDef1.Value = 2;
            numericIni1.Value = 1;
            numericMob1.Value = 3;
            numericProximity1.Value = 2;
            pictureBoxAtt1.Image = Properties.Resources.icon_pdmg;
            aResultsSort();
        }

        private void buttonReset2_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0) listView2.FocusedItem.Selected = false;
            textBox2.BackColor = Color.White;
            textBox2.ForeColor = Color.Black;
            textBox2.Text = null;
            textBoxAtt2.Text = null;
            textBoxCurrentHP2.Text = null;
            textBoxMaxHP2.Text = null;
            textBoxModifier2.Text = null;
            textBoxReduction2.Text = null;
            numericDef2.Value = 2;
            numericMDef2.Value = 2;
            numericIni2.Value = 1;
            numericMob2.Value = 3;
            numericProximity2.Value = 2;
            pictureBoxAtt2.Image = Properties.Resources.icon_pdmg;
            aResultsSort();
        }

        private void buttonReset3_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0) listView3.FocusedItem.Selected = false;
            textBox3.BackColor = Color.White;
            textBox3.ForeColor = Color.Black;
            textBox3.Text = null;
            textBoxAtt3.Text = null;
            textBoxCurrentHP3.Text = null;
            textBoxMaxHP3.Text = null;
            textBoxModifier3.Text = null;
            textBoxReduction3.Text = null;
            numericDef3.Value = 2;
            numericMDef3.Value = 2;
            numericIni3.Value = 1;
            numericMob3.Value = 3;
            numericProximity3.Value = 2;
            pictureBoxAtt3.Image = Properties.Resources.icon_pdmg;
            aResultsSort();
        }

        public void buttonUpdate_Click(object sender, EventArgs e)
        {
            File.Delete(ProgramUpd.filePath);
            this.InvokeIfRequired((value) => buttonUpdate.Text = value, "Wait...");
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                ProgramUpd.update();
                this.InvokeIfRequired((value) => buttonUpdate.Text = value, "Ready!");
                this.InvokeIfRequired((value) => buttonUpdate.Enabled = value, false);
            }).Start();
        }
        private void buttonAdd1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1)
            {
                Form2 form2 = new Form2();
                var cursorPos = new Point(Cursor.Position.X, Cursor.Position.Y);
                form2.StartPosition = FormStartPosition.Manual;
                form2.Left = cursorPos.X-30;
                form2.Top = cursorPos.Y;
                form2.Deactivate += delegate
                { form2.Close(); };
                form2.Show();
                indicator = 1;
            }
        }

        private void buttonAdd2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1)
            {
                Form2 form2 = new Form2();
                var cursorPos = new Point(Cursor.Position.X, Cursor.Position.Y);
                form2.StartPosition = FormStartPosition.Manual;
                form2.Left = cursorPos.X - 30;
                form2.Top = cursorPos.Y;
                form2.Deactivate += delegate
                { form2.Close(); };
                form2.Show();
                indicator = 2;
            }
        }

        private void buttonAdd3_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1)
            {
                Form2 form2 = new Form2();
                var cursorPos = new Point(Cursor.Position.X, Cursor.Position.Y);
                form2.StartPosition = FormStartPosition.Manual;
                form2.Left = cursorPos.X - 30;
                form2.Top = cursorPos.Y;
                form2.Deactivate += delegate
                { form2.Close(); };
                form2.Show();
                indicator = 3;
            }
        }

        private void buttonAdd4_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1)
            {
                Form2 form2 = new Form2();
                var cursorPos = new Point(Cursor.Position.X, Cursor.Position.Y);
                form2.StartPosition = FormStartPosition.Manual;
                form2.Left = cursorPos.X - 30;
                form2.Top = cursorPos.Y;
                form2.Deactivate += delegate
                { form2.Close(); };
                form2.Show();
                indicator = 4;
            }
        }

        private void buttonAdd5_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1)
            {
                Form2 form2 = new Form2();
                var cursorPos = new Point(Cursor.Position.X, Cursor.Position.Y);
                form2.StartPosition = FormStartPosition.Manual;
                form2.Left = cursorPos.X - 30;
                form2.Top = cursorPos.Y;
                form2.Deactivate += delegate
                { form2.Close(); };
                form2.Show();
                indicator = 5;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1)
            {
                Form2 form2 = new Form2();
                var cursorPos = new Point(Cursor.Position.X, Cursor.Position.Y);
                form2.StartPosition = FormStartPosition.Manual;
                form2.Left = cursorPos.X - 100;
                form2.Top = cursorPos.Y+20;
                form2.Deactivate += delegate
                { form2.Close(); };
                form2.Show();
                indicator = 6;
            }
        }


        private void buttonReset4_Click(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count > 0) listView4.FocusedItem.Selected = false;
            textBox4.BackColor = Color.White;
            textBox4.ForeColor = Color.Black;
            textBox4.Text = null;
            textBoxAtt4.Text = null;
            textBoxCurrentHP4.Text = null;
            textBoxMaxHP4.Text = null;
            textBoxModifier4.Text = null;
            textBoxReduction4.Text = null;
            numericDef4.Value = 2;
            numericMDef4.Value = 2;
            numericIni4.Value = 1;
            numericMob4.Value = 3;
            numericProximity4.Value = 2;
            pictureBoxAtt4.Image = Properties.Resources.icon_pdmg;
            aResultsSort();
        }

        private void checkBoxArmorPenetration_CheckedChanged(object sender, EventArgs e)
        {
            CalculateAttackResult1();
            CalculateAttackResult2();
            CalculateAttackResult3();
            CalculateAttackResult4();
            CalculateAttackResult5();

        }

        private void buttonTeams_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1)
            {
                Form3 form3 = new Form3();
                form3.Deactivate += delegate
                { form3.Close(); };
                form3.Show();
                indicator = 1;
            }
        }

        private void buttonReset5_Click(object sender, EventArgs e)
        {
            if (listView5.SelectedItems.Count > 0) listView5.FocusedItem.Selected = false;
            textBox5.BackColor = Color.White;
            textBox5.ForeColor = Color.Black;
            textBox5.Text = null;
            textBoxAtt5.Text = null;
            textBoxCurrentHP5.Text = null;
            textBoxMaxHP5.Text = null;
            textBoxModifier5.Text = null;
            textBoxReduction5.Text = null;
            numericDef5.Value = 2;
            numericMDef5.Value = 2;
            numericIni5.Value = 1;
            numericMob5.Value = 3;
            numericProximity5.Value = 2;
            pictureBoxAtt4.Image = Properties.Resources.icon_pdmg;
            aResultsSort();
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            label1.Text = "Atakujący";
            textBoxAttack.Enabled = true;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void checkBoxBlocked2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateAttackResult2();
        }

        private void checkBoxBlocked3_CheckedChanged(object sender, EventArgs e)
        {
            CalculateAttackResult3();
        }

        private void checkBoxBlocked4_CheckedChanged(object sender, EventArgs e)
        {
            CalculateAttackResult4();
        }

        private void checkBoxBlocked5_CheckedChanged(object sender, EventArgs e)
        {
            CalculateAttackResult5();
        }
        
        public void pictureBoxAtt1_Click(object sender, EventArgs e)
        {
            if (damageType1 == "phy")
            {
                damageType1 = "mag";
                pictureBoxAtt1.Image = Properties.Resources.icon_magic;
            }
            else if (damageType1 == "mag")
            {
                damageType1 = "true";
                pictureBoxAtt1.Image = Properties.Resources.icon_truedmg;
            }
            else
            {
                damageType1 = "phy";
                pictureBoxAtt1.Image = Properties.Resources.icon_pdmg;
            }
            CalculateAttackResult1();
            CalculateAttackResult2();
            CalculateAttackResult3();
            CalculateAttackResult4();
            CalculateAttackResult5();
        }

        private void pictureBoxAtt1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxAtt1.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBoxAtt1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxAtt1.BorderStyle = BorderStyle.None;
        }

        private void pictureBoxAtt1_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAtt1.BorderStyle = wasBorder;
        }

        private void pictureBoxAtt1_MouseEnter(object sender, EventArgs e)
        {
            wasBorder = pictureBoxAtt1.BorderStyle;
        }

        public void pictureBoxAtt2_Click(object sender, EventArgs e)
        {
            if (damageType2 == "phy")
            {
                damageType2 = "mag";
                pictureBoxAtt2.Image = Properties.Resources.icon_magic;
            }
            else if (damageType2 == "mag")
            {
                damageType2 = "true";
                pictureBoxAtt2.Image = Properties.Resources.icon_truedmg;
            }
            else
            {
                damageType2 = "phy";
                pictureBoxAtt2.Image = Properties.Resources.icon_pdmg;
            }
            CalculateAttackResult1();
            CalculateAttackResult2();
            CalculateAttackResult3();
            CalculateAttackResult4();
            CalculateAttackResult5();
        }

        private void pictureBoxAtt2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxAtt2.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBoxAtt2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxAtt2.BorderStyle = BorderStyle.None;
        }

        private void pictureBoxAtt2_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAtt2.BorderStyle = wasBorder;
        }

        private void pictureBoxAtt2_MouseEnter(object sender, EventArgs e)
        {
            wasBorder = pictureBoxAtt2.BorderStyle;
        }
        
        public void pictureBoxAtt3_Click(object sender, EventArgs e)
        {
            if (damageType3 == "phy")
            {
                damageType3 = "mag";
                pictureBoxAtt3.Image = Properties.Resources.icon_magic;
            }
            else if (damageType3 == "mag")
            {
                damageType3 = "true";
                pictureBoxAtt3.Image = Properties.Resources.icon_truedmg;
            }
            else
            {
                damageType3 = "phy";
                pictureBoxAtt3.Image = Properties.Resources.icon_pdmg;
            }
            CalculateAttackResult1();
            CalculateAttackResult2();
            CalculateAttackResult3();
            CalculateAttackResult4();
            CalculateAttackResult5();
        }

        private void pictureBoxAtt3_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxAtt3.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBoxAtt3_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxAtt3.BorderStyle = BorderStyle.None;
        }

        private void pictureBoxAtt3_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAtt3.BorderStyle = wasBorder;
        }

        private void pictureBoxAtt3_MouseEnter(object sender, EventArgs e)
        {
            wasBorder = pictureBoxAtt3.BorderStyle;
        }
        
        public void pictureBoxAtt4_Click(object sender, EventArgs e)
        {
            if (damageType4 == "phy")
            {
                damageType4 = "mag";
                pictureBoxAtt4.Image = Properties.Resources.icon_magic;
            }
            else if (damageType4 == "mag")
            {
                damageType4 = "true";
                pictureBoxAtt4.Image = Properties.Resources.icon_truedmg;
            }
            else
            {
                damageType4 = "phy";
                pictureBoxAtt4.Image = Properties.Resources.icon_pdmg;
            }
            CalculateAttackResult1();
            CalculateAttackResult2();
            CalculateAttackResult3();
            CalculateAttackResult4();
            CalculateAttackResult5();
        }

        private void pictureBoxAtt4_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxAtt4.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBoxAtt4_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxAtt4.BorderStyle = BorderStyle.None;
        }

        private void pictureBoxAtt4_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAtt4.BorderStyle = wasBorder;
        }

        private void pictureBoxAtt4_MouseEnter(object sender, EventArgs e)
        {
            wasBorder = pictureBoxAtt4.BorderStyle;
        }

        public void pictureBoxAtt5_Click(object sender, EventArgs e)
        {
            if (damageType5 == "phy")
            {
                damageType5 = "mag";
                pictureBoxAtt5.Image = Properties.Resources.icon_magic;
            }
            else if (damageType5 == "mag")
            {
                damageType5 = "true";
                pictureBoxAtt5.Image = Properties.Resources.icon_truedmg;
            }
            else
            {
                damageType5 = "phy";
                pictureBoxAtt5.Image = Properties.Resources.icon_pdmg;
            }
            CalculateAttackResult1();
            CalculateAttackResult2();
            CalculateAttackResult3();
            CalculateAttackResult4();
            CalculateAttackResult5();
        }

        private void pictureBoxAtt5_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxAtt5.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBoxAtt5_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxAtt5.BorderStyle = BorderStyle.None;
        }

        private void pictureBoxAtt5_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAtt5.BorderStyle = wasBorder;
        }

        private void pictureBoxAtt5_MouseEnter(object sender, EventArgs e)
        {
            wasBorder = pictureBoxAtt5.BorderStyle;
        }

        private void checkBoxRanged_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxCanMelee.Visible = !checkBoxCanMelee.Visible;
            pictureBoxCanMelee.Visible = !pictureBoxCanMelee.Visible;
            if (labelDmgType.Text == "fiz")
            {
                if (checkBoxRanged.Checked) pictureBoxDmgType.Image = pbImage2;
                else pictureBoxDmgType.Image = pbImage1;
            }
            if (labelDmgType.Text == "mag")
            {
                if (checkBoxRanged.Checked) pictureBoxDmgType.Image = pbImage4;
                else pictureBoxDmgType.Image = pbImage3;
            }
            if (checkBoxRanged.Checked)
            {
                labelChoices.Text = "Targetting options. Proximity counts.";
                checkBoxCanMelee.Checked = false;
            }
            else
            {
                labelChoices.Text = "Targetting options.";
                checkBoxCanMelee.Checked = true;
            }
            CalculateAttackResult1();
            CalculateAttackResult2();
            CalculateAttackResult3();
            CalculateAttackResult4();
            CalculateAttackResult5();

        }

        private void buttonCopyMods_Click(object sender, EventArgs e)
        {
            textBoxModifier2.Text = textBoxModifier1.Text;
            textBoxModifier3.Text = textBoxModifier1.Text;
            textBoxModifier4.Text = textBoxModifier1.Text;
            textBoxModifier5.Text = textBoxModifier1.Text;
        }

        private void checkBoxCanMelee_CheckedChanged(object sender, EventArgs e)
        {
            CalculateAttackResult1();
            CalculateAttackResult2();
            CalculateAttackResult3();
            CalculateAttackResult4();
            CalculateAttackResult5();
        }

        private void numericProximity1_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult1();
        }

        private void numericProximity2_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult2();
        }

        private void numericProximity3_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult3();
        }

        private void numericProximity4_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult4();
        }

        private void numericProximity5_ValueChanged(object sender, EventArgs e)
        {
            CalculateAttackResult5();
        }

        public void assignValues()
        {
            if (holder != null)
            {
                switch (indicator)
                {
                    case 0:
                        break;
                    case 1:
                        wasString = holder.Name;
                        textBox1.Text = Regex.Replace(holder.Name, " lv", "-");
                        textBox1BackColor();
                        textBoxCurrentHP1.Text = holder.Hp;
                        textBoxMaxHP1.Text = holder.Hp;
                        textBoxAtt1.Text = holder.Attack;
                        numericDef1.Value = Int32.Parse(holder.Def);
                        numericMDef1.Value = Int32.Parse(holder.Mdef);
                        numericIni1.Value = Int32.Parse(holder.Initiative);
                        numericMob1.Value = Int32.Parse(holder.Movement);
                        switch (holder.DamageType)
                        {
                            case "physical":
                                pictureBoxAtt1.Image = Properties.Resources.icon_pdmg;
                                damageType1 = "phy";
                                break;
                            case "magic":
                                pictureBoxAtt1.Image = Properties.Resources.icon_magic;
                                damageType1 = "mag";
                                break;
                            case "both":
                                pictureBoxAtt1.Image = Properties.Resources.icon_truedmg;
                                damageType1 = "true";
                                break;
                        }
                        break;
                    case 2:
                        wasString = holder.Name;
                        textBox2.Text = Regex.Replace(holder.Name, " lv", "-");
                        textBox2BackColor();
                        textBoxCurrentHP2.Text = holder.Hp;
                        textBoxMaxHP2.Text = holder.Hp;
                        textBoxAtt2.Text = holder.Attack;
                        numericDef2.Value = Int32.Parse(holder.Def);
                        numericMDef2.Value = Int32.Parse(holder.Mdef);
                        numericIni2.Value = Int32.Parse(holder.Initiative);
                        numericMob2.Value = Int32.Parse(holder.Movement);
                        switch (holder.DamageType)
                        {
                            case "physical":
                                pictureBoxAtt2.Image = Properties.Resources.icon_pdmg;
                                damageType2 = "phy";
                                break;
                            case "magic":
                                pictureBoxAtt2.Image = Properties.Resources.icon_magic;
                                damageType2 = "mag";
                                break;
                            case "both":
                                pictureBoxAtt2.Image = Properties.Resources.icon_truedmg;
                                damageType2 = "true";
                                break;
                        }
                        break;
                    case 3:
                        wasString = holder.Name;
                        textBox3.Text = Regex.Replace(holder.Name, " lv", "-");
                        textBox3BackColor();
                        textBoxCurrentHP3.Text = holder.Hp;
                        textBoxMaxHP3.Text = holder.Hp;
                        textBoxAtt3.Text = holder.Attack;
                        numericDef3.Value = Int32.Parse(holder.Def);
                        numericMDef3.Value = Int32.Parse(holder.Mdef);
                        numericIni3.Value = Int32.Parse(holder.Initiative);
                        numericMob3.Value = Int32.Parse(holder.Movement);
                        switch (holder.DamageType)
                        {
                            case "physical":
                                pictureBoxAtt3.Image = Properties.Resources.icon_pdmg;
                                damageType3 = "phy";
                                break;
                            case "magic":
                                pictureBoxAtt3.Image = Properties.Resources.icon_magic;
                                damageType3 = "mag";
                                break;
                            case "both":
                                pictureBoxAtt3.Image = Properties.Resources.icon_truedmg;
                                damageType3 = "true";
                                break;
                        }
                        break;
                    case 4:
                        wasString = holder.Name;
                        textBox4.Text = Regex.Replace(holder.Name, " lv", "-");
                        textBox4BackColor();
                        textBoxCurrentHP4.Text = holder.Hp;
                        textBoxMaxHP4.Text = holder.Hp;
                        textBoxAtt4.Text = holder.Attack;
                        numericDef4.Value = Int32.Parse(holder.Def);
                        numericMDef4.Value = Int32.Parse(holder.Mdef);
                        numericIni4.Value = Int32.Parse(holder.Initiative);
                        numericMob4.Value = Int32.Parse(holder.Movement);
                        switch (holder.DamageType)
                        {
                            case "physical":
                                pictureBoxAtt4.Image = Properties.Resources.icon_pdmg;
                                damageType4 = "phy";
                                break;
                            case "magic":
                                pictureBoxAtt4.Image = Properties.Resources.icon_magic;
                                damageType4 = "mag";
                                break;
                            case "both":
                                pictureBoxAtt4.Image = Properties.Resources.icon_truedmg;
                                damageType4 = "true";
                                break;
                        }
                        break;
                    case 5:
                        wasString = holder.Name;
                        textBox5.Text = Regex.Replace(holder.Name, " lv", "-");
                        textBox5BackColor();
                        textBoxCurrentHP5.Text = holder.Hp;
                        textBoxMaxHP5.Text = holder.Hp;
                        textBoxAtt5.Text = holder.Attack;
                        numericDef5.Value = Int32.Parse(holder.Def);
                        numericMDef5.Value = Int32.Parse(holder.Mdef);
                        numericIni5.Value = Int32.Parse(holder.Initiative);
                        numericMob5.Value = Int32.Parse(holder.Movement);
                        switch (holder.DamageType)
                        {
                            case "physical":
                                pictureBoxAtt5.Image = Properties.Resources.icon_pdmg;
                                damageType5 = "phy";
                                break;
                            case "magic":
                                pictureBoxAtt5.Image = Properties.Resources.icon_magic;
                                damageType5 = "mag";
                                break;
                            case "both":
                                pictureBoxAtt5.Image = Properties.Resources.icon_truedmg;
                                damageType5 = "true";
                                break;
                        }
                        break;
                    case 6:
                        textBoxAttack.Text = holder.Attack;
                        numericDef.Value = Int32.Parse(holder.Def);
                        numericMDef.Value = Int32.Parse(holder.Mdef);
                        label1.Text = holder.Name;
                        textBoxAttack.Enabled = false;
                        switch (holder.DamageType)
                        {
                            case "physical":
                                pictureBoxDmgType.Image = Properties.Resources.icon_pdmg;
                                damageType = "phy";
                                labelDmgType.Text = "fiz";
                                break;
                            case "magic":
                                pictureBoxDmgType.Image = Properties.Resources.icon_magic;
                                damageType = "mag";
                                labelDmgType.Text = "mag";
                                break;
                            case "both":
                                pictureBoxDmgType.Image = Properties.Resources.icon_truedmg;
                                damageType = "true";
                                labelDmgType.Text = "oba";
                                break;
                        }
                        break;
                }
                indicator = 0;
                holder = null;
            }
        }
    }
    public static class ControlExtensions
    {
        public static void InvokeIfRequired(this Control control, Action action)
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }
        public static void InvokeIfRequired<T>(this Control control, Action<T> action, T parameter)
        {
            if (control.InvokeRequired)
                control.Invoke(action, parameter);
            else
                action(parameter);
        }
    }
}