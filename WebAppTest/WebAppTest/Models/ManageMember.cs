using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppTest.Models
{
    public class ManageMember
    {
        public int ID { set; get; }

        [Required(ErrorMessage = "You can input first name.")]
        [Display(Name = "First Name")]
        public string first_name { set; get; }

        [Required(ErrorMessage = "You can input sur name.")]
        [Display(Name = "Sur Name")]
        public string surname { set; get; }

        [Required(ErrorMessage = "You can input email.")]
        [Display(Name = "Email")]
        public string email { set; get; }
    }

    class MemberList
    {
        DBConnection db;
        public MemberList()
        {
            db = new DBConnection();
        }

        public List<ManageMember> getMember(string ID)
        {
            string sql;
            if (string.IsNullOrEmpty(ID))
            {
                sql = "SELECT * FROM members";
            }
            else
            {
                sql = "SELECT * FROM members WHERE Id = " + ID;
            }

            List<ManageMember> strList = new List<ManageMember>();
            SqlConnection con = db.GetConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            // open connect
            con.Open();
            cmd.Fill(dt);

            //close connect
            cmd.Dispose();
            con.Close();

            ManageMember strMB;
            for(int i = 0; i<dt.Rows.Count; i++)
            {
                strMB = new ManageMember();
                strMB.ID = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
                strMB.first_name = dt.Rows[i]["first_name"].ToString();
                strMB.surname = dt.Rows[i]["surname"].ToString();
                strMB.email = dt.Rows[i]["email"].ToString();

                strList.Add(strMB);
            }

            return strList;

        }

        // insert member
        public void AddMembers(ManageMember strMB)
        {
            string sql = "INSERT INTO members(first_name, surname, email)VALUES(N'"+strMB.first_name+"', N'"+strMB.surname+"', N'"+strMB.email+"')";
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            // open connect
            con.Open();
            cmd.ExecuteNonQuery();

            //close connect
            cmd.Dispose();
            con.Close();
        }

        //update data
        public void UpdateMembers(ManageMember strMB)
        {
            string sql = "UPDATE member SET first_name = N'"+strMB.first_name+"', surname = N'"+strMB.surname+"', email = '"+strMB.email+"' ";
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            // open connect
            con.Open();
            cmd.ExecuteNonQuery();

            //close connect
            cmd.Dispose();
            con.Close();
        }
    }
}