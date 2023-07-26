using System;
using System.Windows.Forms;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
    public partial class frmEditRichText: frmDialogBase
    {
        #region constructor

        public frmEditRichText()
        {
           InitializeComponent();
        }

        #endregion

        #region fields

        private bool m_bWordWrap = true;

        #endregion

		#region Properties

		public string RtfText
		{
			get { return m_richTextBox.Rtf; }
		}

		public string PlainText
		{
			get { return m_richTextBox.Text; }
		}
		#endregion		// #region Properties

        #region publicMethods

        public bool EditText(ref string strText)
        {
			try
			{
				m_richTextBox.Rtf = strText;
                DialogResult dr = ShowDialog();
                if (dr == DialogResult.OK)
                {
                    strText = m_richTextBox.Rtf;
                    return true;
                }
                return false;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Text Editor", ex);
			}
        }

		public bool EditPlainText(string strText)
		{
			try
			{
				m_richTextBox.Text = strText;
				return ( ShowDialog() == DialogResult.OK );
			}
			catch( Exception ex )
			{
				return Display.ShowError("Text Editor", ex);
			}
		}
		#endregion

        #region HelperMethods
        private void OnClickUndo(object sender, EventArgs e)
        {
            m_richTextBox.Undo();
        }

        private void OnClickEditRedo(object sender, EventArgs e)
        {
            m_richTextBox.Redo();

        }

        private void OnClickEditCut(object sender, EventArgs e)
        {
            m_richTextBox.Cut();
        }

        private void OnClickEditCopy(object sender, EventArgs e)
        {
            m_richTextBox.Copy();
        }

        private void OnClickEditPaste(object sender, EventArgs e)
        {
            /*	Copy Text or Bitmap data from clipboard	*/
            IDataObject l_objClipboard = Clipboard.GetDataObject();
            if (l_objClipboard.GetDataPresent(DataFormats.Bitmap) == true)
            {
                m_richTextBox.Paste(DataFormats.GetFormat(DataFormats.Bitmap));
            }
            else if (l_objClipboard.GetDataPresent(DataFormats.Text) == true)
            {
                m_richTextBox.Paste(DataFormats.GetFormat(DataFormats.Text));
            }
            else if (l_objClipboard.GetDataPresent(DataFormats.Dib) == true)
            {
                m_richTextBox.Paste(DataFormats.GetFormat(DataFormats.Dib));
            }

        }

        private void OnClickEditSelectAll(object sender, EventArgs e)
        {
            m_richTextBox.SelectAll();
        }


        private void OnClickEditFont(object sender, EventArgs e)
        {
            if (m_fontDialog.ShowDialog() == DialogResult.OK)
            {
                m_richTextBox.SelectionFont = m_fontDialog.Font;
            }

        }

        private void OnClickWordWrap(object sender, EventArgs e)
        {
            m_richTextBox.WordWrap = m_bWordWrap;
            m_bWordWrap = !m_bWordWrap;
            IDM_FORMATWORDWRAP.Checked = m_bWordWrap;
        }

        private void OnClickIndent(object sender, EventArgs e)
        {
            m_richTextBox.SelectionIndent = m_richTextBox.SelectionIndent + 30;

        }

        private void OnClickUnindent(object sender, EventArgs e)
        {
            m_richTextBox.SelectionIndent = m_richTextBox.SelectionIndent - 30;

        }

        private void OnClickBullet(object sender, EventArgs e)
        {
            m_richTextBox.SelectionBullet = !m_richTextBox.SelectionBullet;
            IDM_Bullet.Checked = !IDM_Bullet.Checked;
        }

        private void OnClickLeftAllign(object sender, EventArgs e)
        {
            m_richTextBox.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void OnClickCenterAllign(object sender, EventArgs e)
        {
            m_richTextBox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void OnClickRightAllign(object sender, EventArgs e)
        {
            m_richTextBox.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void OnClickColor(object sender, EventArgs e)
        {
            if (m_colorDialog.ShowDialog() == DialogResult.OK)
            {
                m_richTextBox.SelectionColor = m_colorDialog.Color;
            }
        }

        private void OnClickPrint(object sender, EventArgs e)
        {
            this.printForm();
        }
        protected bool printForm()
        {
			string docName = "RTF_Editor_Temp_Window";
			pdSelect.PrinterSettings.PrinterName = ClsEnvironment.GetLastPrinter(docName);
            DialogResult result = pdSelect.ShowDialog();
            if (result == DialogResult.OK)
            {
                printRichText.Print();
				ClsEnvironment.UpdateLastPrinter(docName, pdSelect.PrinterSettings.PrinterName);
                return true;
            }
            return false;
        }

        #endregion

        #region EventHandlers
        private void onToolBarClick(object sender, ToolBarButtonClickEventArgs e)
        {
            int l_iImageIndex = e.Button.ImageIndex;
            if (l_iImageIndex == 0)
            {
                OnClickEditFont(sender, e);
            }
            else if (l_iImageIndex == 1)
            {
               OnClickBullet(sender, e);
            }
            else if (l_iImageIndex == 2)
            {
                OnClickLeftAllign(sender, e);
            }
            else if (l_iImageIndex == 3)
            {
                OnClickCenterAllign(sender, e);
            }
            else if (l_iImageIndex == 4)
            {
                OnClickRightAllign(sender, e);
            }
            else if (l_iImageIndex == 8)
            {
                OnClickPrint(sender, e);
            }
        }

        private void m_toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            this.onToolBarClick(sender, e);
        }
        #endregion

        private void m_richTextBox_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }



        #region OverrideMethods

        #endregion




               
    }
    }