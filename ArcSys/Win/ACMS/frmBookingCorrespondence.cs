using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.ACMS.Business;
using CS2010.Common;
using CS2010.CommonWinCtrls;

namespace CS2010.ArcSys.Win
{
	public partial class frmBookingCorrespondence : CS2010.CommonWinCtrls.frmDialogBase
	{
		public frmBookingCorrespondence()
		{
			InitializeComponent();
		}
		protected ClsBookingCorrespondence theItem;
		protected ClsBookingRequest theRequest;
		private bool UseCorrText;

		public bool AddCorrespondence(ClsBookingRequest request)
		{
			return AddCorrespondence(request, "M");
		}
		public bool AddCorrespondence(ClsBookingRequest request, string sType)
		{
			try
			{
				theRequest = request;
				SetDropdowns();
				theItem = new ClsBookingCorrespondence();
				theItem.Partner_Cd = request.Partner_Cd;
				theItem.Partner_Request_Cd = request.Partner_Request_Cd;
				theItem.Corr_Dt = DateTime.Now;
				theItem.Corr_User = ClsEnvironment.UserName;
				theItem.Corr_Cd = sType;
				BindObject();
				SetEmailVisibility(false);
				return ShowDialog() == DialogResult.OK;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				Program.ShowError(ex);
				return false;
			}
		}
		public bool ShowCorrespondence(ClsBookingCorrespondence corr)
		{
			theItem = corr;
			SetDropdowns();
			BindObject();
			if (theItem.Corr_Cd == "EO")
				SetEmailVisibility(true);
			else
				SetEmailVisibility(false);

			try
			{
				return ShowDialog() == DialogResult.OK;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return false;
			}
		}


		void SetDropdowns()
		{
			cmbType.DataSource = ClsCorrespondenceType.GetAll(true);
			DataTable dtEmailList = ClsPartnerEmailList.GetAll();
			cmbEmailList.DataSource = dtEmailList;
		}

		protected void BindObject()
		{
			try
			{
				BindHelper.Bind(txtCorrDate, theItem, "Corr_Dt");
				BindHelper.Bind(cmbType, theItem, "Corr_Cd");
				BindHelper.Bind(txtUser, theItem, "Corr_User");
				BindHelper.Bind(txtEmailFrom, theItem, "Email_From");
				BindHelper.Bind(txtTo, theItem, "Email_To");
				// If there is something in corr_text bind to it, otherwise use corr_textlong
				if (!string.IsNullOrWhiteSpace(theItem.Corr_Text))
				{
					BindHelper.Bind(txtEdit, theItem, "Corr_Text");
					UseCorrText = true;
				}
				else
				{
					BindHelper.Bind(txtEdit, theItem, "Corr_Textlong");
					UseCorrText = false;
				}
				//txtEdit.Value = theItem.Corr_Text;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		protected void GetEmails()
		{
			DataRowView dv = (DataRowView)cmbEmailList.SelectedItem;
			string sList = dv.Row["email_list_cd"].ToString();

			DataTable dt = ClsPartnerEmail.GetEmailList(sList);
			grdEmails.DataSource = dt;
		}

		protected override bool SaveChanges()
		{
			try
			{
				string txt = (UseCorrText) ? theItem.Corr_Text : theItem.Corr_Textlong;
				if (txt == null || txt.Length < 2)
				{
					Program.Show("You must enter something in the text area.");
					return false;
				}
				if (theItem.Corr_Cd == "EO")
				{
					if (grdEmails.GetSelectedDataRowList().Count < 1)
					{
						Program.Show("You must select at least one email address");
						return false;
					}
					if (!SendAnEmail())
						return false;
				}
				theItem.Corr_User = ClsEnvironment.UserName;
				if (theItem.Corr_ID != null)
				{
					if (!theItem.ValidateUpdate())
						throw new Exception(theItem.Error);
					theItem.Update();
				}
				else
				{
					if (!theItem.ValidateInsert())
						throw new Exception(theItem.Error);
					theItem.Corr_ID = ClsBookingCorrespondence.NextID();
					theItem.Insert();
				}
				if (theItem.Corr_Cd == "N")
					if (theItem.Corr_Textlong.IsNotNull())
					{
						if (theItem.Corr_Textlong.Length > 600)
							Program.Show("Warning: Only the first 600 characters of this message will be sent as confirmation notes");
					}

				return true;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return false;
			}
		}

		protected bool SendAnEmail()
		{
			theItem.Email_To = "";
			ClsEmail email = new ClsEmail();
			email.From = theItem.Email_From = "acms@amslgroup.com";
			email.Subject = "ACMS Re: PCFN " + theItem.Partner_Request_Cd;
			email.Body = (UseCorrText) ? theItem.Corr_Text : theItem.Corr_Textlong;
			DataRow[] eList = grdEmails.GetCheckedDataRows();
			foreach (DataRow drow in eList)
			{
				string sAddr = drow["outlook_email"].ToString();
				email.AddTo(sAddr);
				theItem.Email_To = theItem.Email_To + ";" + sAddr;
			}
			email.SendMail();
			theItem.Email_Sent = "Y";
			return true;
		}

		protected void SetEmailVisibility(bool bVisible)
		{
			if (bVisible)
			{
				splitMain.Panel2Collapsed = false;
				txtTo.Visible = true;
				txtEmailFrom.Visible = true;
			}
			else
			{
				splitMain.Panel2Collapsed = true;
				txtTo.Visible = false;
				txtEmailFrom.Visible = false;

			}

		}

		private void cmbEmailList_TextChanged(object sender, EventArgs e)
		{
			GetEmails();
		}

		private void cmbType_ValueChanged(object sender, EventArgs e)
		{
			// Set objects on or off depending upon whether or not this is an email out
			if (cmbType.SelectedIndex < 0)
				return;
			DataRowView dv = (DataRowView)cmbType.SelectedItem;
			string sCode = dv.Row["corr_cd"].ToString();
			if (sCode == "EO")
				SetEmailVisibility(true);
			else
				SetEmailVisibility(false);
		}


	}
}
