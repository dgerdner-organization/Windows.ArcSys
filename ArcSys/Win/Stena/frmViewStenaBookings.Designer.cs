namespace CS2010.ArcSys.Win
{
	partial class frmViewStenaBookings
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
			Janus.Windows.GridEX.GridEXLayout cmbRoutes_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewStenaBookings));
			Janus.Windows.GridEX.GridEXLayout grdMain_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.ucPanel1 = new CS2010.CommonWinCtrls.ucPanel();
			this.ucLabel5 = new CS2010.CommonWinCtrls.ucLabel();
			this.btnClear = new CS2010.CommonWinCtrls.ucButton();
			this.cmbRoutes = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.txtBookingNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtStenaID = new CS2010.CommonWinCtrls.ucTextBox();
			this.ucLabel3 = new CS2010.CommonWinCtrls.ucLabel();
			this.ucLabel4 = new CS2010.CommonWinCtrls.ucLabel();
			this.ucToDays = new CS2010.CommonWinCtrls.ucNumericUpDown();
			this.ucLabel2 = new CS2010.CommonWinCtrls.ucLabel();
			this.ucLabel1 = new CS2010.CommonWinCtrls.ucLabel();
			this.ucFromDays = new CS2010.CommonWinCtrls.ucNumericUpDown();
			this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
			this.grdMain = new CS2010.CommonWinCtrls.ucGridEx();
			this.ucPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbRoutes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ucToDays)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ucFromDays)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
			this.SuspendLayout();
			// 
			// ucPanel1
			// 
			this.ucPanel1.Controls.Add(this.ucLabel5);
			this.ucPanel1.Controls.Add(this.btnClear);
			this.ucPanel1.Controls.Add(this.cmbRoutes);
			this.ucPanel1.Controls.Add(this.txtBookingNo);
			this.ucPanel1.Controls.Add(this.txtStenaID);
			this.ucPanel1.Controls.Add(this.ucLabel3);
			this.ucPanel1.Controls.Add(this.ucLabel4);
			this.ucPanel1.Controls.Add(this.ucToDays);
			this.ucPanel1.Controls.Add(this.ucLabel2);
			this.ucPanel1.Controls.Add(this.ucLabel1);
			this.ucPanel1.Controls.Add(this.ucFromDays);
			this.ucPanel1.Controls.Add(this.btnSearch);
			this.ucPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucPanel1.Location = new System.Drawing.Point(0, 0);
			this.ucPanel1.Name = "ucPanel1";
			this.ucPanel1.Size = new System.Drawing.Size(782, 173);
			this.ucPanel1.TabIndex = 0;
			// 
			// ucLabel5
			// 
			this.ucLabel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ucLabel5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.ucLabel5.Location = new System.Drawing.Point(0, 0);
			this.ucLabel5.Name = "ucLabel5";
			this.ucLabel5.Size = new System.Drawing.Size(484, 25);
			this.ucLabel5.TabIndex = 14;
			this.ucLabel5.Text = "This looks directly into the STENA booking portal";
			this.ucLabel5.Click += new System.EventHandler(this.ucLabel5_Click);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(193, 146);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 13;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// cmbRoutes
			// 
			this.cmbRoutes.CodeColumn = "route_cd";
			this.cmbRoutes.DescriptionColumn = "route_description";
			cmbRoutes_DesignTimeLayout.LayoutString = resources.GetString("cmbRoutes_DesignTimeLayout.LayoutString");
			this.cmbRoutes.DesignTimeLayout = cmbRoutes_DesignTimeLayout;
			this.cmbRoutes.DisplayMember = "route_cdroute_description";
			this.cmbRoutes.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbRoutes.LabelText = "Route";
			this.cmbRoutes.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbRoutes.Location = new System.Drawing.Point(100, 79);
			this.cmbRoutes.Name = "cmbRoutes";
			this.cmbRoutes.SelectedIndex = -1;
			this.cmbRoutes.SelectedItem = null;
			this.cmbRoutes.Size = new System.Drawing.Size(207, 20);
			this.cmbRoutes.TabIndex = 12;
			this.cmbRoutes.ValueColumn = "route_cd";
			this.cmbRoutes.ValueMember = "route_cd";
			// 
			// txtBookingNo
			// 
			this.txtBookingNo.LabelText = "Booking#";
			this.txtBookingNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtBookingNo.LinkDisabledMessage = "Link Disabled";
			this.txtBookingNo.Location = new System.Drawing.Point(100, 57);
			this.txtBookingNo.Name = "txtBookingNo";
			this.txtBookingNo.Size = new System.Drawing.Size(100, 20);
			this.txtBookingNo.TabIndex = 11;
			// 
			// txtStenaID
			// 
			this.txtStenaID.LabelText = "Stena ID";
			this.txtStenaID.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtStenaID.LinkDisabledMessage = "Link Disabled";
			this.txtStenaID.Location = new System.Drawing.Point(100, 35);
			this.txtStenaID.Name = "txtStenaID";
			this.txtStenaID.Size = new System.Drawing.Size(100, 20);
			this.txtStenaID.TabIndex = 10;
			// 
			// ucLabel3
			// 
			this.ucLabel3.Location = new System.Drawing.Point(144, 127);
			this.ucLabel3.Name = "ucLabel3";
			this.ucLabel3.Size = new System.Drawing.Size(29, 13);
			this.ucLabel3.TabIndex = 9;
			this.ucLabel3.Text = "days";
			// 
			// ucLabel4
			// 
			this.ucLabel4.Location = new System.Drawing.Point(40, 127);
			this.ucLabel4.Name = "ucLabel4";
			this.ucLabel4.Size = new System.Drawing.Size(53, 13);
			this.ucLabel4.TabIndex = 8;
			this.ucLabel4.Text = "To Today";
			// 
			// ucToDays
			// 
			this.ucToDays.Location = new System.Drawing.Point(100, 123);
			this.ucToDays.Name = "ucToDays";
			this.ucToDays.Size = new System.Drawing.Size(41, 20);
			this.ucToDays.TabIndex = 7;
			this.ucToDays.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
			// 
			// ucLabel2
			// 
			this.ucLabel2.Location = new System.Drawing.Point(144, 105);
			this.ucLabel2.Name = "ucLabel2";
			this.ucLabel2.Size = new System.Drawing.Size(29, 13);
			this.ucLabel2.TabIndex = 6;
			this.ucLabel2.Text = "days";
			// 
			// ucLabel1
			// 
			this.ucLabel1.Location = new System.Drawing.Point(30, 105);
			this.ucLabel1.Name = "ucLabel1";
			this.ucLabel1.Size = new System.Drawing.Size(63, 13);
			this.ucLabel1.TabIndex = 5;
			this.ucLabel1.Text = "From Today";
			// 
			// ucFromDays
			// 
			this.ucFromDays.Location = new System.Drawing.Point(100, 101);
			this.ucFromDays.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            -2147483648});
			this.ucFromDays.Name = "ucFromDays";
			this.ucFromDays.Size = new System.Drawing.Size(41, 20);
			this.ucFromDays.TabIndex = 4;
			this.ucFromDays.Value = new decimal(new int[] {
            7,
            0,
            0,
            -2147483648});
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(99, 146);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 3;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// grdMain
			// 
			grdMain_DesignTimeLayout.LayoutString = resources.GetString("grdMain_DesignTimeLayout.LayoutString");
			this.grdMain.DesignTimeLayout = grdMain_DesignTimeLayout;
			this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdMain.ExportFileID = null;
			this.grdMain.Location = new System.Drawing.Point(0, 173);
			this.grdMain.Name = "grdMain";
			this.grdMain.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdMain.Size = new System.Drawing.Size(782, 323);
			this.grdMain.TabIndex = 1;
			this.grdMain.SelectionChanged += new System.EventHandler(this.grdMain_SelectionChanged);
			// 
			// frmViewStenaBookings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(782, 496);
			this.Controls.Add(this.grdMain);
			this.Controls.Add(this.ucPanel1);
			this.Name = "frmViewStenaBookings";
			this.Text = "View Stena Bookings";
			this.ucPanel1.ResumeLayout(false);
			this.ucPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbRoutes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ucToDays)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ucFromDays)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucPanel ucPanel1;
		private CommonWinCtrls.ucGridEx grdMain;
		private CommonWinCtrls.ucButton btnSearch;
		private CommonWinCtrls.ucLabel ucLabel3;
		private CommonWinCtrls.ucLabel ucLabel4;
		private CommonWinCtrls.ucNumericUpDown ucToDays;
		private CommonWinCtrls.ucLabel ucLabel2;
		private CommonWinCtrls.ucLabel ucLabel1;
		private CommonWinCtrls.ucNumericUpDown ucFromDays;
		private CommonWinCtrls.ucTextBox txtStenaID;
		private CommonWinCtrls.ucMultiColumnCombo cmbRoutes;
		private CommonWinCtrls.ucTextBox txtBookingNo;
		private CommonWinCtrls.ucButton btnClear;
		private CommonWinCtrls.ucLabel ucLabel5;
	}
}
