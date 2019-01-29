using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileDataController;
using System.Configuration;

namespace FileDataControllerTest
{
    [TestClass]
    public class FileDataProcessorTest
    {
        FileDataProcessor oFileDataProcessor = new FileDataProcessor();
        string strOutPut = null;
        string[] arrVersion = Convert.ToString("-v,--v,/v,--version").Split(',');
        string[] arrSize = Convert.ToString("-s,--s,/s,--size").Split(',');


        [TestMethod]
        public void ProcessFileDataValidVersion()
        {
            strOutPut = oFileDataProcessor.ProcessFileData("-v c:/demo.txt",arrVersion,arrSize);
            Assert.IsTrue(strOutPut.Contains("File Version"));
        }

        [TestMethod]
        public void ProcessFileDataValidSize()
        {
            strOutPut = oFileDataProcessor.ProcessFileData("-s c:/demo.txt", arrVersion, arrSize);
            Assert.IsTrue(strOutPut.Contains("File Size"));
        }

        [TestMethod]
        public void ProcessFileDataInValidVersion()
        {
            strOutPut = oFileDataProcessor.ProcessFileData("version c:/demo.txt", arrVersion, arrSize);
            Assert.IsFalse(strOutPut.Contains("File Version")); 
        }

        [TestMethod]
        public void ProcessFileDataInValidSize()
        {
            strOutPut = oFileDataProcessor.ProcessFileData("version c:/demo.txt", arrVersion, arrSize);
            Assert.IsFalse(strOutPut.Contains("File Size"));
        }
    }
}
