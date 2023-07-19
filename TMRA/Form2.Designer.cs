
namespace TMRA
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericLevel = new System.Windows.Forms.NumericUpDown();
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.comboBoxRarity = new System.Windows.Forms.ComboBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // numericLevel
            // 
            this.numericLevel.Location = new System.Drawing.Point(150, 52);
            this.numericLevel.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericLevel.Name = "numericLevel";
            this.numericLevel.Size = new System.Drawing.Size(39, 23);
            this.numericLevel.TabIndex = 0;
            this.numericLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericLevel.Value = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericLevel.Visible = false;
            this.numericLevel.ValueChanged += new System.EventHandler(this.numericLevel_ValueChanged);
            // 
            // comboBoxName
            // 
            this.comboBoxName.BackColor = System.Drawing.Color.White;
            this.comboBoxName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.Location = new System.Drawing.Point(23, 81);
            this.comboBoxName.MaxDropDownItems = 50;
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(103, 23);
            this.comboBoxName.TabIndex = 3;
            this.comboBoxName.Text = "Unit";
            this.comboBoxName.Visible = false;
            this.comboBoxName.SelectedIndexChanged += new System.EventHandler(this.comboBoxName_SelectedIndexChanged);
            // 
            // comboBoxRarity
            // 
            this.comboBoxRarity.BackColor = System.Drawing.Color.White;
            this.comboBoxRarity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxRarity.FormattingEnabled = true;
            this.comboBoxRarity.Items.AddRange(new object[] {
            "Pomarańcze",
            "Fiolety",
            "Niebieskie",
            "Zielone"});
            this.comboBoxRarity.Location = new System.Drawing.Point(23, 52);
            this.comboBoxRarity.Name = "comboBoxRarity";
            this.comboBoxRarity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxRarity.Size = new System.Drawing.Size(103, 23);
            this.comboBoxRarity.TabIndex = 2;
            this.comboBoxRarity.Text = "Rarity";
            this.comboBoxRarity.Visible = false;
            this.comboBoxRarity.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBoxRarity.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBoxRarity_MouseClick);
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.Color.White;
            this.buttonLoad.Location = new System.Drawing.Point(132, 80);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 6;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Visible = false;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TMRA.Properties.Resources.boss_chat;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(246, 134);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.comboBoxName);
            this.Controls.Add(this.comboBoxRarity);
            this.Controls.Add(this.numericLevel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Wczytanie danych";
            this.MouseEnter += new System.EventHandler(this.Form2_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.numericLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericLevel;
        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.ComboBox comboBoxRarity;
        private System.Windows.Forms.Button buttonLoad;
    }
}