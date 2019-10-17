using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace WebAppTest.Models
{
    public class DBConnection
    {
        string strCon;
        public DBConnection()
        {
            strCon = ConfigurationManager.ConnectionStrings["membersConnectionString"].ConnectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(strCon);
        }
    }
}