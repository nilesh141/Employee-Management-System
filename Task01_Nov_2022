CREATE DATABASE EMS_SriHarshini_DB
USE EMS_SriHarshini_DB
GO
CREATE TABLE Department_Nilesh(
Dept_Id VARCHAR(15) PRIMARY KEY,
Dept_Name VARCHAR(50),
Dept_Location VARCHAR(40));

CREATE TABLE Employee_Vidya(
Emp_Number INT PRIMARY KEY,
Emp_FName VARCHAR(20),
Emp_LName VARCHAR(20),
Emp_Dob DATE,
Emp_Doj DATE,
Emp_Salary INT,
Dept_Id VARCHAR(15) FOREIGN KEY REFERENCES Department_Nilesh(Dept_Id) ON DELETE CASCADE
);

CREATE TABLE Dependent_SriHarshini(
Dpendnt_Name VARCHAR(20),
Dpendnt_Gender VARCHAR(15),
Dpendnt_Dob DATE,
Dpendnt_Reltn VARCHAR(20),
Emp_Number INT FOREIGN KEY REFERENCES Employee_Vidya(Emp_Number) ON DELETE CASCADE,
PRIMARY KEY(Emp_Number,Dpendnt_Name)
);

--stored procedure for insertion
CREATE PROCEDURE SProc_InsrtDept @deptId VARCHAR(15),@deptName VARCHAR(50), @deptLoctn VARCHAR(40)
AS BEGIN
INSERT INTO Department_Nilesh 
VALUES(@deptId,@deptName,@deptLoctn)
END

CREATE PROCEDURE SProc_InsrtEmp @empNum INT,@empFName VARCHAR(20),@empLName VARCHAR(20), @empDob DATE,@empDoj DATE, @empSalry INT,@deptId VARCHAR(15)
AS BEGIN
INSERT INTO Employee_Vidya 
VALUES(@empNum,@empFName,@empLName,@empDob,@empDoj,@empSalry,@deptId)
END

CREATE PROCEDURE SProc_InsrtDpendt @dpendtName VARCHAR(20),@dpendtGender VARCHAR(15),@dpendtDob DATE,@dpendtReltn VARCHAR(20),@empNum INT
AS BEGIN
INSERT INTO Dependent_SriHarshini 
VALUES(@dpendtName,@dpendtGender,@dpendtDob,@dpendtReltn,@empNum)
END

--stored procedure for updation
    CREATE PROCEDURE SProc_UpdateDepartment @Department_id VARCHAR(15) ,@Department_Name varchar(50),@Department_Loc varchar(40)
	AS BEGIN
	UPDATE Department_Nilesh 
	SET  Dept_Id = @Department_id  ,Dept_Name=@Department_Name ,Dept_Location=@Department_Loc ;
	END

	CREATE PROCEDURE SProc_UpdateEmployee @Emp_num int,@Emp_Fname varchar(20),@Emp_Lname varchar(20),@Emp_Dob Date,@Emp_Doj Date,@Emp_Sal int,@Dept_Id VARCHAR(15)
	AS BEGIN
	UPDATE Employee_Vidya 
	SET Emp_Number=@Emp_num ,Emp_FName=@Emp_Fname ,Emp_LName=@Emp_Lname,Emp_Dob=@Emp_Dob ,Emp_Doj=@Emp_Doj,Emp_Salary=@Emp_Sal,Dept_Id=@Dept_Id;
	END

	CREATE PROCEDURE SProc_UpdateDependent @Dpdnt_name VARCHAR(20),@Dpdnt_gender varchar(15),@Dpdnt_dob Date,@Dpdnt_rel varchar(20),@Emp_num int
	AS BEGIN
	UPDATE  Dependent_SriHarshini 
	SET  Dpendnt_Name=@Dpdnt_name,Dpendnt_Gender=@Dpdnt_gender ,Dpendnt_Dob=@Dpdnt_dob ,Dpendnt_Reltn=@Dpdnt_rel,Emp_Number=@Emp_num;
	END

	-- storage procedure for DELETION

	CREATE PROCEDURE SProc_DeleteDepartment @dept_Id VARCHAR(15)
	AS BEGIN
	DELETE Department_Nilesh 
	WHERE Dept_Id=@dept_Id;
	END

	CREATE PROCEDURE SProc_DeleteEmployee @Emp_num INT
	AS BEGIN
	DELETE Employee_Vidya 
	WHERE Emp_Number= @Emp_num
	END

	CREATE PROCEDURE SProc_DeleteDependent @DpndntName VARCHAR(20),@empNum INT
	AS BEGIN
	DELETE  Dependent_SriHarshini 
	WHERE Emp_Number=@empNum AND Dpendnt_Name=@DpndntName
	END

--stored procedure for display
	CREATE PROCEDURE SProc_SelectDepartment @dept_Id VARCHAR(15)
	AS BEGIN
	SELECT * FROM  Department_Nilesh 
	WHERE Dept_Id= @dept_Id 
	END

	CREATE PROCEDURE SProc_SelectEmployee @emp_Num INT
	AS BEGIN
	SELECT * FROM  Employee_Vidya 
	WHERE Emp_Number= @emp_Num 
	END

	CREATE PROCEDURE SProc_SelectDependent @dpdnt_Name VARCHAR(20),@emp_Num INT
	AS BEGIN
	SELECT * FROM  Dependent_SriHarshini 
	WHERE Emp_Number=@emp_Num AND Dpendnt_Name=@dpdnt_Name
	END


