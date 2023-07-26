namespace ASL.ITrack.WinCtrls
{
	partial class frmSearchIssues
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
			if( disposing && ( components != null ) )
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchIssues));
			Janus.Windows.GridEX.GridEXLayout grdIssues_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.Common.Layouts.JanusLayoutReference grdIssues_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column4.HeaderImage");
			Janus.Windows.GridEX.GridEXLayout grdNew_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.tbbSearch = new System.Windows.Forms.ToolStripButton();
			this.tbbOptions = new System.Windows.Forms.ToolStripDropDownButton();
			this.cnuOptionsCreate = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsN1 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuOptionsEmail = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsN2 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuOptionsIT = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsITSequence = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsITN1 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuOptionsITDeveloper = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsITClearDeveloper = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsITN2 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuOptionsITWip = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsITReleaseFlag = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsITDataFix = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsITEmg = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsITDevAssist = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsITNewReq = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsITDevNoteFlg = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsITN3 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuOptionsUpdateIssues = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsReleaseTest = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsReleaseProd = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsITN4 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuOptionsShowNew = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsN3 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuOptionsRefresh = new System.Windows.Forms.ToolStripMenuItem();
			this.tbbClose = new System.Windows.Forms.ToolStripButton();
			this.cnuAttachments = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.sbrChild = new System.Windows.Forms.StatusStrip();
			this.sbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
			this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
			this.grdIssues = new CS2010.CommonWinCtrls.ucGridEx();
			this.pnlMain = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.grdNew = new CS2010.CommonWinCtrls.ucGridEx();
			this.cnuNew = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cnuNewN1 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuNewClear = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuNewMove = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuNewHide = new System.Windows.Forms.ToolStripMenuItem();
			this.pnlTop = new CS2010.CommonWinCtrls.ucPanel();
			this.lblParams = new System.Windows.Forms.Label();
			this.cnuActions = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cnuActionsStatusNew = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuActionsStatusHold = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuActionsStatusSpec = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuActionsStatusDev = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuActionsStatusPend = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuActionsStatusTest = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuActionsStatusApprove = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuActionsStatusClose = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuActionsStatusNoAction = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuActionsN1 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuActionsAddAttachment = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuActionsAddNote = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuActionsPriority = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuActionsN2 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuActionsEditIssue = new System.Windows.Forms.ToolStripMenuItem();
			this.tbrMain.SuspendLayout();
			this.sbrChild.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdIssues)).BeginInit();
			this.pnlMain.Panel1.SuspendLayout();
			this.pnlMain.Panel2.SuspendLayout();
			this.pnlMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdNew)).BeginInit();
			this.cnuNew.SuspendLayout();
			this.pnlTop.SuspendLayout();
			this.cnuActions.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbrMain
			// 
			this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbSearch,
            this.tbbOptions,
            this.tbbClose});
			this.tbrMain.Location = new System.Drawing.Point(0, 0);
			this.tbrMain.Name = "tbrMain";
			this.tbrMain.Size = new System.Drawing.Size(782, 25);
			this.tbrMain.TabIndex = 0;
			this.tbrMain.Visible = false;
			// 
			// tbbSearch
			// 
			this.tbbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbSearch.Name = "tbbSearch";
			this.tbbSearch.Size = new System.Drawing.Size(44, 22);
			this.tbbSearch.Text = "&Search";
			this.tbbSearch.Click += new System.EventHandler(this.tbbSearch_Click);
			// 
			// tbbOptions
			// 
			this.tbbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cnuOptionsCreate,
            this.cnuOptionsN1,
            this.cnuOptionsEmail,
            this.cnuOptionsN2,
            this.cnuOptionsIT,
            this.cnuOptionsN3,
            this.cnuOptionsRefresh});
			this.tbbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbOptions.Name = "tbbOptions";
			this.tbbOptions.Size = new System.Drawing.Size(57, 22);
			this.tbbOptions.Text = "&Options";
			// 
			// cnuOptionsCreate
			// 
			this.cnuOptionsCreate.Name = "cnuOptionsCreate";
			this.cnuOptionsCreate.Size = new System.Drawing.Size(186, 22);
			this.cnuOptionsCreate.Text = "Create New Issue...";
			this.cnuOptionsCreate.Click += new System.EventHandler(this.cnuOptionsCreate_Click);
			// 
			// cnuOptionsN1
			// 
			this.cnuOptionsN1.Name = "cnuOptionsN1";
			this.cnuOptionsN1.Size = new System.Drawing.Size(183, 6);
			// 
			// cnuOptionsEmail
			// 
			this.cnuOptionsEmail.Name = "cnuOptionsEmail";
			this.cnuOptionsEmail.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.cnuOptionsEmail.Size = new System.Drawing.Size(186, 22);
			this.cnuOptionsEmail.Text = "Send &Email...";
			this.cnuOptionsEmail.ToolTipText = "Multiple issues can be selected to be included in the email";
			this.cnuOptionsEmail.Click += new System.EventHandler(this.cnuOptionsEmail_Click);
			// 
			// cnuOptionsN2
			// 
			this.cnuOptionsN2.Name = "cnuOptionsN2";
			this.cnuOptionsN2.Size = new System.Drawing.Size(183, 6);
			// 
			// cnuOptionsIT
			// 
			this.cnuOptionsIT.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cnuOptionsITSequence,
            this.cnuOptionsITN1,
            this.cnuOptionsITDeveloper,
            this.cnuOptionsITClearDeveloper,
            this.cnuOptionsITN2,
            this.cnuOptionsITWip,
            this.cnuOptionsITReleaseFlag,
            this.cnuOptionsITDataFix,
            this.cnuOptionsITEmg,
            this.cnuOptionsITDevAssist,
            this.cnuOptionsITNewReq,
            this.cnuOptionsITDevNoteFlg,
            this.cnuOptionsITN3,
            this.cnuOptionsUpdateIssues,
            this.cnuOptionsReleaseTest,
            this.cnuOptionsReleaseProd,
            this.cnuOptionsITN4,
            this.cnuOptionsShowNew});
			this.cnuOptionsIT.Name = "cnuOptionsIT";
			this.cnuOptionsIT.Size = new System.Drawing.Size(186, 22);
			this.cnuOptionsIT.Text = "IT Options";
			this.cnuOptionsIT.Visible = false;
			// 
			// cnuOptionsITSequence
			// 
			this.cnuOptionsITSequence.Name = "cnuOptionsITSequence";
			this.cnuOptionsITSequence.Size = new System.Drawing.Size(326, 22);
			this.cnuOptionsITSequence.Text = "Set Priority Sequence (Multiple Issues)...";
			this.cnuOptionsITSequence.Click += new System.EventHandler(this.cnuOptionsITSequence_Click);
			// 
			// cnuOptionsITN1
			// 
			this.cnuOptionsITN1.Name = "cnuOptionsITN1";
			this.cnuOptionsITN1.Size = new System.Drawing.Size(323, 6);
			// 
			// cnuOptionsITDeveloper
			// 
			this.cnuOptionsITDeveloper.Name = "cnuOptionsITDeveloper";
			this.cnuOptionsITDeveloper.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
			this.cnuOptionsITDeveloper.Size = new System.Drawing.Size(326, 22);
			this.cnuOptionsITDeveloper.Text = "Change IT Owner (Multiple Issues)...";
			this.cnuOptionsITDeveloper.Click += new System.EventHandler(this.cnuOptionsDeveloper_Click);
			// 
			// cnuOptionsITClearDeveloper
			// 
			this.cnuOptionsITClearDeveloper.Name = "cnuOptionsITClearDeveloper";
			this.cnuOptionsITClearDeveloper.Size = new System.Drawing.Size(326, 22);
			this.cnuOptionsITClearDeveloper.Text = "Clear IT Owner (Multiple Issues)";
			this.cnuOptionsITClearDeveloper.Click += new System.EventHandler(this.cnuOptionsClearDeveloper_Click);
			// 
			// cnuOptionsITN2
			// 
			this.cnuOptionsITN2.Name = "cnuOptionsITN2";
			this.cnuOptionsITN2.Size = new System.Drawing.Size(323, 6);
			// 
			// cnuOptionsITWip
			// 
			this.cnuOptionsITWip.Name = "cnuOptionsITWip";
			this.cnuOptionsITWip.Size = new System.Drawing.Size(326, 22);
			this.cnuOptionsITWip.Text = "Change WIP Flag (Multiple Issues)...";
			this.cnuOptionsITWip.Click += new System.EventHandler(this.cnuOptionsITFlag_Click);
			// 
			// cnuOptionsITReleaseFlag
			// 
			this.cnuOptionsITReleaseFlag.Name = "cnuOptionsITReleaseFlag";
			this.cnuOptionsITReleaseFlag.Size = new System.Drawing.Size(326, 22);
			this.cnuOptionsITReleaseFlag.Text = "Change Release Flag (Multiple Issues)...";
			this.cnuOptionsITReleaseFlag.Click += new System.EventHandler(this.cnuOptionsITFlag_Click);
			// 
			// cnuOptionsITDataFix
			// 
			this.cnuOptionsITDataFix.Name = "cnuOptionsITDataFix";
			this.cnuOptionsITDataFix.Size = new System.Drawing.Size(326, 22);
			this.cnuOptionsITDataFix.Text = "Change Data Fix Flag (Multiple Issues)...";
			this.cnuOptionsITDataFix.Click += new System.EventHandler(this.cnuOptionsITFlag_Click);
			// 
			// cnuOptionsITEmg
			// 
			this.cnuOptionsITEmg.Name = "cnuOptionsITEmg";
			this.cnuOptionsITEmg.Size = new System.Drawing.Size(326, 22);
			this.cnuOptionsITEmg.Text = "Change Emergency Flag (Multiple Issues)...";
			this.cnuOptionsITEmg.Click += new System.EventHandler(this.cnuOptionsITFlag_Click);
			// 
			// cnuOptionsITDevAssist
			// 
			this.cnuOptionsITDevAssist.Name = "cnuOptionsITDevAssist";
			this.cnuOptionsITDevAssist.Size = new System.Drawing.Size(326, 22);
			this.cnuOptionsITDevAssist.Text = "Change Developer &Assist Flag (Multiple Issues)...";
			this.cnuOptionsITDevAssist.Click += new System.EventHandler(this.cnuOptionsITFlag_Click);
			// 
			// cnuOptionsITNewReq
			// 
			this.cnuOptionsITNewReq.Name = "cnuOptionsITNewReq";
			this.cnuOptionsITNewReq.Size = new System.Drawing.Size(326, 22);
			this.cnuOptionsITNewReq.Text = "Change New Requirement Flag (Multiple Issues)...";
			this.cnuOptionsITNewReq.Click += new System.EventHandler(this.cnuOptionsITFlag_Click);
			// 
			// cnuOptionsITDevNoteFlg
			// 
			this.cnuOptionsITDevNoteFlg.Name = "cnuOptionsITDevNoteFlg";
			this.cnuOptionsITDevNoteFlg.Size = new System.Drawing.Size(326, 22);
			this.cnuOptionsITDevNoteFlg.Text = "Toggle Note Developer &Flag (Single Note)...";
			this.cnuOptionsITDevNoteFlg.Click += new System.EventHandler(this.cnuOptionsITDevNoteFlg_Click);
			// 
			// cnuOptionsITN3
			// 
			this.cnuOptionsITN3.Name = "cnuOptionsITN3";
			this.cnuOptionsITN3.Size = new System.Drawing.Size(323, 6);
			// 
			// cnuOptionsUpdateIssues
			// 
			this.cnuOptionsUpdateIssues.Name = "cnuOptionsUpdateIssues";
			this.cnuOptionsUpdateIssues.Size = new System.Drawing.Size(326, 22);
			this.cnuOptionsUpdateIssues.Text = "Update Multiple Issues";
			this.cnuOptionsUpdateIssues.Click += new System.EventHandler(this.cnuOptionsUpdateIssues_Click);
			// 
			// cnuOptionsReleaseTest
			// 
			this.cnuOptionsReleaseTest.Name = "cnuOptionsReleaseTest";
			this.cnuOptionsReleaseTest.Size = new System.Drawing.Size(326, 22);
			this.cnuOptionsReleaseTest.Text = "Relea&se Multiple Issues (Test)";
			this.cnuOptionsReleaseTest.Click += new System.EventHandler(this.cnuOptionsReleaseTest_Click);
			// 
			// cnuOptionsReleaseProd
			// 
			this.cnuOptionsReleaseProd.Name = "cnuOptionsReleaseProd";
			this.cnuOptionsReleaseProd.Size = new System.Drawing.Size(326, 22);
			this.cnuOptionsReleaseProd.Text = "Release Multiple Issues (Production)";
			this.cnuOptionsReleaseProd.Click += new System.EventHandler(this.cnuOptionsReleaseProd_Click);
			// 
			// cnuOptionsITN4
			// 
			this.cnuOptionsITN4.Name = "cnuOptionsITN4";
			this.cnuOptionsITN4.Size = new System.Drawing.Size(323, 6);
			// 
			// cnuOptionsShowNew
			// 
			this.cnuOptionsShowNew.CheckOnClick = true;
			this.cnuOptionsShowNew.Name = "cnuOptionsShowNew";
			this.cnuOptionsShowNew.Size = new System.Drawing.Size(326, 22);
			this.cnuOptionsShowNew.Text = "Check for New Issues (Display Notification Area)";
			this.cnuOptionsShowNew.Click += new System.EventHandler(this.cnuOptionsShowNew_Click);
			// 
			// cnuOptionsN3
			// 
			this.cnuOptionsN3.Name = "cnuOptionsN3";
			this.cnuOptionsN3.Size = new System.Drawing.Size(183, 6);
			this.cnuOptionsN3.Visible = false;
			// 
			// cnuOptionsRefresh
			// 
			this.cnuOptionsRefresh.Name = "cnuOptionsRefresh";
			this.cnuOptionsRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.cnuOptionsRefresh.Size = new System.Drawing.Size(186, 22);
			this.cnuOptionsRefresh.Text = "&Refresh";
			this.cnuOptionsRefresh.Click += new System.EventHandler(this.cnuOptionsRefresh_Click);
			// 
			// tbbClose
			// 
			this.tbbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbClose.Name = "tbbClose";
			this.tbbClose.Size = new System.Drawing.Size(37, 22);
			this.tbbClose.Text = "Close";
			this.tbbClose.Click += new System.EventHandler(this.tbbClose_Click);
			// 
			// cnuAttachments
			// 
			this.cnuAttachments.Name = "cnuAttachments";
			this.cnuAttachments.Size = new System.Drawing.Size(61, 4);
			// 
			// sbrChild
			// 
			this.sbrChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbProgressCaption,
            this.sbbProgressMeter});
			this.sbrChild.Location = new System.Drawing.Point(0, 474);
			this.sbrChild.Name = "sbrChild";
			this.sbrChild.Size = new System.Drawing.Size(782, 22);
			this.sbrChild.TabIndex = 4;
			this.sbrChild.Visible = false;
			// 
			// sbProgressCaption
			// 
			this.sbProgressCaption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.sbProgressCaption.IsLink = true;
			this.sbProgressCaption.Name = "sbProgressCaption";
			this.sbProgressCaption.Size = new System.Drawing.Size(223, 17);
			this.sbProgressCaption.Text = "Searching... (Click here to cancel the search)";
			this.sbProgressCaption.Visible = false;
			this.sbProgressCaption.Click += new System.EventHandler(this.sbbProgressCaption_Click);
			// 
			// sbbProgressMeter
			// 
			this.sbbProgressMeter.Name = "sbbProgressMeter";
			this.sbbProgressMeter.Size = new System.Drawing.Size(100, 16);
			this.sbbProgressMeter.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.sbbProgressMeter.Visible = false;
			// 
			// grdIssues
			// 
			this.grdIssues.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdIssues.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdIssues.BuiltInTextsData = resources.GetString("grdIssues.BuiltInTextsData");
			this.grdIssues.DataMember = "Issues";
			grdIssues_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("grdIssues_DesignTimeLayout_Reference_0.Instance")));
			grdIssues_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            grdIssues_DesignTimeLayout_Reference_0});
			grdIssues_DesignTimeLayout.LayoutString = resources.GetString("grdIssues_DesignTimeLayout.LayoutString");
			this.grdIssues.DesignTimeLayout = grdIssues_DesignTimeLayout;
			this.grdIssues.DisplayFieldChooser = true;
			this.grdIssues.DisplayFontSelector = true;
			this.grdIssues.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdIssues.ExportFileID = "Issue List";
			this.grdIssues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdIssues.GroupByBoxInfoFormatStyle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.grdIssues.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdIssues.Hierarchical = true;
			this.grdIssues.Location = new System.Drawing.Point(0, 0);
			this.grdIssues.Name = "grdIssues";
			this.grdIssues.Size = new System.Drawing.Size(782, 354);
			this.grdIssues.TabIndex = 6;
			this.grdIssues.UseGroupRowSelector = true;
			this.grdIssues.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdIssues_LoadingRow);
			this.grdIssues.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdIssues_KeyDown);
			this.grdIssues.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdIssues_ColumnButtonClick);
			this.grdIssues.DoubleClick += new System.EventHandler(this.grdIssues_DoubleClick);
			// 
			// pnlMain
			// 
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 23);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// pnlMain.Panel1
			// 
			this.pnlMain.Panel1.Controls.Add(this.grdIssues);
			// 
			// pnlMain.Panel2
			// 
			this.pnlMain.Panel2.Controls.Add(this.grdNew);
			this.pnlMain.Size = new System.Drawing.Size(782, 473);
			this.pnlMain.SplitterDistance = 354;
			this.pnlMain.TabIndex = 7;
			// 
			// grdNew
			// 
			this.grdNew.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdNew.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdNew.ContextMenuStrip = this.cnuNew;
			this.grdNew.DataMember = "Issues";
			grdNew_DesignTimeLayout.LayoutString = resources.GetString("grdNew_DesignTimeLayout.LayoutString");
			this.grdNew.DesignTimeLayout = grdNew_DesignTimeLayout;
			this.grdNew.DisplayFieldChooser = true;
			this.grdNew.DisplayFontSelector = true;
			this.grdNew.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdNew.ExportFileID = "Issue List";
			this.grdNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdNew.GroupByBoxVisible = false;
			this.grdNew.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdNew.Location = new System.Drawing.Point(0, 0);
			this.grdNew.Name = "grdNew";
			this.grdNew.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelectionSameTable;
			this.grdNew.Size = new System.Drawing.Size(782, 115);
			this.grdNew.TabIndex = 7;
			this.grdNew.UseGroupRowSelector = true;
			this.grdNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdNew_KeyDown);
			this.grdNew.DoubleClick += new System.EventHandler(this.grdNew_DoubleClick);
			// 
			// cnuNew
			// 
			this.cnuNew.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cnuNewN1,
            this.cnuNewClear,
            this.cnuNewMove,
            this.cnuNewHide});
			this.cnuNew.Name = "cnuNew";
			this.cnuNew.Size = new System.Drawing.Size(233, 76);
			// 
			// cnuNewN1
			// 
			this.cnuNewN1.Name = "cnuNewN1";
			this.cnuNewN1.Size = new System.Drawing.Size(229, 6);
			// 
			// cnuNewClear
			// 
			this.cnuNewClear.Name = "cnuNewClear";
			this.cnuNewClear.Size = new System.Drawing.Size(232, 22);
			this.cnuNewClear.Text = "Clear Issues";
			this.cnuNewClear.Click += new System.EventHandler(this.cnuNewClear_Click);
			// 
			// cnuNewMove
			// 
			this.cnuNewMove.Name = "cnuNewMove";
			this.cnuNewMove.Size = new System.Drawing.Size(232, 22);
			this.cnuNewMove.Text = "Move Issues to Search Results";
			this.cnuNewMove.Click += new System.EventHandler(this.cnuNewMove_Click);
			// 
			// cnuNewHide
			// 
			this.cnuNewHide.Name = "cnuNewHide";
			this.cnuNewHide.Size = new System.Drawing.Size(232, 22);
			this.cnuNewHide.Text = "Hide Section";
			this.cnuNewHide.Click += new System.EventHandler(this.cnuOptionsShowNew_Click);
			// 
			// pnlTop
			// 
			this.pnlTop.Controls.Add(this.lblParams);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Size = new System.Drawing.Size(782, 23);
			this.pnlTop.TabIndex = 0;
			this.pnlTop.Resize += new System.EventHandler(this.pnlTop_Resize);
			// 
			// lblParams
			// 
			this.lblParams.AutoSize = true;
			this.lblParams.Location = new System.Drawing.Point(4, 4);
			this.lblParams.Name = "lblParams";
			this.lblParams.Size = new System.Drawing.Size(79, 13);
			this.lblParams.TabIndex = 0;
			this.lblParams.Text = "Search Params";
			// 
			// cnuActions
			// 
			this.cnuActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cnuActionsStatusNew,
            this.cnuActionsStatusHold,
            this.cnuActionsStatusSpec,
            this.cnuActionsStatusDev,
            this.cnuActionsStatusPend,
            this.cnuActionsStatusTest,
            this.cnuActionsStatusApprove,
            this.cnuActionsStatusClose,
            this.cnuActionsStatusNoAction,
            this.cnuActionsN1,
            this.cnuActionsAddAttachment,
            this.cnuActionsAddNote,
            this.cnuActionsPriority,
            this.cnuActionsN2,
            this.cnuActionsEditIssue});
			this.cnuActions.Name = "cnuActions";
			this.cnuActions.Size = new System.Drawing.Size(314, 302);
			// 
			// cnuActionsStatusNew
			// 
			this.cnuActionsStatusNew.Name = "cnuActionsStatusNew";
			this.cnuActionsStatusNew.Size = new System.Drawing.Size(313, 22);
			this.cnuActionsStatusNew.Tag = "NEW";
			this.cnuActionsStatusNew.Text = "NEW - Default Status";
			this.cnuActionsStatusNew.ToolTipText = "Resets the issue to the very first (default) status";
			this.cnuActionsStatusNew.Click += new System.EventHandler(this.grdIssues_ActionClick);
			// 
			// cnuActionsStatusHold
			// 
			this.cnuActionsStatusHold.Name = "cnuActionsStatusHold";
			this.cnuActionsStatusHold.Size = new System.Drawing.Size(313, 22);
			this.cnuActionsStatusHold.Tag = "HOLD";
			this.cnuActionsStatusHold.Text = "HOLD - On Hold";
			this.cnuActionsStatusHold.ToolTipText = "Issue will not be worked or researched (until business/development resources beco" +
				"me available)";
			this.cnuActionsStatusHold.Click += new System.EventHandler(this.grdIssues_ActionClick);
			// 
			// cnuActionsStatusSpec
			// 
			this.cnuActionsStatusSpec.Name = "cnuActionsStatusSpec";
			this.cnuActionsStatusSpec.Size = new System.Drawing.Size(313, 22);
			this.cnuActionsStatusSpec.Tag = "SPEC";
			this.cnuActionsStatusSpec.Text = "SPEC - Specification";
			this.cnuActionsStatusSpec.ToolTipText = "Issue requires further discussion and/or I.T. requires input from the busine" +
				"ss (a spec document may be created)";
			this.cnuActionsStatusSpec.Click += new System.EventHandler(this.grdIssues_ActionClick);
			// 
			// cnuActionsStatusDev
			// 
			this.cnuActionsStatusDev.Name = "cnuActionsStatusDev";
			this.cnuActionsStatusDev.Size = new System.Drawing.Size(313, 22);
			this.cnuActionsStatusDev.Tag = "DEV";
			this.cnuActionsStatusDev.Text = "DEV - Development";
			this.cnuActionsStatusDev.ToolTipText = "Issue failed testing and/or I.T. input is required";
			this.cnuActionsStatusDev.Click += new System.EventHandler(this.grdIssues_ActionClick);
			// 
			// cnuActionsStatusPend
			// 
			this.cnuActionsStatusPend.Name = "cnuActionsStatusPend";
			this.cnuActionsStatusPend.Size = new System.Drawing.Size(313, 22);
			this.cnuActionsStatusPend.Tag = "PEND";
			this.cnuActionsStatusPend.Text = "PEND - Pending Release to Test";
			this.cnuActionsStatusPend.ToolTipText = "Development completed and issue is ready to be released to test environment";
			this.cnuActionsStatusPend.Click += new System.EventHandler(this.grdIssues_ActionClick);
			// 
			// cnuActionsStatusTest
			// 
			this.cnuActionsStatusTest.Name = "cnuActionsStatusTest";
			this.cnuActionsStatusTest.Size = new System.Drawing.Size(313, 22);
			this.cnuActionsStatusTest.Tag = "TEST";
			this.cnuActionsStatusTest.Text = "TEST - Available for Testing";
			this.cnuActionsStatusTest.ToolTipText = "Issue is available for testing";
			this.cnuActionsStatusTest.Click += new System.EventHandler(this.grdIssues_ActionClick);
			// 
			// cnuActionsStatusApprove
			// 
			this.cnuActionsStatusApprove.Name = "cnuActionsStatusApprove";
			this.cnuActionsStatusApprove.Size = new System.Drawing.Size(313, 22);
			this.cnuActionsStatusApprove.Tag = "APPROVED";
			this.cnuActionsStatusApprove.Text = "APPROVED - Pending Release to Production";
			this.cnuActionsStatusApprove.ToolTipText = "Testing was successful and the issue is pending release to production";
			this.cnuActionsStatusApprove.Click += new System.EventHandler(this.grdIssues_ActionClick);
			// 
			// cnuActionsStatusClose
			// 
			this.cnuActionsStatusClose.Name = "cnuActionsStatusClose";
			this.cnuActionsStatusClose.Size = new System.Drawing.Size(313, 22);
			this.cnuActionsStatusClose.Tag = "CLOSED";
			this.cnuActionsStatusClose.Text = "Close Issue";
			this.cnuActionsStatusClose.Click += new System.EventHandler(this.grdIssues_ActionClick);
			// 
			// cnuActionsStatusNoAction
			// 
			this.cnuActionsStatusNoAction.Enabled = false;
			this.cnuActionsStatusNoAction.Name = "cnuActionsStatusNoAction";
			this.cnuActionsStatusNoAction.Size = new System.Drawing.Size(313, 22);
			this.cnuActionsStatusNoAction.Text = "Status of this issue cannot be changed";
			// 
			// cnuActionsN1
			// 
			this.cnuActionsN1.Name = "cnuActionsN1";
			this.cnuActionsN1.Size = new System.Drawing.Size(310, 6);
			// 
			// cnuActionsAddAttachment
			// 
			this.cnuActionsAddAttachment.Name = "cnuActionsAddAttachment";
			this.cnuActionsAddAttachment.Size = new System.Drawing.Size(313, 22);
			this.cnuActionsAddAttachment.Tag = "ADDATTACH";
			this.cnuActionsAddAttachment.Text = "Add Attachment...";
			this.cnuActionsAddAttachment.Click += new System.EventHandler(this.grdIssues_ActionClick);
			// 
			// cnuActionsAddNote
			// 
			this.cnuActionsAddNote.Name = "cnuActionsAddNote";
			this.cnuActionsAddNote.Size = new System.Drawing.Size(313, 22);
			this.cnuActionsAddNote.Tag = "ADDNOTE";
			this.cnuActionsAddNote.Text = "&Add Note (without changing status)...";
			this.cnuActionsAddNote.ToolTipText = "Add more information to the issue but leave the issue in its current status";
			this.cnuActionsAddNote.Click += new System.EventHandler(this.grdIssues_ActionClick);
			// 
			// cnuActionsPriority
			// 
			this.cnuActionsPriority.Name = "cnuActionsPriority";
			this.cnuActionsPriority.Size = new System.Drawing.Size(313, 22);
			this.cnuActionsPriority.Tag = "PRIORITY";
			this.cnuActionsPriority.Text = "Set &Priority (Emergency, Data Fix, Due Date)...";
			this.cnuActionsPriority.ToolTipText = "Set issue priority by setting/changing the emergency flag, data fix flag, and/or " +
				"the due date";
			this.cnuActionsPriority.Click += new System.EventHandler(this.grdIssues_ActionClick);
			// 
			// cnuActionsN2
			// 
			this.cnuActionsN2.Name = "cnuActionsN2";
			this.cnuActionsN2.Size = new System.Drawing.Size(310, 6);
			// 
			// cnuActionsEditIssue
			// 
			this.cnuActionsEditIssue.Name = "cnuActionsEditIssue";
			this.cnuActionsEditIssue.Size = new System.Drawing.Size(313, 22);
			this.cnuActionsEditIssue.Text = "&Edit Issue";
			this.cnuActionsEditIssue.Click += new System.EventHandler(this.grdIssues_ActionClick);
			// 
			// frmSearchIssues
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 496);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.pnlTop);
			this.Controls.Add(this.sbrChild);
			this.Controls.Add(this.tbrMain);
			this.MergeToolbar = this.tbrMain;
			this.Name = "frmSearchIssues";
			this.Text = "Search Issues";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSearchIssues_FormClosed);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearchIssues_FormClosing);
			this.tbrMain.ResumeLayout(false);
			this.tbrMain.PerformLayout();
			this.sbrChild.ResumeLayout(false);
			this.sbrChild.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdIssues)).EndInit();
			this.pnlMain.Panel1.ResumeLayout(false);
			this.pnlMain.Panel2.ResumeLayout(false);
			this.pnlMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdNew)).EndInit();
			this.cnuNew.ResumeLayout(false);
			this.pnlTop.ResumeLayout(false);
			this.pnlTop.PerformLayout();
			this.cnuActions.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tbrMain;
		private System.Windows.Forms.ToolStripButton tbbSearch;
		private System.Windows.Forms.ToolStripButton tbbClose;
		private System.Windows.Forms.StatusStrip sbrChild;
		private System.Windows.Forms.ToolStripStatusLabel sbProgressCaption;
		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private System.Windows.Forms.ContextMenuStrip cnuAttachments;
		private System.Windows.Forms.ToolStripDropDownButton tbbOptions;
		private System.Windows.Forms.ToolStripSeparator cnuOptionsN1;
		private System.Windows.Forms.ToolStripSeparator cnuOptionsN2;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsRefresh;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsEmail;
		private System.Windows.Forms.ToolStripSeparator cnuOptionsN3;
		private CS2010.CommonWinCtrls.ucGridEx grdIssues;
		public CS2010.CommonWinCtrls.ucSplitContainer pnlMain;
		private CS2010.CommonWinCtrls.ucGridEx grdNew;
		private System.Windows.Forms.ContextMenuStrip cnuNew;
		private System.Windows.Forms.ToolStripMenuItem cnuNewClear;
		private System.Windows.Forms.ToolStripMenuItem cnuNewMove;
		private System.Windows.Forms.ToolStripMenuItem cnuNewHide;
		private System.Windows.Forms.ToolStripSeparator cnuNewN1;
		private CS2010.CommonWinCtrls.ucPanel pnlTop;
		private System.Windows.Forms.Label lblParams;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsIT;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsITDeveloper;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsShowNew;
		private System.Windows.Forms.ContextMenuStrip cnuActions;
		private System.Windows.Forms.ToolStripSeparator cnuOptionsITN1;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsITClearDeveloper;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsITDevNoteFlg;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsUpdateIssues;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsReleaseTest;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsReleaseProd;
		private System.Windows.Forms.ToolStripSeparator cnuOptionsITN2;
		private System.Windows.Forms.ToolStripSeparator cnuOptionsITN3;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsITNewReq;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsITDevAssist;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsITWip;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsCreate;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsITEmg;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsITReleaseFlag;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsITDataFix;
		private System.Windows.Forms.ToolStripSeparator cnuActionsN1;
		private System.Windows.Forms.ToolStripMenuItem cnuActionsPriority;
		private System.Windows.Forms.ToolStripMenuItem cnuActionsAddNote;
		private System.Windows.Forms.ToolStripSeparator cnuActionsN2;
		private System.Windows.Forms.ToolStripMenuItem cnuActionsEditIssue;
		private System.Windows.Forms.ToolStripMenuItem cnuActionsStatusNew;
		private System.Windows.Forms.ToolStripMenuItem cnuActionsStatusHold;
		private System.Windows.Forms.ToolStripMenuItem cnuActionsStatusSpec;
		private System.Windows.Forms.ToolStripMenuItem cnuActionsStatusDev;
		private System.Windows.Forms.ToolStripMenuItem cnuActionsStatusPend;
		private System.Windows.Forms.ToolStripMenuItem cnuActionsStatusTest;
		private System.Windows.Forms.ToolStripMenuItem cnuActionsStatusApprove;
		private System.Windows.Forms.ToolStripMenuItem cnuActionsStatusClose;
		private System.Windows.Forms.ToolStripMenuItem cnuActionsStatusNoAction;
		private System.Windows.Forms.ToolStripMenuItem cnuActionsAddAttachment;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsITSequence;
		private System.Windows.Forms.ToolStripSeparator cnuOptionsITN4;
	}
}