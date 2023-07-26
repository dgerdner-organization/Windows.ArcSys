using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CS2010.Common;
using System.Configuration;

namespace CS2010.ArcSys.Business
{
    public class manager_actual_vs_budget
    {
        /// <summary>
        /// This method merges Line and WWL data and adds default records for each of the 28 categories
        /// </summary>
        /// <param name="Line">Line Sales Summary Data</param>
        /// <param name="WWL">WWL EDI Data</param>
        /// <param name="p">Params used to run query</param>
        /// <returns></returns>
        public DataTable MergeActualVsBudgetReport(DataTable Line, DataTable WWL, ActualVsBudgetParams p)
        {
            DataRow dr;
            string Direction = p.DirectionText;

            if (Line != null)
            {

                // SDDC

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "01-SDDC-AAL", Direction, null, null, null, null, 0, 0, 0, 0, "SDDC", "AAL", 1, 1 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "02-SDDC-LIGHT", Direction, null, null, null, null, 0, 0, 0, 0, "SDDC", "LIGHT", 1, 2 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "03-SDDC-HEAVY", Direction, null, null, null, null, 0, 0, 0, 0, "SDDC", "HEAVY", 1, 3 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "04-SDDC-NOS", Direction, null, null, null, null, 0, 0, 0, 0, "SDDC", "NOS", 1, 4 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "05-SDDC-HELOS", Direction, null, null, null, null, 0, 0, 0, 0, "SDDC", "HELOS", 1, 5 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "06-SDDC-CONTAINERS", Direction, null, null, null, null, 0, 0, 0, 0, "SDDC", "CONTAINERS", 1, 6 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "07-SDDC-PORT AND LINER", Direction, null, null, null, null, 0, 0, 0, 0, "SDDC", "PORT AND LINER", 1, 7 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "08-SDDC-BAF", Direction, null, null, null, null, 0, 0, 0, 0, "SDDC", "BAF", 1, 8 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "09-SDDC-LINEHAUL", Direction, null, null, null, null, 0, 0, 0, 0, "SDDC", "LINEHAUL", 1, 9 };
                Line.Rows.Add(dr);

                // FMS

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "10-FMS-LIGHT", Direction, null, null, null, null, 0, 0, 0, 0, "FMS", "LIGHT", 2, 10 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "11-FMS-HEAVY", Direction, null, null, null, null, 0, 0, 0, 0, "FMS", "HEAVY", 2, 11 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "12-FMS-NOS", Direction, null, null, null, null, 0, 0, 0, 0, "FMS", "NOS", 2, 12 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "13-FMS-HELOS", Direction, null, null, null, null, 0, 0, 0, 0, "FMS", "HELOS", 2, 13 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "14-FMS-CONTAINERS", Direction, null, null, null, null, 0, 0, 0, 0, "FMS", "CONTAINERS", 2, 14 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "15-FMS-PORT AND LINER", Direction, null, null, null, null, 0, 0, 0, 0, "FMS", "PORT AND LINER", 2, 15 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "16-FMS-BAF", Direction, null, null, null, null, 0, 0, 0, 0, "FMS", "BAF", 2, 16 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "17-FMS-LINEHAUL", Direction, null, null, null, null, 0, 0, 0, 0, "FMS", "LINEHAUL", 2, 17 };
                Line.Rows.Add(dr);

                // OEF

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "18-OEF-LIGHT", Direction, null, null, null, null, 0, 0, 0, 0, "OEF", "LIGHT", 3, 18 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "19-OEF-HEAVY", Direction, null, null, null, null, 0, 0, 0, 0, "OEF", "HEAVY", 3, 19 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "20-OEF-NOS", Direction, null, null, null, null, 0, 0, 0, 0, "OEF", "NOS", 3, 20 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "21-OEF-HELOS", Direction, null, null, null, null, 0, 0, 0, 0, "OEF", "HELOS", 3, 21 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "22-OEF-CONTAINERS", Direction, null, null, null, null, 0, 0, 0, 0, "OEF", "CONTAINERS", 3, 22 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "23-OEF-PORT AND LINER", Direction, null, null, null, null, 0, 0, 0, 0, "OEF", "PORT AND LINER", 3, 23 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "24-OEF-BAF", Direction, null, null, null, null, 0, 0, 0, 0, "OEF", "BAF", 3, 24 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "25-OEF-LINEHAUL", Direction, null, null, null, null, 0, 0, 0, 0, "OEF", "LINEHAUL", 3, 25 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "26-OEF-AIR", Direction, null, null, null, null, 0, 0, 0, 0, "OEF", "AIR", 3, 26 };
                Line.Rows.Add(dr);

                // HHG

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "27-HHG-HHG", Direction, null, null, null, null, 0, 0, 0, 0, "HHG", "HHG", 4, 27 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "28-HHG-PORT AND LINER", Direction, null, null, null, null, 0, 0, 0, 0, "HHG", "PORT AND LINER", 4, 28 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "29-HHG-BAF", Direction, null, null, null, null, 0, 0, 0, 0, "HHG", "BAF", 4, 29 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "30-HHG-LINEHAUL", Direction, null, null, null, null, 0, 0, 0, 0, "HHG", "LINEHAUL", 4, 30 };
                Line.Rows.Add(dr);

                // FLAG

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "31-FLAG-CARS", Direction, null, null, null, null, 0, 0, 0, 0, "FLAG", "CARS", 5, 31 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "32-FLAG-RORO", Direction, null, null, null, null, 0, 0, 0, 0, "FLAG", "RORO", 5, 32 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "33-FLAG-OTHER", Direction, null, null, null, null, 0, 0, 0, 0, "FLAG", "OTHER", 5, 33 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "34-FLAG-HHG", Direction, null, null, null, null, 0, 0, 0, 0, "FLAG", "HHG", 5, 34 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "35-FLAG-PORT AND LINER", Direction, null, null, null, null, 0, 0, 0, 0, "FLAG", "PORT AND LINER", 5, 35 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "36-FLAG-BAF", Direction, null, null, null, null, 0, 0, 0, 0, "FLAG", "BAF", 5, 36 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "37-FLAG-LINEHAUL", Direction, null, null, null, null, 0, 0, 0, 0, "FLAG", "LINEHAUL", 5, 37 };
                Line.Rows.Add(dr);

                // COMMERCIAL (WWL)

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "38-COMMERCIAL-CONTAINER", Direction, null, null, null, null, 0, 0, 0, 0, "COMMERCIAL", "CONTAINER", 6, 38 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "39-COMMERCIAL-AUTO", Direction, null, null, null, null, 0, 0, 0, 0, "COMMERCIAL", "AUTO", 6, 39 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "40-COMMERCIAL-RORO", Direction, null, null, null, null, 0, 0, 0, 0, "COMMERCIAL", "RORO", 6, 40 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "41-COMMERCIAL-BREAKBULK", Direction, null, null, null, null, 0, 0, 0, 0, "COMMERCIAL", "BREAKBULK", 6, 41 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "42-COMMERCIAL-BAF", Direction, null, null, null, null, 0, 0, 0, 0, "COMMERCIAL", "BAF", 6, 42 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "43-COMMERCIAL-LINEHAUL", Direction, null, null, null, null, 0, 0, 0, 0, "COMMERCIAL", "LINEHAUL", 6, 43 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "78-COMMERICIAL-PORT AND LINER", Direction, null, null, null, null, 0, 0, 0, 0, "COMMERCIAL", "PORT AND LINER", 6, 78 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "44-ARC-COMMERCIAL", Direction, null, null, null, null, 0, 0, 0, 0, "ARC", "COMMERCIAL", 7, 44 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "45-SDDC-SHORTSEA", Direction, null, null, null, null, 0, 0, 0, 0, "SDDC", "SHORTSEA", 7, 44 };
                Line.Rows.Add(dr);

                dr = Line.NewRow();
                dr.ItemArray = new object[] { "46-SDDC-OTO", Direction, null, null, null, null, 0, 0, 0, 0, "SDDC", "OTO", 7, 44 };
                Line.Rows.Add(dr);


                // Break each Category down to Parent and Child
                foreach (DataRow d in Line.Rows)
                {
                    switch (d[0].ToString())
                    {
                        // SDDC
                        case "01-SDDC-AAL": d[10] = "SDDC"; d[11] = "AAL"; d[12] = 1; d[13] = 1; break;
                        case "02-SDDC-LIGHT": d[10] = "SDDC"; d[11] = "LIGHT"; d[12] = 1; d[13] = 2; break;
                        case "03-SDDC-HEAVY": d[10] = "SDDC"; d[11] = "HEAVY"; d[12] = 1; d[13] = 3; break;
                        case "04-SDDC-NOS": d[10] = "SDDC"; d[11] = "NOS"; d[12] = 1; d[13] = 4; break;
                        case "05-SDDC-HELOS": d[10] = "SDDC"; d[11] = "HELOS"; d[12] = 1; d[13] = 5; break;
                        case "06-SDDC-CONTAINERS": d[10] = "SDDC"; d[11] = "CONTAINERS"; d[12] = 1; d[13] = 6; break;
                        case "07-SDDC-PORT AND LINER": d[10] = "SDDC"; d[11] = "PORT AND LINER"; d[12] = 1; d[13] = 7; break;
                        case "08-SDDC-BAF": d[10] = "SDDC"; d[11] = "BAF"; d[12] = 1; d[13] = 8; break;
                        case "09-SDDC-LINEHAUL": d[10] = "SDDC"; d[11] = "LINEHAUL"; d[12] = 1; d[13] = 9; break;
                        case "45-SDDC-SHORTSEA": d[10] = "SDDC"; d[11] = "SHORTSEA"; d[12] = 1; d[13] = 10; break;
                        case "46-SDDC-OTO": d[10] = "SDDC"; d[11] = "OTO"; d[12] = 1; d[13] = 11; break;
                        // FMS
                        case "10-FMS-LIGHT": d[10] = "FMS"; d[11] = "LIGHT"; d[12] = 2; d[13] = 10; break;
                        case "11-FMS-HEAVY": d[10] = "FMS"; d[11] = "HEAVY"; d[12] = 2; d[13] = 11; break;
                        case "12-FMS-NOS": d[10] = "FMS"; d[11] = "NOS"; d[12] = 2; d[13] = 12; break;
                        case "13-FMS-HELOS": d[10] = "FMS"; d[11] = "HELOS"; d[12] = 2; d[13] = 13; break;
                        case "14-FMS-CONTAINERS": d[10] = "FMS"; d[11] = "CONTAINERS"; d[12] = 2; d[13] = 14; break;
                        case "15-FMS-PORT AND LINER": d[10] = "FMS"; d[11] = "PORT AND LINER"; d[12] = 2; d[13] = 15; break;
                        case "16-FMS-BAF": d[10] = "FMS"; d[11] = "BAF"; d[12] = 2; d[13] = 16; break;
                        case "17-FMS-LINEHAUL": d[10] = "FMS"; d[11] = "LINEHAUL"; d[12] = 2; d[13] = 17; break;
                        // OEF
                        case "18-OEF-LIGHT": d[10] = "OEF"; d[11] = "LIGHT"; d[12] = 3; d[13] = 18; break;
                        case "19-OEF-HEAVY": d[10] = "OEF"; d[11] = "HEAVY"; d[12] = 3; d[13] = 19; break;
                        case "20-OEF-NOS": d[10] = "OEF"; d[11] = "NOS"; d[12] = 3; d[13] = 20; break;
                        case "21-OEF-HELOS": d[10] = "OEF"; d[11] = "HELOS"; d[12] = 3; d[13] = 21; break;
                        case "22-OEF-CONTAINERS": d[10] = "OEF"; d[11] = "CONTAINERS"; d[12] = 3; d[13] = 22; break;
                        case "23-OEF-PORT AND LINER": d[10] = "OEF"; d[11] = "PORT AND LINER"; d[12] = 3; d[13] = 23; break;
                        case "24-OEF-BAF": d[10] = "OEF"; d[11] = "BAF"; d[12] = 3; d[13] = 24; break;
                        case "25-OEF-LINEHAUL": d[10] = "OEF"; d[11] = "LINEHAUL"; d[12] = 3; d[13] = 25; break;
                        case "26-OEF-AIR": d[10] = "OEF"; d[11] = "AIR"; d[12] = 3; d[13] = 26; break;
                        // HHG
                        case "27-HHG-HHG": d[10] = "HHG"; d[11] = "HHG"; d[12] = 4; d[13] = 27; break;
                        case "28-HHG-PORT AND LINER": d[10] = "HHG"; d[11] = "PORT AND LINER"; d[12] = 4; d[13] = 28; break;
                        case "29-HHG-BAF": d[10] = "HHG"; d[11] = "BAF"; d[12] = 4; d[13] = 29; break;
                        case "30-HHG-LINEHAUL": d[10] = "HHG"; d[11] = "LINEHAUL"; d[12] = 4; d[13] = 30; break;
                        // FLAG
                        case "31-FLAG-CARS": d[10] = "FLAG"; d[11] = "CARS"; d[12] = 5; d[13] = 31; break;
                        case "32-FLAG-RORO": d[10] = "FLAG"; d[11] = "RORO"; d[12] = 5; d[13] = 32; break;
                        case "33-FLAG-OTHER": d[10] = "FLAG"; d[11] = "OTHER"; d[12] = 5; d[13] = 33; break;
                        case "34-FLAG-HHG": d[10] = "FLAG"; d[11] = "HHG"; d[12] = 5; d[13] = 34; break;
                        case "35-FLAG-PORT AND LINER": d[10] = "FLAG"; d[11] = "PORT AND LINER"; d[12] = 5; d[13] = 35; break;
                        case "36-FLAG-BAF": d[10] = "FLAG"; d[11] = "BAF"; d[12] = 5; d[13] = 36; break;
                        case "37-FLAG-LINEHAUL": d[10] = "FLAG"; d[11] = "LINEHAUL"; d[12] = 5; d[13] = 37; break;
                        // COMMERCIAL (WWL)
                        case "38-COMMERCIAL-CONTAINER": d[10] = "COMMERCIAL"; d[11] = "CONTAINER"; d[12] = 6; d[13] = 38; break;
                        case "39-COMMERCIAL-AUTO": d[10] = "COMMERCIAL"; d[11] = "AUTO"; d[12] = 6; d[13] = 39; break;
                        case "40-COMMERCIAL-RORO": d[10] = "COMMERCIAL"; d[11] = "RORO"; d[12] = 6; d[13] = 40; break;
                        case "41-COMMERCIAL-BREAKBULK": d[10] = "COMMERCIAL"; d[11] = "BREAKBULK"; d[12] = 6; d[13] = 41; break;
                        case "42-COMMERCIAL-BAF": d[10] = "COMMERCIAL"; d[11] = "BAF"; d[12] = 6; d[13] = 42; break;
                        case "43-COMMERCIAL-LINEHAUL": d[10] = "COMMERCIAL"; d[11] = "LINEHAUL"; d[12] = 6; d[13] = 43; break;
                        case "78-COMMERICIAL-PORT AND LINER": d[10] = "COMMERCIAL"; d[11] = "PORT AND LINER"; d[12] = 6; d[13] = 78; break;

                        case "44-ARC-COMMERCIAL": d[10] = "ARC"; d[11] = "COMMERCIAL"; d[12] = 7; d[13] = 44; break;

                        case "99-UNKNOWN": d[10] = "UNKNOWN"; d[11] = "UNKNOWN"; d[12] = 7; d[13] = 99; break;
                        default: 
                            d[10] = "ERROR"; d[11] = "ERROR"; d[12] = 0; d[13] = 0; break;
                    }
                }

                // Merge WWL data
                // NOTE: Cannot use the Merge method because of diffent datatypes from Oracle and SQL Server.  And once
                // loaded cannot change the datatype of the datatable.
                if (WWL.Rows.Count > 0)
                {
                    foreach (DataRow drWWL in WWL.Rows)
                    {
                        dr = Line.NewRow();
                        dr.ItemArray = new object[] { drWWL[0], drWWL[1], drWWL[2], drWWL[3], drWWL[4], drWWL[5], drWWL[6], drWWL[7], drWWL[8], drWWL[9], drWWL[10], drWWL[11], drWWL[12], drWWL[13], drWWL[14], drWWL[15], drWWL[16], drWWL[17], drWWL[18], drWWL[19], drWWL[22], drWWL[21], drWWL[23], drWWL[24], drWWL[25], drWWL[26] };
                        Line.Rows.Add(dr);
                    }
                }
                return Line;
            }
            else
            {
                if (WWL != null) return WWL;
            }

            return null;
        }

        public bool TestLineConnection()
        {
            if (ClsConMgr.Manager["LINE"] == null)
            {
                ConnectionStringSettings cns = ConfigurationManager.ConnectionStrings["LINE"];

                ClsConMgr.Manager.AddConnection(
                    "LINE", 
                    cns.ProviderName, 
                    cns.ConnectionString,
                    "line-edi-user", 
                    "dg20100512", 
                    null);
            }
            
            ClsConnection cn = ClsConMgr.Manager["LINE"];
            string sql = "Select CURRENT_TIMESTAMP";
            if( cn.GetScalar(sql) == null ) return false;

            return true;
        }

        public bool TestWWLConnection()
        {
            if (ClsConMgr.Manager["ODS"] == null)
            {
                ConnectionStringSettings cns = ConfigurationManager.ConnectionStrings["ODS"];

                ClsConMgr.Manager.AddConnection(
                    "ODS",
                    cns.ProviderName,
                    cns.ConnectionString,
                    "ods",
                    "ods_user",
                    null);
            }

            ClsConnection cn = ClsConMgr.Manager["ODS"];
            string sql = "Select SYSDATE from DUAL";
            if (cn.GetScalar(sql) == null) return false;

            return true;
        }

        public List<LineWWLMergedSummary> GetSummary(DataTable MergedDataTable)
        {
            var results = from row in MergedDataTable.AsEnumerable()
                          let a = new
                          {
                              GroupParent = row[10].ToString(),
                              GroupChild = row[11].ToString(),
                              YearMon = row[24].ToString(),
                              YearQtr = row[25].ToString()
                          }
                          group row by a into b
                          select new LineWWLMergedSummary()
                          {
                              GroupParent = b.Key.GroupParent,
                              GroupChild = b.Key.GroupChild,
                              YearMon = b.Key.YearMon,
                              YearQtr = b.Key.YearQtr,
                              Weight = b.Sum(row => row[6].ToDouble()),
                              Packages = b.Sum(row => row[7].ToDouble()),
                              Rate = b.Sum(row => row[8].ToDouble()),
                              Cubic_Meters = b.Sum(row => row[9].ToDecimal())
                          };

            return results.ToList();
        }

        public List<LineWWLMergedSummary> GetPortPairSummary(DataTable MergedDataTable)
        {
            var results = from row in MergedDataTable.AsEnumerable()
                          let a = new
                          {
                              PortPair = string.Format("{0} - {1}",row[22].ToString(), row[23].ToString()),
                              GroupParent = row[10].ToString(),
                              GroupChild = row[11].ToString(),
                              YearMon = row[24].ToString(),
                              YearQtr = row[25].ToString()
                          }
                          group row by a into b
                          select new LineWWLMergedSummary()
                          {
                              PortPair = b.Key.PortPair,
                              GroupParent = b.Key.GroupParent,
                              GroupChild = b.Key.GroupChild,
                              YearMon = b.Key.YearMon,
                              YearQtr = b.Key.YearQtr,
                              Weight = b.Sum(row => row[6].ToDouble()),
                              Packages = b.Sum(row => row[7].ToDouble()),
                              Rate = b.Sum(row => row[8].ToDouble()),
                              Cubic_Meters = b.Sum(row => row[9].ToDecimal())
                          };

            return results.ToList();
        }

        public List<LineWWLMergedSummary> GetPortFlowSummary(DataTable MergedDataTable)
        {
            // Get POL
            var resultsPOL = (from row in MergedDataTable.AsEnumerable()
                          let a = new
                          {
                              Port =  row[22].ToString(),
                              GroupParent = row[10].ToString(),
                              GroupChild = row[11].ToString(),
                              YearMon = row[24].ToString(),
                              YearQtr = row[25].ToString()
                          }
                          group row by a into b
                          select new LineWWLMergedSummary()
                          {
                              Port = b.Key.Port,
                              GroupParent = b.Key.GroupParent,
                              GroupChild = b.Key.GroupChild,
                              YearMon = b.Key.YearMon,
                              YearQtr = b.Key.YearQtr,
                              Weight = b.Sum(row => row[6].ToDouble()),
                              Packages = b.Sum(row => row[7].ToDouble()),
                              Rate = b.Sum(row => row[8].ToDouble()),
                              Cubic_Meters = b.Sum(row => row[9].ToDecimal())
                          }).ToList();

            // Get POD
            var resultsPOD = (from row in MergedDataTable.AsEnumerable()
                          let a = new
                          {
                              Port = row[23].ToString(),
                              GroupParent = row[10].ToString(),
                              GroupChild = row[11].ToString(),
                              YearMon = row[24].ToString(),
                              YearQtr = row[25].ToString()
                          }
                          group row by a into b
                          select new LineWWLMergedSummary()
                          {
                              Port = b.Key.Port,
                              GroupParent = b.Key.GroupParent,
                              GroupChild = b.Key.GroupChild,
                              YearMon = b.Key.YearMon,
                              YearQtr = b.Key.YearQtr,
                              Weight = b.Sum(row => row[6].ToDouble()),
                              Packages = b.Sum(row => row[7].ToDouble()),
                              Rate = b.Sum(row => row[8].ToDouble()),
                              Cubic_Meters = b.Sum(row => row[9].ToDecimal())
                          }).ToList();


            foreach (LineWWLMergedSummary s in resultsPOD) resultsPOL.Add(s);

            var results =
                from rowPOL in resultsPOL
                let a = new
                {
                    Port = rowPOL.Port,
                    GroupParent = rowPOL.GroupParent,
                    GroupChild = rowPOL.GroupChild,
                    YearMon = rowPOL.YearMon,
                    YearQtr = rowPOL.YearQtr
                }
                group rowPOL by a into b
                select new LineWWLMergedSummary()
                          {
                              Port = b.Key.Port,
                              GroupParent = b.Key.GroupParent,
                              GroupChild = b.Key.GroupChild,
                              YearMon = b.Key.YearMon,
                              YearQtr = b.Key.YearQtr,
                              Weight = b.Sum(g => g.Weight.ToDouble()),
                              Packages = b.Sum(g => g.Packages.ToDouble()),
                              Rate = b.Sum(g => g.Rate.ToDouble()),
                              Cubic_Meters = b.Sum(g => g.Cubic_Meters.ToDecimal())
                          };
                                                             
            return results.ToList();
        }
    }

    public struct ActualVsBudgetParams
    {
        public string FilterText
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                // Sail Dates
                if (_StartDt.IsNotNull() && _EndDt.IsNotNull())
                {
                    sb.AppendFormat("Sail Dates: From {0:MM/dd/yyyy} To {1:MM/dd/yyyy} - ", _StartDt, _EndDt);
                }
                else if (_StartDt.IsNotNull() && _EndDt.IsNull())
                {
                    sb.AppendFormat("Sail Dates: From {0:MM/dd/yyyy} - ", _StartDt);
                }
                else if (_StartDt.IsNull() && _EndDt.IsNotNull())
                {
                    sb.AppendFormat("Sail Dates:  To {0:MM/dd/yyyy} - ", _EndDt);
                }

                sb.AppendFormat("Direction: {0} - ", DirectionText);

                sb.AppendFormat("WWL Service: {0} - ", ServiceText);

                if (_LineService.IsNull())
                    sb.AppendFormat("LINE Service: ALL - ");
                else
                    sb.AppendFormat("LINE Service: {0} - ", _LineService);

                if (Voyage.IsNotNull())
                    sb.AppendFormat("Voyage: {0} - ", Voyage);

                if (Bol.IsNotNull())
                    sb.AppendFormat("B/L #: {0} - ", Bol);

                return sb.ToString();

            }
        }
        
        
        private string _DirectionInd;
        /// <summary>
        /// Direction Indicator for Voyage direction ...
        /// Values are E=Eastbound, W=Westbound, O=Other
        /// </summary>
        public string DirectionInd
        {
            get { return _DirectionInd; }
            set { _DirectionInd = value; }
        }

        public string DirectionText
        {
            get
            {
                if (DirectionInd == "E") return "EASTBOUND";
                if (DirectionInd == "W") return "WESTBOUND";
                if (DirectionInd == "O") return "OTHER";
                return "BOTH";
            }
        }

        private DateTime? _StartDt;

        public DateTime? StartDt
        {
            get { return _StartDt; }
            set { _StartDt = value; }
        }

        private DateTime? _EndDt;

        public DateTime? EndDt
        {
            get { return _EndDt; }
            set { _EndDt = value; }
        }

        private string _Voyage;

        public string Voyage
        {
            get { return _Voyage; }
            set { _Voyage = value; }
        }

        private string _Bol;

        public string Bol
        {
            get { return _Bol; }
            set { _Bol = value; }
        }

        private string _SeviceInd;

        public string ServiceInd
        {
            get { return _SeviceInd; }
            set { _SeviceInd = value; }
        }

        private string _LineService;

        public string LineService
        {
            get { return _LineService; }
            set { _LineService = value; }
        }

        public string ServiceText
        {
            get
            {
                if (_SeviceInd == "E") return "EUROPE";
                if (_SeviceInd == "M") return "MIDDLE EAST";
                return "ALL";
            }
        }

    }

    public class LineWWLMergedSummary
    {
        public string GroupParent { get; set; }
        public string GroupChild { get; set; }
        public double Weight { get; set; }
        public double Packages { get; set; }
        public double Rate { get; set; }
        public decimal Cubic_Meters { get; set; }
        public string PortPair { get; set; }
        public string Port { get; set; }
        public string YearMon { get; set; }
        public string YearQtr { get; set; }
    }
}
