using System;
using System.Text;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ITrack.Business;

namespace ASL.ITrack.WinCtrls
{
	public partial class frmCreateIssue : Form
	{
		#region Fields

		protected ClsIssue theIssue;

		#endregion		// #region Fields

		#region Internal Properties

		private string IssueTitle
		{
			get
			{
				StringBuilder sb = new StringBuilder(txtDesc.Text);
				sb.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ");
				if( sb.Length > 30 ) sb.Length = 30;
				return sb.ToString();
			}
		}
		#endregion		// #region Internal Properties

		#region Constructors

		public frmCreateIssue()
		{
			InitializeComponent();
		}
		#endregion		// #region Constructors		

		#region Public Methods

		public ClsIssue CreateIssue()
		{
			try
			{
				theIssue = new ClsIssue();
				theIssue.SetDefaults();

				chkEmergency.Visible = ClsConvert.YNToBool(ClsUser.CurrentUser.Admin_Flg);
				if( ClsEnvironment.IsDeveloper ) cmbBizOwner.Visible = true;

				return (ShowDialog() == DialogResult.OK) ? theIssue : null;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
				return null;
			}
		}
		#endregion		// #region Public Methods

		#region Event Handlers

		private void frmCreateIssue_Load(object sender, EventArgs e)
		{
			try
			{
				BindHelper.Bind(cmbProject, theIssue, "Project_Cd");
				BindHelper.Bind(chkDataFix, theIssue, "Data_Fix_Flg");
				BindHelper.Bind(chkEmergency, theIssue, "Emg_Flg");
				BindHelper.Bind(cmbBizOwner, theIssue, "Biz_Owner_Login");

				MinimumSize = new System.Drawing.Size(600, 200);

				string s = ClsUser.GetDevelopers();
				cmbBizOwner.Filter = string.Format("USER_LOGIN NOT IN ({0})", s);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void rdoReproduceYes_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if( rdoReproduceYes.Checked )
					Display.Show("I-Track",
						"Please specify how the problem can be reproduced as part of the description");
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void chkEmergency_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if( chkEmergency.Checked )
				{
					if( !Display.Ask("Confirm Emergency", ClsIssue.EmgWarningQuestion) )
						chkEmergency.Checked = false;
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				if( !SaveChanges() ) return;

				DialogResult = DialogResult.OK;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Event Handlers

		#region Save Methods

		public bool SaveChanges()
		{
			try
			{
				string title = IssueTitle;
				theIssue.Issue_Dsc = (title != null) ? title.ToUpper() : title;

				if( !rdoReproduceNo.Checked && !rdoReproduceYes.Checked && !rdoNA.Checked )
					return Display.ShowError("I-Track", "Please select whether the problem can be reproduced or not");

				if( !theIssue.ValidateInsert() ) return Display.ShowError("I-Track", theIssue.Error);

				string firstNote = txtDesc.Text.Trim();
				if( string.IsNullOrEmpty(firstNote) )
					return Display.ShowError("I-Track", "Must provide a description of the issue");

				if( firstNote.Length < 20 )
					return Display.ShowError("I-Track", "Must provide a more detailed description of the issue");

				if( ClsEnvironment.IsDeveloper )
				{
					if( string.IsNullOrEmpty(theIssue.Biz_Owner_Login) )
						return Display.ShowError("I-Track", "Must specifiy the business owner");
					ClsUser usr = ClsUser.GetUsingLogin(theIssue.Biz_Owner_Login);
					if( usr != null && usr.Def_Category_Cd != null )
						theIssue.Category_Cd = usr.Def_Category_Cd;
				}

				ClsEmail em = new ClsEmail();
				if( !HandleEmail(em) ) return false;

				theIssue.AddNewIssue(firstNote);

				AttemptSendEmail(em);

				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("I-Track", ex);
			}
		}

		private bool HandleEmail(ClsEmail em)
		{
			try
			{
				string line = new string('-', 132);
				string issTitle = IssueTitle;

				em.From = ClsUser.CurrentUser.Email.ToLower();
				// use app.config server em.SMTPServer = "172.16.1.3";

				StringBuilder sbBody = new StringBuilder();
				if( !chkEmergency.Checked )
				{
					if( ClsEnvironment.IsDeveloper ) return true;

					bool emailDev = ClsITrackConfig.EmailDevNew;
					bool emailBiz = ClsITrackConfig.EmailBizNew;
					if( !emailBiz && !emailDev ) return true;

					if( emailDev ) em.AddTo(ClsITrackConfig.DevDistributionList);
					if( emailBiz ) em.AddTo(ClsUser.CurrentUser.Email.ToLower());

					em.Subject = string.Format("ITrack Issue Added: {0}", issTitle);

					StringBuilder sb = new StringBuilder();
					sb.AppendFormat
						("{0} {1}: NEW ISSUE ADDED (see description below)\r\n{2}\r\n{3}\r\n",
						theIssue.Project_Cd,
						(theIssue.Category != null ? theIssue.Category.Category_Nm : theIssue.Category_Cd),
						line, txtDesc.Text);
					em.Body = sb.ToString();

					return true;
				}
				else
				{
					if( !ClsITrackConfig.EmailEmg ) return true;

					em.To = ClsITrackConfig.EmgDistributionList.ToLower();
					if( !em.To.Contains(ClsUser.CurrentUser.Email.ToLower()) )
						em.CC = ClsUser.CurrentUser.Email.ToLower();
					em.Subject = string.Format("ITrack Emergency Issue Added: {0}", issTitle);

					StringBuilder sb = new StringBuilder(ClsIssue.EmgEmailIntro);
					sb.AppendFormat
						("\r\n\r\n{0} {1}: NEW ISSUE ADDED (see description below)\r\n{2}\r\n{3}\r\n",
						theIssue.Project_Cd,
						(theIssue.Category != null ? theIssue.Category.Category_Nm : theIssue.Category_Cd),
						line, txtDesc.Text);

					em.Body = sb.ToString();

					using( frmEmail f = new frmEmail() )
					{
						f.EmailAddresses = ClsUser.GetEmailList();
						f.UpperCaseTextBoxes = false;
						if( !f.ShowEmail(em, true, true) ) return false;
					}
				}
				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("I-Track", ex);
			}
		}

		private void AttemptSendEmail(ClsEmail em)
		{
			try
			{
				if( ClsEnvironment.IsDeveloper ) return;

				if( chkEmergency.Checked )
				{
					if( ClsITrackConfig.EmailEmg ) em.SendMail();
				}
				else
				{
					if( ClsITrackConfig.EmailDevNew || ClsITrackConfig.EmailBizNew )
						em.SendMail();
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Save Methods
	}
}
