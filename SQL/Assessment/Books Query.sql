/* Create the below tables with appropriate data types and constraints. Then Solve the queries.
Create a book table with id as primary key and provide the appropriate data type to other attributes .isbn no should be unique for each book
*/
create database Assessment
CREATE TABLE books (id INT PRIMARY KEY,title VARCHAR(200),author VARCHAR(100),isbn VARCHAR(20) UNIQUE,published_date DATETIME);
CREATE TABLE reviews (id INT PRIMARY KEY, book_id INT, reviewer_name VARCHAR(100),content VARCHAR(500),rating INT,published_date DATETIME,FOREIGN KEY (book_id) REFERENCES books(id));
INSERT INTO books VALUES(1, 'My First SQL book', 'Mary Parker', '981483029127', '2012-02-22 12:08:17'),(2, 'My Second SQL book', 'John Mayer', '857300923713', '1972-07-03 09:22:45'),(3, 'My Third SQL book', 'Cary Flint', '523120967812', '2015-10-18 14:05:44');
INSERT INTO reviews VALUES(1, 1, 'John Smith', 'My first review', 4, '2017-12-10 05:50:11'),(2, 1, 'John Smith', 'My second review', 5, '2017-12-13 15:05:12'),(3, 2, 'Alice Walker', 'Another review', 1, '2017-10-22 23:47:10');
CREATE TABLE customers (id INT PRIMARY KEY, name VARCHAR(50),age INT,address VARCHAR(100),salary DECIMAL(10,2));
INSERT INTO customers VALUES(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),(2, 'Khilan', 25, 'Delhi', 1500.00),(3, 'Kaushik', 23, 'Kota', 2000.00),(4, 'Chaitali', 25, 'Mumbai', 6500.00),(5, 'Hardik', 27, 'Bhopal', 8500.00),(6, 'Komal', 22, 'MP', 4500.00),(7, 'Muffy', 24, 'Indore', 10000.00);
CREATE TABLE orders (ord_id INT PRIMARY KEY,date DATETIME,customer_id INT,amount INT,FOREIGN KEY (customer_id) REFERENCES customers(id));
INSERT INTO orders VALUES(102, '2009-10-08 00:00:00', 3, 3000),(100, '2009-10-08 00:00:00', 3, 1500),(101, '2009-11-20 00:00:00', 2, 1560),(103, '2008-05-20 00:00:00', 4, 2060);
CREATE TABLE StudentDetails (RegisterNo INT PRIMARY KEY,Name VARCHAR(50),Age INT,Qualification VARCHAR(20),MobileNo BIGINT, Mail_id VARCHAR(50), Location VARCHAR(30), Gender CHAR(1));
INSERT INTO StudentDetails VALUES(2, 'Sai', 22, 'B.E', 9952836777, 'Sai@gmail.com', 'Chennai', 'M'),(3, 'Kumar', 20, 'BSC', 7890125648, 'Kumar@gmail.com', 'Madurai', 'M'),(4, 'Selvi', 22, 'B.Tech', 8904567342, 'selvi@gmail.com', 'Selam', 'F'),(5, 'Nisha', 25, 'M.E', 7834672310, 'Nisha@gmail.com', 'Theni', 'F'),(6, 'SaiSaran', 21, 'B.A', 7890345678, 'saran@gmail.com', 'Madurai', 'F'),(7, 'Tom', 23, 'BCA', 8901234675, 'Tom@gmail.com', 'Pune', 'M');
--1.Write a query to fetch the details of the books written by author whose name ends with er.
SELECT title, author from books where author LIKE '%er';
--2.Display the Title ,Author and ReviewerName for all the books from the above table
SELECT  b.title, b.author, r.reviewer_name from books b JOIN reviews r on b.id = r.book_id;
--3.Display the reviewer name who reviewed more than one book.
SELECT reviewer_name from reviews group by reviewer_name Having COUNT(DISTINCT book_id) > 1;
--4.Display the Name for the customer from above customer table who live in same address which has character o anywhere in address
SELECT name from customers where address LIKE '%o%';
--5.Write a query to display the Date,Total no of customer placed order on same Date
select date,count(distinct customer_id) as total_customers from orders group by date;
--6.Display the Names of the Employee in lower case, whose salary is null
SELECT LOWER(name) as name from customers where salary IS NULL;
--7.Write a sql server query to display the Gender,Total no of male and female from the above relation
SELECT Gender, count(*) as TotalCount from StudentDetails group by Gender;

