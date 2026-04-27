--1.Write a T-SQL Program to find the factorial of a given number.
DECLARE @num INT = 5; 
DECLARE @fact BIGINT = 1;
DECLARE @i INT = 1;

WHILE @i <= @num
BEGIN
    SET @fact = @fact * @i;
    SET @i = @i + 1;
END

PRINT 'Factorial = ' + CAST(@fact AS VARCHAR);

--2.Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number. 
CREATE PROCEDURE sp_MultiplicationTable
    @num INT,
    @limit INT
AS
BEGIN
    DECLARE @i INT = 1;

    WHILE @i <= @limit
    BEGIN
        PRINT CAST(@num AS VARCHAR) + ' x ' + 
              CAST(@i AS VARCHAR) + ' = ' + 
              CAST(@num * @i AS VARCHAR);

        SET @i = @i + 1;
    END
END;
EXEC sp_MultiplicationTable 5, 10;


--3. Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly student table
CREATE TABLE Student1 ( Sid INT PRIMARY KEY,Sname VARCHAR(50));
INSERT INTO Student1 (Sid, Sname) VALUES(1, 'Jack'),(2, 'Rithvik'),(3, 'Jaspreeth'),(4, 'Praveen'),(5, 'Bisa'),(6, 'Suraj');
CREATE TABLE Marks ( Mid INT PRIMARY KEY,Sid INT,Score INT,FOREIGN KEY (Sid) REFERENCES Student1(Sid));
INSERT INTO Marks (Mid, Sid, Score) VALUES(1, 1, 23),(2, 6, 95),(3, 4, 98),(4, 2, 17),(5, 3, 53),(6, 5, 13);

--Creating Function
CREATE FUNCTION fn_StudentStatus (@score INT)
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @status VARCHAR(10);

    IF @score >= 50
        SET @status = 'Pass';
    ELSE
        SET @status = 'Fail';

    RETURN @status;
END;

SELECT  S.Sid, S.Sname, M.Score,dbo.fn_StudentStatus(M.Score) AS Status FROM Student1 S JOIN Marks M ON S.Sid = M.Sid;