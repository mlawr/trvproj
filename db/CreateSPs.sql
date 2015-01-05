USE [CustomerDB]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCustomer]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetCustomer]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetCustomer]  
(@CustomerID int)
AS
BEGIN 
SELECT [CustomerID]
      ,[LastName]
      ,[FirstName]
      ,[DateOfBirth]
      ,[Email]
      ,[StreetAddress]
      ,[City]
      ,[StateCode]
      ,[ZipCode]
  FROM [CustomerDB].[dbo].[Customer]
  WHERE [CustomerID]= @CustomerID
END 


GO
GRANT EXECUTE ON [dbo].[GetCustomer] TO custuser
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCustomerList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetCustomerList]
GO

CREATE procedure [dbo].[GetCustomerList] as 

BEGIN 
Select CustomerID,FirstName, LastName,StateName,City 
from Customer c left outer join StateList s 
on c.StateCode = s.StateCode 
ORDER BY LastName, FirstName
END 



GO
GRANT EXECUTE ON [dbo].[GetCustomerList] TO custuser
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetStateList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetStateList]
GO

Create procedure [dbo].[GetStateList] as 
BEGIN 
SELECT StateCode,StateName FROM StateList WHERE StateStatus = 1
END 
GO
GRANT EXECUTE ON [dbo].[GetStateList] TO custuser
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertCustomer]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertCustomer]
GO

Create procedure [dbo].[InsertCustomer] 
@lastName varchar(200),
@firstName varchar(200),
@DOB date,
@email varchar(150),
@address varchar(200),
@city varchar(150),
@state char(2),
@zipcode varchar(10),
@customerID int out

AS
BEGIN 
INSERT INTO Customer
(LastName,
FirstName,
DateOfBirth,
Email,
StreetAddress,
City,
StateCode,
ZipCode)
values(@lastName ,@firstName,@DOB,@email,@address,@city,@state,@zipcode)
Select @customerID = SCOPE_IDENTITY()
END 

GO
GRANT EXECUTE ON [dbo].[InsertCustomer] TO custuser
GO

CREATE procedure [dbo].[UpdateCustomer]
(
	@lastName varchar(200),
	@firstName varchar(200),
	@DOB date,
	@email varchar(150),
	@address varchar(200),
	@city varchar(150),
	@state char(2),
	@zipcode varchar(10),
	@customerID int
)
as 
BEGIN 
	UPDATE dbo.Customer
	SET 
	LastName = @lastName,
	FirstName= @firstName,
	DateOfBirth = @DOB,
	Email = @email,
	StreetAddress = @address,
	City = @city,
	StateCode = @state,
	ZipCode = @zipcode
	WHERE CustomerID = @customerID
END


GO
GRANT EXECUTE ON [dbo].[UpdateCustomer] TO custuser
GO





