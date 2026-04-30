/* 1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition

   a) HRA as 10% of Salary
   b) DA as 20% of Salary
   c) PF as 8% of Salary
   d) IT as 5% of Salary
   e) Deductions as sum of PF and IT
   f) Gross Salary as sum of Salary, HRA, DA
   g) Net Salary as Gross Salary - Deductions

Print the payslip neatly with all details*/
CREATE PROCEDURE GeneratePayslip
    @EmpNo INT
AS
BEGIN
    DECLARE 
        @EmpName VARCHAR(20),
        @Salary DECIMAL(10,2),
        @HRA DECIMAL(10,2),
        @DA DECIMAL(10,2),
        @PF DECIMAL(10,2),
        @IT DECIMAL(10,2),
        @Deductions DECIMAL(10,2),
        @GrossSalary DECIMAL(10,2),
        @NetSalary DECIMAL(10,2);
    SELECT  @EmpName = ename, @Salary = sal FROM EMP WHERE empno = @EmpNo;
   
    SET @HRA = @Salary * 0.10;
    SET @DA = @Salary * 0.20;
    SET @PF = @Salary * 0.08;
    SET @IT = @Salary * 0.05;

    SET @Deductions = @PF + @IT;
    SET @GrossSalary = @Salary + @HRA + @DA;
    SET @NetSalary = @GrossSalary - @Deductions;

    PRINT '========================================';
    PRINT '               PAYSLIP                 ';
    PRINT '========================================';
    PRINT 'Emp No        : ' + CAST(@EmpNo AS VARCHAR);
    PRINT 'Employee Name : ' + @EmpName;
    PRINT '----------------------------------------';
    PRINT 'Basic Salary  : ' + CAST(@Salary AS VARCHAR);
    PRINT 'HRA (10%)     : ' + CAST(@HRA AS VARCHAR);
    PRINT 'DA (20%)      : ' + CAST(@DA AS VARCHAR);
    PRINT '----------------------------------------';
    PRINT 'Gross Salary  : ' + CAST(@GrossSalary AS VARCHAR);
    PRINT '----------------------------------------';
    PRINT 'PF (8%)       : ' + CAST(@PF AS VARCHAR);
    PRINT 'IT (5%)       : ' + CAST(@IT AS VARCHAR);
    PRINT 'Deductions    : ' + CAST(@Deductions AS VARCHAR);
    PRINT '----------------------------------------';
    PRINT 'Net Salary    : ' + CAST(@NetSalary AS VARCHAR);
    PRINT '========================================';
END;
EXEC GeneratePayslip @EmpNo = 7369;

/*2.  Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manipulate" etc

Note: Create holiday table with (holiday_date,Holiday_name). Store at least 4 holiday details. try to match the dates and stop manipulation */

CREATE TABLE Holiday (holiday_date DATE,holiday_name VARCHAR(50));
INSERT INTO Holiday VALUES ('2026-05-01', 'MayDay'),('2026-05-19', 'Bakrid'),('2026-11-12', 'Diwali'),('2026-12-25', 'Christmas');

CREATE TRIGGER trg_RestrictHolidayDML
ON EMP
INSTEAD OF INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Today DATE;
    DECLARE @HolidayName VARCHAR(50);

    SET @Today = CAST(GETDATE() AS DATE);

    SELECT @HolidayName = holiday_name
    FROM Holiday
    WHERE holiday_date = @Today;

    IF @HolidayName IS NOT NULL
    BEGIN
        RAISERROR ('Due to %s you cannot manipulate data', 16, 1, @HolidayName);
        RETURN;
    END

    
    IF EXISTS (SELECT * FROM inserted) AND NOT EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO EMP
        SELECT * FROM inserted;
    END

   
    IF EXISTS (SELECT * FROM deleted) AND NOT EXISTS (SELECT * FROM inserted)
    BEGIN
        DELETE FROM EMP
        WHERE empno IN (SELECT empno FROM deleted);
    END

    
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        UPDATE E
        SET 
            E.ename = I.ename,
            E.job = I.job,
            E.mgr_id = I.mgr_id,
            E.hiredate = I.hiredate,
            E.sal = I.sal,
            E.comm = I.comm,
            E.deptno = I.deptno
        FROM EMP E
        INNER JOIN inserted I ON E.empno = I.empno;
    END
END;
