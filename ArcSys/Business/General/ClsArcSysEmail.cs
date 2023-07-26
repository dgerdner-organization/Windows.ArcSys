using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public class ClsArcSysEmail
	{
		// Contains common settings that can be used for emails throughout 
		// any ArcSys application
		//private string _SMTP = "172.16.1.3";
		private string _SMTP = "relay.appriver.com";
		private string _From = "ACMS@wlhinet.com";
		private List<string> _To = new List<string>();
		private List<string> _ErrorTo = new List<string>();
		private string _Subect = "ArcSys Email Notification";

		public string Subject
		{
			get { return _Subect; }
			set { _Subect = value; }
		}

		public void AddTo(string sTo)
		{
			_To.Add(sTo);
		}
		public void AddErrorTo(string sTo)
		{
			_ErrorTo.Add(sTo);
		}
		public void SendEmail(string sMsg)
		{
			SendEmail(sMsg, true);
		}

		public void SendEmail(string sMsg, bool bSuccess)
		{
			ClsEmail objMail = new ClsEmail();
			objMail.SMTPServer = _SMTP;
			objMail.From = _From;
			this.AddTo("dgerdner@amslgroup.com");
			this.AddErrorTo("dgerdner@amslgroup.com");
		
			foreach (string s in _To)
			{
				objMail.AddTo(s);
			}
			foreach (string s in _ErrorTo)
			{
				objMail.AddCC(s);
			}
			objMail.Body = sMsg;
			objMail.Subject = _Subect;
			if (!bSuccess)
				objMail.Subject = _Subect + " * FAIL *";
			objMail.SendMail();

		}
	}
}
