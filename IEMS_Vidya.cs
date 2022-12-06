using System;
using System.Data;

namespace EMS_ClassLib
{
    internal interface IEMS_Vidya
    {
        int InsertDepartment(string connectionName, string deptId, string deptName, string deptLoc);
        int InsertEmployee(string connectionName, int empNum, string empFName, string empLName, DateTime empDob, DateTime empDoj, int empSalry, string empDeptId);
        int InsertDependent(string connectionName, int dpdntEmpNum, string dpndntName, string dpndtGender, DateTime dpndtDob, string dpdpntReltn);

        DataSet GetDepartmentById(string connectionName, string deptId);
        DataSet GetEmployeeById(string connectionName, int empNum);
        DataSet GetDependentById(string connectionName, int empNum, string dpdtName);
        DataSet fetchData(string connectionName,string tblName);
        int UpdateDepartment(string connectionName, string deptId, string deptname, string deptLoct);
        int UpdateEmployee(string connectionName, int empNum, string empFName, string empLName, DateTime empDob, DateTime empDoj, int empSalry, string deptmId);
        int UpdateDependent(string connectionName, int empNumb, string dpndntName, string dpndntGndr, DateTime dpndntDob, string dpdpntReltn);
        int DeleteDepartment(string connectionName, string deptId);
        int DeleteEmployee(string connectionName, int empId);
        int DeleteDependent(string connectionName, int empNum, string dpdntName);

    }
}
