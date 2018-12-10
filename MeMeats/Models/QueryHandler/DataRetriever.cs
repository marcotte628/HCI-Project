using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Web;

namespace HCIProject.Models.DataRetriever
{
    public class DataRetriever
    {
        private ResultParser resultParser = new ResultParser();
        private SqlHandler sqlHandler;
        public string GetAllPatientData()
        {
            // read and collect Data folder for patient data and return
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //
            return "";
        }

        public string GetQueryResult(string procedureName, string[] parameters, object[] values)
        {
            this.sqlHandler = new SqlHandler(procedureName, parameters, values);
            DataTable queryReturn = sqlHandler.Execute();
            var ret = this.resultParser.GetResultString(queryReturn);
            return ret;
        }

        public string GetNoResult()
        {
            var ret = "[{ Query: '...', Table: '...', Shown: '...', Here: '...'},]";
            string currentDirectory = HttpRuntime.AppDomainAppPath + "Data\\Patients.txt";
            string text = System.IO.File.ReadAllText(@currentDirectory);

       

            return text;

        }

       
    }
}