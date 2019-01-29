using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDataController
{
    
    public interface IFileDataProcessor
    {
        string ProcessFileData(string strInParam, string[] arVersion, string[] arSize);
    }

}
