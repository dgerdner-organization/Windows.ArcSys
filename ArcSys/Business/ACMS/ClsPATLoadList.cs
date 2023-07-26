using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net;
using System.Text.RegularExpressions;
using CS2010.Common;
using CS2010.ArcSys.Business.PAT;
using CS2010.ArcSys.Business;
using System.ComponentModel;

namespace CS2010.ACMS.Business
{

	public class ClsPATLoadList
	{
		private string _Error;
		public string Error
		{ get { return _Error; } }
		public bool HasErrors
		{ get { return !string.IsNullOrEmpty(_Error); } }

        public void SendToPAT(bool bLive, LobHeader lobHeader, string VoyageNo)
        {
            try
            {
                //
                // Login
                //

				//  This is Test Environment
				////System.ServiceModel.EndpointAddress epa =
				////    new System.ServiceModel.EndpointAddress("https://esb.staging.sddc.army.mil/services/PatLOB");
				////System.ServiceModel.Channels.CustomBinding PATbinding =
				////    new System.ServiceModel.Channels.CustomBinding("PatLOBSoap12Binding");

				// This is Production Version 1
				System.ServiceModel.EndpointAddress epa =
					new System.ServiceModel.EndpointAddress("https://esb.sddc.army.mil/services/SurfacePatLOBServiceVersion1");
				System.ServiceModel.Channels.CustomBinding PATbinding =
					new System.ServiceModel.Channels.CustomBinding("SurfacePatLOBServiceVersion1Soap11Binding");

                PatLOBPortTypeClient pt = new PatLOBPortTypeClient(PATbinding, epa);

                var defaultCredentials = pt.ChannelFactory.Endpoint.Behaviors.Find<System.ServiceModel.Description.ClientCredentials>();
                pt.ChannelFactory.Endpoint.Behaviors.Remove(defaultCredentials);

                System.ServiceModel.Description.ClientCredentials loginCredentials = new System.ServiceModel.Description.ClientCredentials();
                loginCredentials.UserName.UserName = "AROF_PAT_LOB";

				//// Test Password
				//loginCredentials.UserName.Password = "woKsDL57&3a!";
                
				// Production Password
				loginCredentials.UserName.Password = "Qdob#lx22y@c";
                pt.Endpoint.Behaviors.Add(loginCredentials);

                //
                // Create Master and Detail
                //
                ///// Master
                ClsVVoyage voydoc = ClsVVoyage.GetByVoyageNo(VoyageNo);
                ArcSys.Business.PAT.LOBMasterRecord mr = new ArcSys.Business.PAT.LOBMasterRecord();
                mr.scac = "AROF";
                //mr.poe = dtSource.Rows[0]["pol_location_cd"].ToString();
                mr.poe = lobHeader.Pol_Location_Cd;

                mr.voydoc = voydoc.Military_Voyage_Cd;
                mr.vesselName = voydoc.Vessel.Vessel_Dsc;
                mr.metric = false;
                mr.metricSpecified = false;
                mr.sailDate = voydoc.Sail_Dt.GetValueOrDefault();
                mr.sailDateSpecified = true;

                // Detail List
                List<LOBDetailRecord> listDr = new List<LOBDetailRecord>();
                #region Old Looping Logic
                //foreach (DataRow dr in dtSource.Rows)
                //{
                //    LOBDetailRecord dtl = new LOBDetailRecord();
                //    dtl.bookingNumber = dr["booking_no"].ToString();
                //    dtl.commVoydoc = dr["voyage_no"].ToString();
                //    dtl.cargoDescription = dr["cargo_dsc"].ToString();
                //    dtl.commentOne = dr["COMMENT_ONE"].ToString();
                //    dtl.commentTwo = dr["COMMENT_TWO"].ToString();
                //    dtl.consigneeDODAAC = dr["consignee_dodaac"].ToString();
                //    dtl.consignorDODAAC = dr["consignor_dodaac"].ToString();
                //    dtl.containerNumber = dr["container_no"].ToString();
                //    dtl.cube = 100;
                //    dtl.cubeSpecified = true;

                //    dtl.has315vd = (dr["vd_flg"].ToString() == "Y") ? true : false;
                //    dtl.has315vdSpecified = true;
                //    dtl.hasSi = (dr["si_flg"].ToString() == "Y") ? true : false;
                //    dtl.hasSiSpecified = true;
                //    dtl.headID = "";
                //    dtl.height = 90;
                //    dtl.heightSpecified = true;
                //    dtl.isBooked = true;
                //    dtl.isBookedSpecified = true;
                //    dtl.isManifested = true;
                //    dtl.isManifestedSpecified = true;
                //    dtl.length = 150;
                //    dtl.lengthSpecified = true;
                //    dtl.mton = 150;
                //    dtl.mtonSpecified = true;
                //    dtl.pcfn = dr["pcfn"].ToString();
                //    dtl.pod = dr["pod_location_cd"].ToString();
                //    dtl.recID = null;
                //    dtl.revised = false;
                //    dtl.tcn = dr["tcn"].ToString();
                //    dtl.vanType = null;
                //    dtl.vesselStatus = dr["vessel_status_cd"].ToString();
                //    dtl.weight = 1200;
                //    dtl.weightSpecified = true;
                //    dtl.width = 85;
                //    dtl.widthSpecified = true;

                //    listDr.Add(dtl);
                //}
                #endregion
                #region New Looping Logic
                foreach(LobDetailExtract de in lobHeader.detailExtract)
                {
                    LOBDetailRecord dtl = new LOBDetailRecord();
                    dtl.bookingNumber = de.lobExtract.booking_no;
                    dtl.commVoydoc = lobHeader.Military_Voyage_No;
                    dtl.cargoDescription = de.lobExtract.cargo_dsc;
                    dtl.commentOne = de.lobExtract.comment_one;
                    dtl.commentTwo = de.lobExtract.comment_two;
                    dtl.consigneeDODAAC = de.lobExtract.consignee_dodaac;
                    dtl.consignorDODAAC = de.lobExtract.consignor_dodaac;
                    dtl.containerNumber = de.lobExtract.container_no;
					dtl.cube = (float)de.lobExtract.sddc_cbft;
                    dtl.cubeSpecified = true;

                    dtl.has315vd = (de.lobExtract.vd_flg == "Y") ? true : false;
                    dtl.has315vdSpecified = true;
                    dtl.hasSi = (de.lobExtract.si_flg == "Y") ? true : false;
                    dtl.hasSiSpecified = true;
                    dtl.headID = "";
                    dtl.height = (float)de.lobExtract.height_nbr;
                    dtl.heightSpecified = true;
                    dtl.isBooked = true;
                    dtl.isBookedSpecified = true;
                    dtl.isManifested = true;
                    dtl.isManifestedSpecified = true;
                    dtl.length = (float)de.lobExtract.length_nbr;
                    dtl.lengthSpecified = true;
                    dtl.mton = (float)de.lobExtract.mton_nbr;
                    dtl.mtonSpecified = true;
                    dtl.pcfn = de.lobExtract.pcfn;
                    dtl.pod = de.lobExtract.pod_location_cd;
					//dtl.pod = "KF3";
                    dtl.recID = null;
                    dtl.revised = false;
                    dtl.tcn = de.lobExtract.tcn;
                    dtl.vanType = null;
                    dtl.vesselStatus = de.lobExtract.vessel_status_cd;
                    dtl.weight = (float)de.lobExtract.weight_nbr;
                    dtl.weightSpecified = true;
                    dtl.width = (float)de.lobExtract.width_nbr;
					dtl.widthSpecified = true;
					dtl.cargoDescription = dtl.cargoDescription.Replace("&", " ");
                    listDr.Add(dtl);
					if (dtl.tcn.EndsWith("3XFX"))
					{
						string a = dtl.tcn;
					}
                }
                #endregion

                // Create Upload Object
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                UploadLOBRequest r = new UploadLOBRequest();
                r.lobMaster = mr;
                r.lobDetailRecords = listDr.ToArray();

                // Invoke Upload method
				string sIP = new WebClient().DownloadString("http://icanhazip.com");
				sIP = Regex.Replace(sIP, "[^0-9/.]+", "", RegexOptions.Compiled);
                //r.ip_address = "47.19.140.62";
				r.ip_address = sIP;

                UploadLOBResponse uResponse;
                if (bLive)
                {
                    uResponse = pt.UploadLOB(r);
                }
                else
                {
                    uResponse = pt.GetLOBWarningsAndErrors(r);
                }
                string sResponse = uResponse.response;
                _Error = sResponse;
				if (uResponse.validationResponses != null)
				{
					foreach (LOBValidResponse lr in uResponse.validationResponses)
					{
						if (lr.msg != null)
							_Error = _Error + " * " + lr.msg;
					}
				}
				else
				{
					if (!lobHeader.UpdateTransmitDate(mr.sailDate))
						_Error = _Error + " * " + "Transmit date did not update.  Contact Support";
				}
            }
            catch (Exception ex)
            {
                _Error = ex.Message;
            }


        }

        //public void SendToPAT(bool bLive, BindingList<clsLOB> cargoList, string VoyageNo)
        //{
        //    try
        //    {
        //        //
        //        // Login
        //        //
        //        //System.ServiceModel.EndpointAddress epa =
        //        //    new System.ServiceModel.EndpointAddress("https://esb.staging.sddc.army.mil/services/PatLOB");
        //        //System.ServiceModel.Channels.CustomBinding PATbinding =
        //        //    new System.ServiceModel.Channels.CustomBinding("PatLOBSoap12Binding");
        //        System.ServiceModel.EndpointAddress epa =
        //            new System.ServiceModel.EndpointAddress("https://esb.sddc.army.mil/services/SurfacePatLOBServiceVersion1");
        //        System.ServiceModel.Channels.CustomBinding PATbinding =
        //            new System.ServiceModel.Channels.CustomBinding("SurfacePatLOBServiceVersion1Soap11Binding");

        //        PatLOBPortTypeClient pt = new PatLOBPortTypeClient(PATbinding, epa);

        //        var defaultCredentials = pt.ChannelFactory.Endpoint.Behaviors.Find<System.ServiceModel.Description.ClientCredentials>();
        //        pt.ChannelFactory.Endpoint.Behaviors.Remove(defaultCredentials);

        //        System.ServiceModel.Description.ClientCredentials loginCredentials = new System.ServiceModel.Description.ClientCredentials();
        //        loginCredentials.UserName.UserName = "AROF_PAT_LOB";
        //        //loginCredentials.UserName.Password = "woKsDL57&3a!";
        //        loginCredentials.UserName.Password = "Qdob#lx22y@c";
        //        pt.Endpoint.Behaviors.Add(loginCredentials);

        //        //
        //        // Create Master and Detail
        //        //
        //        ///// Master
        //        ClsVVoyage voydoc = ClsVVoyage.GetByVoyageNo(VoyageNo);
        //        ArcSys.Business.PAT.LOBMasterRecord mr = new ArcSys.Business.PAT.LOBMasterRecord();
        //        mr.scac = "AROF";
        //        //mr.poe = dtSource.Rows[0]["pol_location_cd"].ToString();
        //        clsLOB c = cargoList[0];
        //        mr.poe = c.lobExtract.pol_location_cd;

        //        mr.voydoc = voydoc.Military_Voyage_Cd;
        //        mr.vesselName = voydoc.Vessel.Vessel_Dsc;
        //        mr.metric = false;
        //        mr.metricSpecified = false;
        //        mr.sailDate = voydoc.Sail_Dt.GetValueOrDefault();
        //        mr.sailDateSpecified = true;

        //        // Detail List
        //        List<LOBDetailRecord> listDr = new List<LOBDetailRecord>();
        //        #region Old Looping Logic
        //        //foreach (DataRow dr in dtSource.Rows)
        //        //{
        //        //    LOBDetailRecord dtl = new LOBDetailRecord();
        //        //    dtl.bookingNumber = dr["booking_no"].ToString();
        //        //    dtl.commVoydoc = dr["voyage_no"].ToString();
        //        //    dtl.cargoDescription = dr["cargo_dsc"].ToString();
        //        //    dtl.commentOne = dr["COMMENT_ONE"].ToString();
        //        //    dtl.commentTwo = dr["COMMENT_TWO"].ToString();
        //        //    dtl.consigneeDODAAC = dr["consignee_dodaac"].ToString();
        //        //    dtl.consignorDODAAC = dr["consignor_dodaac"].ToString();
        //        //    dtl.containerNumber = dr["container_no"].ToString();
        //        //    dtl.cube = 100;
        //        //    dtl.cubeSpecified = true;

        //        //    dtl.has315vd = (dr["vd_flg"].ToString() == "Y") ? true : false;
        //        //    dtl.has315vdSpecified = true;
        //        //    dtl.hasSi = (dr["si_flg"].ToString() == "Y") ? true : false;
        //        //    dtl.hasSiSpecified = true;
        //        //    dtl.headID = "";
        //        //    dtl.height = 90;
        //        //    dtl.heightSpecified = true;
        //        //    dtl.isBooked = true;
        //        //    dtl.isBookedSpecified = true;
        //        //    dtl.isManifested = true;
        //        //    dtl.isManifestedSpecified = true;
        //        //    dtl.length = 150;
        //        //    dtl.lengthSpecified = true;
        //        //    dtl.mton = 150;
        //        //    dtl.mtonSpecified = true;
        //        //    dtl.pcfn = dr["pcfn"].ToString();
        //        //    dtl.pod = dr["pod_location_cd"].ToString();
        //        //    dtl.recID = null;
        //        //    dtl.revised = false;
        //        //    dtl.tcn = dr["tcn"].ToString();
        //        //    dtl.vanType = null;
        //        //    dtl.vesselStatus = dr["vessel_status_cd"].ToString();
        //        //    dtl.weight = 1200;
        //        //    dtl.weightSpecified = true;
        //        //    dtl.width = 85;
        //        //    dtl.widthSpecified = true;

        //        //    listDr.Add(dtl);
        //        //}
        //        #endregion
        //        #region New Looping Logic
        //        foreach (clsLOB cargo in cargoList)
        //        {
        //            LOBDetailRecord dtl = new LOBDetailRecord();
        //            dtl.bookingNumber = cargo.lobExtract.booking_no;
        //            dtl.commVoydoc = cargo.lobHeader.Military_Voyage_No;
        //            dtl.cargoDescription = cargo.lobExtract.cargo_dsc;
        //            dtl.commentOne = cargo.lobExtract.comment_one;
        //            dtl.commentTwo = cargo.lobExtract.comment_two;
        //            dtl.consigneeDODAAC = cargo.lobExtract.consignee_dodaac;
        //            dtl.consignorDODAAC = cargo.lobExtract.consignor_dodaac;
        //            dtl.containerNumber = cargo.lobExtract.container_no;
        //            dtl.cube = (float)cargo.lobExtract.cube_nbr;
        //            dtl.cubeSpecified = true;

        //            dtl.has315vd = (cargo.lobExtract.vd_flg == "Y") ? true : false;
        //            dtl.has315vdSpecified = true;
        //            dtl.hasSi = (cargo.lobExtract.si_flg == "Y") ? true : false;
        //            dtl.hasSiSpecified = true;
        //            dtl.headID = "";
        //            dtl.height = (float)cargo.lobExtract.height_nbr;
        //            dtl.heightSpecified = true;
        //            dtl.isBooked = true;
        //            dtl.isBookedSpecified = true;
        //            dtl.isManifested = true;
        //            dtl.isManifestedSpecified = true;
        //            dtl.length = (float)cargo.lobExtract.length_nbr;
        //            dtl.lengthSpecified = true;
        //            dtl.mton = (float)cargo.lobExtract.mton_nbr;
        //            dtl.mtonSpecified = true;
        //            dtl.pcfn = cargo.lobExtract.pcfn;
        //            dtl.pod = cargo.lobExtract.pod_location_cd;
        //            dtl.recID = null;
        //            dtl.revised = false;
        //            dtl.tcn = cargo.lobExtract.tcn;
        //            dtl.vanType = null;
        //            dtl.vesselStatus = cargo.lobExtract.vessel_status_cd;
        //            dtl.weight = (float)cargo.lobExtract.weight_nbr;
        //            dtl.weightSpecified = true;
        //            dtl.width = (float)cargo.lobExtract.width_nbr;

        //            dtl.widthSpecified = true;

        //            listDr.Add(dtl);
        //        }
        //        #endregion

        //        // Create Upload Object
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        //        UploadLOBRequest r = new UploadLOBRequest();
        //        r.lobMaster = mr;
        //        r.lobDetailRecords = listDr.ToArray();

        //        // Invoke Upload method
        //        r.ip_address = "47.19.140.62";
        //        UploadLOBResponse uResponse;
        //        if (bLive)
        //        {
        //            uResponse = pt.UploadLOB(r);
        //        }
        //        else
        //        {
        //            uResponse = pt.GetLOBWarningsAndErrors(r);
        //        }
        //        string sResponse = uResponse.response;
        //        _Error = sResponse;
        //        if (uResponse.validationResponses != null)
        //        {
        //            foreach (LOBValidResponse lr in uResponse.validationResponses)
        //            {
        //                if (lr.msg != null)
        //                    _Error = _Error + " * " + lr.msg;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _Error = ex.Message;
        //    }


        //}
	}
}
