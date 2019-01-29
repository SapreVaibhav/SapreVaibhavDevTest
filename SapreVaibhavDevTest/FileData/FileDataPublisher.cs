using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileDataController;
using System.Configuration;

namespace FileData
{
    /// <summary>
    /// FileDataPublisher access the FileDataController to get FileData
    /// </summary>
    class FileDataPublisher
    {
        FileDataProcessor oFileDataProcessor = new FileDataProcessor();
        string strInput = "";
        string strResult = "";
        string[] arrVersion = ConfigurationSettings.AppSettings["VersionCollection"].Split(',');
        string[] arrSize = ConfigurationSettings.AppSettings["SizeCollection"].Split(',');

        internal void GenerateFileData()
        {
            try
            {
                Console.WriteLine("Please provide Inputs: ");
                strInput = Console.ReadLine();
                Console.WriteLine();

                strResult = oFileDataProcessor.ProcessFileData(strInput,arrVersion,arrSize);
                Console.WriteLine(strResult);

                Console.WriteLine();
                Console.WriteLine("Do you want perform action again?{Y/N}");
                string strYN = Console.ReadLine();
                Console.WriteLine();

                if(strYN == "Y" || strYN == "y" )
                {
                    GenerateFileData();
                }
                else 
                {
                    Environment.Exit(0);
                }
                    
            }
            catch(Exception Ex)
            {
                Console.WriteLine(ConfigurationSettings.AppSettings["CustomErrorMsg"]);
                GenerateFileData();
            }
        }

        
    }
}
