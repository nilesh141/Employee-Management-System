using System;
using System.Configuration;
using System.Data;
using EMS_ClassLib;

using static System.Console;
namespace ConsoleApp_EMS_Nilesh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                for (bool exit = false; !exit;)
                {
                    WriteLine("\n\t\t**********Welcome to Employee Management System************\n");
                    WriteLine("\t\t\tBelow are options to choose from \n");
                    WriteLine("\t\t\tPress\n");
                    WriteLine("\t\t\t 1 Add "); //lettting user chose operation to be performed
                    WriteLine("\t\t\t 2 Show ");
                    WriteLine("\t\t\t 3 Update");
                    WriteLine("\t\t\t 4 Delete");
                    WriteLine("\t\t\t 5 Exit");
                    //storing connection string
                    string conn = ConfigurationManager.ConnectionStrings["Conn_EMSDB"].ConnectionString;
                    EMS_ClasLib_class clslibObj = new EMS_ClasLib_class(); //creating an instance of class library
                    int opt1 = int.Parse(ReadLine());
                    switch (opt1)
                    {
                        case 1:
                            WriteLine("\t\t\tNow Press \n");  //Interacting with user to perform operations
                            WriteLine("\t\t\t1  Add a Department");
                            WriteLine("\t\t\t2  Add an Employee");
                            WriteLine("\t\t\t3  Add a dependent to an Employee");
                            int InsOpt = int.Parse(ReadLine());
                            switch (InsOpt)
                            {
                                case 1:
                                    WriteLine("\t\t\tEnter Departmemt ID:"); //fetching data from user
                                    string deptId = ReadLine();
                                    WriteLine("\t\t\tEnter Department name:");
                                    string deptName = ReadLine();
                                    WriteLine("\t\t\tEnter Department Location");
                                    string deptLoc = ReadLine();
                                    //performing the selected operation & giving user friendly message
                                    WriteLine("\t\tResult:" + clslibObj.InsertDepartment(conn, deptId, deptName, deptLoc) + " department added successfully\n");
                                    break;
                                case 2:
                                    WriteLine("\t\t\tEnter Employee number:");
                                    int empNum = int.Parse(ReadLine());
                                    WriteLine("\t\t\tEnter Employee Fist Name:");
                                    string empFName = ReadLine();
                                    WriteLine("\t\t\tEnter Employee Last Name:");
                                    string empLName = ReadLine();
                                    WriteLine("\t\t\tEnter Employee Date of Birth:");
                                    DateTime empDob = DateTime.Parse(ReadLine());
                                    WriteLine("\t\t\tEnter Date of Joining:");
                                    DateTime empDoj = DateTime.Parse(ReadLine());
                                    WriteLine("\t\t\tEnter salary:");
                                    int empSalry = int.Parse(ReadLine());
                                    WriteLine("\t\t\tEnter department ID of the employee");
                                    string empDeptId = ReadLine();
                                    //performing the selected operation by calling method from class libr & giving user friendly message
                                    WriteLine("\t\tResult:" + clslibObj.InsertEmployee(conn, empNum, empFName, empLName, empDob.Date, empDoj.Date, empSalry, empDeptId) + " employee added successfully\n");
                                    break;
                                case 3:
                                    WriteLine("\t\t\tEnter Employee number for whom dependent to be added:");
                                    int dpdntEmpNum = int.Parse(ReadLine());  //gettting user input
                                    WriteLine("\t\t\tEnter dependent name:");
                                    string dpndntName = ReadLine();
                                    WriteLine("\t\t\tEnter gender of dependent:");
                                    string dpndtGender = ReadLine();
                                    WriteLine("\t\t\tEnter dependent Date of Birth:");
                                    DateTime dpndtDob = DateTime.Parse(ReadLine());
                                    WriteLine("\t\t\tEnter relationship with Employee:");
                                    string dpndtReltn = ReadLine();
                                                                                                                   //implementing string interpolation
                                    WriteLine("\t\tResult: "+clslibObj.InsertDependent(conn, dpdntEmpNum, dpndntName, dpndtGender, dpndtDob.Date, dpndtReltn) + $" dependent  added to employee with id {dpdntEmpNum}" + " successfully\n");
                                    break;
                                default:
                                    WriteLine("\t\tResult: Invalid choice please choose correct option\n");
                                    break;
                            }
                            break;
                        case 2:
                            WriteLine("\t\t\tNow Press\n");
                            WriteLine("\t\t\t1 Show Department"); // operation choice selection by user
                            WriteLine("\t\t\t2 Show Employee");
                            WriteLine("\t\t\t3 Show Dependent");
                            int DispOpt = int.Parse(ReadLine());
                            switch (DispOpt)
                            {
                                case 1:
                                    WriteLine("\t\t\tNow Press\n");
                                    WriteLine("\t\t\t1 Show Department for a Id:");
                                    WriteLine("\t\t\t2 Show All Department");
                                    int DisType = int.Parse(ReadLine());
                                    switch (DisType)
                                    {
                                        case 1:
                                            WriteLine("\t\t\tEnter Department ID:");//gettting user input
                                            string deptID = ReadLine(); //personal comment->be careful while passing arguement to method
                                            WriteLine("\t\t***** Department Data******\n");
                                            WriteLine("\t\t\t\tDepartment_ID \t Department_Name\t Department_Location\n");
                                            foreach (DataRow row in clslibObj.GetDepartmentById(conn, deptID).Tables[0].Rows)  //reading data from dataset table 1 by 1
                                            {
                                                WriteLine("\t\t\t\t{0}\t\t{1}\t\t{2}", row[0], row[1], row[2]);   //dataset table is returned by GetDepartmentById method so iterating to datatable
                                            }
                                            break;
                                        case 2:
                                            WriteLine("\t\t***** Department Data******\n");
                                            WriteLine("\t\t\t\tDepartment_ID \t Department_Name\t Department_Location\n");
                                            foreach (DataRow row in clslibObj.fetchData(conn, "Department_Nilesh").Tables[0].Rows)  //reading data from dataset table 1 by 1
                                            {
                                                WriteLine("\t\t\t\t{0}\t\t{1}\t\t{2}", row[0], row[1], row[2]);
                                            }
                                            break;
                                        default:
                                            WriteLine("\t\tResult: Invalid choice please choose correct option\n");
                                            break;
                                    }
                                    break;
                                case 2:
                                    WriteLine("\t\t\tNow Press\n");
                                    WriteLine("\t\t\t1 Show Employee using Id");
                                    WriteLine("\t\t\t2 Show all Employees");
                                    int DispType = int.Parse(ReadLine());
                                    switch (DispType)
                                    {
                                        case 1:
                                            WriteLine("\t\t\tEnter Employee number:");
                                            int empNum = int.Parse(ReadLine()); //comment for creator->be careful while passing arguement to method
                                            WriteLine("\t\t***** Employee Information******\n");
                                            WriteLine("\tEmployee_No.\tFirst_Name\tLast_Name\tDOB\t\t\tDOJ\t\t\tSalary\tDepartment_ID\n");
                                            foreach (DataRow row in clslibObj.GetEmployeeById(conn, empNum).Tables[0].Rows)  //reading data from dataset table 1 by 1
                                            {
                                                WriteLine("\t{0}\t\t{1}\t\t{2}\t\t{3}\t{4}\t{5}\t{6}", row[0], row[1], row[2], row[3], row[4], row[5], row[6]);
                                            }
                                            break;
                                        case 2:
                                            WriteLine("\t\t***** Employee Information******\n");
                                            WriteLine("\tEmployee_No.\tFirst_Name\tLast_Name\tDOB\t\t\tDOJ\t\t\tSalary\tDepartment_ID\n");
                                            foreach (DataRow row in clslibObj.fetchData(conn, "Employee_Vidya").Tables[0].Rows)  //reading data from dataset table 1 by 1
                                            {
                                                WriteLine("\t{0}\t\t{1}\t\t{2}\t\t{3}\t{4}\t{5}\t{6}", row[0], row[1], row[2], row[3], row[4], row[5], row[6]);
                                            }
                                            break;
                                        default:
                                            WriteLine("\t\tResult: Invalid choice please choose correct option\n");
                                            break;
                                    }
                                    break;
                                case 3:
                                    WriteLine("\t\t\tNow Press\n");
                                    WriteLine("\t\t\t1 Show Dependent using Employee number and dependent name");
                                    WriteLine("\t\t\t2 show all dependents");
                                    int DisplType = int.Parse(ReadLine());
                                    switch (DisplType)
                                    {
                                        case 1:
                                            WriteLine("\t\t\tEnter Employee number:");
                                            int empNum = int.Parse(ReadLine());
                                            WriteLine("\t\t\tEnter Dependent name:");
                                            string dpdtName = ReadLine();
                                            WriteLine("\t\t\t***** Dependent Information******\n");
                                            WriteLine("\t\t\t\tName \t Gender\t DOB\t\t Relationship\t\t Employee_No.\n");
                                            foreach (DataRow row in clslibObj.GetDependentById(conn, empNum, dpdtName).Tables[0].Rows)  //reading data from dataset table 1 by 1
                                            {
                                                WriteLine("\t\t\t\t{0}\t\t{1}\t\t{2}\t\t{3}", row[0], row[1], row[2], row[3], row[4]);
                                            }
                                            break;
                                        case 2:
                                            WriteLine("\t\t***** Dependent Information******");
                                            WriteLine("\t\t\t\tName \t Gender\t DOB\t \t\tRelationship\tEmployee_No");
                                            foreach (DataRow row in clslibObj.fetchData(conn, "Dependent_SriHarshini").Tables[0].Rows)  //reading data from dataset table 1 by 1
                                            {
                                                WriteLine("\t\t\t\t{0}\t\t{1}\t{2}\t\t{3}\t{4}", row[0], row[1], row[2], row[3], row[4]);
                                            }
                                            break;
                                        default:
                                            WriteLine("\t\tResult:Invalid choice please choose correct option\n");
                                            break;
                                    }
                                    break;
                                default:
                                    WriteLine("\t\tResult: Invalid choice please choose correct option\n");
                                    break;
                            }
                            break;
                        case 3:
                            WriteLine("\t\t\tNow Press\n");
                            WriteLine("\t\t\t1 Update department Info");
                            WriteLine("\t\t\t2 Update Employee Info");
                            WriteLine("\t\t\t3 Update Dependent details");
                            int UpdtOpt = int.Parse(ReadLine());
                            switch (UpdtOpt)
                            {
                                case 1:
                                    WriteLine("\t\t\tEnter department id for which records need to be updated:");
                                    string deptId = ReadLine();
                                    WriteLine("\t\t\tEnter Department name:");
                                    string deptname = ReadLine();
                                    WriteLine("\t\t\tEnter Department Location:");
                                    string deptLoct = ReadLine();
                                    WriteLine("\t\tResult: "+ clslibObj.UpdateDepartment(conn, deptId, deptname, deptLoct) + " department updated successfully\n");
                                    break;
                                case 2:
                                    WriteLine("\t\t\tEnter Employee Number for which records need to be updated:");
                                    int empNum = int.Parse(ReadLine());
                                    WriteLine("\t\t\tEnter Employee First Name:");
                                    string empFName = ReadLine();
                                    WriteLine("\t\t\tEnter Employee Last Name:");
                                    string empLName = ReadLine();
                                    WriteLine("\t\t\tEnter Employee Date of Birth:");
                                    DateTime empDob = DateTime.Parse(ReadLine());
                                    WriteLine("\t\t\tEnter Employee Date of Joining:");
                                    DateTime empDoj = DateTime.Parse(ReadLine());
                                    WriteLine("\t\t\tEnter Employee Salary:");
                                    int empSalry = int.Parse(ReadLine());
                                    WriteLine("\t\t\tEnter Department ID where Employee works:");
                                    string deptmId = ReadLine();
                                    WriteLine("\t\tResult: " + clslibObj.UpdateEmployee(conn, empNum, empFName, empLName, empDob, empDoj, empSalry, deptmId) + " Employee updated succesfully\n");
                                    break;
                                case 3:
                                    WriteLine("\t\t\tEnter Employee number whose Dependent to be updated:");
                                    int empNumb = int.Parse(ReadLine());
                                    WriteLine("\t\t\tEnter name of dependent whose record to be updated:");
                                    string dpndntName = ReadLine();
                                    WriteLine("\t\t\tEnter Dependent gender:");
                                    string dpndntGndr = ReadLine();
                                    WriteLine("\t\t\tEnter Dependent Date of Birth:");
                                    DateTime dpndntDob = DateTime.Parse(ReadLine());
                                    WriteLine("\t\t\tEnter relationship with Employee:");
                                    string dpdpntReltn = ReadLine();
                                    WriteLine("\t\tResult: " + clslibObj.UpdateDependent(conn, empNumb, dpndntName, dpndntGndr, dpndntDob, dpdpntReltn) + " Dependent updated succesfully\n");
                                    break;
                                default:
                                    WriteLine("\t\t\tResult:Invalid choice please choose correct option\n");
                                    break;

                            }
                            break;
                        case 4:
                            WriteLine("\t\t\tNow Press\n");
                            WriteLine("\t\t\t1 delete a department");
                            WriteLine("\t\t\t2 delete an employee");
                            WriteLine("\t\t\t3 delete a dependent");
                            int DelOpt = int.Parse(ReadLine());
                            switch (DelOpt)
                            {
                                case 1:
                                    WriteLine("\t\t\tEnter Department ID whose record to be deleted:");
                                    string deptId = ReadLine();
                                    WriteLine("\t\t\tDeleting a Department ...");
                                    WriteLine("\t\t\tResult: Deleted " + clslibObj.DeleteDepartment(conn, deptId) + " department succesfully\n");
                                    break;
                                case 2:
                                    WriteLine("\t\t\tEnter Employee number whose record to be deleted:");
                                    int empId = int.Parse(ReadLine());
                                    WriteLine("\t\t\tDeleting an Employee...");
                                    WriteLine("\t\t\tResult: Deleted " + clslibObj.DeleteEmployee(conn, empId) + " Employee succesfully\n");
                                    break;
                                case 3:
                                    WriteLine("\t\t\tEnter Employee number whose dependent to be removed:");
                                    int empNum = int.Parse(ReadLine());
                                    WriteLine("\t\t\tEnter Dependent name whose data to be deleted:");
                                    string dpdntName = ReadLine();
                                    WriteLine("\t\t\tDeleting Dependent...");
                                    WriteLine("\t\t\tResult: Deleted " + clslibObj.DeleteDependent(conn, empNum, dpdntName) + " dependent succesfully\n");
                                    break;
                                default:
                                    WriteLine("\t\t\tResult:Invalid choice please choose correct option\n");
                                    break;
                            }

                            break;
                        case 5:
                            exit = true;
                            WriteLine("\t\t\tPress Enter to exit from console Window\n");
                            break;
                        default:
                            WriteLine("\t\t\tResult:Invalid choice please choose correct option\n");
                            break;
                    }
                }

            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            ReadLine();
        }
    }
}
