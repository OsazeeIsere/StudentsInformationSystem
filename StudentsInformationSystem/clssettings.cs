using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace StudentsInformationSystem
{
    public class clssettings
    {

        private MySql.Data.MySqlClient.MySqlCommand cmcommand;
        //private MySql.Data.MySqlClient.MySqlConnection conconnect1;
        private string strConn = "Server=localhost;Port=3306;Database=studentsrecord;Uid=root;Pwd=prayer;";

        public MySql.Data.MySqlClient.MySqlDataAdapter adadapter;
        public System.Data.DataTable getdatabase(string strcommand)
        {
            System.Data.DataTable tempgetdatabase = null;
            tempgetdatabase = new System.Data.DataTable();
            MySql.Data.MySqlClient.MySqlConnection cn = new MySql.Data.MySqlClient.MySqlConnection();
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter();
            MySql.Data.MySqlClient.MySqlCommand cm = new MySql.Data.MySqlClient.MySqlCommand();
            string strconnection = "";
            strconnection = "Server=localhost;Port=3306;Database=studentsrecord;Uid=root;Pwd=prayer;";
            cn.ConnectionString = strconnection;
            cn.Open();
            cm.CommandText = strcommand;
            ad.SelectCommand = cm;
            cm.Connection = cn;
            System.Data.DataTable dt = new System.Data.DataTable();
            ad.Fill(dt);
            tempgetdatabase = dt;
            cn.Close();
            return tempgetdatabase;
        }
        public void adddata(string strinsert)
        {
            MySql.Data.MySqlClient.MySqlConnection cn = new MySql.Data.MySqlClient.MySqlConnection();
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter();
            MySql.Data.MySqlClient.MySqlCommand cm = new MySql.Data.MySqlClient.MySqlCommand();

            string strconnection = "";
            strconnection = "server= localhost;port=3306;database=studentsrecord;uid=root;pwd=prayer";
            cn.ConnectionString = strconnection;
            cn.Open();
            cm.CommandText = strinsert;
            cm.Connection = cn;
            cm.ExecuteNonQuery();
            cn.Close();
        }
        public System.Data.DataTable getdatatable(string strstatement)
        {
            System.Data.DataTable tempgetdatatable = null;
            // this public function is used to get the records in a particular table in the database
            // an adapter is used to access the records which are then populated into
            // a datatable in memory from where we can work on records as we please
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = strConn;
            tempgetdatatable = new System.Data.DataTable();

            try
            {
                cmcommand = new MySql.Data.MySqlClient.MySqlCommand();
                adadapter = new MySql.Data.MySqlClient.MySqlDataAdapter();
                conn.Open();
                cmcommand.Connection = conn;
                cmcommand.CommandText = strstatement;

                adadapter.SelectCommand = cmcommand;
                adadapter.Fill(tempgetdatatable);
                conn.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();

            }
            finally
            {
                GC.Collect();
            }
            return tempgetdatatable;

        }
        public int getlastid(string strtable, string struser)
        {
            int lastid = 0;

            try
            {
                System.Data.DataTable dtuser = new System.Data.DataTable();

                dtuser = getdatabase("Select * From " + strtable);
                if (dtuser.Rows.Count > 0)
                {
                    lastid = Convert.ToInt32(dtuser.Rows[dtuser.Rows.Count - 1]["userid"]);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            return lastid;
        }

        public void audit(string struser, string strtable, string strcolumn, string strdetails, int intadminid)

        {
            try
            {
                string strinsert = "Insert Into audit(user,table,column,details,adminid) Values ('" + struser + "','" + strtable + "','" + strcolumn + "','" + strdetails + "'," + intadminid + ");";
                AddData(strinsert);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        public void AddData(string strSqlInsert)
        {
            // this sub is used to execute insert sql commmands on the database
            String strconnection = null;
            MySqlDataAdapter adpSqlAdapter;
            adpSqlAdapter = new MySqlDataAdapter();
            try
            {
                MySqlConnection conn = new MySqlConnection();
                strconnection = "server= localhost;port=3306;database=studentsrecord;uid=root;pwd=prayer";
                conn.ConnectionString = strconnection;
                MySqlCommand comCommand;
                comCommand = new MySqlCommand();
                comCommand.CommandText = strSqlInsert;
                conn.Open();
                comCommand.Connection = conn;
                comCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

                ex.ToString();
            }
            finally
            {
                GC.Collect();
            }

        }

    }
}