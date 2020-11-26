select * from sys.databases
create database payroll_service1
use payroll_service
select DB_NAME()

create table employee_payroll
(
id int identity(1,1),
name varchar(25) not null,
salary money not null,
start date not null
);

select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='employee_payroll'

insert into employee_payroll values
('Bill',100000.00,'2018-01-03'),
('Teresa',200000.00,'2019-11-13'),
('Charlie',300000.00,'2020-05-21');

select * from employee_payroll

select * from employee_payroll where name = 'Bill'

select GETDATE()

select * from employee_payroll where start between '2018-01-01' and GETDATE();