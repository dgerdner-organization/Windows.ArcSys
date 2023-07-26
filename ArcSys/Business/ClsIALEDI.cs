using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;
using CS2010.ArcSys.Business;
using System.IO;
using System.Data;

namespace CS2010.ArcSys.Business
{
	public class ClsIALEDI
	{
		#region Properties 
		public static string sRoot = "\\\\commserver01\\in_out\\ial_detail_in\\";
		public static string sPath = sRoot + "in\\";
		public static string sArk = sRoot + "archive\\";
		public static string sError = sRoot + "error\\";

		public static string sSIRoot = "\\\\commserver01\\in_out\\ial_shipping_instructions_in\\";
		public static string sSIPath = sSIRoot + "in\\";
		public static string sSIArk = sSIRoot + "archive\\";
		public static string sSIError = sSIRoot + "error\\";

		public static string sBolOutRoot = "\\\\commserver01\\in_out\\ial_bol_out\\";
		public static string sBolOutPath = sBolOutRoot + "ftpout\\";

		public string Errors
		{
			get
			{
				return _Errors.ToString();
			}
		}
		protected StringBuilder _Errors = new StringBuilder();

		protected StringBuilder _Warnings = new StringBuilder();
		public string Warnings
		{
			get { return _Warnings.ToString(); }
		}
		protected bool HasErrors
		{
			get
			{
				if (_Errors.Length < 1)
					return false;
				return true;
			}
		}
		protected StringBuilder _Removes;
		protected StringBuilder Removes
		{
			get
			{
				return _Removes;
			}
		}
		public bool HasRecalls = false;
		#endregion

		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Cargo Detail 
		public static List<string> UnprocessedDetailFiles
		{
			get
			{
				string[] sFiles = Directory.GetFiles(sPath);
				List<string> l = new List<string>();
				foreach (string s in sFiles)
				{
					l.Add(s);
				}
				return l;
			}

		}
		public static List<string> FailedDetailFiles
		{
			get
			{
				string[] sFiles = Directory.GetFiles(sError);
				List<string> l = new List<string>();
				foreach (string s in sFiles)
				{
					l.Add(s);
				}
				return l;
			}
		}
		public static List<string> FailedSIFiles
		{
			get
			{
				string[] sFiles = Directory.GetFiles(sSIError);
				List<string> l = new List<string>();
				foreach (string s in sFiles)
				{
					l.Add(s);
				}
				return l;
			}
		}

		public void ProcessCargoDetails()
		{
			// This looks for a CSV file from IAL that contains vehicle detail information.
			// It will place it into t_edi_cargo_detail for later processing
			string[] sFiles = Directory.GetFiles(sPath);
			Array.Sort(sFiles);
			foreach (string sFile in sFiles)
			{
				string sFileOnly = sFile.Replace(sPath, "");
				bool bSuccess = ParseFile(sFile);
				
				if (bSuccess)
				{
					//File.Move(sFile, sArk + sFileOnly);
					MoveFile(sFile, sArk + sFileOnly);
				}
				else
				{
					File.Move(sFile, sError + sFileOnly);
				}
			}

			// Now process anything that is unprocessed
			UpdateLine();

			// Cleanup.
			ClsLineSQL.CleanupBookRcvVins();
			return;
		}

		private void MoveFile(string sFrom, string sTo)
		{
			//
			// Use this for moving files, so if there is an error it can be consumed here
			//
			try
			{
				if (File.Exists(sTo))
					File.Delete(sFrom);
				else
					File.Move(sFrom, sTo);
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
			}
		}
		public void ArchiveCargoDetail()
		{
			// Move from Error folder to ARchive
			List<string> lFiles = FailedDetailFiles;
			foreach (string sFile in lFiles)
			{
				string sFileOnly = sFile.Replace(sError, "");
				File.Move(sFile, sArk + sFileOnly);
			}

		}
		protected bool ParseFile(string sFile)
		{
			try
			{
				FileStream filestream = new FileStream(sFile,
											FileMode.Open,
											FileAccess.Read,
											FileShare.ReadWrite);
				StreamReader file = new StreamReader(filestream, Encoding.UTF8, true, 128);

				string sLine;
				int ix = 0;
				_Removes = new StringBuilder();
				while ((sLine = file.ReadLine()) != null)
				{
					ix++;
					if (ix == 1)
					{
						// Skip the first line, which is a header
						continue;
					}
					if (sLine.Length < 5)
						continue;
					InsertRow(sLine, sFile);
				}
				file.Close();
				if (Removes.Length > 0)
				{
					// April 2017 DGERDNER
					//    Do not send the email when processing the Remove.  Instead, this will happen if the user chooses
					//    to process the Remove in the Dashboard.
					// If there were removals, send an email
					//ClsEmail em = new ClsEmail();
					//em.From = "helpdesk@amslgroup.com";
					//em.AddTo("arccustomerservice@amslgroup.com");
					//em.AddCC("dgerdner@amslgroup.com");
					//em.Subject = "IAL Remove Cargo";
					//em.Body = Removes.ToString();
					//em.SendMail();
				}
				if (HasRecalls)
				{
					// If there were recalls, send an email
					ClsEmail em = new ClsEmail();
					em.From = "helpdesk@amslgroup.com";
					em.AddTo("arccustomerservice@amslgroup.com");
					em.AddCC("dgerdner@amslgroup.com");
					em.Subject = "IAL Recalls";
					em.Body = "New cargo detail was received from IAL for a vehicle that has an outstanding recall.  See the Dashboard for details.";
					em.SendMail();
				}
				return !this.HasErrors;
			}

			catch (Exception ex)
			{
				if (ex.Message.ToLower().Contains("mail"))
				{
					// Do not consider this to be an error if it's an email problem
					ClsErrorHandler.LogException(ex);
					_Warnings.AppendLine(ex.Message);
					return true;
				}
				ClsErrorHandler.LogException(ex);
				_Errors.AppendLine(ex.Message);
				return false;
			}
		}

		protected bool InsertRow(string sLine, string sFileNm)
		{
			ClsEdiInboundDetail dtl = new ClsEdiInboundDetail();
			try
			{
				string[] sColumns = sLine.Split(',');
				if (sColumns.Length < 11)
				{
					_Errors.AppendFormat("Not enough columns in line {0} ", sLine);
					return false;
				}
				dtl.Booking_No = sColumns[0];
				dtl.Vehicle_Type_Cd = sColumns[1];
				dtl.Length_Nbr = ClsConvert.ToDecimal(sColumns[2]);
				dtl.Width_Nbr = ClsConvert.ToDecimal(sColumns[3]);
				dtl.Height_Nbr = ClsConvert.ToDecimal(sColumns[4]);
				dtl.Weight_Nbr = ClsConvert.ToDecimal(sColumns[5]);
				dtl.Vehicle_Year = ClsConvert.ToInt16(sColumns[6]);
				dtl.Make = sColumns[7];
				dtl.Model = sColumns[8];
				dtl.Vin = sColumns[9];
				dtl.Customer_Order_No = sColumns[10];
				dtl.Processed_Flg = "N";
				dtl.Source_File = sFileNm;
				if (sColumns.Length > 11)
				{
					// If there is a 'REMOVE' column at the end, delete
					// that piece of cargo
					string sRemove = sColumns[11];
					ClsEdiInboundRemove rem = new ClsEdiInboundRemove();
					rem.Booking_No = dtl.Booking_No;
					rem.Vin = dtl.Vin;
					rem.Processed_Flg = "N";
					rem.Process_Msg = "";
					if (sRemove.ToUpper().StartsWith( "REMOVE"))
					{
						string sRemoveMsg = string.Format("Remove {0} from {1} ", dtl.Vin, dtl.Booking_No);
						_Removes.AppendLine("");
						if (dtl.DeleteCargo())
							_Removes.AppendLine(sRemoveMsg);
						else
						{
							sRemoveMsg = sRemoveMsg + " : Cannot remove because cargo is received";
							rem.Process_Msg = sRemoveMsg;
							_Removes.AppendLine(sRemoveMsg);
						}
						rem.Insert();
						return true;
					}
				}
				dtl.Insert();
				// Check to see if this vehicle is on the recall list
				if (ClsRecall.CheckRecall(dtl.Vehicle_Year.GetValueOrDefault(), dtl.Make, dtl.Model))
				{
					HasRecalls = true;
				}
				// If there is an existing "Remove" message for this booking/VIN, delete it because
				// it no longer applies.  It suggests a case where they sent us a Remove followed by a New 
				// in order to update data.
				//if (dtl.Vin == "1J4FA24157L184084")
				//{
				//    string a = "a";
				//}
				
				DataTable dtRem = ClsEdiInboundRemove.GetByQuery(dtl.Booking_No, dtl.Vin, "N");
				if (dtRem.Rows.Count > 0)
				{
					ClsEdiInboundRemove r = new ClsEdiInboundRemove(dtRem.Rows[0]);
					r.Processed_Flg = "Y";
					r.Update();
				}

				return true;
			}

			catch (Exception ex)
			{
				if (ex.Message.ToLower().Contains("unique"))
				{
					// DGERDNER: October2018
					// Removed logging of duplicate VINS, it's too common to bother with.
					//
					string sMsg = string.Format("VIN {0} is a duplicate for booking {1} ", dtl.Vin, dtl.Booking_No);
					//ClsErrorHandler.LogWarning(sMsg);
					//ClsErrorHandler.LogError(sMsg);
					_Warnings.AppendLine(sMsg);
					return true;
				}
				else
				{
					_Errors.AppendLine("");
					_Errors.AppendFormat("{0} {1}", sLine, ex.Message);
				}
				return false;
			}
		}

		public bool UpdateLine()
		{
			ClsEdiInboundDetail dtl = null;
			bool bErrors = false;
			try
			{
				DataTable dt = ClsEdiInboundDetail.GetUnprocessed(false,99999,null,null,"LINE");
				foreach (DataRow drow in dt.Rows)
				{
					dtl = new ClsEdiInboundDetail(drow);
					if (dtl.Processed_Flg == "Y")
						continue;
					if (!dtl.Weight_Nbr.HasValue)
					{
						bErrors = true;
						_Errors.AppendFormat("Weight is missing: {0} {1} ", dtl.Booking_No, dtl.Vin);
						continue;
					}
					if (!dtl.Height_Nbr.HasValue)
					{
						bErrors = true;
						_Errors.AppendFormat("Height is missing: {0} {1} ", dtl.Booking_No, dtl.Vin);
						continue;
					}
					if (!dtl.Length_Nbr.HasValue)
					{
						bErrors = true;
						_Errors.AppendFormat("Length is missing: {0} {1} ", dtl.Booking_No, dtl.Vin);
						continue;
					}
					if (dtl.Height_Nbr >= 63 && dtl.Vehicle_Type_Cd == "CAR")
					{
						dtl.Process_Msg = "Error: Vehicle is 63 inches or higher, but coded as CAR";
						dtl.Update();
						bErrors = true;
						_Errors.AppendFormat("{0} {1} {2}", dtl.Booking_No, dtl.Vin, dtl.Process_Msg);
						continue;
					}
					if (dtl.Height_Nbr < 63 && dtl.Vehicle_Type_Cd == "VAN" && dtl.Create_Dt > dtl.Create_Dt.GetValueOrDefault().AddHours(-3))
					{
						// Jan 2017 DGERDNER
						// Only send this if the row was created within the last couple hours.  Otherwise it keeps sending
						// an email over and over again.
						//
						// 
						dtl.Process_Msg = "Error: Vehicle is less than 63 inches, but coded as VAN";
						dtl.Update();
						bErrors = true;
						_Errors.AppendFormat("{0} {1} {2}", dtl.Booking_No, dtl.Vin, dtl.Process_Msg);
						continue;
					}
					DataRow roro = ClsLineSQL.GetAvailableRoro(dtl.Booking_No, dtl.Vin, dtl.Vehicle_Type_Cd);
					if (roro == null)
					{
						dtl.Process_Msg = "Could not find available line in LINE RoRo tab";
						dtl.Update();
						//bErrors = true;
						_Warnings.AppendFormat("{0} {1} {2}", dtl.Booking_No, dtl.Vin, dtl.Process_Msg);
						continue;
					}
					string sDogs = dtl.Vehicle_Year.ToString() + ' ' + dtl.Make + ' ' + dtl.Model;
                    sDogs = sDogs.Replace("-", " ");
                    sDogs = sDogs.Replace("(", " ");
					ClsLineSQL.UpdateRoro(roro, dtl.Vin, sDogs);
					dtl.Processed_Flg = "Y";
					dtl.Process_Msg = "";
					dtl.Update();


				}
				return !bErrors;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				if (dtl != null)
				{
					dtl.Process_Msg = ex.Message;
					dtl.Update();
					_Errors.AppendFormat("{0} {1} {2}", dtl.Booking_No, dtl.Vin, dtl.Process_Msg);
				}
				return false;
			}
		}
		#endregion

		#region Shipping Instructions
		public static List<string> UnprocessedSIFiles
		{
			get
			{
				string[] sFiles = Directory.GetFiles(sSIPath);
				List<string> l = new List<string>();
				foreach (string s in sFiles)
				{
					l.Add(s);
				}
				return l;
			}
		}

		public void ProcessShippingInstructions()
		{
			bool bInTrans = Connection.IsInTransaction;
			if (!bInTrans)
				Connection.TransactionBegin();
			try
			{
				// This looks for a CSV file from IAL that contains vehicle detail information.
				// It will place it into t_edi_cargo_detail for later processing
				List<string> lFiles = UnprocessedSIFiles;
				foreach (string sFile in lFiles)
				{
					
					string sFileOnly = sFile.Replace(sSIPath, "");
					bool bSuccess = ParseSIFile(sFile);

					if (bSuccess)
					{
						//File.Move(sFile, sSIArk + sFileOnly);
						MoveFile(sFile, sSIArk + sFileOnly);
					}
					else
					{
						//File.Move(sFile, sSIError + sFileOnly);
						MoveFile(sFile, sSIError + sFileOnly);
					}
					if (!bInTrans)
						Connection.TransactionCommit();
				}
				return;
			}
			catch (Exception ex)
			{
				_Errors.AppendLine(ex.Message);
				if (!bInTrans)
					Connection.TransactionRollback();
				return;
			}
		}

		public void ArchiveShippingInstructsion()
		{
			// Move from Error folder to ARchive
			List<string> lFiles = FailedSIFiles;
			foreach (string sFile in lFiles)
			{
				string sFileOnly = sFile.Replace(sSIError, "");
				File.Move(sFile, sSIArk + sFileOnly);
			}

		}

		protected bool ParseSIFile(string sFile)
		{
			bool bErrors = false;
			try
			{
				FileStream filestream = new FileStream(sFile,
											FileMode.Open,
											FileAccess.Read,
											FileShare.ReadWrite);
				StreamReader file = new StreamReader(filestream, Encoding.UTF8, true, 128);

				string sLine;
				int ix = 0;
				while ((sLine = file.ReadLine()) != null)
				{
					ix++;
					if (ix == 1)
					{
						// Skip the first line, which is a header
						continue;
					}
					if (sLine.Length < 2)
					{
						// Skip blank lines (common at the end of the file)
						continue;
					}
					if (!InsertSIRow(sLine, sFile))
					    bErrors = true;
				}
				file.Close();
				return !bErrors;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				_Errors.AppendLine(ex.Message);
				return false;
			}
		}

		protected bool InsertSIRow(string sLine, string sFileNm)
		{
			bool bInTrans = Connection.IsInTransaction;
			if (!bInTrans)
				Connection.TransactionBegin();
			ClsEdiInboundSi si = new ClsEdiInboundSi();
			try
			{
				string[] sColumns = sLine.Split(',');
				if (sColumns.Length < 5)
				{
					_Errors.AppendFormat("Not enough columns in line {0} ", sLine);
					return false;
				}

				si.Trans_Ctl_No = ClsConvert.ToInt32(sColumns[0]);
				si.Booking_No = sColumns[1];
				si.Vin = sColumns[2];
				si.First_Nm = sColumns[3];
				si.Last_Nm = sColumns[4];
				if (sColumns.Length > 5)
				{
					si.Addr1 = sColumns[5];
					si.Addr2 = sColumns[6];
					si.Addr3 = sColumns[7];
					si.City = sColumns[8];
					si.State_Cd = sColumns[9];
					si.Country_Cd = sColumns[10];
					si.Zip_Cd = sColumns[11];
				}
				si.Processed_Flg = "N";
				string s = Path.GetFileName(sFileNm);
				si.Source_File = s;

				si.Insert();
				if (!bInTrans)
					Connection.TransactionCommit();
				return true;
			}
			catch (Exception ex)
			{

				if (!bInTrans)
					Connection.TransactionRollback();
				if (ex.Message.ToLower().Contains("unique"))
				{
					// DGERDNER: October2018
					// Removed logging of duplicate VINS, it's too common to bother with.
					//
					//ClsErrorHandler.LogException(ex);
					string sMsg = string.Format("VIN {0} is a duplicate for booking {1} ", si.Vin, si.Booking_No);
					_Warnings.AppendLine(sMsg);
					return true;
				}
				ClsErrorHandler.LogException(ex);
				_Errors.AppendLine("");
				_Errors.AppendFormat("{0} {1}", sLine, ex.Message);
				return false;
			}
		}

		#endregion

		#region Send BOLs Out
		public void SendBolsOut()
		{
			bool bInTrans = Connection.IsInTransaction;
			if (!bInTrans)
				Connection.TransactionBegin();
			try
			{
				// Get EDI and Trading Partner Info
				ClsTradingPartner partner = ClsTradingPartner.GetUsingKey("IAL");
				ClsTradingPartnerEdi ediInfo =
						ClsTradingPartnerEdi.GetByMap(partner.Trading_Partner_Cd, "BOLOUT");
				string sFile = ediInfo.File_Path + ediInfo.Prefix + partner.Outbound_Isa_Nbr.ToString() + ".csv";

				// Create the text file for export
				string sql = string.Format(@"select 
						CUSTOMER_ORDER_NO,VIN,CARGO_BOL_NO,POL_LOCATION_CD,POD_LOCATION_CD,POL_ETS,POD_ETA,VESSEL_CD,VOYAGE_NO,FREIGHT_AMT
							from v_ial_bol_out ");
				
                DataTable dt = Connection.GetDataTable(sql);
				if (dt.Rows.Count > 0)
					PutDataTableToCsv(sFile, dt, false);
				else
				{
					_Warnings.Append("Nothing to export");
					return;
				}

				// Log to the outbound BOL log table
				sql = "select distinct cargo_bol_no from v_ial_bol_out ";
				dt = Connection.GetDataTable(sql);
				foreach (DataRow drow in dt.Rows)
				{
					string sBolNo = drow["cargo_bol_no"].ToString();
					ClsEdiOutboundBol log = new ClsEdiOutboundBol();
					log.Bol_No = sBolNo;
					log.Trading_Partner_Cd = partner.Trading_Partner_Cd;
					log.Isa_Nbr = partner.Outbound_Isa_Nbr;
					log.Processed_Flg = "Y";
					log.Insert();
				}

				// Log to the generic outbound log
				ClsEdiOutboundLog obLog = new ClsEdiOutboundLog();
				obLog.File_Nm = sFile;
				obLog.Trading_Partner_Cd = partner.Trading_Partner_Cd;
				obLog.Isa_Nbr = partner.Outbound_Isa_Nbr;
				obLog.Edi_Message_No = "BOL";
				obLog.Log_Dt = DateTime.Now;
				obLog.Insert();

				// Update the partner table's current ISA# column
				partner.Outbound_Isa_Nbr = partner.Outbound_Isa_Nbr + 1;
				partner.Update();

				if (!bInTrans)
					Connection.TransactionCommit();
				return;
			}
			catch (Exception ex)
			{
				if (!bInTrans)
					Connection.TransactionRollback();
				ClsErrorHandler.LogException(ex);
				_Errors.AppendLine(ex.Message);
				throw;
			}
		}

		public void SendITVOut(string sActivity)
		{
			bool bInTrans = Connection.IsInTransaction;
			if (bInTrans)
				Connection.TransactionCommit();
			Connection.TransactionBegin();
			bInTrans = false;
			try
			{
				// Get EDI and Trading Partner Info
				ClsTradingPartner partner = ClsTradingPartner.GetUsingKey("IAL");
				ClsTradingPartnerEdi ediInfo =
						ClsTradingPartnerEdi.GetByMap(partner.Trading_Partner_Cd, "ITVOUT");
				if (sActivity == "RECEIVED")
					ediInfo =ClsTradingPartnerEdi.GetByMap(partner.Trading_Partner_Cd, "RCVOUT");
				string sFile = ediInfo.File_Path + ediInfo.Prefix + partner.Outbound_Isa_Nbr.ToString() + ".csv";

				// Create the text file for export
				string sql = string.Format(@"select distinct
					 vessel_cd, voyage_no, port, booking_no, ial_order_no, vin, activity_cd, activity_dt, itv_id, isa_nbr
					 from V_IAL_ITV_OUT t
					  where activity_cd = '{0}' ", sActivity);
				DataTable dt = Connection.GetDataTable(sql);
				if (dt.Rows.Count > 0)
				{
					// Update the ISA for all of the ITV that was just sent.
					foreach (DataRow drow in dt.Rows)
					{
						if (drow.ItemArray.Length < 5)
							continue;
						int iItvID = drow["itv_id"].ToInt();
						sql = string.Format(@"
							update t_itv set isa_nbr = {0} where itv_id = {1} ", partner.Outbound_Isa_Nbr, iItvID);
						Connection.RunSQL(sql);
						//i.Update();
					}
					// Send to text file
					dt.Columns.Remove("itv_id");
					dt.Columns.Remove("isa_nbr");
					PutDataTableToCsv(sFile, dt, false);
				}
				else
				{
					_Warnings.Append("Nothing to export");
					if (!bInTrans)
						Connection.TransactionRollback();
					return;
				}


			
				// Log to the generic outbound log
				ClsEdiOutboundLog obLog = new ClsEdiOutboundLog();
				obLog.File_Nm = sFile;
				obLog.Trading_Partner_Cd = partner.Trading_Partner_Cd;
				obLog.Isa_Nbr = partner.Outbound_Isa_Nbr;
				obLog.Edi_Message_No = "ITV";
				obLog.Log_Dt = DateTime.Now;
				obLog.Insert();

				// Update the partner table's current ISA# column
				partner.Outbound_Isa_Nbr = partner.Outbound_Isa_Nbr + 1;
				partner.Update();

				if (!bInTrans)
					Connection.TransactionCommit();
				return;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				_Warnings.AppendLine(ex.Message);
				Connection.TransactionRollback();
			}
		}
		#endregion

		#region TOPS update
		public void BookingsToTops()
		{
			string sql = "select distinct(booking_no) as booking_no from t_edi_inbound_detail where create_dt > sysdate - 1 ";
			DataTable dt = Connection.GetDataTable(sql);
			foreach (DataRow drow in dt.Rows)
			{
			}
		}
		#endregion

		#region Helper Methods
		static void PutDataTableToCsv(string path, DataTable table, bool isFirstRowHeader)
		{
			var lines = new List<string>(); // create a list of strings to hold the file rows

			// if there are headers add them to the file first
			if (isFirstRowHeader)
			{
				string[] colnames = table.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
				var header = string.Join(",", colnames);
				lines.Add(header);
			}

			// Place commas between the elements of each row
			var valueLines = table.AsEnumerable().Cast<DataRow>().Select(row => string.Join(",", row.ItemArray.Select(o => o.ToString()).ToArray()));

			// Stuff the rows into a string joined by new line characters
			var allLines = string.Join(Environment.NewLine, valueLines.ToArray<string>());
			lines.Add(allLines);

			// put that file to bed
			try
			{
				File.WriteAllLines(path, lines.ToArray());
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
			}
		}
		#endregion

        #region Recalls

        /// <summary>
        /// This will be expanded on once we have the table built and refine the requirements.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetIALRecalls(ClsConnection conn)
        {
            string SQL = @"
                Select 
                    det.vehicle_year as POV_YEAR,
                    det.make as POV_MAKE,
                    det.model as POV_MODEL,
                    det.BOOKING_NO,
                    det.VIN,
                    det.CUSTOMER_ORDER_NO,
                    det.CREATE_DT
                from t_edi_inbound_detail det 
                    inner join r_recall r on 
                        (det.make like '%'||r.vehicle_make||'%' and  
                            det.model like '%'||r.vehicle_model||'%' and 
                            det.vehicle_year = r.vehicle_year and 
                            r.active_flg = 'Y')
                    where det.vin not in (Select v.vin from r_recall_vin v)           
                order by det.CREATE_DT";

            return conn.GetDataTable(SQL);

        }

        #endregion

		#region Overheights
		public static DataTable GetOverHeights(ClsConnection conn)
		{
			//
			// First gather all new over height cargo and place into the over height table
			//  with processed_flg (reviewed indicator) to "N"
			//
			string sql = @"
				insert into t_edi_inbound_overht
				 (edi_inbound_overht_id, edi_inbound_detail_id, processed_flg)
				select
				 edi_inbound_overht_id_seq.nextval,
				 d.edi_inbound_detail_id,
				 'N'
				 from t_edi_inbound_detail d
				  inner join t_booking_line b on d.booking_no = b.booking_no
				  where d.create_dt > sysdate - 180
				   and d.height_nbr * 2.539876 > 195
					and not exists
					(select 1 from t_edi_inbound_overht h where d.edi_inbound_detail_id = h.edi_inbound_detail_id) ";
			conn.RunSQL(sql);

			//
			// Then gather all unprocessed overheight cargo from the table
			//
			sql = @"
				select 
				   oh.edi_inbound_overht_id,
				   oh.edi_inbound_detail_id,
					d.booking_no,
				   d.vehicle_type_cd,
				   b.voyage_no,
				   d.vin,
				   round(2.539876 * d.height_nbr,2) as height_nbr, 
				   round(2.539876 * d.length_nbr,2) as length_nbr,
				   round(2.539876 * d.width_nbr,2) as width_nbr
				 from t_edi_inbound_overht oh
				  inner join t_edi_inbound_detail d on d.edi_inbound_detail_id = oh.edi_inbound_detail_id
				  inner join t_booking_line b on d.booking_no = b.booking_no
				  where oh.processed_flg = 'N'
                    order by b.voyage_no, d.booking_no, d.vin ";
			return conn.GetDataTable(sql);
		}

		public static DataTable GetOverHeightHistory()
		{
			string sql = @"
				select 
				   d.create_dt as detail_rcvd_dt,
				   oh.modify_dt,
				   CASE 
					  WHEN oh.processed_flg = 'Y' then oh.modify_dt
						ELSE null
						  END as reviewed_dt,
				   CASE 
					  WHEN oh.processed_flg = 'Y' then oh.modify_user 
						ELSE null
						  END as reviewer,
				   oh.edi_inbound_overht_id,
				   oh.edi_inbound_detail_id,
					d.booking_no,
				   d.vehicle_type_cd,
				   b.voyage_no,
				   d.vin,
				   round(2.539876 * d.height_nbr,2) as height_nbr, 
				   round(2.539876 * d.length_nbr,2) as length_nbr,
				   round(2.539876 * d.width_nbr,2) as width_nbr,
				   oh.processed_flg as processed_flg
				 from t_edi_inbound_overht oh
				  inner join t_edi_inbound_detail d on d.edi_inbound_detail_id = oh.edi_inbound_detail_id
				  inner join t_booking_line b on d.booking_no = b.booking_no
                where oh.edi_inbound_overht_id > 10000
			    order by b.voyage_no, d.booking_no, d.vin
				   ";

			return Connection.GetDataTable(sql);
		}

		#endregion

		#region Removes
		public void CleanUpRemoves()
		{
			bool bInTrans = Connection.IsInTransaction;
			if (!bInTrans)
				Connection.TransactionStart();
			try
			{
				// This gets rid of extameous Remove messages.  The two scenarios are:
				//
				//	1. If there is a cargo detail for this remove, then it means that 
				//     after the remove was processed we must have received another
				//     cargo detail file.  So this Remove should be ignored.
				//
				//   2. If the VIN does not exist in LINE (car_head table) for this booking
				//      then we obviously don't need the Remove, because its only purpose
				//		is to tell the users that they need to delete the VIN from LINE
				//
				//    NOTE:
				//       It only performs this on Removes that at least 30 minutes old.
				//       This is so we don't accidently do it to one prematurely, because
				//       there was a mixup in the order the files were processed.  I'm
				//       not sure it's needed but just to be safe.
				string sql = string.Format(@"
					delete 
					 from t_edi_inbound_remove r
					  where r.processed_flg = 'N'
						and r.create_dt < sysdate - .01
					   and exists
					   (select 1 from t_edi_inbound_detail d
						 where d.booking_no = r.booking_no
						   and d.vin = r.vin)
					");
				Connection.RunSQL(sql);

                // May 2020
                // Instead of making direct calls to LINE, make direct calls to OCEAN
//                sql = string.Format(@"
//					delete 
//					 from t_edi_inbound_remove r
//					  where r.processed_flg = 'N'
//						  and r.create_dt < sysdate - .01
//					   and not exists
//					   (select 1
//							from dba.car_head<DBLINK>sql01 h
//							 where h.""cr1_bunr"" = r.booking_no
//							   and h.cr1_vin = r.vin) 
//					");
//                Connection.RunSQL(sql);
                DataTable dtRemoves = ClsEdiInboundRemove.GetUnprocessed();
                foreach (DataRow drow in dtRemoves.Rows)
                {
                    // For all unprocessed Removes, look to see if the cargo exists in OCEAN
                    //   If not, that means it's already been removed, so just delete this row.
                    //
                    ClsEdiInboundRemove remv = new ClsEdiInboundRemove(drow);
                    ClsVwArcBookingCargo cargo = ClsVwArcBookingCargo.GetForBookingSerialNo(remv.Booking_No, remv.Vin);
                    if (cargo == null)
                    {
                        sql = string.Format(@"
                            delete from t_edi_inbound_remove
                                where booking_no = '{0}' and vin = '{1}' ", remv.Booking_No, remv.Vin);
                        Connection.RunSQL(sql);
                    }
                }
				if (!bInTrans)
					Connection.TransactionCommit();
			}
			catch (Exception ex)
			{
				if (!bInTrans)
					Connection.TransactionRollback();
				throw ex;
			}
		}
		#endregion

	}
}
