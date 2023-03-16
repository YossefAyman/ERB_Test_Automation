using Aspose.Pdf.Operators;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Windows.Forms;
using TestAutomationDbModels;
namespace TestAutomationDbDataAccess
{
    public static class TestConfig
    {
        public static List<TestAutomationDbModels.TestConfig> BasicGetList(string key = null )
        {
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            //connetionString = "Data Source=DBSERVER\\TEST;  Initial Catalog=TestAutomation;User ID=sa;Password=Boniansatest@cc";

            connetionString = WebConfigurationManager.AppSettings["ConnectString"];

            sql = "SELECT dbo.TestConfig.[Key], dbo.TestConfig.Value FROM dbo.TestConfig";
            if (key != null)
            {
                sql += " where [key] = '" + key + "'";
            }
            connection = new SqlConnection(connetionString);
            List<TestAutomationDbModels.TestConfig> testConfigList = new List<TestAutomationDbModels.TestConfig>();
            TestAutomationDbModels.TestConfig testConfig = new TestAutomationDbModels.TestConfig();   
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    testConfig = new TestAutomationDbModels.TestConfig();
                    if (dataReader["Value"] != DBNull.Value)
                    {
                        testConfig.Key = dataReader["Key"].ToString();
                        testConfig.Value = dataReader["Value"].ToString();
                    }
                    testConfigList.Add(testConfig);
                    //MessageBox.Show(dataReader.GetValue(0) + " - " + dataReader.GetValue(1));
                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex);
            }

            return testConfigList;
        }

        public static List<TestAutomationDbModels.TestConfig> GetList()
        {
            return BasicGetList();
        }
        public static TestAutomationDbModels.TestConfig Get(string key)
        {
            List<TestAutomationDbModels.TestConfig> TestConfigList = BasicGetList(key);
            return TestConfigList.Any() ? TestConfigList.First() : null;
        }

        public static void UpdateValueForSpacificKey(TestAutomationDbModels.TestConfig config_test)
        {
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            string new_Set_Value = (int.Parse(config_test.Value) +1).ToString();

            connetionString = WebConfigurationManager.AppSettings["ConnectString"];

            if (config_test != null)
            {
                sql = "update dbo.TestConfig set value = '" + new_Set_Value + "' where [key] = '" + config_test.Key + "'" ;
            }
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                command.ExecuteReader();
                command.Dispose();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex);
            }


        }

    }
}