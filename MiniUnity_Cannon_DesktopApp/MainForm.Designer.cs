namespace MiniUnity_Cannon_DesktopApp
{
    partial class MainForm
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
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.GameParamGroupBox = new System.Windows.Forms.GroupBox();
            this.PlaySoundCheckBox = new System.Windows.Forms.CheckBox();
            this.ScaleEdit = new System.Windows.Forms.NumericUpDown();
            this.TimeScaleEdit = new System.Windows.Forms.NumericUpDown();
            this.ScaleLabel = new System.Windows.Forms.Label();
            this.FramePerSecEdit = new System.Windows.Forms.NumericUpDown();
            this.TimeScaleLabel = new System.Windows.Forms.Label();
            this.FramePerSecLabel = new System.Windows.Forms.Label();
            this.RunButton = new System.Windows.Forms.Button();
            this.AngleEdit = new System.Windows.Forms.NumericUpDown();
            this.AngleLabel = new System.Windows.Forms.Label();
            this.VelocityEdit = new System.Windows.Forms.NumericUpDown();
            this.VelocityLabel = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.GameCanvasPanel = new System.Windows.Forms.Panel();
            this.ControlPanel.SuspendLayout();
            this.GameParamGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeScaleEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FramePerSecEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AngleEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VelocityEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // ControlPanel
            // 
            this.ControlPanel.Controls.Add(this.GameParamGroupBox);
            this.ControlPanel.Controls.Add(this.RunButton);
            this.ControlPanel.Controls.Add(this.AngleEdit);
            this.ControlPanel.Controls.Add(this.AngleLabel);
            this.ControlPanel.Controls.Add(this.VelocityEdit);
            this.ControlPanel.Controls.Add(this.VelocityLabel);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ControlPanel.Location = new System.Drawing.Point(0, 0);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(164, 674);
            this.ControlPanel.TabIndex = 0;
            // 
            // GameParamGroupBox
            // 
            this.GameParamGroupBox.Controls.Add(this.PlaySoundCheckBox);
            this.GameParamGroupBox.Controls.Add(this.ScaleEdit);
            this.GameParamGroupBox.Controls.Add(this.TimeScaleEdit);
            this.GameParamGroupBox.Controls.Add(this.ScaleLabel);
            this.GameParamGroupBox.Controls.Add(this.FramePerSecEdit);
            this.GameParamGroupBox.Controls.Add(this.TimeScaleLabel);
            this.GameParamGroupBox.Controls.Add(this.FramePerSecLabel);
            this.GameParamGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GameParamGroupBox.Location = new System.Drawing.Point(0, 462);
            this.GameParamGroupBox.Name = "GameParamGroupBox";
            this.GameParamGroupBox.Size = new System.Drawing.Size(164, 212);
            this.GameParamGroupBox.TabIndex = 5;
            this.GameParamGroupBox.TabStop = false;
            this.GameParamGroupBox.Text = "��������� ����";
            // 
            // PlaySoundCheckBox
            // 
            this.PlaySoundCheckBox.AutoSize = true;
            this.PlaySoundCheckBox.Location = new System.Drawing.Point(10, 146);
            this.PlaySoundCheckBox.Name = "PlaySoundCheckBox";
            this.PlaySoundCheckBox.Size = new System.Drawing.Size(50, 17);
            this.PlaySoundCheckBox.TabIndex = 3;
            this.PlaySoundCheckBox.Text = "����";
            this.PlaySoundCheckBox.UseVisualStyleBackColor = true;
            // 
            // ScaleEdit
            // 
            this.ScaleEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScaleEdit.Location = new System.Drawing.Point(10, 189);
            this.ScaleEdit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ScaleEdit.Name = "ScaleEdit";
            this.ScaleEdit.Size = new System.Drawing.Size(144, 20);
            this.ScaleEdit.TabIndex = 2;
            this.ScaleEdit.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ScaleEdit.ValueChanged += new System.EventHandler(this.ScaleEdit_ValueChanged);
            // 
            // TimeScaleEdit
            // 
            this.TimeScaleEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeScaleEdit.Location = new System.Drawing.Point(10, 110);
            this.TimeScaleEdit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.TimeScaleEdit.Name = "TimeScaleEdit";
            this.TimeScaleEdit.Size = new System.Drawing.Size(144, 20);
            this.TimeScaleEdit.TabIndex = 2;
            this.TimeScaleEdit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TimeScaleEdit.ValueChanged += new System.EventHandler(this.TimeScaleEdit_ValueChanged);
            // 
            // ScaleLabel
            // 
            this.ScaleLabel.AutoSize = true;
            this.ScaleLabel.Location = new System.Drawing.Point(7, 170);
            this.ScaleLabel.Name = "ScaleLabel";
            this.ScaleLabel.Size = new System.Drawing.Size(131, 13);
            this.ScaleLabel.TabIndex = 0;
            this.ScaleLabel.Text = "�������, ������ � 1�� ";
            // 
            // FramePerSecEdit
            // 
            this.FramePerSecEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FramePerSecEdit.Location = new System.Drawing.Point(12, 62);
            this.FramePerSecEdit.Name = "FramePerSecEdit";
            this.FramePerSecEdit.Size = new System.Drawing.Size(143, 20);
            this.FramePerSecEdit.TabIndex = 1;
            this.FramePerSecEdit.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.FramePerSecEdit.ValueChanged += new System.EventHandler(this.FramePerSecEdit_ValueChanged);
            // 
            // TimeScaleLabel
            // 
            this.TimeScaleLabel.AutoSize = true;
            this.TimeScaleLabel.Location = new System.Drawing.Point(7, 94);
            this.TimeScaleLabel.Name = "TimeScaleLabel";
            this.TimeScaleLabel.Size = new System.Drawing.Size(100, 13);
            this.TimeScaleLabel.TabIndex = 0;
            this.TimeScaleLabel.Text = "������� �������";
            // 
            // FramePerSecLabel
            // 
            this.FramePerSecLabel.Location = new System.Drawing.Point(9, 27);
            this.FramePerSecLabel.Name = "FramePerSecLabel";
            this.FramePerSecLabel.Size = new System.Drawing.Size(149, 32);
            this.FramePerSecLabel.TabIndex = 0;
            this.FramePerSecLabel.Text = "������� ����������, ������ � ���";
            // 
            // RunButton
            // 
            this.RunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RunButton.Location = new System.Drawing.Point(78, 129);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 4;
            this.RunButton.Text = "���!";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // AngleEdit
            // 
            this.AngleEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AngleEdit.Location = new System.Drawing.Point(12, 86);
            this.AngleEdit.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.AngleEdit.Name = "AngleEdit";
            this.AngleEdit.Size = new System.Drawing.Size(141, 20);
            this.AngleEdit.TabIndex = 3;
            this.AngleEdit.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.AngleEdit.ValueChanged += new System.EventHandler(this.AngleEdit_ValueChanged);
            // 
            // AngleLabel
            // 
            this.AngleLabel.AutoSize = true;
            this.AngleLabel.Location = new System.Drawing.Point(9, 70);
            this.AngleLabel.Name = "AngleLabel";
            this.AngleLabel.Size = new System.Drawing.Size(147, 13);
            this.AngleLabel.TabIndex = 2;
            this.AngleLabel.Text = "���� ����������, �������";
            // 
            // VelocityEdit
            // 
            this.VelocityEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VelocityEdit.Location = new System.Drawing.Point(12, 29);
            this.VelocityEdit.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.VelocityEdit.Name = "VelocityEdit";
            this.VelocityEdit.Size = new System.Drawing.Size(141, 20);
            this.VelocityEdit.TabIndex = 1;
            this.VelocityEdit.ThousandsSeparator = true;
            this.VelocityEdit.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.VelocityEdit.ValueChanged += new System.EventHandler(this.VelocityEdit_ValueChanged);
            // 
            // VelocityLabel
            // 
            this.VelocityLabel.AutoSize = true;
            this.VelocityLabel.Location = new System.Drawing.Point(9, 13);
            this.VelocityLabel.Name = "VelocityLabel";
            this.VelocityLabel.Size = new System.Drawing.Size(137, 13);
            this.VelocityLabel.TabIndex = 0;
            this.VelocityLabel.Text = "�������� �������, �/���";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(164, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 674);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // GameCanvasPanel
            // 
            this.GameCanvasPanel.BackColor = System.Drawing.Color.White;
            this.GameCanvasPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameCanvasPanel.Location = new System.Drawing.Point(167, 0);
            this.GameCanvasPanel.Name = "GameCanvasPanel";
            this.GameCanvasPanel.Size = new System.Drawing.Size(937, 674);
            this.GameCanvasPanel.TabIndex = 2;
            //this.GameCanvasPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GameCanvasPanel_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 674);
            this.Controls.Add(this.GameCanvasPanel);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.ControlPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "���� \"�����\"";
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            this.GameParamGroupBox.ResumeLayout(false);
            this.GameParamGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeScaleEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FramePerSecEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AngleEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VelocityEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.NumericUpDown AngleEdit;
        private System.Windows.Forms.Label AngleLabel;
        private System.Windows.Forms.NumericUpDown VelocityEdit;
        private System.Windows.Forms.Label VelocityLabel;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel GameCanvasPanel;
        private System.Windows.Forms.GroupBox GameParamGroupBox;
        private System.Windows.Forms.NumericUpDown TimeScaleEdit;
        private System.Windows.Forms.NumericUpDown FramePerSecEdit;
        private System.Windows.Forms.Label TimeScaleLabel;
        private System.Windows.Forms.Label FramePerSecLabel;
        private System.Windows.Forms.CheckBox PlaySoundCheckBox;
        private System.Windows.Forms.NumericUpDown ScaleEdit;
        private System.Windows.Forms.Label ScaleLabel;
    }
}

