namespace UniverseSimulator {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.MainTblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.MainPicBox = new System.Windows.Forms.PictureBox();
            this.ParamsPanel = new System.Windows.Forms.Panel();
            this.StopBtn = new System.Windows.Forms.Button();
            this.FpsLbl = new System.Windows.Forms.Label();
            this.IterationLbl = new System.Windows.Forms.Label();
            this.FpsUpDown = new System.Windows.Forms.NumericUpDown();
            this.ElementsLbl = new System.Windows.Forms.Label();
            this.ParticlesLbl = new System.Windows.Forms.Label();
            this.ElementsUpDown = new System.Windows.Forms.NumericUpDown();
            this.ParticlesUpDown = new System.Windows.Forms.NumericUpDown();
            this.TempUpDown = new System.Windows.Forms.NumericUpDown();
            this.TempLbl = new System.Windows.Forms.Label();
            this.SizeLbl = new System.Windows.Forms.Label();
            this.SizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.PlayPauseBtn = new System.Windows.Forms.Button();
            this.SimulationWorker = new System.ComponentModel.BackgroundWorker();
            this.EnergyLbl = new System.Windows.Forms.Label();
            this.MainTblLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPicBox)).BeginInit();
            this.ParamsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FpsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElementsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticlesUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TempUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTblLayout
            // 
            this.MainTblLayout.ColumnCount = 1;
            this.MainTblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTblLayout.Controls.Add(this.MainPicBox, 0, 1);
            this.MainTblLayout.Controls.Add(this.ParamsPanel, 0, 0);
            this.MainTblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTblLayout.Location = new System.Drawing.Point(0, 0);
            this.MainTblLayout.Name = "MainTblLayout";
            this.MainTblLayout.RowCount = 2;
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTblLayout.Size = new System.Drawing.Size(753, 609);
            this.MainTblLayout.TabIndex = 0;
            // 
            // MainPicBox
            // 
            this.MainPicBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPicBox.Location = new System.Drawing.Point(3, 123);
            this.MainPicBox.Name = "MainPicBox";
            this.MainPicBox.Size = new System.Drawing.Size(747, 483);
            this.MainPicBox.TabIndex = 0;
            this.MainPicBox.TabStop = false;
            this.MainPicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPicBox_Paint);
            // 
            // ParamsPanel
            // 
            this.ParamsPanel.Controls.Add(this.StopBtn);
            this.ParamsPanel.Controls.Add(this.FpsLbl);
            this.ParamsPanel.Controls.Add(this.EnergyLbl);
            this.ParamsPanel.Controls.Add(this.IterationLbl);
            this.ParamsPanel.Controls.Add(this.FpsUpDown);
            this.ParamsPanel.Controls.Add(this.ElementsLbl);
            this.ParamsPanel.Controls.Add(this.ParticlesLbl);
            this.ParamsPanel.Controls.Add(this.ElementsUpDown);
            this.ParamsPanel.Controls.Add(this.ParticlesUpDown);
            this.ParamsPanel.Controls.Add(this.TempUpDown);
            this.ParamsPanel.Controls.Add(this.TempLbl);
            this.ParamsPanel.Controls.Add(this.SizeLbl);
            this.ParamsPanel.Controls.Add(this.SizeUpDown);
            this.ParamsPanel.Controls.Add(this.PlayPauseBtn);
            this.ParamsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParamsPanel.Location = new System.Drawing.Point(3, 3);
            this.ParamsPanel.Name = "ParamsPanel";
            this.ParamsPanel.Size = new System.Drawing.Size(747, 114);
            this.ParamsPanel.TabIndex = 1;
            // 
            // StopBtn
            // 
            this.StopBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StopBtn.Enabled = false;
            this.StopBtn.Location = new System.Drawing.Point(512, 6);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(75, 23);
            this.StopBtn.TabIndex = 15;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // FpsLbl
            // 
            this.FpsLbl.AutoSize = true;
            this.FpsLbl.Location = new System.Drawing.Point(428, 37);
            this.FpsLbl.Name = "FpsLbl";
            this.FpsLbl.Size = new System.Drawing.Size(109, 13);
            this.FpsLbl.TabIndex = 14;
            this.FpsLbl.Text = "Iterations Per Second";
            // 
            // IterationLbl
            // 
            this.IterationLbl.AutoSize = true;
            this.IterationLbl.Location = new System.Drawing.Point(428, 63);
            this.IterationLbl.Name = "IterationLbl";
            this.IterationLbl.Size = new System.Drawing.Size(57, 13);
            this.IterationLbl.TabIndex = 14;
            this.IterationLbl.Text = "Iteration: 0";
            // 
            // FpsUpDown
            // 
            this.FpsUpDown.Location = new System.Drawing.Point(543, 35);
            this.FpsUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.FpsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FpsUpDown.Name = "FpsUpDown";
            this.FpsUpDown.Size = new System.Drawing.Size(44, 20);
            this.FpsUpDown.TabIndex = 13;
            this.FpsUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ElementsLbl
            // 
            this.ElementsLbl.AutoSize = true;
            this.ElementsLbl.Location = new System.Drawing.Point(9, 89);
            this.ElementsLbl.Name = "ElementsLbl";
            this.ElementsLbl.Size = new System.Drawing.Size(50, 13);
            this.ElementsLbl.TabIndex = 12;
            this.ElementsLbl.Text = "Elements";
            // 
            // ParticlesLbl
            // 
            this.ParticlesLbl.AutoSize = true;
            this.ParticlesLbl.Location = new System.Drawing.Point(9, 63);
            this.ParticlesLbl.Name = "ParticlesLbl";
            this.ParticlesLbl.Size = new System.Drawing.Size(47, 13);
            this.ParticlesLbl.TabIndex = 11;
            this.ParticlesLbl.Text = "Particles";
            // 
            // ElementsUpDown
            // 
            this.ElementsUpDown.Location = new System.Drawing.Point(85, 87);
            this.ElementsUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.ElementsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ElementsUpDown.Name = "ElementsUpDown";
            this.ElementsUpDown.Size = new System.Drawing.Size(120, 20);
            this.ElementsUpDown.TabIndex = 10;
            this.ElementsUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // ParticlesUpDown
            // 
            this.ParticlesUpDown.Location = new System.Drawing.Point(85, 61);
            this.ParticlesUpDown.Maximum = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.ParticlesUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ParticlesUpDown.Name = "ParticlesUpDown";
            this.ParticlesUpDown.Size = new System.Drawing.Size(120, 20);
            this.ParticlesUpDown.TabIndex = 9;
            this.ParticlesUpDown.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // TempUpDown
            // 
            this.TempUpDown.Location = new System.Drawing.Point(85, 35);
            this.TempUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.TempUpDown.Name = "TempUpDown";
            this.TempUpDown.Size = new System.Drawing.Size(120, 20);
            this.TempUpDown.TabIndex = 8;
            this.TempUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // TempLbl
            // 
            this.TempLbl.AutoSize = true;
            this.TempLbl.Location = new System.Drawing.Point(9, 37);
            this.TempLbl.Name = "TempLbl";
            this.TempLbl.Size = new System.Drawing.Size(61, 13);
            this.TempLbl.TabIndex = 7;
            this.TempLbl.Text = "Initial Temp";
            // 
            // SizeLbl
            // 
            this.SizeLbl.AutoSize = true;
            this.SizeLbl.Location = new System.Drawing.Point(9, 11);
            this.SizeLbl.Name = "SizeLbl";
            this.SizeLbl.Size = new System.Drawing.Size(62, 13);
            this.SizeLbl.TabIndex = 5;
            this.SizeLbl.Text = "Lattice Size";
            // 
            // SizeUpDown
            // 
            this.SizeUpDown.Location = new System.Drawing.Point(85, 9);
            this.SizeUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.SizeUpDown.Name = "SizeUpDown";
            this.SizeUpDown.Size = new System.Drawing.Size(120, 20);
            this.SizeUpDown.TabIndex = 3;
            this.SizeUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.SizeUpDown.ValueChanged += new System.EventHandler(this.SizeUpDown_ValueChanged);
            // 
            // PlayPauseBtn
            // 
            this.PlayPauseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayPauseBtn.Location = new System.Drawing.Point(431, 6);
            this.PlayPauseBtn.Name = "PlayPauseBtn";
            this.PlayPauseBtn.Size = new System.Drawing.Size(75, 23);
            this.PlayPauseBtn.TabIndex = 2;
            this.PlayPauseBtn.Text = "Play";
            this.PlayPauseBtn.UseVisualStyleBackColor = true;
            this.PlayPauseBtn.Click += new System.EventHandler(this.PlayPauseBtn_Click);
            // 
            // SimulationWorker
            // 
            this.SimulationWorker.WorkerSupportsCancellation = true;
            this.SimulationWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SimulationWorker_DoWork);
            this.SimulationWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SimulationWorker_RunWorkerCompleted);
            // 
            // EnergyLbl
            // 
            this.EnergyLbl.AutoSize = true;
            this.EnergyLbl.Location = new System.Drawing.Point(428, 87);
            this.EnergyLbl.Name = "EnergyLbl";
            this.EnergyLbl.Size = new System.Drawing.Size(43, 13);
            this.EnergyLbl.TabIndex = 14;
            this.EnergyLbl.Text = "Energy:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 609);
            this.Controls.Add(this.MainTblLayout);
            this.MinimumSize = new System.Drawing.Size(320, 220);
            this.Name = "MainForm";
            this.Text = "Universe Simulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MainTblLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainPicBox)).EndInit();
            this.ParamsPanel.ResumeLayout(false);
            this.ParamsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FpsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElementsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParticlesUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TempUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTblLayout;
        private System.Windows.Forms.PictureBox MainPicBox;
        private System.Windows.Forms.Panel ParamsPanel;
        private System.Windows.Forms.Label ParticlesLbl;
        private System.Windows.Forms.NumericUpDown ParticlesUpDown;
        private System.Windows.Forms.NumericUpDown TempUpDown;
        private System.Windows.Forms.Label TempLbl;
        private System.Windows.Forms.Label SizeLbl;
        private System.Windows.Forms.NumericUpDown SizeUpDown;
        private System.Windows.Forms.Button PlayPauseBtn;
        private System.Windows.Forms.Label ElementsLbl;
        private System.Windows.Forms.NumericUpDown ElementsUpDown;
        private System.Windows.Forms.Label IterationLbl;
        private System.Windows.Forms.NumericUpDown FpsUpDown;
        private System.Windows.Forms.Button StopBtn;
        private System.ComponentModel.BackgroundWorker SimulationWorker;
        private System.Windows.Forms.Label FpsLbl;
        private System.Windows.Forms.Label EnergyLbl;
    }
}

