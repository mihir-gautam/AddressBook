create table ContactInfo
(
ContactId int identity(1,1) not null primary key,
FirstName varchar(25) not null,
LastName varchar(25) not null,
PhoneNumber varchar(12) not null,
Email varchar(20) not null
);
--Insert into Contact_Info
insert into ContactInfo values
('Bill','Jones','9856985696','billjones@gmail.com'),
('Leena','Thomas','7458632156','leena@gmail.com'),
('Terrisa','Gates','8425693856','gates@gmail.com'),
('Priyanka','Chopra','9589657485','priyanka@gmail.com'),
('Karishma','Khanna','9424787845','karishma@gmail.com'),
('Rakhi','Saraf','8596785425','rakhi@gmail.com');
create table ContactType
(
ContactId int foreign key references ContactInfo(ContactId) on delete cascade,
Contact_Type varchar(20) not null
);
--Add enteries to contact_type
insert into ContactType values
(1,'Friends'),
(2,'Family'),
(3,'Friends'),
(4,'Friends'),
(5,'Family'),
(6,'Professional');
--create Address table
create table Address
(
ContactId int foreign key references ContactInfo(ContactId) on delete cascade,
Address varchar(60) not null,
City varchar(15) not null,
State varchar(20) not null,
Zipcode varchar(6) not null
);
select * from Address;
--Insert into Address table
insert into Address values
(1,'Street 4','Mumbai','Maharashtra','452856'),
(2,'New Market','Bhopal','Madhya Pradesh','852147'),
(3,'Malviya Nagar','Ajmer','Rajasthan','547856'),
(4,'Gopal Vihar','Bhopal','Madhya Pradesh','658927'),
(5,'Manik Nagar','Ajmer','Rajasthan','125463');
--View Contact_type
select * from ContactType
--Join contact_info and contacttype and Address
select * from (ContactInfo contact inner join ContactType type
on (contact.ContactId = type.ContactId)) inner join Address address on address.ContactId = contact.ContactId
--Count contact by type
select type.Contact_Type, COUNT(contact.FirstName) from ContactInfo contact inner join ContactType type
on (contact.ContactId = type.ContactId)
Group by type.Contact_Type;
--Add DateAdded field to the contact_info
Alter table ContactInfo
Add JoiningDate datetime
--Add DateAdded
Update ContactInfo set 
JoiningDate = '2019-05-31' where ContactId = 1
Update ContactInfo set 
JoiningDate = '2020-05-06' where ContactId = 2
Update ContactInfo set 
JoiningDate = '2019-04-01' where ContactId = 3
Update ContactInfo set 
JoiningDate = '2018-03-09' where ContactId = 4
Update ContactInfo set 
JoiningDate = '2019-08-07' where ContactId = 5
Update ContactInfo set 
JoiningDate = '2020-09-30' where ContactId = 6