namespace CS2010.CommonWinCtrls
{
    partial class ucSearchContainer
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PictureBox = new CS2010.CommonWinCtrls.ucPictureBox();
            this.btnClear = new CS2010.CommonWinCtrls.ucButton();
            this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.BackColor = System.Drawing.SystemColors.Highlight;
            this.PictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.PictureBox.Location = new System.Drawing.Point(0, 0);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(192, 50);
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(90, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(10, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ucSearchContainer
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name = "SplitContainer";
            // 
            // 
            // 
            this.Panel1.Controls.Add(this.btnSearch);
            this.Panel1.Controls.Add(this.btnClear);
            this.Panel1.Controls.Add(this.PictureBox);
            this.Panel1MinSize = 1;
            this.Size = new System.Drawing.Size(477, 415);
            this.SplitterDistance = 194;
            this.SplitterWidth = 10;
            this.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SearchContainer_SplitterMoved);
            this.DoubleClick += new System.EventHandler(this.SearchContainer_DoubleClick);
            this.Resize += new System.EventHandler(this.SearchContainer_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonWinCtrls.ucButton btnSearch;
        private CommonWinCtrls.ucButton btnClear;
        private CommonWinCtrls.ucPictureBox PictureBox;

    }
}
