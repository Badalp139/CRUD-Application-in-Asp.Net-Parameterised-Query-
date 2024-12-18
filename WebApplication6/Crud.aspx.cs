using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication6
{
    public partial class Crud : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection("data source=LAPTOP-P4KQMG8A\\SQLEXPRESS07;initial catalog=demo;integrated security=true");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                string query = "insert into employe2(empid,name,salary,city)values(@empid,@name,@salary,@city)";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@empid", txtEmpId.Text);
                cmd.Parameters.AddWithValue("@name", txtEmpName.Text);
                cmd.Parameters.AddWithValue("@salary", txtSalary.Text);
                cmd.Parameters.AddWithValue("@city", txtCity.Text);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    lblMessage.Text = "Record Update sucessful";
                }
                else
                {
                    lblMessage.Text = "record not inserted";
                    cn.Close();
                }


            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                string query = "update employe2 set salary=@salary,empid=@empid,name=@name,city=@city where empid=@empid";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@salary", txtSalary.Text);
                cmd.Parameters.AddWithValue("@name", txtEmpName.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@empid", txtEmpId.Text);
                int result = cmd.ExecuteNonQuery();
                if(result==1)
                {
                    lblMessage.Text = "Record Update Sucessfully";
                }
                else
                {
                    lblMessage.Text = "Record Not Update";
                    cn.Close();
                }


            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                string query = "delete from employe2 where empid=@empid";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@empid", txtEmpId.Text);
                int result = cmd.ExecuteNonQuery();
                if(result==1)
                {
                    lblMessage.Text = "Record Delete sucessful";
                }
                else
                {
                    lblMessage.Text = "Record Not Delete";
                    cn.Close();
                }

            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtEmpName.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtEmpId.Text = string.Empty;
            txtSalary.Text = string.Empty;
            lblMessage.Text = string.Empty;
        }
    }
}