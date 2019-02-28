namespace Makpro1
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
            this.components = new System.ComponentModel.Container();
            this.picTree = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tipColor = new System.Windows.Forms.ToolTip(this.components);
            this.lblBGColor = new System.Windows.Forms.Label();
            this.lblLineColor = new System.Windows.Forms.Label();
            this.lblBoxFillColor = new System.Windows.Forms.Label();
            this.lblFontColor = new System.Windows.Forms.Label();
            this.nudBoxWidth = new System.Windows.Forms.NumericUpDown();
            this.nudBoxHeight = new System.Windows.Forms.NumericUpDown();
            this.nudMargin = new System.Windows.Forms.NumericUpDown();
            this.nudHorizontalSpace = new System.Windows.Forms.NumericUpDown();
            this.nudVerticalSpace = new System.Windows.Forms.NumericUpDown();
            this.nudFontSize = new System.Windows.Forms.NumericUpDown();
            this.nudLineWidth = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBoxWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBoxHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHorizontalSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVerticalSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // picTree
            // 
            this.picTree.AccessibleName = "";
            this.picTree.Location = new System.Drawing.Point(191, 5);
            this.picTree.Name = "picTree";
            this.picTree.Size = new System.Drawing.Size(725, 537);
            this.picTree.TabIndex = 0;
            this.picTree.TabStop = false;
            // 
            // lblBGColor
            // 
            this.lblBGColor.AutoSize = true;
            this.lblBGColor.Location = new System.Drawing.Point(12, 265);
            this.lblBGColor.Name = "lblBGColor";
            this.lblBGColor.Size = new System.Drawing.Size(49, 13);
            this.lblBGColor.TabIndex = 15;
            this.lblBGColor.Text = "BG Color";
            this.tipColor.SetToolTip(this.lblBGColor, "BG Color");
            this.lblBGColor.Click += new System.EventHandler(this.lblBGColor_Click_1);
            // 
            // lblLineColor
            // 
            this.lblLineColor.AutoSize = true;
            this.lblLineColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLineColor.Location = new System.Drawing.Point(12, 242);
            this.lblLineColor.Name = "lblLineColor";
            this.lblLineColor.Size = new System.Drawing.Size(54, 13);
            this.lblLineColor.TabIndex = 6;
            this.lblLineColor.Text = "Line Color";
            this.tipColor.SetToolTip(this.lblLineColor, "Line color");
            this.lblLineColor.Click += new System.EventHandler(this.lblLineColor_Click_1);
            // 
            // lblBoxFillColor
            // 
            this.lblBoxFillColor.AutoSize = true;
            this.lblBoxFillColor.Location = new System.Drawing.Point(12, 218);
            this.lblBoxFillColor.Name = "lblBoxFillColor";
            this.lblBoxFillColor.Size = new System.Drawing.Size(46, 13);
            this.lblBoxFillColor.TabIndex = 13;
            this.lblBoxFillColor.Text = "Fill Color";
            this.tipColor.SetToolTip(this.lblBoxFillColor, "Fill color");
            this.lblBoxFillColor.Click += new System.EventHandler(this.lblBoxFillColor_Click_1);
            // 
            // lblFontColor
            // 
            this.lblFontColor.AutoSize = true;
            this.lblFontColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFontColor.Location = new System.Drawing.Point(12, 196);
            this.lblFontColor.Name = "lblFontColor";
            this.lblFontColor.Size = new System.Drawing.Size(55, 13);
            this.lblFontColor.TabIndex = 12;
            this.lblFontColor.Text = "Font Color";
            this.tipColor.SetToolTip(this.lblFontColor, "Font color");
            this.lblFontColor.Click += new System.EventHandler(this.lblFontColor_Click_1);
            // 
            // nudBoxWidth
            // 
            this.nudBoxWidth.Location = new System.Drawing.Point(101, 164);
            this.nudBoxWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudBoxWidth.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudBoxWidth.Name = "nudBoxWidth";
            this.nudBoxWidth.Size = new System.Drawing.Size(62, 20);
            this.nudBoxWidth.TabIndex = 23;
            this.nudBoxWidth.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudBoxWidth.ValueChanged += new System.EventHandler(this.nudBoxWidth_ValueChanged);
            // 
            // nudBoxHeight
            // 
            this.nudBoxHeight.Location = new System.Drawing.Point(101, 138);
            this.nudBoxHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudBoxHeight.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudBoxHeight.Name = "nudBoxHeight";
            this.nudBoxHeight.Size = new System.Drawing.Size(62, 20);
            this.nudBoxHeight.TabIndex = 22;
            this.nudBoxHeight.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudBoxHeight.ValueChanged += new System.EventHandler(this.nudBoxHeight_ValueChanged);
            // 
            // nudMargin
            // 
            this.nudMargin.Location = new System.Drawing.Point(101, 112);
            this.nudMargin.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMargin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMargin.Name = "nudMargin";
            this.nudMargin.Size = new System.Drawing.Size(62, 20);
            this.nudMargin.TabIndex = 21;
            this.nudMargin.Value = new decimal(new int[] {
            140,
            0,
            0,
            0});
            this.nudMargin.ValueChanged += new System.EventHandler(this.nudMargin_ValueChanged_1);
            // 
            // nudHorizontalSpace
            // 
            this.nudHorizontalSpace.Location = new System.Drawing.Point(101, 86);
            this.nudHorizontalSpace.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudHorizontalSpace.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHorizontalSpace.Name = "nudHorizontalSpace";
            this.nudHorizontalSpace.Size = new System.Drawing.Size(62, 20);
            this.nudHorizontalSpace.TabIndex = 20;
            this.nudHorizontalSpace.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudHorizontalSpace.ValueChanged += new System.EventHandler(this.nudHorizontalSpace_ValueChanged_1);
            // 
            // nudVerticalSpace
            // 
            this.nudVerticalSpace.Location = new System.Drawing.Point(101, 60);
            this.nudVerticalSpace.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudVerticalSpace.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudVerticalSpace.Name = "nudVerticalSpace";
            this.nudVerticalSpace.Size = new System.Drawing.Size(62, 20);
            this.nudVerticalSpace.TabIndex = 19;
            this.nudVerticalSpace.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudVerticalSpace.ValueChanged += new System.EventHandler(this.nudVerticalSpace_ValueChanged_1);
            // 
            // nudFontSize
            // 
            this.nudFontSize.Location = new System.Drawing.Point(101, 34);
            this.nudFontSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudFontSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFontSize.Name = "nudFontSize";
            this.nudFontSize.Size = new System.Drawing.Size(62, 20);
            this.nudFontSize.TabIndex = 18;
            this.nudFontSize.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.nudFontSize.ValueChanged += new System.EventHandler(this.nudFontSize_ValueChanged_1);
            // 
            // nudLineWidth
            // 
            this.nudLineWidth.Location = new System.Drawing.Point(101, 8);
            this.nudLineWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudLineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLineWidth.Name = "nudLineWidth";
            this.nudLineWidth.Size = new System.Drawing.Size(62, 20);
            this.nudLineWidth.TabIndex = 17;
            this.nudLineWidth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudLineWidth.ValueChanged += new System.EventHandler(this.nudLineWidth_ValueChanged_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Box Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Box Height";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Margin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Horizontal Space";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Vertical Space";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Font Size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Line width";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 543);
            this.Controls.Add(this.nudBoxWidth);
            this.Controls.Add(this.nudBoxHeight);
            this.Controls.Add(this.nudMargin);
            this.Controls.Add(this.nudHorizontalSpace);
            this.Controls.Add(this.nudVerticalSpace);
            this.Controls.Add(this.nudFontSize);
            this.Controls.Add(this.nudLineWidth);
            this.Controls.Add(this.lblBGColor);
            this.Controls.Add(this.lblLineColor);
            this.Controls.Add(this.lblBoxFillColor);
            this.Controls.Add(this.lblFontColor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picTree);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBoxWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBoxHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHorizontalSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVerticalSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picTree;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolTip tipColor;
        private System.Windows.Forms.NumericUpDown nudBoxWidth;
        private System.Windows.Forms.NumericUpDown nudBoxHeight;
        private System.Windows.Forms.NumericUpDown nudMargin;
        private System.Windows.Forms.NumericUpDown nudHorizontalSpace;
        private System.Windows.Forms.NumericUpDown nudVerticalSpace;
        private System.Windows.Forms.NumericUpDown nudFontSize;
        private System.Windows.Forms.NumericUpDown nudLineWidth;
        private System.Windows.Forms.Label lblBGColor;
        private System.Windows.Forms.Label lblLineColor;
        private System.Windows.Forms.Label lblBoxFillColor;
        private System.Windows.Forms.Label lblFontColor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}