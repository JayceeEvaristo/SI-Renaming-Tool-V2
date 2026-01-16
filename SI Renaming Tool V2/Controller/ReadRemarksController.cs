using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Vml.Office;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Renaming_Tool_V2.Controller
{
    public class ReadRemarksController
    {

        public bool IsIemms(string remark)
        {
            if (remark.ToUpper().Contains("IEMMS"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetRemarkType(string stlRun)
        {

            string remarkType = "";
            if(stlRun.ToUpper().ToArray()[0] == 'R')
            {
                remarkType = "RF";
            }
            else if (stlRun.ToUpper().ToArray()[0] == 'F')
            {
                remarkType = "WF";
            }

            return remarkType;
        }

        public string GetStlRun(string stlRun, string remarkType, bool isIemms)
        {
            /*
            TS - RF / WF / WAD
            WF = Regular Energy, STL_RUN = F
            RF = Regular Reserve, STL_RUN = R

            WF = IEMMS Energy, STL_RUN = F1
            RF = IEMMS Reserve, STL_RUN = R1 */

            string newStlRun = "";

            if (remarkType == "WAD")
            {
                newStlRun = "F";
            }
            else
            {
                if (!isIemms)
                {
                    if (remarkType == "WF")
                    {
                        newStlRun = "F";
                    }
                    else if (remarkType == "RF")
                    {
                        if (stlRun.Contains("R"))
                        {
                            char[] chars = stlRun.ToCharArray();
                            chars[0] = 'F';

                            newStlRun = new string(chars);
                        }
                        else
                        {
                            newStlRun = stlRun;
                        }
                    }
                }
                else
                {
                    if (remarkType == "WF")
                    {
                        newStlRun = "F";
                    }
                    else if (remarkType == "RF")
                    {
                        if (stlRun.Contains("R"))
                        {
                            char[] chars = stlRun.ToCharArray();
                            chars[0] = 'F';

                            newStlRun = chars[0].ToString();
                        }
                        else
                        {
                            newStlRun = stlRun;
                        }
                    }
                }
            }


            // di pa sure if tama
            /* if (remarkType == "WF" || remarkType == "RF")
            {
                char[] chars = stlRun.ToCharArray();
                newStlRun = chars[0].ToString();
            }

            if (remarkType == "WAD")
            {
                if (stlRun.Contains("R"))
                {
                    char[] chars = stlRun.ToCharArray();
                    chars[0] = 'F';

                    newStlRun = chars.ToString();
                }
                else
                {
                    newStlRun = stlRun;
                }
            }*/

            return newStlRun;
        }

        public string GetMarketFeeType(bool isIemms, string remarkType, string origStlRun)
        {
            /*
            LAST SUFFIX OF PDF FILE-- MF or RMF or MF1 or RMF1
            MF = Regular Energy, STL_RUN = F
            RF = Regular Reserve, STL_RUN = R

            MF1 = IEMMS Energy, STL_RUN = F1
            RMF1 = IEMMS Reserve, STL_RUN = R1 */
            string marketFeeType = "";
            string numberSuffix = isIemms ? "1" : "";

            if (remarkType == "WAD")
            {
                if (origStlRun.ToCharArray()[0] == 'R')
                {
                    marketFeeType = "RMF";
                }
                else
                {
                    marketFeeType = "MF";
                }
            }
            else
            {
                if (remarkType.ToCharArray()[0] == 'R')
                {
                    marketFeeType = "RMF" + numberSuffix;
                }
                else if (remarkType.ToCharArray()[0] == 'W')
                {
                    marketFeeType = "MF" + numberSuffix;
                }
            }

            /*
            if (remarkType == "WAD")
            {
                marketFeeType = "MF";
            }
            else if (remarkType == "RF")
            {
                if (remark.ToUpper().Contains("IEMMS"))
                {
                    marketFeeType = "RMF1";
                }
                else
                {
                    marketFeeType = "RMF";
                }
            }
            else if (remarkType == "WF")
            {
                if(remark.ToUpper().Contains("IEMMS"))
                {
                    marketFeeType = "MF1";
                }
                else
                {
                    marketFeeType = "MF";
                }
            } */

            return marketFeeType;

        }

        #region GetMarketFeeType
        public string Backup2GetMarketFeeType(bool isIemms, string remarkType, string origStlRun)
        {
            /*
            LAST SUFFIX OF PDF FILE-- MF or RMF or MF1 or RMF1
            MF = Regular Energy, STL_RUN = F
            RF = Regular Reserve, STL_RUN = R

            MF1 = IEMMS Energy, STL_RUN = F1
            RMF1 = IEMMS Reserve, STL_RUN = R1 */
            string marketFeeType = "";
            string numberSuffix = isIemms ? "1" : "";

            if (remarkType == "WAD")
            {
                if (origStlRun.ToCharArray()[0] == 'R')
                {
                    marketFeeType = "RMF";
                }
                else
                {
                    marketFeeType = "MF";
                }
            }
            else
            {
                if (remarkType.ToCharArray()[0] == 'R')
                {
                    marketFeeType = "RMF" + numberSuffix;
                }
                else if (remarkType.ToCharArray()[0] == 'W')
                {
                    marketFeeType = "MF" + numberSuffix;
                }
            }





            /*
            if (remarkType == "WAD")
            {
                marketFeeType = "MF";
            }
            else if (remarkType == "RF")
            {
                if (remark.ToUpper().Contains("IEMMS"))
                {
                    marketFeeType = "RMF1";
                }
                else
                {
                    marketFeeType = "RMF";
                }
            }
            else if (remarkType == "WF")
            {
                if(remark.ToUpper().Contains("IEMMS"))
                {
                    marketFeeType = "MF1";
                }
                else
                {
                    marketFeeType = "MF";
                }
            } */

            return marketFeeType;

        }

        public string Backup_GetMarketFeeType(string remarkType, string stlRun, string remark, string origStlRun)
        {
            /*
            LAST SUFFIX OF PDF FILE-- MF or RMF or MF1 or RMF1
            MF = Regular Energy, STL_RUN = F
            RF = Regular Reserve, STL_RUN = R

            MF1 = IEMMS Energy, STL_RUN = F1
            RMF1 = IEMMS Reserve, STL_RUN = R1 */
            string marketFeeType = "";
            if (remarkType == "WAD")
            {
                if (origStlRun.ToCharArray()[0] == 'R')
                {
                    marketFeeType = "RMF";
                }
                else
                {
                    marketFeeType = "MF";
                }
            }
            if (stlRun == "F")
            {
                marketFeeType = "MF";
            }
            else if (stlRun == "F1")
            {
                marketFeeType = "MF1";
            }
            else if (stlRun == "R")
            {
                marketFeeType = "RMF";
            }
            else if (stlRun == "R1")
            {
                marketFeeType = "RMF1";

            }




            /*
            if (remarkType == "WAD")
            {
                marketFeeType = "MF";
            }
            else if (remarkType == "RF")
            {
                if (remark.ToUpper().Contains("IEMMS"))
                {
                    marketFeeType = "RMF1";
                }
                else
                {
                    marketFeeType = "RMF";
                }
            }
            else if (remarkType == "WF")
            {
                if(remark.ToUpper().Contains("IEMMS"))
                {
                    marketFeeType = "MF1";
                }
                else
                {
                    marketFeeType = "MF";
                }
            } */

            return marketFeeType;

        }
        #endregion

        #region GetStlRun
        public string BackupGetStlRun(string stlRun, string remarkType, bool isIemms)
        {
            /*
            TS - RF / WF / WAD
            WF = Regular Energy, STL_RUN = F
            RF = Regular Reserve, STL_RUN = R

            WF = IEMMS Energy, STL_RUN = F1
            RF = IEMMS Reserve, STL_RUN = R1 */

            string newStlRun = "";

            if (remarkType == "WAD")
            {
                newStlRun = "F";
            }
            else
            {
                if (!isIemms)
                {
                    if (remarkType == "WF")
                    {
                        newStlRun = "F";
                    }
                    else if (remarkType == "RF")
                    {
                        if (stlRun.Contains("R"))
                        {
                            char[] chars = stlRun.ToCharArray();
                            chars[0] = 'F';

                            newStlRun = new string(chars);
                        }
                        else
                        {
                            newStlRun = stlRun;
                        }
                    }
                }
                else
                {
                    if (remarkType == "WF")
                    {
                        newStlRun = "F1";
                    }
                    else if (remarkType == "RF")
                    {
                        if (stlRun.Contains("R"))
                        {
                            char[] chars = stlRun.ToCharArray();
                            chars[0] = 'F';

                            newStlRun = new string(chars);
                        }
                        else
                        {
                            newStlRun = stlRun;
                        }
                    }
                }
            }


            // di pa sure if tama
            /* if (remarkType == "WF" || remarkType == "RF")
            {
                char[] chars = stlRun.ToCharArray();
                newStlRun = chars[0].ToString();
            }

            if (remarkType == "WAD")
            {
                if (stlRun.Contains("R"))
                {
                    char[] chars = stlRun.ToCharArray();
                    chars[0] = 'F';

                    newStlRun = chars.ToString();
                }
                else
                {
                    newStlRun = stlRun;
                }
            }*/

            return newStlRun;
        }
        #endregion

        #region GetRemarkType
        public string BackupGetRemarkType(string remark, string stlRun)
        {

            string remarkType = "";
            string finalRemarkType = "";
            string firstChar = "";
            string secondChar = "";

            if (remark.ToUpper().Contains("ADJUSTMENT"))
            {
                finalRemarkType = "WAD";
            }
            else
            {
                if (remark.ToUpper().Contains("WESM"))
                {
                    firstChar = "W";
                }
                else
                {
                    firstChar = "R";
                }

                if (stlRun.ToUpper().Contains("F") || stlRun.ToUpper().Contains("R"))
                {
                    secondChar = "F";
                }
                else
                {
                    secondChar = "P";
                }

                finalRemarkType = firstChar + secondChar;
            }

            remarkType = finalRemarkType;

            return remarkType;
        }
        #endregion
    }
}
