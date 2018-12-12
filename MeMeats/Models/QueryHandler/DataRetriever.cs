using System;
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

        public string GetQueryResult(string procedureName, string[] parameters, object[] values)
        {
            this.sqlHandler = new SqlHandler(procedureName, parameters, values);
            DataTable queryReturn = sqlHandler.Execute();
            var ret = this.resultParser.GetResultString(queryReturn);
            return ret;
        }

        public string GetPatientData(string pid)
        {
            // get all data from the Data folder
            string patientFile = HttpRuntime.AppDomainAppPath + "Data\\Patients.txt";
            string data = System.IO.File.ReadAllText(@patientFile);

            //break into array based on ,
            string[] patients = data.Split('}');

            //get only the one with pid
            string ret = "{";
            string key = " PID: '" + pid + "'";
            foreach (string patient in patients)
            {
                if (patient.Contains(key))
                {
                    if (patient.StartsWith(","))
                    {
                        ret += patient.Substring(1, patient.Length-1);
                        
                    }
                    else
                    {
                        ret += patient;
                    }
                    
                    break;
                }
            }

            ret += "}}";
            // strip out all data that does not have the given uid
            // organize into json object 
            // send to front
            return ret;

        }

        public string GetAllPatientData()
        {
            var ret = "[";
            string patientFile = HttpRuntime.AppDomainAppPath + "Data\\Patients.txt";
            string data = System.IO.File.ReadAllText(@patientFile);
            ret += data + "]";
            return ret;

        }

        public string CreatePatient(string name, string dob, string height, string weight, string note)
        {
            string patientsFile = HttpRuntime.AppDomainAppPath + "Data\\Patients.txt";
            string data = System.IO.File.ReadAllText(@patientsFile);

            //break into array based on 
            string[] patients = data.Split('}');
            var pid = "" + patients.Length;
            DateTime dateTime = DateTime.UtcNow.Date;
            string newData = "";
            // update the patient 
            for (int i = 0; i < patients.Length; i++)
            {
                    patients[i] += "}";
                    newData += patients[i];
            }

            //build up the new Patients.txt string
            newData = newData.Substring(0, newData.Length - 1);

            // add the new patient info to newData
            newData += "{ Photo: '...', PID: '" + pid + "', Name: '" + name + "', DOB: '" + dob + "', LV: '" + dateTime.ToString("MM/dd/yyyy") + "', Height: '" + height + "', Weight: '" + weight + "', Notes: '" + note + "' },";
            //overwrite file
            System.IO.File.WriteAllText(@patientsFile, newData);
            return GetPatientData(pid);
        }

            public string UpdatePatient(string pid, string name, string dob, string height, string weight, string note)
        {
                string patientsFile = HttpRuntime.AppDomainAppPath + "Data\\Patients.txt";
                string data = System.IO.File.ReadAllText(@patientsFile);

                //break into array based on 
                string[] patients = data.Split('}');
                string key = " PID: '" + pid + "'";
                DateTime dateTime = DateTime.UtcNow.Date;
                string newData = "";
                // update the patient 
                for (int i = 0; i < patients.Length; i++)
                {

                    if (patients[i].Contains(key))
                    {
                        if(i == 0)
                            patients[i] = "{ Photo: '...', PID: '"+ pid +"', Name: '"+ name +"', DOB: '"+ dob +"', LV: '"+ dateTime.ToString("MM/dd/yyyy") + "', Height: '"+ height +"', Weight: '"+ weight +"', Notes: '"+note +"' }";
                        else
                            patients[i] = ",{ Photo: '...', PID: '" + pid + "', Name: '" + name + "', DOB: '" + dob + "', LV: '" + dateTime.ToString("MM/dd/yyyy") + "', Height: '" + height + "', Weight: '" + weight + "', Notes: '" + note + "' }";

                }
                else
                    {
                        patients[i] += "}";
                    }
                    newData += patients[i];
                }

                //build up the new Patients.txt string

                newData = newData.Substring(0, newData.Length - 1);
                //overwrite file
                System.IO.File.WriteAllText(@patientsFile, newData);
                return GetPatientData(pid);

        }
    }
}