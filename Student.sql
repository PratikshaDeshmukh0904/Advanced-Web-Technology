USE [Student]
GO
/****** Object:  Table [dbo].[registration]    Script Date: 03/12/2023 16:24:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[registration](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[dob] [date] NULL,
	[sex] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[address] [varchar](max) NULL,
	[image] [varchar](50) NULL,
	[ContentType] [nvarchar](200) NULL,
	[Data] [varbinary](max) NULL,
 CONSTRAINT [PK_registration] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[registration] ON
INSERT [dbo].[registration] ([id], [name], [dob], [sex], [phone], [address], [image], [ContentType], [Data]) VALUES (11, N'divya yadav   ', CAST(0x1E450B00 AS Date), N'Male', N'9878767676', N'karad', N'Images/maxresdefault.jpg', NULL, NULL)
INSERT [dbo].[registration] ([id], [name], [dob], [sex], [phone], [address], [image], [ContentType], [Data]) VALUES (20, N'divya yadav', CAST(0x1E450B00 AS Date), N'Female', N'9087676765', N'karad', N'Images/logo.png', NULL, NULL)
INSERT [dbo].[registration] ([id], [name], [dob], [sex], [phone], [address], [image], [ContentType], [Data]) VALUES (21, N'divya', CAST(0x13450B00 AS Date), N'Female', N'9878767676', N'karad', N'Images/logo.png', NULL, NULL)
SET IDENTITY_INSERT [dbo].[registration] OFF
/****** Object:  Table [dbo].[Image_Details]    Script Date: 03/12/2023 16:24:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Image_Details](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[ImageName] [varchar](50) NULL,
	[Image] [nvarchar](max) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Image_Details] ON
INSERT [dbo].[Image_Details] ([ImageId], [ImageName], [Image]) VALUES (1, N'logo.png', N'APP_DATA/logo.png')
INSERT [dbo].[Image_Details] ([ImageId], [ImageName], [Image]) VALUES (2, N'logo.png', N'Images/logo.png')
INSERT [dbo].[Image_Details] ([ImageId], [ImageName], [Image]) VALUES (3, N'tv.jpg', N'Images/tv.jpg')
INSERT [dbo].[Image_Details] ([ImageId], [ImageName], [Image]) VALUES (4, N'logo.png', N'Images/logo.png')
INSERT [dbo].[Image_Details] ([ImageId], [ImageName], [Image]) VALUES (5, N'logo.png', N'Images/logo.png')
SET IDENTITY_INSERT [dbo].[Image_Details] OFF
/****** Object:  StoredProcedure [dbo].[SPregistration]    Script Date: 03/12/2023 16:24:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SPregistration] (
                               @User    VARCHAR(255),
                               @dob     date,
                               @sex     VARCHAR(10),
                               @ph         VARCHAR(20),
                               @address VARCHAR(255),
                               @Name VARCHAR(255),
                               @ContentType NVARCHAR(200),
                               @Data VARBINARY(MAX))
AS
  BEGIN
Insert into Registration(name,dob,sex,phone,address,image,ContentType, Data) values (@User,@dob,@sex,@ph,@address,@Name, @ContentType, @Data)
end
GO
