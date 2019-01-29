using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyTools;

namespace FileDataController
{
    /// <summary>
    /// FileDataProcessor class to process Input params
    /// </summary>
    public class FileDataProcessor : IFileDataProcessor
    {
        string strReturnData = "";

        public string ProcessFileData(string strInParam, string[] arVersion, string[] arSize)
        {
            try
            {
                string[] strParam = strInParam.Split(' ');
                FileDetails oFileDetails = new FileDetails();

                //string[] arrVersion = ConfigurationSettings.AppSettings["VersionCollection"].Split(',');
                //string[] arrSize = ConfigurationSettings.AppSettings["SizeCollection"].Split(',');

                //string[] arrVersion = Convert.ToString("-v,--v,/v,--version").Split(',');
                //string[] arrSize = Convert.ToString("-s,--s,/s,--size").Split(',');

                if (strInParam.Length < 2)
                {
                    strReturnData = "Please, enter valid Inputs.";
                }
                else if (arSize.Contains(strParam[0].ToLower()))
                {
                    strReturnData = String.Concat("File Size: ", Convert.ToString(oFileDetails.Size(strParam[1].Trim())));
                }
                else if (arVersion.Contains(strParam[0].ToLower()))
                {
                    strReturnData = String.Concat("File Version: ", oFileDetails.Version(strParam[1].Trim()));
                }
            }
            catch(Exception Ex)
            {
                //strReturnData = ConfigurationSettings.AppSettings["CustomErrorMsg"];
                strReturnData = "Some error has occured. Please, try again.";
            }

            return strReturnData;

        }

    }
}
