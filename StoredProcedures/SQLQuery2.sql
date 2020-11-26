create procedure SpAddContactDetails
(
@FirstName varchar(25),
@LastName varchar(25),
@PhoneNumber varchar(25),
@Email varchar(25),
@JoiningDate DateTime,
@Contact_Type varchar(25),
@Address varchar(25),
@City varchar(25),
@State varchar(25),
@ZipCode varchar(25)
)
as
begin
insert into ContactInfo values
(
@FirstName,@LastName, @PhoneNumber, @Email, @JoiningDate
);
insert into ContactType values
(
@@IDENTITY, @Contact_Type
)
Declare @CustId int
select @CustId = ContactId from ContactInfo where Email = @Email
insert into Address values
(
@CustId, @Address, @City, @State, @ZipCode
)
end