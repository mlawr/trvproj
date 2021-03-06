USE [CustomerDB]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 01/05/2015 05:19:50 ******/

INSERT [dbo].[Customer] ( [LastName], [FirstName], [DateOfBirth], [Email], [StreetAddress], [City], [StateCode], [ZipCode]) 
	VALUES ( N'Joe', N'Frank', CAST(0xB0080B00 AS Date), N'joe.frank@abcemail.com', N'123 Main St', N'New York', N'NY', N'10105')
INSERT [dbo].[Customer] ( [LastName], [FirstName], [DateOfBirth], [Email], [StreetAddress], [City], [StateCode], [ZipCode]) 
	VALUES ( N'Jane', N'Doe', CAST(0x88150B00 AS Date), N'abc@email.com', N'123 Elm St', N'New York', N'NY', N'10105')
INSERT [dbo].[Customer] ( [LastName], [FirstName], [DateOfBirth], [Email], [StreetAddress], [City], [StateCode], [ZipCode]) 
	VALUES ( N'Mick', N'Jick', CAST(0x39250B00 AS Date), N'dgfh@hgm.com', N'345 Elm St', N'Watertown', N'GA', N'87639')
INSERT [dbo].[Customer] ( [LastName], [FirstName], [DateOfBirth], [Email], [StreetAddress], [City], [StateCode], [ZipCode]) 
	VALUES ( N'Nick', N'Mick', CAST(0x39250B00 AS Date), N'dgfh@hgm.com', N'11 Elm St', N'Waterbury', N'WI', N'54647')

