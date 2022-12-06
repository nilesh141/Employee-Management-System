using System;
using System.Data.SqlClient;
using System.Data;

namespace EMS_ClassLib
{
    public class EMS_ClasLib_class : IEMS_Vidya
    {
        public int InsertDepartment(string connectionName, string deptId, string deptName, string deptLoc)
        {
            //creating connection using connection string passed from UI layer
            SqlConnection sqlConnection = new SqlConnection(connectionName);
            using (sqlConnection)
            {
                sqlConnection.Open(); //opening connection
                SqlDataAdapter adapter = new SqlDataAdapter(); //creating an  instance of adapter
                adapter.SelectCommand = new SqlCommand("SProc_InsrtDept", sqlConnection);
                adapter.SelectCommand.Parameters.AddWithValue("@deptId", deptId);
                adapter.SelectCommand.Parameters.AddWithValue("@deptName", deptName);
                adapter.SelectCommand.Parameters.AddWithValue("@deptLoctn", deptLoc);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                return adapter.SelectCommand.ExecuteNonQuery(); //returning number of rows affected
                sqlConnection.Close(); //closing connection

            }
        }
        public int InsertEmployee(string connectionName, int empNum, string empFName, string empLName,
            DateTime empDob, DateTime empDoj, int empSalry, string empDeptId)
        {

            //creating connection using connection string passed from UI layer
            SqlConnection sqlConnection = new SqlConnection(connectionName);
            using (sqlConnection)
            {
                sqlConnection.Open(); //opening connection
                SqlDataAdapter adapter = new SqlDataAdapter(); //creating an  instance of adapter
                adapter.SelectCommand = new SqlCommand("SProc_InsrtEmp", sqlConnection);
                adapter.SelectCommand.Parameters.AddWithValue("@empNum", empNum);
                adapter.SelectCommand.Parameters.AddWithValue("@empFName", empFName);
                adapter.SelectCommand.Parameters.AddWithValue("@empLName", empLName);
                adapter.SelectCommand.Parameters.AddWithValue("@empDob", empDob);
                adapter.SelectCommand.Parameters.AddWithValue("@empDoj", empDoj);
                adapter.SelectCommand.Parameters.AddWithValue("@empSalry", empSalry);
                adapter.SelectCommand.Parameters.AddWithValue("@deptId", empDeptId);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                return adapter.SelectCommand.ExecuteNonQuery(); //returning number of rows affected
                sqlConnection.Close(); //closing connection

            }

        }
        public int InsertDependent(string connectionName, int dpdntEmpNum, string dpndntName,
            string dpndtGender, DateTime dpndtDob, string dpdpntReltn)
        {
            //creating connection using connection string passed from UI layer
            SqlConnection sqlConnection = new SqlConnection(connectionName);
            using (sqlConnection)
            {
                sqlConnection.Open(); //opening connection
                SqlDataAdapter adapter = new SqlDataAdapter(); //creating an  instance of adapter
                adapter.SelectCommand = new SqlCommand("SProc_InsrtDpendt", sqlConnection);              
                adapter.SelectCommand.Parameters.AddWithValue("@dpendtName", dpndntName);
                adapter.SelectCommand.Parameters.AddWithValue("@dpendtGender", dpndtGender);
                adapter.SelectCommand.Parameters.AddWithValue("@dpendtDob", dpndtDob);
                adapter.SelectCommand.Parameters.AddWithValue("@dpendtReltn", dpdpntReltn);
                adapter.SelectCommand.Parameters.AddWithValue("@empNum", dpdntEmpNum);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                return adapter.SelectCommand.ExecuteNonQuery(); //returning number of rows affected
                sqlConnection.Close(); //closing connection

            }
        }
        public DataSet GetDepartmentById(string connectionName, string deptId)
        {
            //creating connection using connection string passed from UI layer
            SqlConnection sqlConnection = new SqlConnection(connectionName);
            using (sqlConnection)
            {
                
                SqlDataAdapter adapter = new SqlDataAdapter(); //creating an  instance of adapter
                adapter.SelectCommand = new SqlCommand("SProc_SelectDepartment", sqlConnection);
                adapter.SelectCommand.Parameters.AddWithValue("@dept_Id", deptId);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet dataset = new DataSet(); //creating an instance of dataset
                adapter.Fill(dataset); //populating dataset object
                return dataset;
                

            }

        }
        public DataSet GetEmployeeById(string connectionName, int empNum)
        {
            //creating connection using connection string passed from UI layer
            SqlConnection sqlConnection = new SqlConnection(connectionName);
            using (sqlConnection)
            {
                
                SqlDataAdapter adapter = new SqlDataAdapter(); //creating an  instance of adapter
                adapter.SelectCommand = new SqlCommand("SProc_SelectEmployee", sqlConnection);
                adapter.SelectCommand.Parameters.AddWithValue("@emp_Num", empNum);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet dataset = new DataSet(); //creating an instance of dataset
                adapter.Fill(dataset); //populating dataset object
                return dataset;
                

            }

        }
        public DataSet GetDependentById(string connectionName, int empNum, string dpdtName)
        {
            //creating connection using connection string passed from UI layer
            SqlConnection sqlConnection = new SqlConnection(connectionName);
            using (sqlConnection)
            {
                
                SqlDataAdapter adapter = new SqlDataAdapter(); //creating an  instance of adapter
                adapter.SelectCommand = new SqlCommand("SProc_SelectDependent", sqlConnection);              
                adapter.SelectCommand.Parameters.AddWithValue("@dpdnt_Name", dpdtName);
                adapter.SelectCommand.Parameters.AddWithValue("@emp_Num", empNum);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet dataset = new DataSet(); //creating an instance of dataset
                adapter.Fill(dataset); //populating dataset object
                return dataset;
                

            }
        }
        public DataSet fetchData(string conn, string tblNm)
        {
            SqlConnection sqlConnection = new SqlConnection(conn);
            using (sqlConnection)
            {
                string tblName = tblNm;
                
                string qry = "SELECT * FROM " + tblName; //storing query as string
                //creating an instance of command & passing query(to be executed) & connection string to its constructor
                SqlCommand command = new SqlCommand(qry, sqlConnection);

                //creating an instance of adapter to pass command(to be executed) to its constructor
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataSet dataset = new DataSet(); //creating an instance of dataset
                adapter.Fill(dataset);  //populating dataset object
                return dataset;
                
            }
        }
            public int UpdateDepartment(string connectionName, string deptId, string deptname, string deptLoct)
        {
            //creating connection using connection string passed from UI layer
            SqlConnection sqlConnection = new SqlConnection(connectionName);
            using (sqlConnection)
            {
                sqlConnection.Open(); //opening connection
                SqlDataAdapter adapter = new SqlDataAdapter(); //creating an  instance of adapter
                adapter.SelectCommand = new SqlCommand("SProc_UpdateDepartment", sqlConnection);
                adapter.SelectCommand.Parameters.AddWithValue("@Department_id", deptId);
                adapter.SelectCommand.Parameters.AddWithValue("@Department_Name", deptname);
                adapter.SelectCommand.Parameters.AddWithValue("@Department_Loc", deptLoct);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                return adapter.SelectCommand.ExecuteNonQuery(); //returning number of rows affected
                sqlConnection.Close(); //closing connection

            }
        }
        public int UpdateEmployee(string connectionName, int empNum, string empFName, string empLName,
            DateTime empDob, DateTime empDoj, int empSalry, string deptmId)
        {
            //creating connection using connection string passed from UI layer
            SqlConnection sqlConnection = new SqlConnection(connectionName);
            using (sqlConnection)
            {
                sqlConnection.Open(); //opening connection
                SqlDataAdapter adapter = new SqlDataAdapter(); //creating an  instance of adapter
                adapter.SelectCommand = new SqlCommand("SProc_UpdateEmployee", sqlConnection);
                adapter.SelectCommand.Parameters.AddWithValue("@Emp_num", empNum);
                adapter.SelectCommand.Parameters.AddWithValue("@Emp_Fname", empFName);
                adapter.SelectCommand.Parameters.AddWithValue("@Emp_Lname", empLName);
                adapter.SelectCommand.Parameters.AddWithValue("@Emp_Dob", empDob);
                adapter.SelectCommand.Parameters.AddWithValue("@Emp_Doj", empDoj);
                adapter.SelectCommand.Parameters.AddWithValue("@Emp_Sal", empSalry);
                adapter.SelectCommand.Parameters.AddWithValue("@Dept_Id", deptmId);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                return adapter.SelectCommand.ExecuteNonQuery(); //returning number of rows affected
                sqlConnection.Close(); //closing connection

            }
        }
        public int UpdateDependent(string connectionName, int empNumb, string dpndntName, string dpndntGndr,
            DateTime dpndntDob, string dpdpntReltn)
        {
            //creating connection using connection string passed from UI layer
            SqlConnection sqlConnection = new SqlConnection(connectionName);
            using (sqlConnection)
            {
                sqlConnection.Open(); //opening connection
                SqlDataAdapter adapter = new SqlDataAdapter(); //creating an  instance of adapter
                adapter.SelectCommand = new SqlCommand("SProc_UpdateDependent", sqlConnection);              
                adapter.SelectCommand.Parameters.AddWithValue("@Dpdnt_name", dpndntName);
                adapter.SelectCommand.Parameters.AddWithValue("@Dpdnt_gender", dpndntGndr);
                adapter.SelectCommand.Parameters.AddWithValue("@Dpdnt_dob", dpndntDob);
                adapter.SelectCommand.Parameters.AddWithValue("@Dpdnt_rel", dpdpntReltn);
                adapter.SelectCommand.Parameters.AddWithValue("@Emp_num", empNumb);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                return adapter.SelectCommand.ExecuteNonQuery(); //returning number of rows affected
                sqlConnection.Close(); //closing connection

            }

        }
        public int DeleteDepartment(string connectionName, string deptId)
        {
            //creating connection using connection string passed from UI layer
            SqlConnection sqlConnection = new SqlConnection(connectionName);
            using (sqlConnection)
            {
                sqlConnection.Open(); //opening connection
                SqlDataAdapter adapter = new SqlDataAdapter(); //creating an  instance of adapter
                adapter.SelectCommand = new SqlCommand("SProc_DeleteDepartment", sqlConnection);
                adapter.SelectCommand.Parameters.AddWithValue("@dept_Id", deptId);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                return adapter.SelectCommand.ExecuteNonQuery(); //returning number of rows affected
                sqlConnection.Close();
            }

        }
        public int DeleteEmployee(string connectionName, int empId)
        {
            //creating connection using connection string passed from UI layer
            SqlConnection sqlConnection = new SqlConnection(connectionName);
            using (sqlConnection)
            {
                sqlConnection.Open(); //opening connection
                SqlDataAdapter adapter = new SqlDataAdapter(); //creating an  instance of adapter
                adapter.SelectCommand = new SqlCommand("SProc_DeleteEmployee", sqlConnection);
                adapter.SelectCommand.Parameters.AddWithValue("@Emp_num", empId);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                return adapter.SelectCommand.ExecuteNonQuery(); //returning number of rows affected
                sqlConnection.Close();
            }
        }
        public int DeleteDependent(string connectionName, int empNum, string dpdntName)
        {
            //creating connection using connection string passed from UI layer
            SqlConnection sqlConnection = new SqlConnection(connectionName);
            using (sqlConnection)
            {
                sqlConnection.Open(); //opening connection
                SqlDataAdapter adapter = new SqlDataAdapter(); //creating an  instance of adapter
                adapter.SelectCommand = new SqlCommand("SProc_DeleteDependent", sqlConnection);              
                adapter.SelectCommand.Parameters.AddWithValue("@DpndntName", dpdntName);
                adapter.SelectCommand.Parameters.AddWithValue("@empNum", empNum);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                return adapter.SelectCommand.ExecuteNonQuery(); //returning number of rows affected
                sqlConnection.Close();
            }
        }
    }
}
