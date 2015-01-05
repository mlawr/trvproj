USE [CustomerDB]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 01/05/2015 05:04:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [varchar](200) NULL,
	[FirstName] [varchar](200) NULL,
	[DateOfBirth] [date] NULL,
	[Email] [varchar](150) NULL,
	[StreetAddress] [varchar](200) NULL,
	[City] [varchar](150) NULL,
	[StateCode] [char](2) NULL,
	[ZipCode] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_StateList] FOREIGN KEY([StateCode])
REFERENCES [dbo].[StateList] ([StateCode])
GO

ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_StateList]
GO
USE [CustomerDB]
GO

/****** Object:  Table [dbo].[StateList]    Script Date: 01/05/2015 05:05:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[StateList](
	[StateCode] [char](2) NOT NULL,
	[StateName] [varchar](150) NULL,
	[StateStatus] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[StateCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

INSERT INTO StateList Values
('AL','ALABAMA',1)
,('AK','ALASKA',1)
,('AZ','ARIZONA',1)
,('AR','ARKANSAS',1)
,('CA','CALIFORNIA',1)
,('CO','COLORADO',1)
,('CT','CONNECTICUT',1)
,('DE','DELAWARE',1)
,('FL','FLORIDA',1)
,('GA','GEORGIA',1)
,('HI','HAWAII',1)
,('ID','IDAHO',1)
,('IL','ILLINOIS',1)
,('IN','INDIANA',1)
,('IA','IOWA',1)
,('KS','KANSAS',1)
,('KY','KENTUCKY',1)
,('LA','LOUISIANA',1)
,('ME','MAINE',1)
,('MD','MARYLAND',1)
,('MA','MASSACHUSETTS',1)
,('MI','MICHIGAN',1)
,('MN','MINNESOTA',1)
,('MS','MISSISSIPPI',1)
,('MO','MISSOURI',1)
,('MT','MONTANA',1)
,('NE','NEBRASKA',1)
,('NV','NEVADA',1)
,('NH','NEW HAMPSHIRE',1)
,('NJ','NEW JERSEY',1)
,('NM','NEW MEXICO',1)
,('NY','NEW YORK',1)
,('NC','NORTH CAROLINA',1)
,('ND','NORTH DAKOTA',1)
,('OH','OHIO',1)
,('OK','OKLAHOMA',1)
,('OR','OREGON',1)
,('PA','PENNSYLVANIA',1)
,('RI','RHODE ISLAND',1)
,('SC','SOUTH CAROLINA',1)
,('SD','SOUTH DAKOTA',1)
,('TN','TENNESSEE',1)
,('TX','TEXAS',1)
,('UT','UTAH',1)
,('VT','VERMONT',1)
,('VA','VIRGINIA',1)
,('WA','WASHINGTON',1)
,('WV','WEST VIRGINIA',1)
,('WI','WISCONSIN',1)
,('WY','WYOMING',1)

GO

