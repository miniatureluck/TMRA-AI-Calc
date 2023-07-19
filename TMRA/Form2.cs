using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DataUpdater;
using System.Xml.Linq;
using System.Xml;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
    
namespace TMRA
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.boss_chat;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            comboBoxRarity.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxName.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        
        string rarityFilter;
        string json = File.ReadAllText(ProgramUpd.filePath);
        public static MonsterDataFromFile holder;

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxName.Visible = true;
            numericLevel.Enabled = false;
            numericLevel.Visible = true;
            comboBoxName.Items.Clear();
            switch (comboBoxRarity.SelectedIndex)
            {
                case 0:
                    rarityFilter = "diabolic";
                    numericLevel.Minimum = 9;
                    break;
                case 1:
                    rarityFilter = "monstrous";
                    numericLevel.Minimum = 6;
                    break;
                case 2:
                    rarityFilter = "epic";
                    numericLevel.Minimum = 3;
                    break;
                case 3:
                    rarityFilter = "common";
                    numericLevel.Minimum = 1;
                    break;
                default:
                    break;
            }
            List<MonsterDataFromFile> filteredMonsters = JsonConvert.DeserializeObject<List<MonsterDataFromFile>>(json);
            List<MonsterDataFromFile> filteredMonstersBy = new List<MonsterDataFromFile>();
            foreach (var unit in filteredMonsters)
            {
                if (unit.Rarity == rarityFilter) filteredMonstersBy.Add(unit);
            }
            foreach (var unit2 in filteredMonstersBy)
            {
                //unit2.Name = Regex.Replace(unit2.Name, " lv[0-9]*", "");
                if (!comboBoxName.Items.Contains(Regex.Replace(unit2.Name, " lv[0-9]*", ""))) comboBoxName.Items.Add(Regex.Replace(unit2.Name, " lv[0-9]*", ""));
            }
            
            
        }
        
        public class MonsterDataFromFile
        {
            public string Name { get; set; }
            public string Rarity { get; set; }

            [JsonProperty(PropertyName = "Damage Type")]
            public string DamageType { get; set; }
            public string Hp { get; set; }
            public string Attack { get; set; }
            public string Def { get; set; }
            public string Mdef { get; set; }
            public string Initiative { get; set; }
            public string Movement { get; set; }

        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<MonsterDataFromFile> filteredMonstersForInput = JsonConvert.DeserializeObject<List<MonsterDataFromFile>>(json);
            foreach (var unit in filteredMonstersForInput)
            {
                if (unit.Name == comboBoxName.GetItemText(comboBoxName.SelectedItem) + " lv" + numericLevel.Value) holder = unit;
            }
            if (holder != null)
            {
                buttonLoad.Visible = true;
            }
            numericLevel.Enabled = true;
            numericLevel.Focus();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            Form1.holder = holder;
            var principalForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            principalForm.assignValues();
            this.Close();
        }

        private void Form2_MouseEnter(object sender, EventArgs e)
        {

            comboBoxRarity.Visible = true;
        }

        private void comboBoxRarity_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBoxRarity.SelectedIndex == -1) comboBoxRarity.SelectedIndex = 0;
        }

        private void numericLevel_ValueChanged(object sender, EventArgs e)
        {
            List<MonsterDataFromFile> filteredMonstersForInput = JsonConvert.DeserializeObject<List<MonsterDataFromFile>>(json);
            foreach (var unit in filteredMonstersForInput)
            {
                if (unit.Name == comboBoxName.GetItemText(comboBoxName.SelectedItem) + " lv" + numericLevel.Value) holder = unit;
            }
            if (holder != null)
            {
                buttonLoad.Enabled = true;
            }
        }
    }
}
