
namespace TMRA
{
    partial class MonsterControl
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public decimal uProximity
        {
            get { return numericProximity.Value; }
            set { numericProximity.Value = value; }
        }
        public string uTextBoxAtt
        {
            get { return textBoxAtt.Text; }
            set { textBoxAtt.Text = value; }
        }
        public decimal uInitiative
        {
            get { return numericIni.Value; }
            set { numericIni.Value = value; }
        }
        public decimal uMobility
        {
            get { return numericMob.Value; }
            set { numericMob.Value = value; }
        }
        public decimal uMDef
        {
            get { return numericMDef.Value; }
            set { numericMDef.Value = value; }
        }
        public decimal uDef
        {
            get { return numericDef.Value; }
            set { numericDef.Value = value; }
        }
        public string uReduction
        {
            get { return textBoxReduction.Text; }
            set { textBoxReduction.Text = value; }
        }
        public string uModifier
        {
            get { return textBoxModifier.Text; }
            set { textBoxModifier.Text = value; }
        }
        public string uMaxHP
        {
            get { return textBoxMaxHP.Text; }
            set { textBoxMaxHP.Text = value; }
        }
        public string uCurrentHP
        {
            get { return textBoxCurrentHP.Text; }
            set { textBoxCurrentHP.Text = value; }
        }
        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericProximity = new System.Windows.Forms.NumericUpDown();
            this.textBoxAtt = new System.Windows.Forms.TextBox();
            this.numericIni = new System.Windows.Forms.NumericUpDown();
            this.textBoxReduction = new System.Windows.Forms.TextBox();
            this.textBoxModifier = new System.Windows.Forms.TextBox();
            this.labelHP = new System.Windows.Forms.Label();
            this.textBoxMaxHP = new System.Windows.Forms.TextBox();
            this.labelHPs1 = new System.Windows.Forms.Label();
            this.textBoxCurrentHP = new System.Windows.Forms.TextBox();
            this.numericMob = new System.Windows.Forms.NumericUpDown();
            this.numericMDef = new System.Windows.Forms.NumericUpDown();
            this.numericDef = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericProximity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMDef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDef)).BeginInit();
            this.SuspendLayout();
            // 
            // numericProximity
            // 
            this.numericProximity.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericProximity.Location = new System.Drawing.Point(284, 1);
            this.numericProximity.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericProximity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericProximity.Name = "numericProximity";
            this.numericProximity.Size = new System.Drawing.Size(32, 22);
            this.numericProximity.TabIndex = 199;
            this.numericProximity.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericProximity.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // textBoxAtt
            // 
            this.textBoxAtt.BackColor = System.Drawing.Color.White;
            this.textBoxAtt.ForeColor = System.Drawing.Color.Black;
            this.textBoxAtt.Location = new System.Drawing.Point(168, 1);
            this.textBoxAtt.Name = "textBoxAtt";
            this.textBoxAtt.Size = new System.Drawing.Size(32, 23);
            this.textBoxAtt.TabIndex = 196;
            this.textBoxAtt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericIni
            // 
            this.numericIni.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericIni.Location = new System.Drawing.Point(114, 1);
            this.numericIni.Maximum = new decimal(new int[] {
            199,
            0,
            0,
            0});
            this.numericIni.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericIni.Name = "numericIni";
            this.numericIni.Size = new System.Drawing.Size(48, 22);
            this.numericIni.TabIndex = 194;
            this.numericIni.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericIni.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textBoxReduction
            // 
            this.textBoxReduction.BackColor = System.Drawing.Color.White;
            this.textBoxReduction.ForeColor = System.Drawing.Color.Black;
            this.textBoxReduction.Location = new System.Drawing.Point(245, 1);
            this.textBoxReduction.Name = "textBoxReduction";
            this.textBoxReduction.Size = new System.Drawing.Size(33, 23);
            this.textBoxReduction.TabIndex = 191;
            this.textBoxReduction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxModifier
            // 
            this.textBoxModifier.BackColor = System.Drawing.Color.White;
            this.textBoxModifier.ForeColor = System.Drawing.Color.Black;
            this.textBoxModifier.Location = new System.Drawing.Point(206, 1);
            this.textBoxModifier.Name = "textBoxModifier";
            this.textBoxModifier.Size = new System.Drawing.Size(33, 23);
            this.textBoxModifier.TabIndex = 188;
            this.textBoxModifier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelHP
            // 
            this.labelHP.AutoSize = true;
            this.labelHP.Location = new System.Drawing.Point(403, 5);
            this.labelHP.Name = "labelHP";
            this.labelHP.Size = new System.Drawing.Size(28, 15);
            this.labelHP.TabIndex = 187;
            this.labelHP.Text = "= %";
            // 
            // textBoxMaxHP
            // 
            this.textBoxMaxHP.BackColor = System.Drawing.Color.White;
            this.textBoxMaxHP.ForeColor = System.Drawing.Color.Black;
            this.textBoxMaxHP.Location = new System.Drawing.Point(369, 1);
            this.textBoxMaxHP.Name = "textBoxMaxHP";
            this.textBoxMaxHP.Size = new System.Drawing.Size(32, 23);
            this.textBoxMaxHP.TabIndex = 186;
            // 
            // labelHPs1
            // 
            this.labelHPs1.AutoSize = true;
            this.labelHPs1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelHPs1.Location = new System.Drawing.Point(354, 3);
            this.labelHPs1.Name = "labelHPs1";
            this.labelHPs1.Size = new System.Drawing.Size(15, 18);
            this.labelHPs1.TabIndex = 185;
            this.labelHPs1.Text = "/";
            // 
            // textBoxCurrentHP
            // 
            this.textBoxCurrentHP.BackColor = System.Drawing.Color.White;
            this.textBoxCurrentHP.ForeColor = System.Drawing.Color.Black;
            this.textBoxCurrentHP.Location = new System.Drawing.Point(321, 1);
            this.textBoxCurrentHP.Name = "textBoxCurrentHP";
            this.textBoxCurrentHP.Size = new System.Drawing.Size(32, 23);
            this.textBoxCurrentHP.TabIndex = 184;
            this.textBoxCurrentHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericMob
            // 
            this.numericMob.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericMob.Location = new System.Drawing.Point(76, 1);
            this.numericMob.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericMob.Name = "numericMob";
            this.numericMob.Size = new System.Drawing.Size(32, 22);
            this.numericMob.TabIndex = 183;
            this.numericMob.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericMob.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numericMDef
            // 
            this.numericMDef.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericMDef.Location = new System.Drawing.Point(38, 1);
            this.numericMDef.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericMDef.Name = "numericMDef";
            this.numericMDef.Size = new System.Drawing.Size(32, 22);
            this.numericMDef.TabIndex = 179;
            this.numericMDef.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericMDef.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericDef
            // 
            this.numericDef.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericDef.Location = new System.Drawing.Point(0, 1);
            this.numericDef.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericDef.Name = "numericDef";
            this.numericDef.Size = new System.Drawing.Size(32, 22);
            this.numericDef.TabIndex = 177;
            this.numericDef.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericDef.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // MonsterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericProximity);
            this.Controls.Add(this.textBoxAtt);
            this.Controls.Add(this.numericIni);
            this.Controls.Add(this.textBoxReduction);
            this.Controls.Add(this.textBoxModifier);
            this.Controls.Add(this.labelHP);
            this.Controls.Add(this.textBoxMaxHP);
            this.Controls.Add(this.labelHPs1);
            this.Controls.Add(this.textBoxCurrentHP);
            this.Controls.Add(this.numericMob);
            this.Controls.Add(this.numericMDef);
            this.Controls.Add(this.numericDef);
            this.Name = "MonsterControl";
            this.Size = new System.Drawing.Size(481, 26);
            ((System.ComponentModel.ISupportInitialize)(this.numericProximity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMDef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDef)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericProximity;
        private System.Windows.Forms.TextBox textBoxAtt;
        private System.Windows.Forms.NumericUpDown numericIni;
        private System.Windows.Forms.TextBox textBoxReduction;
        private System.Windows.Forms.TextBox textBoxModifier;
        private System.Windows.Forms.Label labelHP;
        private System.Windows.Forms.TextBox textBoxMaxHP;
        private System.Windows.Forms.Label labelHPs1;
        private System.Windows.Forms.TextBox textBoxCurrentHP;
        private System.Windows.Forms.NumericUpDown numericMob;
        private System.Windows.Forms.NumericUpDown numericMDef;
        private System.Windows.Forms.NumericUpDown numericDef;
    }
}
