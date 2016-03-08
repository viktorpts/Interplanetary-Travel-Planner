namespace Planner
{
	partial class MainMap
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
			this.DateYearsSpinner = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.DateDaysSpinner = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.PanelStarChart = new System.Windows.Forms.Panel();
			this.ProjectedYearsSpinner = new System.Windows.Forms.NumericUpDown();
			this.ProjectedDaysSpinner = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.FocusControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.CheckEeloo = new System.Windows.Forms.CheckBox();
			this.CheckJool = new System.Windows.Forms.CheckBox();
			this.CheckDres = new System.Windows.Forms.CheckBox();
			this.CheckDuna = new System.Windows.Forms.CheckBox();
			this.CheckKerbin = new System.Windows.Forms.CheckBox();
			this.CheckEve = new System.Windows.Forms.CheckBox();
			this.CheckMoho = new System.Windows.Forms.CheckBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.ExtendPhaseCheck = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.Button_DeltaV_P3 = new System.Windows.Forms.Button();
			this.Button_DeltaV_P2 = new System.Windows.Forms.Button();
			this.Button_DeltaV_P1 = new System.Windows.Forms.Button();
			this.Button_DeltaV_R3 = new System.Windows.Forms.Button();
			this.Button_DeltaV_R2 = new System.Windows.Forms.Button();
			this.Button_DeltaV_R1 = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.DeltaV_Box = new System.Windows.Forms.TextBox();
			this.Transfer_List = new System.Windows.Forms.ListBox();
			this.label7 = new System.Windows.Forms.Label();
			this.Transfer_Combo_StartingBody = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.DateYearsSpinner)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DateDaysSpinner)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ProjectedYearsSpinner)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ProjectedDaysSpinner)).BeginInit();
			this.FocusControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// DateYearsSpinner
			// 
			this.DateYearsSpinner.Location = new System.Drawing.Point(705, 28);
			this.DateYearsSpinner.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.DateYearsSpinner.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.DateYearsSpinner.Name = "DateYearsSpinner";
			this.DateYearsSpinner.Size = new System.Drawing.Size(60, 20);
			this.DateYearsSpinner.TabIndex = 1;
			this.DateYearsSpinner.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.DateYearsSpinner.ValueChanged += new System.EventHandler(this.DateYearsChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(705, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Year";
			// 
			// DateDaysSpinner
			// 
			this.DateDaysSpinner.Location = new System.Drawing.Point(771, 28);
			this.DateDaysSpinner.Maximum = new decimal(new int[] {
            427,
            0,
            0,
            0});
			this.DateDaysSpinner.Name = "DateDaysSpinner";
			this.DateDaysSpinner.Size = new System.Drawing.Size(60, 20);
			this.DateDaysSpinner.TabIndex = 1;
			this.DateDaysSpinner.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.DateDaysSpinner.ValueChanged += new System.EventHandler(this.DateDaysChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(768, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Day";
			// 
			// PanelStarChart
			// 
			this.PanelStarChart.BackColor = global::System.Drawing.Color.Black;
			this.PanelStarChart.Location = new System.Drawing.Point(12, 12);
			this.PanelStarChart.Name = "PanelStarChart";
			this.PanelStarChart.Size = new System.Drawing.Size(640, 640);
			this.PanelStarChart.TabIndex = 3;
			this.PanelStarChart.Paint += new System.Windows.Forms.PaintEventHandler(this.StarChart_Paint);
			// 
			// ProjectedYearsSpinner
			// 
			this.ProjectedYearsSpinner.Location = new System.Drawing.Point(915, 28);
			this.ProjectedYearsSpinner.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.ProjectedYearsSpinner.Name = "ProjectedYearsSpinner";
			this.ProjectedYearsSpinner.Size = new System.Drawing.Size(60, 20);
			this.ProjectedYearsSpinner.TabIndex = 4;
			this.ProjectedYearsSpinner.ValueChanged += new System.EventHandler(this.ProjectedYearsChanged);
			// 
			// ProjectedDaysSpinner
			// 
			this.ProjectedDaysSpinner.Location = new System.Drawing.Point(981, 28);
			this.ProjectedDaysSpinner.Maximum = new decimal(new int[] {
            426,
            0,
            0,
            0});
			this.ProjectedDaysSpinner.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.ProjectedDaysSpinner.Name = "ProjectedDaysSpinner";
			this.ProjectedDaysSpinner.Size = new System.Drawing.Size(60, 20);
			this.ProjectedDaysSpinner.TabIndex = 5;
			this.ProjectedDaysSpinner.ValueChanged += new System.EventHandler(this.ProjectedDaysChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(658, 30);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Epoch:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(912, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Years";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(978, 12);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(31, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Days";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(862, 30);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(47, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "Duration";
			// 
			// FocusControl
			// 
			this.FocusControl.Controls.Add(this.tabPage1);
			this.FocusControl.Controls.Add(this.tabPage2);
			this.FocusControl.Controls.Add(this.tabPage3);
			this.FocusControl.Controls.Add(this.tabPage4);
			this.FocusControl.Controls.Add(this.tabPage5);
			this.FocusControl.Location = new System.Drawing.Point(658, 430);
			this.FocusControl.Name = "FocusControl";
			this.FocusControl.SelectedIndex = 0;
			this.FocusControl.Size = new System.Drawing.Size(380, 199);
			this.FocusControl.TabIndex = 10;
			this.FocusControl.SelectedIndexChanged += new System.EventHandler(this.FocusChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.CheckEeloo);
			this.tabPage1.Controls.Add(this.CheckJool);
			this.tabPage1.Controls.Add(this.CheckDres);
			this.tabPage1.Controls.Add(this.CheckDuna);
			this.tabPage1.Controls.Add(this.CheckKerbin);
			this.tabPage1.Controls.Add(this.CheckEve);
			this.tabPage1.Controls.Add(this.CheckMoho);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(372, 173);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Kerbol";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// CheckEeloo
			// 
			this.CheckEeloo.AutoSize = true;
			this.CheckEeloo.Checked = true;
			this.CheckEeloo.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.CheckEeloo.Location = new System.Drawing.Point(7, 151);
			this.CheckEeloo.Name = "CheckEeloo";
			this.CheckEeloo.Size = new System.Drawing.Size(53, 17);
			this.CheckEeloo.TabIndex = 6;
			this.CheckEeloo.Text = "Eeloo";
			this.CheckEeloo.UseVisualStyleBackColor = true;
			this.CheckEeloo.CheckedChanged += new System.EventHandler(this.CheckChanged);
			// 
			// CheckJool
			// 
			this.CheckJool.AutoSize = true;
			this.CheckJool.Checked = true;
			this.CheckJool.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.CheckJool.Location = new System.Drawing.Point(7, 127);
			this.CheckJool.Name = "CheckJool";
			this.CheckJool.Size = new System.Drawing.Size(45, 17);
			this.CheckJool.TabIndex = 5;
			this.CheckJool.Text = "Jool";
			this.CheckJool.UseVisualStyleBackColor = true;
			this.CheckJool.CheckedChanged += new System.EventHandler(this.CheckChanged);
			// 
			// CheckDres
			// 
			this.CheckDres.AutoSize = true;
			this.CheckDres.Checked = true;
			this.CheckDres.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.CheckDres.Location = new System.Drawing.Point(7, 103);
			this.CheckDres.Name = "CheckDres";
			this.CheckDres.Size = new System.Drawing.Size(48, 17);
			this.CheckDres.TabIndex = 4;
			this.CheckDres.Text = "Dres";
			this.CheckDres.UseVisualStyleBackColor = true;
			this.CheckDres.CheckedChanged += new System.EventHandler(this.CheckChanged);
			// 
			// CheckDuna
			// 
			this.CheckDuna.AutoSize = true;
			this.CheckDuna.Checked = true;
			this.CheckDuna.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.CheckDuna.Location = new System.Drawing.Point(7, 79);
			this.CheckDuna.Name = "CheckDuna";
			this.CheckDuna.Size = new System.Drawing.Size(52, 17);
			this.CheckDuna.TabIndex = 3;
			this.CheckDuna.Text = "Duna";
			this.CheckDuna.UseVisualStyleBackColor = true;
			this.CheckDuna.CheckedChanged += new System.EventHandler(this.CheckChanged);
			// 
			// CheckKerbin
			// 
			this.CheckKerbin.AutoSize = true;
			this.CheckKerbin.Checked = true;
			this.CheckKerbin.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.CheckKerbin.Location = new System.Drawing.Point(7, 55);
			this.CheckKerbin.Name = "CheckKerbin";
			this.CheckKerbin.Size = new System.Drawing.Size(56, 17);
			this.CheckKerbin.TabIndex = 2;
			this.CheckKerbin.Text = "Kerbin";
			this.CheckKerbin.UseVisualStyleBackColor = true;
			this.CheckKerbin.CheckedChanged += new System.EventHandler(this.CheckChanged);
			// 
			// CheckEve
			// 
			this.CheckEve.AutoSize = true;
			this.CheckEve.Checked = true;
			this.CheckEve.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.CheckEve.Location = new System.Drawing.Point(7, 31);
			this.CheckEve.Name = "CheckEve";
			this.CheckEve.Size = new System.Drawing.Size(45, 17);
			this.CheckEve.TabIndex = 1;
			this.CheckEve.Text = "Eve";
			this.CheckEve.UseVisualStyleBackColor = true;
			this.CheckEve.CheckedChanged += new System.EventHandler(this.CheckChanged);
			// 
			// CheckMoho
			// 
			this.CheckMoho.AutoSize = true;
			this.CheckMoho.Checked = true;
			this.CheckMoho.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.CheckMoho.Location = new System.Drawing.Point(7, 7);
			this.CheckMoho.Name = "CheckMoho";
			this.CheckMoho.Size = new System.Drawing.Size(53, 17);
			this.CheckMoho.TabIndex = 0;
			this.CheckMoho.Text = "Moho";
			this.CheckMoho.UseVisualStyleBackColor = true;
			this.CheckMoho.CheckedChanged += new System.EventHandler(this.CheckChanged);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.checkBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(372, 173);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Kerbin";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(7, 7);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(80, 17);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "checkBox1";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(372, 173);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Eve";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// tabPage4
			// 
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(372, 173);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Duna";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// tabPage5
			// 
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(372, 173);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Jool";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// ExtendPhaseCheck
			// 
			this.ExtendPhaseCheck.AutoSize = true;
			this.ExtendPhaseCheck.Location = new System.Drawing.Point(658, 635);
			this.ExtendPhaseCheck.Name = "ExtendPhaseCheck";
			this.ExtendPhaseCheck.Size = new System.Drawing.Size(139, 17);
			this.ExtendPhaseCheck.TabIndex = 11;
			this.ExtendPhaseCheck.Text = "Extend phase indicators";
			this.ExtendPhaseCheck.UseVisualStyleBackColor = true;
			this.ExtendPhaseCheck.CheckedChanged += new System.EventHandler(this.ExtendPhaseChecked);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.Button_DeltaV_P3);
			this.groupBox1.Controls.Add(this.Button_DeltaV_P2);
			this.groupBox1.Controls.Add(this.Button_DeltaV_P1);
			this.groupBox1.Controls.Add(this.Button_DeltaV_R3);
			this.groupBox1.Controls.Add(this.Button_DeltaV_R2);
			this.groupBox1.Controls.Add(this.Button_DeltaV_R1);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.DeltaV_Box);
			this.groupBox1.Controls.Add(this.Transfer_List);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.Transfer_Combo_StartingBody);
			this.groupBox1.Location = new System.Drawing.Point(661, 54);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(380, 370);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Plan transfer orbit";
			// 
			// Button_DeltaV_P3
			// 
			this.Button_DeltaV_P3.Location = new System.Drawing.Point(341, 31);
			this.Button_DeltaV_P3.Name = "Button_DeltaV_P3";
			this.Button_DeltaV_P3.Size = new System.Drawing.Size(33, 22);
			this.Button_DeltaV_P3.TabIndex = 10;
			this.Button_DeltaV_P3.Text = ">>>";
			this.Button_DeltaV_P3.UseVisualStyleBackColor = true;
			this.Button_DeltaV_P3.Click += new System.EventHandler(this.DeltaV_Step);
			// 
			// Button_DeltaV_P2
			// 
			this.Button_DeltaV_P2.Location = new System.Drawing.Point(315, 31);
			this.Button_DeltaV_P2.Name = "Button_DeltaV_P2";
			this.Button_DeltaV_P2.Size = new System.Drawing.Size(27, 22);
			this.Button_DeltaV_P2.TabIndex = 9;
			this.Button_DeltaV_P2.Text = ">>";
			this.Button_DeltaV_P2.UseVisualStyleBackColor = true;
			this.Button_DeltaV_P2.Click += new System.EventHandler(this.DeltaV_Step);
			// 
			// Button_DeltaV_P1
			// 
			this.Button_DeltaV_P1.Location = new System.Drawing.Point(301, 31);
			this.Button_DeltaV_P1.Name = "Button_DeltaV_P1";
			this.Button_DeltaV_P1.Size = new System.Drawing.Size(15, 22);
			this.Button_DeltaV_P1.TabIndex = 8;
			this.Button_DeltaV_P1.Text = ">";
			this.Button_DeltaV_P1.UseVisualStyleBackColor = true;
			this.Button_DeltaV_P1.Click += new System.EventHandler(this.DeltaV_Step);
			// 
			// Button_DeltaV_R3
			// 
			this.Button_DeltaV_R3.Location = new System.Drawing.Point(148, 31);
			this.Button_DeltaV_R3.Name = "Button_DeltaV_R3";
			this.Button_DeltaV_R3.Size = new System.Drawing.Size(33, 22);
			this.Button_DeltaV_R3.TabIndex = 7;
			this.Button_DeltaV_R3.Text = "<<<";
			this.Button_DeltaV_R3.UseVisualStyleBackColor = true;
			this.Button_DeltaV_R3.Click += new System.EventHandler(this.DeltaV_Step);
			// 
			// Button_DeltaV_R2
			// 
			this.Button_DeltaV_R2.Location = new System.Drawing.Point(180, 31);
			this.Button_DeltaV_R2.Name = "Button_DeltaV_R2";
			this.Button_DeltaV_R2.Size = new System.Drawing.Size(27, 22);
			this.Button_DeltaV_R2.TabIndex = 6;
			this.Button_DeltaV_R2.Text = "<<";
			this.Button_DeltaV_R2.UseVisualStyleBackColor = true;
			this.Button_DeltaV_R2.Click += new System.EventHandler(this.DeltaV_Step);
			// 
			// Button_DeltaV_R1
			// 
			this.Button_DeltaV_R1.Location = new System.Drawing.Point(206, 31);
			this.Button_DeltaV_R1.Name = "Button_DeltaV_R1";
			this.Button_DeltaV_R1.Size = new System.Drawing.Size(15, 22);
			this.Button_DeltaV_R1.TabIndex = 5;
			this.Button_DeltaV_R1.Text = "<";
			this.Button_DeltaV_R1.UseVisualStyleBackColor = true;
			this.Button_DeltaV_R1.Click += new System.EventHandler(this.DeltaV_Step);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(221, 15);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(69, 13);
			this.label8.TabIndex = 4;
			this.label8.Text = "Delta V [m/s]";
			// 
			// DeltaV_Box
			// 
			this.DeltaV_Box.Location = new System.Drawing.Point(221, 32);
			this.DeltaV_Box.Name = "DeltaV_Box";
			this.DeltaV_Box.Size = new System.Drawing.Size(80, 20);
			this.DeltaV_Box.TabIndex = 3;
			this.DeltaV_Box.Text = "0";
			this.DeltaV_Box.TextChanged += new System.EventHandler(this.DeltaV_Changed);
			// 
			// Transfer_List
			// 
			this.Transfer_List.Enabled = false;
			this.Transfer_List.FormattingEnabled = true;
			this.Transfer_List.Location = new System.Drawing.Point(7, 60);
			this.Transfer_List.Name = "Transfer_List";
			this.Transfer_List.Size = new System.Drawing.Size(366, 303);
			this.Transfer_List.TabIndex = 2;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(69, 13);
			this.label7.TabIndex = 1;
			this.label7.Text = "Starting body";
			// 
			// Transfer_Combo_StartingBody
			// 
			this.Transfer_Combo_StartingBody.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Transfer_Combo_StartingBody.FormattingEnabled = true;
			this.Transfer_Combo_StartingBody.Location = new System.Drawing.Point(7, 32);
			this.Transfer_Combo_StartingBody.Name = "Transfer_Combo_StartingBody";
			this.Transfer_Combo_StartingBody.Size = new System.Drawing.Size(121, 21);
			this.Transfer_Combo_StartingBody.TabIndex = 0;
			this.Transfer_Combo_StartingBody.SelectionChangeCommitted += new System.EventHandler(this.Transfer_Combo_Changed);
			// 
			// MainMap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1053, 665);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.ExtendPhaseCheck);
			this.Controls.Add(this.FocusControl);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.ProjectedDaysSpinner);
			this.Controls.Add(this.ProjectedYearsSpinner);
			this.Controls.Add(this.PanelStarChart);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.DateDaysSpinner);
			this.Controls.Add(this.DateYearsSpinner);
			this.Name = "MainMap";
			this.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Interplanetary Travel Planner";
			((System.ComponentModel.ISupportInitialize)(this.DateYearsSpinner)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DateDaysSpinner)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ProjectedYearsSpinner)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ProjectedDaysSpinner)).EndInit();
			this.FocusControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.NumericUpDown DateYearsSpinner;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown DateDaysSpinner;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel PanelStarChart;
		private System.Windows.Forms.NumericUpDown ProjectedYearsSpinner;
		private System.Windows.Forms.NumericUpDown ProjectedDaysSpinner;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TabControl FocusControl;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.CheckBox CheckEeloo;
		private System.Windows.Forms.CheckBox CheckJool;
		private System.Windows.Forms.CheckBox CheckDres;
		private System.Windows.Forms.CheckBox CheckDuna;
		private System.Windows.Forms.CheckBox CheckKerbin;
		private System.Windows.Forms.CheckBox CheckEve;
		private System.Windows.Forms.CheckBox CheckMoho;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox ExtendPhaseCheck;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox Transfer_Combo_StartingBody;
		private System.Windows.Forms.ListBox Transfer_List;
		private System.Windows.Forms.Button Button_DeltaV_P3;
		private System.Windows.Forms.Button Button_DeltaV_P2;
		private System.Windows.Forms.Button Button_DeltaV_P1;
		private System.Windows.Forms.Button Button_DeltaV_R3;
		private System.Windows.Forms.Button Button_DeltaV_R2;
		private System.Windows.Forms.Button Button_DeltaV_R1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox DeltaV_Box;
	}
}

