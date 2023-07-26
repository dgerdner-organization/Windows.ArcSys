namespace CS2010.CommonWinCtrls
{
    partial class frmEditRichText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditRichText));
            TMGDevelopment.Windows.Forms.BorderStyle borderStyle1 = new TMGDevelopment.Windows.Forms.BorderStyle();
            TMGDevelopment.Windows.Forms.LineStyle lineStyle1 = new TMGDevelopment.Windows.Forms.LineStyle();
            TMGDevelopment.Windows.Forms.LineStyle lineStyle2 = new TMGDevelopment.Windows.Forms.LineStyle();
            TMGDevelopment.Windows.Forms.LineStyle lineStyle3 = new TMGDevelopment.Windows.Forms.LineStyle();
            TMGDevelopment.Windows.Forms.LineStyle lineStyle4 = new TMGDevelopment.Windows.Forms.LineStyle();
            TMGDevelopment.Windows.Forms.LineStyle lineStyle5 = new TMGDevelopment.Windows.Forms.LineStyle();
            TMGDevelopment.Windows.Forms.LineStyle lineStyle6 = new TMGDevelopment.Windows.Forms.LineStyle();
            TMGDevelopment.Windows.Forms.LineStyle lineStyle7 = new TMGDevelopment.Windows.Forms.LineStyle();
            TMGDevelopment.Windows.Forms.LineStyle lineStyle8 = new TMGDevelopment.Windows.Forms.LineStyle();
            this.m_mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.IDM_EDITUNDO = new System.Windows.Forms.MenuItem();
            this.IDM_EDITREDO = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.IDM_EDITCUT = new System.Windows.Forms.MenuItem();
            this.IDM_EDITCOPY = new System.Windows.Forms.MenuItem();
            this.IDM_EDITPASTE = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.IDM_EDITSELECTALL = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.IDM_FORMATFONT = new System.Windows.Forms.MenuItem();
            this.IDM_FORMATWORDWRAP = new System.Windows.Forms.MenuItem();
            this.IDM_Indent = new System.Windows.Forms.MenuItem();
            this.IDM_Unindent = new System.Windows.Forms.MenuItem();
            this.IDM_Bullet = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.IDM_LeftAllign = new System.Windows.Forms.MenuItem();
            this.IDM_CenterAllign = new System.Windows.Forms.MenuItem();
            this.IMD_RightAllign = new System.Windows.Forms.MenuItem();
            this.IDM_Color = new System.Windows.Forms.MenuItem();
            this.m_colorDialog = new System.Windows.Forms.ColorDialog();
            this.m_fontDialog = new System.Windows.Forms.FontDialog();
            this.m_imageListToolBar = new System.Windows.Forms.ImageList(this.components);
            this.m_toolBar = new System.Windows.Forms.ToolBar();
            this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
            this.toolBarBullet = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
            this.toolBarCenter = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.m_richTextBox = new System.Windows.Forms.RichTextBox();
            this.pdSelect = new System.Windows.Forms.PrintDialog();
            this.printRichText = new TMGDevelopment.Windows.Forms.PrintRichTextBox(this.components);
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(562, 438);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(650, 438);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(472, 438);
            this.btnApply.TabStop = true;
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Visible = true;
            // 
            // m_mainMenu
            // 
            this.m_mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem11,
            this.menuItem9});
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 0;
            this.menuItem11.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.IDM_EDITUNDO,
            this.IDM_EDITREDO,
            this.menuItem14,
            this.IDM_EDITCUT,
            this.IDM_EDITCOPY,
            this.IDM_EDITPASTE,
            this.menuItem20,
            this.IDM_EDITSELECTALL});
            this.menuItem11.Text = "&Edit";
            // 
            // IDM_EDITUNDO
            // 
            this.IDM_EDITUNDO.Index = 0;
            this.IDM_EDITUNDO.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.IDM_EDITUNDO.Text = "&Undo";
            this.IDM_EDITUNDO.Click += new System.EventHandler(this.OnClickUndo);
            // 
            // IDM_EDITREDO
            // 
            this.IDM_EDITREDO.Index = 1;
            this.IDM_EDITREDO.Shortcut = System.Windows.Forms.Shortcut.CtrlY;
            this.IDM_EDITREDO.Text = "&Redo";
            this.IDM_EDITREDO.Click += new System.EventHandler(this.OnClickEditRedo);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 2;
            this.menuItem14.Text = "-";
            // 
            // IDM_EDITCUT
            // 
            this.IDM_EDITCUT.Index = 3;
            this.IDM_EDITCUT.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.IDM_EDITCUT.Text = "Cut";
            this.IDM_EDITCUT.Click += new System.EventHandler(this.OnClickEditCut);
            // 
            // IDM_EDITCOPY
            // 
            this.IDM_EDITCOPY.Index = 4;
            this.IDM_EDITCOPY.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.IDM_EDITCOPY.Text = "Copy";
            this.IDM_EDITCOPY.Click += new System.EventHandler(this.OnClickEditCopy);
            // 
            // IDM_EDITPASTE
            // 
            this.IDM_EDITPASTE.Index = 5;
            this.IDM_EDITPASTE.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.IDM_EDITPASTE.Text = "Paste";
            this.IDM_EDITPASTE.Click += new System.EventHandler(this.OnClickEditPaste);
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 6;
            this.menuItem20.Text = "-";
            // 
            // IDM_EDITSELECTALL
            // 
            this.IDM_EDITSELECTALL.Index = 7;
            this.IDM_EDITSELECTALL.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
            this.IDM_EDITSELECTALL.Text = "Select All";
            this.IDM_EDITSELECTALL.Click += new System.EventHandler(this.OnClickEditSelectAll);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 1;
            this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.IDM_FORMATFONT,
            this.IDM_FORMATWORDWRAP,
            this.IDM_Indent,
            this.IDM_Unindent,
            this.IDM_Bullet,
            this.menuItem1,
            this.IDM_Color});
            this.menuItem9.Text = "F&ormat";
            // 
            // IDM_FORMATFONT
            // 
            this.IDM_FORMATFONT.Index = 0;
            this.IDM_FORMATFONT.Text = "Fo&nt";
            this.IDM_FORMATFONT.Click += new System.EventHandler(this.OnClickEditFont);
            // 
            // IDM_FORMATWORDWRAP
            // 
            this.IDM_FORMATWORDWRAP.Checked = true;
            this.IDM_FORMATWORDWRAP.Index = 1;
            this.IDM_FORMATWORDWRAP.RadioCheck = true;
            this.IDM_FORMATWORDWRAP.Text = "Word Wrap";
            this.IDM_FORMATWORDWRAP.Click += new System.EventHandler(this.OnClickWordWrap);
            // 
            // IDM_Indent
            // 
            this.IDM_Indent.Index = 2;
            this.IDM_Indent.Text = "Indent";
            this.IDM_Indent.Click += new System.EventHandler(this.OnClickIndent);
            // 
            // IDM_Unindent
            // 
            this.IDM_Unindent.Index = 3;
            this.IDM_Unindent.Text = "Unindent";
            this.IDM_Unindent.Click += new System.EventHandler(this.OnClickUnindent);
            // 
            // IDM_Bullet
            // 
            this.IDM_Bullet.Index = 4;
            this.IDM_Bullet.RadioCheck = true;
            this.IDM_Bullet.Text = "Bullet";
            this.IDM_Bullet.Click += new System.EventHandler(this.OnClickBullet);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 5;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.IDM_LeftAllign,
            this.IDM_CenterAllign,
            this.IMD_RightAllign});
            this.menuItem1.Text = "Allignment";
            // 
            // IDM_LeftAllign
            // 
            this.IDM_LeftAllign.Index = 0;
            this.IDM_LeftAllign.Text = "Left";
            this.IDM_LeftAllign.Click += new System.EventHandler(this.OnClickLeftAllign);
            // 
            // IDM_CenterAllign
            // 
            this.IDM_CenterAllign.Index = 1;
            this.IDM_CenterAllign.Text = "Center";
            this.IDM_CenterAllign.Click += new System.EventHandler(this.OnClickCenterAllign);
            // 
            // IMD_RightAllign
            // 
            this.IMD_RightAllign.Index = 2;
            this.IMD_RightAllign.Text = "Right";
            this.IMD_RightAllign.Click += new System.EventHandler(this.OnClickRightAllign);
            // 
            // IDM_Color
            // 
            this.IDM_Color.Index = 6;
            this.IDM_Color.Text = "Color";
            this.IDM_Color.Click += new System.EventHandler(this.OnClickColor);
            // 
            // m_imageListToolBar
            // 
            this.m_imageListToolBar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imageListToolBar.ImageStream")));
            this.m_imageListToolBar.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imageListToolBar.Images.SetKeyName(0, "");
            this.m_imageListToolBar.Images.SetKeyName(1, "");
            this.m_imageListToolBar.Images.SetKeyName(2, "");
            this.m_imageListToolBar.Images.SetKeyName(3, "");
            this.m_imageListToolBar.Images.SetKeyName(4, "");
            this.m_imageListToolBar.Images.SetKeyName(5, "");
            this.m_imageListToolBar.Images.SetKeyName(6, "");
            this.m_imageListToolBar.Images.SetKeyName(7, "");
            this.m_imageListToolBar.Images.SetKeyName(8, "FilePrint.bmp");
            // 
            // m_toolBar
            // 
            this.m_toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButton7,
            this.toolBarBullet,
            this.toolBarButton6,
            this.toolBarCenter,
            this.toolBarButton1,
            this.toolBarButton2,
            this.toolBarButton3});
            this.m_toolBar.DropDownArrows = true;
            this.m_toolBar.ImageList = this.m_imageListToolBar;
            this.m_toolBar.Location = new System.Drawing.Point(0, 0);
            this.m_toolBar.Name = "m_toolBar";
            this.m_toolBar.ShowToolTips = true;
            this.m_toolBar.Size = new System.Drawing.Size(754, 28);
            this.m_toolBar.TabIndex = 3;
            this.m_toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.m_toolBar_ButtonClick);
            // 
            // toolBarButton7
            // 
            this.toolBarButton7.ImageIndex = 0;
            this.toolBarButton7.Name = "toolBarButton7";
            this.toolBarButton7.ToolTipText = "Select Font and Style settings";
            // 
            // toolBarBullet
            // 
            this.toolBarBullet.ImageIndex = 1;
            this.toolBarBullet.Name = "toolBarBullet";
            this.toolBarBullet.ToolTipText = "Bullet List";
            // 
            // toolBarButton6
            // 
            this.toolBarButton6.ImageIndex = 2;
            this.toolBarButton6.Name = "toolBarButton6";
            this.toolBarButton6.ToolTipText = "Left Allign";
            // 
            // toolBarCenter
            // 
            this.toolBarCenter.ImageIndex = 3;
            this.toolBarCenter.Name = "toolBarCenter";
            this.toolBarCenter.ToolTipText = "Center Allign";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ImageIndex = 4;
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.ToolTipText = "Right Allign selected text";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.ImageIndex = 8;
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.ToolTipText = "Print Form";
            // 
            // m_richTextBox
            // 
            this.m_richTextBox.AcceptsTab = true;
            this.m_richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_richTextBox.AutoSize = true;
            this.m_richTextBox.BulletIndent = 30;
            this.m_richTextBox.Font = new System.Drawing.Font("Tahoma", 10F);
            this.m_richTextBox.Location = new System.Drawing.Point(0, 55);
            this.m_richTextBox.Name = "m_richTextBox";
            this.m_richTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.m_richTextBox.ShowSelectionMargin = true;
            this.m_richTextBox.Size = new System.Drawing.Size(742, 377);
            this.m_richTextBox.TabIndex = 4;
            this.m_richTextBox.Text = "";
            this.m_richTextBox.TextChanged += new System.EventHandler(this.m_richTextBox_TextChanged);
            // 
            // pdSelect
            // 
            this.pdSelect.AllowPrintToFile = false;
            this.pdSelect.Document = this.printRichText;
            this.pdSelect.ShowNetwork = false;
            // 
            // printRichText
            // 
            lineStyle1.Color = System.Drawing.Color.White;
            borderStyle1.BottomLeftCorner = new TMGDevelopment.Windows.Forms.CornerStyle(new System.Drawing.Size(10, 10), TMGDevelopment.Windows.Forms.CornerType.Normal, lineStyle1);
            lineStyle2.Color = System.Drawing.Color.White;
            borderStyle1.BottomLine = lineStyle2;
            borderStyle1.BottomRightCorner = new TMGDevelopment.Windows.Forms.CornerStyle(new System.Drawing.Size(10, 10), TMGDevelopment.Windows.Forms.CornerType.Normal, lineStyle3);
            lineStyle4.Color = System.Drawing.Color.White;
            borderStyle1.LeftLine = lineStyle4;
            lineStyle5.Color = System.Drawing.Color.White;
            borderStyle1.RightLine = lineStyle5;
            borderStyle1.TopLeftCorner = new TMGDevelopment.Windows.Forms.CornerStyle(new System.Drawing.Size(10, 10), TMGDevelopment.Windows.Forms.CornerType.Normal, lineStyle6);
            lineStyle7.Color = System.Drawing.Color.White;
            borderStyle1.TopLine = lineStyle7;
            lineStyle8.Color = System.Drawing.Color.White;
            borderStyle1.TopRightCorner = new TMGDevelopment.Windows.Forms.CornerStyle(new System.Drawing.Size(10, 10), TMGDevelopment.Windows.Forms.CornerType.Normal, lineStyle8);
            this.printRichText.BorderStyles = borderStyle1;
            this.printRichText.RichTextBoxControl = this.m_richTextBox;
            // 
            // frmEditRichText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 494);
            this.ControlBox = true;
            this.Controls.Add(this.m_toolBar);
            this.Controls.Add(this.m_richTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Menu = this.m_mainMenu;
            this.Name = "frmEditRichText";
            this.Text = "Add/Edit Form Template";
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.m_richTextBox, 0);
            this.Controls.SetChildIndex(this.btnApply, 0);
            this.Controls.SetChildIndex(this.m_toolBar, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem IDM_EDITUNDO;
        private System.Windows.Forms.MenuItem IDM_EDITREDO;
        private System.Windows.Forms.MenuItem menuItem14;
        private System.Windows.Forms.MenuItem IDM_EDITCUT;
        private System.Windows.Forms.MenuItem IDM_EDITCOPY;
        private System.Windows.Forms.MenuItem IDM_EDITPASTE;
        private System.Windows.Forms.MenuItem menuItem20;
        private System.Windows.Forms.MenuItem IDM_EDITSELECTALL;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem IDM_FORMATFONT;
        private System.Windows.Forms.MenuItem IDM_FORMATWORDWRAP;
        private System.Windows.Forms.MenuItem IDM_Indent;
        private System.Windows.Forms.MenuItem IDM_Unindent;
        private System.Windows.Forms.MenuItem IDM_Bullet;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem IDM_LeftAllign;
        private System.Windows.Forms.MenuItem IDM_CenterAllign;
        private System.Windows.Forms.MenuItem IMD_RightAllign;
        private System.Windows.Forms.MenuItem IDM_Color;
        private System.Windows.Forms.ToolBarButton toolBarBullet;
        private System.Windows.Forms.ToolBarButton toolBarCenter;
        private System.Windows.Forms.ToolBarButton toolBarButton7;
        //private System.Windows.Forms.ToolBarButton toolBarRight;
        //private System.Windows.Forms.ToolBarButton toolBarLeft;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        //private System.Windows.Forms.ToolBarButton toolBarPrint;
        protected System.Windows.Forms.MainMenu m_mainMenu;
        protected System.Windows.Forms.ColorDialog m_colorDialog;
        protected System.Windows.Forms.FontDialog m_fontDialog;
        protected System.Windows.Forms.ImageList m_imageListToolBar;
        protected System.Windows.Forms.ToolBar m_toolBar;
        protected System.Windows.Forms.RichTextBox m_richTextBox;
        private System.Windows.Forms.ToolBarButton toolBarButton6;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton toolBarButton3;
        private System.Windows.Forms.PrintDialog pdSelect;
        public TMGDevelopment.Windows.Forms.PrintRichTextBox printRichText;
    }
}