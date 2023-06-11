create database test 
GO
use test
GO
/****** Object:  UserDefinedTableType [dbo].[tblDetailPaimentTable]    Script Date: 7/18/2017 4:35:17 PM ******/
CREATE TYPE [dbo].[tblDetailPaimentTable] AS TABLE(
    [idMonth] [bigint] NULL,
    [NumInscription] [varchar](50) NULL,
    [idOtherFees] [bigint] NULL
)
GO

/****** Object:  Table [dbo].[Classes]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
    [idClass] [bigint] IDENTITY(1,1) NOT NULL,
    [LabelC] [nvarchar](50) NOT NULL,
    [idFiliere] [bigint] NOT NULL,
    [idYear] [bigint] NULL,
 CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED 
(
    [idClass] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DetailPaiment]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailPaiment](
    [idFacture] [bigint] NULL,
    [idMonth] [bigint] NULL,
    [NumInscription] [varchar](50) NULL,
    [idOtherFees] [bigint] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblDiscount]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDiscount](
    [idDiscount] [bigint] IDENTITY(1,1) NOT NULL,
    [Discount] [decimal](18, 2) NOT NULL,
    [Reason] [nvarchar](max) NULL,
    [NumInscription] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblDiscount] PRIMARY KEY CLUSTERED 
(
    [idDiscount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblEmployee]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmployee](
    [idEmployee] [bigint] IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](50) NULL,
    [Photo] [image] NULL,
 CONSTRAINT [PK_tblEmployee] PRIMARY KEY CLUSTERED 
(
    [idEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblFees]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblFees](
    [idFees] [bigint] IDENTITY(1,1) NOT NULL,
    [idyear] [bigint] NOT NULL,
    [GrandTotal] [decimal](18, 2) NOT NULL,
    [TotalPaid] [decimal](18, 2) NOT NULL,
    [DuePaid] [decimal](18, 2) NULL,
    [FeesDate] [datetime] NULL,
    [Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblFees] PRIMARY KEY CLUSTERED 
(
    [idFees] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblFeetype]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblFeetype](
    [idFeesType] [bigint] NOT NULL,
    [labelFee] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblFeetype] PRIMARY KEY CLUSTERED 
(
    [idFeesType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblFiliere]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblFiliere](
    [idFiliere] [bigint] IDENTITY(1,1) NOT NULL,
    [labelFiliere] [nvarchar](50) NOT NULL,
    [idNiveau] [bigint] NOT NULL,
 CONSTRAINT [PK_tblFiliere] PRIMARY KEY CLUSTERED 
(
    [idFiliere] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblNivau]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNivau](
    [idNiveau] [bigint] IDENTITY(1,1) NOT NULL,
    [LabelNivau] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblNivau] PRIMARY KEY CLUSTERED 
(
    [idNiveau] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblOtherFees]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOtherFees](
    [idOtherfees] [bigint] IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](50) NULL,
    [Price] [decimal](18, 2) NULL,
 CONSTRAINT [PK_tblDetailPaiment] PRIMARY KEY CLUSTERED 
(
    [idOtherfees] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[tblschoolYear]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblschoolYear](
    [idyear] [bigint] IDENTITY(1,1) NOT NULL,
    [SchoolYear] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblschoolYear] PRIMARY KEY CLUSTERED 
(
    [idyear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[tblStudent]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStudent](
    [NumInscription] [varchar](50) NOT NULL,
    [FullName] [nvarchar](50) NOT NULL,
    [Gender] [nvarchar](50) NULL,
    [birthday] [date] NULL,
    [birthPlace] [nvarchar](100) NULL,
    [Nationalite] [nvarchar](50) NULL,
    [fatherName] [nvarchar](50) NULL,
    [fatherJob] [nvarchar](50) NULL,
    [adress] [nvarchar](100) NULL,
    [handphone] [nvarchar](50) NULL,
    [homephone] [nvarchar](50) NULL,
    [photo] [image] NULL,
    [status] [bit] NULL,
    [InscriptionDate] [datetime] NULL,
    [Registrationfees] [decimal](18, 2) NULL,
    [Monthlyfees] [decimal](18, 2) NULL,
    [classID] [bigint] NULL,
    [idyear] [bigint] NULL,
 CONSTRAINT [PK_tblStudent] PRIMARY KEY CLUSTERED 
(
    [NumInscription] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblUsers]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsers](
    [username] [nvarchar](50) NOT NULL,
    [FullName] [nvarchar](50) NULL,
    [Email] [nvarchar](50) NULL,
    [pswd] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblUsers] PRIMARY KEY CLUSTERED 
(
    [username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT INTO tblUsers VALUES('Admin','badr elkhiri','badr@gmail.com','Admin123') 
GO
SET IDENTITY_INSERT [dbo].[Classes] ON 

GO
INSERT [dbo].[Classes] ([idClass], [LabelC], [idFiliere], [idYear]) VALUES (1,N'TCLSH 1', 13, 7)
GO
INSERT [dbo].[Classes] ([idClass], [LabelC], [idFiliere], [idYear]) VALUES (2,N'TCLSH 2', 13, 7)
GO
INSERT [dbo].[Classes] ([idClass], [LabelC], [idFiliere], [idYear]) VALUES (3,N'TCS 1', 14, 7)
GO
INSERT [dbo].[Classes] ([idClass], [LabelC], [idFiliere], [idYear]) VALUES (4,N'TCS 2', 14, 7)
GO
INSERT [dbo].[Classes] ([idClass], [LabelC], [idFiliere], [idYear]) VALUES (5,N'A', 1, 7)
GO
INSERT [dbo].[Classes] ([idClass], [LabelC], [idFiliere], [idYear]) VALUES (6,N'B', 1, 7)
GO
SET IDENTITY_INSERT [dbo].[Classes] OFF
GO

GO
SET IDENTITY_INSERT [dbo].[tblDiscount] ON 

GO

SET IDENTITY_INSERT [dbo].[tblDiscount] OFF
GO
SET IDENTITY_INSERT [dbo].[tblFees] ON 

GO
INSERT [dbo].[tblFees] ([idFees], [idyear], [GrandTotal], [TotalPaid], [DuePaid], [FeesDate], [Note]) VALUES (1, 7, CAST(100.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2017-07-15T03:16:00.043' AS DateTime), N'Rien')
GO
INSERT [dbo].[tblFees] ([idFees], [idyear], [GrandTotal], [TotalPaid], [DuePaid], [FeesDate], [Note]) VALUES (2, 7, CAST(200.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2017-07-15T03:16:00.043' AS DateTime), N'Rien')
GO
INSERT [dbo].[tblFees] ([idFees], [idyear], [GrandTotal], [TotalPaid], [DuePaid], [FeesDate], [Note]) VALUES (3, 7, CAST(100.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2017-07-17T04:59:51.283' AS DateTime), N'Rien')
GO
INSERT [dbo].[tblFees] ([idFees], [idyear], [GrandTotal], [TotalPaid], [DuePaid], [FeesDate], [Note]) VALUES (4, 7, CAST(390.00 AS Decimal(18, 2)), CAST(390.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2017-07-17T04:59:51.283' AS DateTime), N'')
GO
SET IDENTITY_INSERT [dbo].[tblFees] OFF
GO
INSERT [dbo].[tblFeetype] ([idFeesType], [labelFee]) VALUES (1, N'Frais d''inscription et d''assurance')
GO
INSERT [dbo].[tblFeetype] ([idFeesType], [labelFee]) VALUES (2, N'Septembre')
GO
INSERT [dbo].[tblFeetype] ([idFeesType], [labelFee]) VALUES (3, N'Octobre')
GO
INSERT [dbo].[tblFeetype] ([idFeesType], [labelFee]) VALUES (4, N'Novembre')
GO
INSERT [dbo].[tblFeetype] ([idFeesType], [labelFee]) VALUES (5, N'Décembre')
GO
INSERT [dbo].[tblFeetype] ([idFeesType], [labelFee]) VALUES (6, N'Janvier')
GO
INSERT [dbo].[tblFeetype] ([idFeesType], [labelFee]) VALUES (7, N'Février')
GO
INSERT [dbo].[tblFeetype] ([idFeesType], [labelFee]) VALUES (8, N'Mars')
GO
INSERT [dbo].[tblFeetype] ([idFeesType], [labelFee]) VALUES (9, N'Avril')
GO
INSERT [dbo].[tblFeetype] ([idFeesType], [labelFee]) VALUES (10, N'Mai')
GO
INSERT [dbo].[tblFeetype] ([idFeesType], [labelFee]) VALUES (11, N'Juin')
GO
GO
SET IDENTITY_INSERT [dbo].[tblFiliere] ON 

GO
INSERT [dbo].[tblFiliere] ([idFiliere], [labelFiliere], [idNiveau]) VALUES (1, 'Jardin d''enfants', 1)
GO
INSERT [dbo].[tblFiliere] ([idFiliere], [labelFiliere], [idNiveau]) VALUES (2, N'Maternelle', 1)
GO
INSERT [dbo].[tblFiliere] ([idFiliere], [labelFiliere], [idNiveau]) VALUES (4, N'Première primaire', 2)
GO
INSERT [dbo].[tblFiliere] ([idFiliere], [labelFiliere], [idNiveau]) VALUES (5, N'Deuxième primaire', 2)
GO
INSERT [dbo].[tblFiliere] ([idFiliere], [labelFiliere], [idNiveau]) VALUES (6, N'Troisième primaire', 2)
GO
INSERT [dbo].[tblFiliere] ([idFiliere], [labelFiliere], [idNiveau]) VALUES (7, N'Quatrième primaire', 2)
GO
INSERT [dbo].[tblFiliere] ([idFiliere], [labelFiliere], [idNiveau]) VALUES (8, N'Cinquième primaire', 2)
GO
INSERT [dbo].[tblFiliere] ([idFiliere], [labelFiliere], [idNiveau]) VALUES (9, N'Sixième primaire', 2)
GO
INSERT [dbo].[tblFiliere] ([idFiliere], [labelFiliere], [idNiveau]) VALUES (10, N'Première préparation', 3)
GO
INSERT [dbo].[tblFiliere] ([idFiliere], [labelFiliere], [idNiveau]) VALUES (11, N'Deuxième préparation', 3)
GO
INSERT [dbo].[tblFiliere] ([idFiliere], [labelFiliere], [idNiveau]) VALUES (12, N'Troisième préparation', 3)
GO
INSERT [dbo].[tblFiliere] ([idFiliere], [labelFiliere], [idNiveau]) VALUES (13, N'TCLSH', 4)
GO
INSERT [dbo].[tblFiliere] ([idFiliere], [labelFiliere], [idNiveau]) VALUES (14, N'TCS', 4)
GO
INSERT [dbo].[tblFiliere] ([idFiliere], [labelFiliere], [idNiveau]) VALUES (15, N'TCT', 4)
GO
SET IDENTITY_INSERT [dbo].[tblFiliere] OFF
GO
SET IDENTITY_INSERT [dbo].[tblNivau] ON 

GO
INSERT [dbo].[tblNivau] ([idNiveau], [LabelNivau]) VALUES (1, N'Apprivoisé')
GO
INSERT [dbo].[tblNivau] ([idNiveau], [LabelNivau]) VALUES (2, N'Primaire')
GO
INSERT [dbo].[tblNivau] ([idNiveau], [LabelNivau]) VALUES (3, N'Préparatoire')
GO
INSERT [dbo].[tblNivau] ([idNiveau], [LabelNivau]) VALUES (4, N'Secondaire')
GO
SET IDENTITY_INSERT [dbo].[tblNivau] OFF
GO
SET IDENTITY_INSERT [dbo].[tblOtherFees] ON 

GO
GO
INSERT [dbo].[tblOtherFees] ([idOtherfees], [Name], [Price]) VALUES (1, N'L''association des parents d''élèves', CAST(10.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[tblOtherFees] OFF
GO
SET IDENTITY_INSERT [dbo].[tblschoolYear] ON 

GO

GO

INSERT [dbo].[tblschoolYear] ([idyear], [SchoolYear]) VALUES (1, N'2015-2016')
GO
INSERT [dbo].[tblschoolYear] ([idyear], [SchoolYear]) VALUES (2, N'2016-2017')
GO
INSERT [dbo].[tblschoolYear] ([idyear], [SchoolYear]) VALUES (3, N'2017-2018')
GO
INSERT [dbo].[tblschoolYear] ([idyear], [SchoolYear]) VALUES (4, N'2018-2019')
GO
INSERT [dbo].[tblschoolYear] ([idyear], [SchoolYear]) VALUES (5, N'2019-2020')
GO
INSERT [dbo].[tblschoolYear] ([idyear], [SchoolYear]) VALUES (6, N'2020-2021')
GO
INSERT [dbo].[tblschoolYear] ([idyear], [SchoolYear]) VALUES (7, N'2021-2022')
GO
SET IDENTITY_INSERT [dbo].[tblschoolYear] OFF

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [unique_Num]    Script Date: 7/18/2017 4:35:18 PM ******/
ALTER TABLE [dbo].[tblDiscount] ADD  CONSTRAINT [unique_Num] UNIQUE NONCLUSTERED 
(
    [NumInscription] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [unique_ch]    Script Date: 7/18/2017 4:35:18 PM ******/
ALTER TABLE [dbo].[tblOtherFees] ADD  CONSTRAINT [unique_ch] UNIQUE NONCLUSTERED 
(
    [Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_tblFiliere] FOREIGN KEY([idFiliere])
REFERENCES [dbo].[tblFiliere] ([idFiliere])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_tblFiliere]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_tblschoolYear] FOREIGN KEY([idYear])
REFERENCES [dbo].[tblschoolYear] ([idyear] )
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_tblschoolYear]
GO
ALTER TABLE [dbo].[DetailPaiment]  WITH CHECK ADD  CONSTRAINT [FK_DetailPaiment_tblFees] FOREIGN KEY([idFacture])
REFERENCES [dbo].[tblFees] ([idFees])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetailPaiment] CHECK CONSTRAINT [FK_DetailPaiment_tblFees]
GO
ALTER TABLE [dbo].[DetailPaiment]  WITH CHECK ADD  CONSTRAINT [FK_DetailPaiment_tblFeetype] FOREIGN KEY([idMonth])
REFERENCES [dbo].[tblFeetype] ([idFeesType])
GO
ALTER TABLE [dbo].[DetailPaiment] CHECK CONSTRAINT [FK_DetailPaiment_tblFeetype]
GO
ALTER TABLE [dbo].[DetailPaiment]  WITH CHECK ADD  CONSTRAINT [FK_DetailPaiment_tblOtherFees] FOREIGN KEY([idOtherFees])
REFERENCES [dbo].[tblOtherFees] ([idOtherfees])
GO
ALTER TABLE [dbo].[DetailPaiment] CHECK CONSTRAINT [FK_DetailPaiment_tblOtherFees]
GO
ALTER TABLE [dbo].[DetailPaiment]  WITH CHECK ADD  CONSTRAINT [FK_DetailPaiment_tblStudent] FOREIGN KEY([NumInscription])
REFERENCES [dbo].[tblStudent] ([NumInscription])
GO
ALTER TABLE [dbo].[DetailPaiment] CHECK CONSTRAINT [FK_DetailPaiment_tblStudent]
GO
ALTER TABLE [dbo].[tblDiscount]  WITH CHECK ADD  CONSTRAINT [FK_tblDiscount_tblStudent] FOREIGN KEY([NumInscription])
REFERENCES [dbo].[tblStudent] ([NumInscription])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblDiscount] CHECK CONSTRAINT [FK_tblDiscount_tblStudent]
GO
ALTER TABLE [dbo].[tblFees]  WITH CHECK ADD  CONSTRAINT [FK_tblFees_tblschoolYear] FOREIGN KEY([idyear])
REFERENCES [dbo].[tblschoolYear] ([idyear])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblFees] CHECK CONSTRAINT [FK_tblFees_tblschoolYear]
GO
ALTER TABLE [dbo].[tblFiliere]  WITH CHECK ADD  CONSTRAINT [FK_tblFiliere_tblNivau] FOREIGN KEY([idNiveau])
REFERENCES [dbo].[tblNivau] ([idNiveau])
GO
ALTER TABLE [dbo].[tblFiliere] CHECK CONSTRAINT [FK_tblFiliere_tblNivau]
GO
ALTER TABLE [dbo].[tblStudent]  WITH CHECK ADD  CONSTRAINT [FK_tblStudent_Classes] FOREIGN KEY([classID])
REFERENCES [dbo].[Classes] ([idClass])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblStudent] CHECK CONSTRAINT [FK_tblStudent_Classes]
GO
ALTER TABLE [dbo].[tblStudent]  WITH CHECK ADD  CONSTRAINT [FK_tblStudent_tblschoolYear] FOREIGN KEY([idyear])
REFERENCES [dbo].[tblschoolYear] ([idyear])

GO
ALTER TABLE [dbo].[tblStudent] CHECK CONSTRAINT [FK_tblStudent_tblschoolYear]
GO


/****** Object:  StoredProcedure [dbo].[PS_addSchoolYear]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PS_addSchoolYear]
@SchoolYear nvarchar(50)
as

INSERT INTO [dbo].[tblschoolYear]
           ([SchoolYear])
     VALUES
           (@SchoolYear)

GO
/****** Object:  StoredProcedure [dbo].[PS_addStudent]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PS_addStudent] 
    @NumInscription varchar(50),
    @FullName nvarchar(50),
    @Gender nvarchar(50) = NULL,
    @birthday date = NULL,
    @birthPlace nvarchar(100) = NULL,
    @Nationalite nvarchar(50) = NULL,
    @fatherName nvarchar(50) = NULL,
    @fatherJob nvarchar(50) = NULL,
    @adress nvarchar(100) = NULL,
    @handphone nvarchar(50) = NULL,
    @homephone nvarchar(50) = NULL,
    @photo image = NULL,
    @status bit = NULL,
    @InscriptionDate datetime = NULL,
    @Registrationfees decimal(18, 2) = NULL,
    @Monthlyfees decimal(18, 2) = NULL,
    @classID bigint = NULL,
    @idyear bigint = NULL
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  
    
    BEGIN TRAN
    
    INSERT INTO [dbo].[tblStudent] ([NumInscription], [FullName], [Gender], [birthday], [birthPlace], [Nationalite], [fatherName], [fatherJob], [adress], [handphone], [homephone], [photo], [status], [InscriptionDate], [Registrationfees], [Monthlyfees], [classID], [idyear])
    SELECT @NumInscription, @FullName, @Gender, @birthday, @birthPlace, @Nationalite, @fatherName, @fatherJob, @adress, @handphone, @homephone, @photo, @status, @InscriptionDate, @Registrationfees, @Monthlyfees, @classID, @idyear
               
    COMMIT

GO
/****** Object:  StoredProcedure [dbo].[Ps_DeleteClasses]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Ps_DeleteClasses]
@idClass bigint
As
    Delete Classes where idClass = @idClass

GO
/****** Object:  StoredProcedure [dbo].[PS_DeleteSchoolYear]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PS_DeleteSchoolYear]
@idyear bigint
as
    delete tblschoolYear where idyear = @idyear

GO
/****** Object:  StoredProcedure [dbo].[Ps_GetClassByFiliere]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Ps_GetClassByFiliere]
@id bigint,
@idYear bigint
as
    select * from Classes where idFiliere = @id and idYear = @idYear

GO
/****** Object:  StoredProcedure [dbo].[PS_GetClassesData]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[PS_GetClassesData]
as
Select idClass 'identifiant Remise', C.LabelC 'Section', F.labelFiliere 'Nom Filière', S.SchoolYear 'Année scolaire' from Classes C
    Join tblFiliere f on f.idFiliere = c.idFiliere
    Join tblschoolYear S on s.idyear = c.idYear

GO
/****** Object:  StoredProcedure [dbo].[PS_GetClassesDataByYear]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[PS_GetClassesDataByYear]
@idyear bigint
as
Select idClass 'identifiant Remise', C.LabelC ' Section', F.labelFiliere 'Nom Filière', S.SchoolYear 'Année scolaire' from Classes C
    Join tblFiliere f on f.idFiliere = c.idFiliere
    Join tblschoolYear S on s.idyear = c.idYear
    Where C.idyear = @idyear

GO
/****** Object:  StoredProcedure [dbo].[Ps_GetFilierByNivau]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Ps_GetFilierByNivau]
@id bigint
as
    select * from tblFiliere where idNiveau = @id

GO
/****** Object:  StoredProcedure [dbo].[Ps_GetFiliers]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[Ps_GetFiliers]
as
    select * from tblFiliere

GO
/****** Object:  StoredProcedure [dbo].[Ps_GetYears]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Ps_GetYears]
as
    select * from tblschoolYear
    order by SchoolYear

GO
/****** Object:  StoredProcedure [dbo].[Ps_InsertClasses]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Ps_InsertClasses]
@Label nvarchar(50)
,@idFiliere bigint
,@idYear bigint
As
    Insert Classes (LabelC, idFiliere, idYear) Values (@Label, @idFiliere, @idYear)

GO
/****** Object:  StoredProcedure [dbo].[PS_InsertFiliere]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[PS_InsertFiliere]
@label nvarchar(50)
,@idNiveau bigint
as

IF EXISTS (select * from tblFiliere where labelFiliere = @label)
    BEGIN
        ROLLBACK;
        RETURN;
    END
ELSE
    BEGIN
        INSERT INTO [dbo].[tblFiliere]
           ([labelFiliere]
           ,[idNiveau])
        VALUES
           (@label
           ,@idNiveau)

    END

GO
/****** Object:  StoredProcedure [dbo].[PS_RemoveFiliere]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[PS_RemoveFiliere]
@id bigint
as
    Delete tblFiliere where idFiliere = @id

GO
/****** Object:  StoredProcedure [dbo].[PS_SelectFiliere]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[PS_SelectFiliere]
as
    select idFiliere 'ID', f.labelFiliere 'Nom', n.LabelNivau 'Nivau' from tblFiliere f
    JOIN tblNivau n on n.idNiveau = f.idNiveau

GO
/****** Object:  StoredProcedure [dbo].[PS_SelectNivau]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[PS_SelectNivau]
as
    select * from tblNivau

GO
/****** Object:  StoredProcedure [dbo].[PS_SelectSchoolYear]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PS_SelectSchoolYear]
as
    select idyear 'ID', SchoolYear 'Année scolaire' from tblschoolYear
    order by SchoolYear

GO
/****** Object:  StoredProcedure [dbo].[Ps_UpdateClasses]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Ps_UpdateClasses]
@idClass bigint
,@Label nvarchar(50)
,@idFiliere bigint
,@idYear bigint
as
    update Classes set LabelC = @Label, idFiliere = @idFiliere, idYear = @idYear
        Where idClass = @idClass

GO
/****** Object:  StoredProcedure [dbo].[PS_UpdateFiliere]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[PS_UpdateFiliere]
@id bigint,
@label nvarchar(50)
,@idNiveau bigint
as
    update tblFiliere set labelFiliere = @label, idNiveau = @idNiveau where idFiliere = @id

GO
/****** Object:  StoredProcedure [dbo].[PS_UpdateSchoolYear]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PS_UpdateSchoolYear]
@idyear bigint,
@SchoolYear nvarchar(50)
as
    update tblschoolYear set SchoolYear = @SchoolYear where idyear = @idyear

GO

/****** Object:  StoredProcedure [dbo].[usp_getDateProfit]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[usp_getDateProfit]
@datebegin date,
@dateend date
as
SELECT SUM(GrandTotal) from tblFees where FeesDate between @datebegin and @dateend

GO
/****** Object:  StoredProcedure [dbo].[usp_GetFeesByDate]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_GetFeesByDate]
@date date
as
select DISTINCT idFees 'Identifiant Frais', s.NumInscription 'Numéro de Étudiant ', s.FullName 'Nom Complet ', ft.labelFee 'Frais', sy.SchoolYear 'Année scolaire', GrandTotal 'Montant total', TotalPaid 'Le montant payé', DuePaid 'Le reste', CONVERT(char, FeesDate, 105) 'Date de paiement' , Note 'Remarques' from tblFees fe
    JOIN DetailPaiment dp on dp.idFacture = fe.idFees
    jOIN tblStudent s on s.NumInscription = dp.NumInscription
    join tblschoolYear sy on sy.idyear = fe.idyear
    JOIN tblFeetype ft on ft.idFeesType = dp.idMonth
    Where CONVERT(date, fe.FeesDate) = @date

GO
/****** Object:  StoredProcedure [dbo].[usp_getLastFees]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_getLastFees]
as
    SELECT MAX(idFees) FROM tblFees

GO
/****** Object:  StoredProcedure [dbo].[usp_getLateThismonth]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[usp_getLateThismonth]
@classID bigint,
@idMonth bigint
as
SELECT [NumInscription]'Num Inscription', [FullName] 'Nom Complet ', [Gender] 'Sexe', Convert(char, birthday, 105) 'Date de naissance', birthPlace 'Lieu de naissance',
     [Nationalite] 'Nationalité', [fatherName]'Nom du père', [fatherJob] 'Père métier', [adress] 'Adresse', [handphone] 'Téléphone mobile', [homephone] 'Téléphone Fixe', Convert(char, InscriptionDate, 105) 'Date Inscription',
      [Registrationfees] 'Frais inscription et assurance', [Monthlyfees] 'Montant mensuel'

    FROM   [dbo].[tblStudent] where classID = @classID
And NumInscription NOT IN (SELECT NumInscription FROM DetailPaiment WHERE idMonth = @idMonth)

GO
/****** Object:  StoredProcedure [dbo].[usp_getLateThismonthNoClasses]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[usp_getLateThismonthNoClasses]
@idYear bigint,
@idMonth bigint
as
SELECT [NumInscription]'Num Inscription', [FullName] 'Nom Complet', [Gender] 'Sexe', Convert(char, birthday, 105) 'Date de naissance', birthPlace 'Lieu de naissance',
     [Nationalite] 'Nationalité', [fatherName]'Nom du père', [fatherJob] 'Père métier', [adress] 'Adresse', [handphone] 'Téléphone mobile', [homephone] 'Téléphone Fixe', Convert(char, InscriptionDate, 105) 'Date Inscription',
      [Registrationfees] 'Frais inscription et assurance', [Monthlyfees] 'Montant mensuel'

    FROM   [dbo].[tblStudent] where idyear = @idYear
And NumInscription NOT IN (SELECT NumInscription FROM DetailPaiment WHERE idMonth = @idMonth)
GO
/****** Object:  StoredProcedure [dbo].[usp_getMu]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_getMu]
@NumInscription varchar(50),
@year nvarchar(50)
as
    Declare @yearly decimal
    Declare @paidRegistrationFee decimal
    Declare @paidMonth decimal
    Declare @idyear bigint
    Declare @Rest decimal
    Select @idyear = idyear from tblschoolYear where SchoolYear = @year
    
    Set @paidRegistrationFee = (Select top 1  COUNT(distinct idFees) from tblFees F join DetailPaiment dp on dp.idFacture = f.idFees
                left join tblOtherFees tof on tof.idOtherfees = dp.idOtherFees
                Where NumInscription = @NumInscription and idyear = @idyear
                and idMonth = 1
                group by NumInscription)

    Set @paidMonth = (Select top 1  COUNT(distinct idFees) from tblFees F join DetailPaiment dp on dp.idFacture = f.idFees
                left join tblOtherFees tof on tof.idOtherfees = dp.idOtherFees
                Where NumInscription = @NumInscription and idyear = @idyear
                and idMonth <> 1
                group by NumInscription)

    Set @yearly = (Select top 1 Registrationfees - (Registrationfees * ISNULL(@paidRegistrationFee, 0)) + (Monthlyfees * (10-ISNULL(@paidMonth, 0))) from tblStudent s
                    Where NumInscription = @NumInscription and idyear = @idyear
                    ) 
    Set @Rest = (Select top 1  SUM(DuePaid) from tblFees F join DetailPaiment dp on dp.idFacture = f.idFees
                left join tblOtherFees tof on tof.idOtherfees = dp.idOtherFees
                Where NumInscription = @NumInscription and idyear = @idyear
                group by NumInscription)

    Select @yearly,ISNULL(@Rest, 0)
GO
/****** Object:  StoredProcedure [dbo].[usp_getMyDiscoutn]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[usp_getMyDiscoutn]
@NumInscription varchar(50)
as
    select top 1 Discount from tblDiscount Where NumInscription = @NumInscription

GO
/****** Object:  StoredProcedure [dbo].[usp_getmylatDue]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_getmylatDue]
@NumInscription varchar(50)
as
    Select ISNULL(sum(DuePaid), 0) from tblFees F join DetailPaiment dp on dp.idFacture = f.idFees
    Where NumInscription = @NumInscription

GO

/****** Object:  StoredProcedure [dbo].[usp_getNameOfUsers]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[usp_getNameOfUsers]
as
    Select username from tblUsers

GO
/****** Object:  StoredProcedure [dbo].[usp_GetNombreOfFees]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[usp_GetNombreOfFees]
@SchoolYear nvarchar(50),
@filiere bigint
as
select DISTINCT idFees 'Identifiant Frais', s.NumInscription 'Numéro de Étudiant ', s.FullName 'Nom Complet ', ft.labelFee 'Frais', sy.SchoolYear 'Année scolaire', GrandTotal 'Montant total', TotalPaid 'Le montant payé', DuePaid 'Le reste', CONVERT(char, FeesDate, 105) 'Date de paiement' , Note 'Remarques' from tblFees fe
    JOIN DetailPaiment dp on dp.idFacture = fe.idFees
    jOIN tblStudent s on s.NumInscription = dp.NumInscription
    join tblschoolYear sy on sy.idyear = fe.idyear
    JOIN tblFeetype ft on ft.idFeesType = dp.idMonth
    Join Classes c on c.idClass = s.classID
    JOIN tblFiliere tbf on tbf.idFiliere = c.idFiliere
    Where sy.SchoolYear = @SchoolYear And tbf.idFiliere = @filiere

GO
/****** Object:  StoredProcedure [dbo].[usp_GetNumeroRecu]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[usp_GetNumeroRecu]
@NumInscription varchar(50)
as
    Select count(Idfees) from tblfees F JOIN DetailPaiment  dp on dp.idFacture = f.idFees
    Where NumInscription = @NumInscription

GO
/****** Object:  StoredProcedure [dbo].[usp_getRecu]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_getRecu]
 @idfees bigint
as
    SELECT idFacture, s.NumInscription, s.FullName, fl.labelFiliere 'filiere', c.LabelC 'classe', y.SchoolYear
    , GrandTotal, TotalPaid, DuePaid, Note FROM tblFees F JOIN DetailPaiment DP ON DP.idFacture = F.idFees
    JOIN tblStudent S ON S.NumInscription = DP.NumInscription
    JOIN tblschoolYear Y ON Y.idyear = F.idyear
    JOIN Classes C ON C.idClass = S.classID
    JOIN tblFiliere FL ON FL.idFiliere = C.idFiliere
    Where idFees = @idfees

GO
/****** Object:  StoredProcedure [dbo].[usp_GetStudentByID]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[usp_GetStudentByID] 
    @NumInscription varchar(50)
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  

    BEGIN TRAN

    SELECT [NumInscription], [FullName], [Gender], [birthday], [birthPlace], [Nationalite], [fatherName], [fatherJob], [adress], [handphone], [homephone], [photo], [status], [InscriptionDate], [Registrationfees], [Monthlyfees], c.LabelC 'class', sy.SchoolYear, f.labelFiliere 'filier', n.LabelNivau 'niveau'
    FROM   [dbo].[tblStudent] S Inner join Classes C on c.idClass = s.classID
    JOIN tblFiliere f on f.idFiliere = c.idFiliere
    JOIN tblNivau N on n.idNiveau = f.idNiveau
    Join tblschoolYear sy on sy.idyear = s.idYear
    WHERE  ([NumInscription] = @NumInscription) 

    COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_getThisMonthProfit]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[usp_getThisMonthProfit]
as
    SELECT SUM(GrandTotal) FROM tblFees where month(FeesDate) = month(getdate())

GO
/****** Object:  StoredProcedure [dbo].[usp_login]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[usp_login]
@username nvarchar(50),
@pswd nvarchar(50)
as

    select * from tblUsers where username = @username and pswd = @pswd

GO

/****** Object:  StoredProcedure [dbo].[Usp_SearchStudentbyClass]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Usp_SearchStudentbyClass]
@idClass bigint
as
    SELECT [NumInscription]'Num Inscription', [FullName] 'Nom Complet ', [Gender] 'Sexe', Convert(char, birthday, 105) 'Date de naissance', birthPlace 'Lieu de naissance',
     [Nationalite] 'Nationalité', [fatherName]'Nom du père', [fatherJob] 'Père métier', [adress] 'Adresse', [handphone] 'Téléphone mobile', [homephone] 'Téléphone Fixe', Convert(char, InscriptionDate, 105) 'Date Inscription',
      [Registrationfees] 'Frais inscription et assurance', [Monthlyfees] 'Montant mensuel', sy.SchoolYear 'Année scolaire', f.labelFiliere 'Filière', c.LabelC 'Section'

    FROM   [dbo].[tblStudent] S Inner join Classes C on c.idClass = s.classID
    JOIN tblFiliere f on f.idFiliere = c.idFiliere
    JOIN tblNivau N on n.idNiveau = f.idNiveau
    Join tblschoolYear sy on sy.idyear = s.idYear
    Where idClass = @idClass

GO
/****** Object:  StoredProcedure [dbo].[Usp_SearchStudentbyDate]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Usp_SearchStudentbyDate]
@dateBegin datetime,
@dateEnd datetime
as
    SELECT [NumInscription]'Num Inscription', [FullName] 'Nom Complet ', [Gender] 'Sexe', Convert(char, birthday, 105) 'Date de naissance', birthPlace 'Lieu de naissance',
     [Nationalite] 'Nationalité', [fatherName]'Nom du père', [fatherJob] 'Père métier', [adress] 'Adresse', [handphone] 'Téléphone mobile', [homephone] 'Téléphone Fixe', Convert(char, InscriptionDate, 105) 'Date Inscription',
      [Registrationfees] 'Frais inscription et assurance', [Monthlyfees] 'Montant mensuel', sy.SchoolYear 'Année scolaire', f.labelFiliere 'Filière', c.LabelC 'Section'

    FROM   [dbo].[tblStudent] S Inner join Classes C on c.idClass = s.classID
    JOIN tblFiliere f on f.idFiliere = c.idFiliere
    JOIN tblNivau N on n.idNiveau = f.idNiveau
    Join tblschoolYear sy on sy.idyear = s.idYear
    Where InscriptionDate between @dateBegin and @dateEnd

GO
/****** Object:  StoredProcedure [dbo].[usp_searchUsr]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[usp_searchUsr]
@search nvarchar(50)
as

    SELECT [username] 'Nom d''utilisateur', [FullName] 'Nom Complet ', 
    [Email] 'Email', [pswd] 'Mot de pass'
    FROM   [dbo].[tblUsers] U
    Where username + FullName + Email like '%' + @search + '%'

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectFees]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[usp_SelectFees]
as
    select DISTINCT idFees 'Identifiant Frais', s.NumInscription 'Numéro de Étudiant ', s.FullName 'Nom Complet ', ft.labelFee 'Frais', sy.SchoolYear 'Année scolaire', GrandTotal 'Montant total', TotalPaid 'Le montant payé', DuePaid 'Le reste', CONVERT(char, FeesDate, 105) 'Date de paiement' , Note 'Remarques' from tblFees fe
    JOIN DetailPaiment dp on dp.idFacture = fe.idFees
    jOIN tblStudent s on s.NumInscription = dp.NumInscription
    join tblschoolYear sy on sy.idyear = fe.idyear
    JOIN tblFeetype ft on ft.idFeesType = dp.idMonth

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectFeesByClass]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[usp_SelectFeesByClass]
@idClass bigint
as
    select DISTINCT idFees 'Identifiant Frais', s.NumInscription 'Numéro de Étudiant ', s.FullName 'Nom Complet ', ft.labelFee 'Frais', sy.SchoolYear 'Année scolaire', GrandTotal 'Montant total', TotalPaid 'Le montant payé', DuePaid 'Le reste', CONVERT(char, FeesDate, 105) 'Date de paiement' , Note 'Remarques' from tblFees fe
    JOIN DetailPaiment dp on dp.idFacture = fe.idFees
    jOIN tblStudent s on s.NumInscription = dp.NumInscription
    join tblschoolYear sy on sy.idyear = fe.idyear
    JOIN tblFeetype ft on ft.idFeesType = dp.idMonth
    Where s.classID = @idClass

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectFeesById]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[usp_SelectFeesById]
@idFees bigint
as
    select DISTINCT idFees 'Identifiant Frais', s.NumInscription 'Numéro de Étudiant ', s.FullName 'Nom Complet ', ft.labelFee 'Frais', sy.SchoolYear 'Année scolaire', GrandTotal 'Montant total', TotalPaid 'Le montant payé', DuePaid 'Le reste', CONVERT(char, FeesDate, 105) 'Date de paiement' , Note 'Remarques' from tblFees fe
    JOIN DetailPaiment dp on dp.idFacture = fe.idFees
    jOIN tblStudent s on s.NumInscription = dp.NumInscription
    join tblschoolYear sy on sy.idyear = fe.idyear
    JOIN tblFeetype ft on ft.idFeesType = dp.idMonth
    Where idFees = @idFees

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectFeesByName]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[usp_SelectFeesByName]
@Name Nvarchar
as
    select DISTINCT idFees 'Identifiant Frais', s.NumInscription 'Numéro de Étudiant ', s.FullName 'Nom Complet ', ft.labelFee 'Frais', sy.SchoolYear 'Année scolaire', GrandTotal 'Montant total', TotalPaid 'Le montant payé', DuePaid 'Le reste', CONVERT(char, FeesDate, 105) 'Date de paiement' , Note 'Remarques' from tblFees fe
    JOIN DetailPaiment dp on dp.idFacture = fe.idFees
    jOIN tblStudent s on s.NumInscription = dp.NumInscription
    join tblschoolYear sy on sy.idyear = fe.idyear
    JOIN tblFeetype ft on ft.idFeesType = dp.idMonth
    Where s.FullName Like '%' + @Name + '%'

GO
/****** Object:  StoredProcedure [dbo].[usp_tblDiscountDelete]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblDiscountDelete] 
    @idDiscount bigint
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  
    
    BEGIN TRAN

    DELETE
    FROM   [dbo].[tblDiscount]
    WHERE  [idDiscount] = @idDiscount

    COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_tblDiscountInsert]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblDiscountInsert] 
    @Discount decimal(18, 2),
    @Reason nvarchar(MAX) = NULL,
    @NumInscription nvarchar(50)
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  
    
    BEGIN TRAN
    
    INSERT INTO [dbo].[tblDiscount] ([Discount], [Reason], [NumInscription])
    SELECT @Discount, @Reason, @NumInscription
    
    -- Begin Return Select <- do not remove
    SELECT [idDiscount], [Discount], [Reason], [NumInscription]
    FROM   [dbo].[tblDiscount]
    WHERE  [idDiscount] = SCOPE_IDENTITY()
    -- End Return Select <- do not remove
               
    COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_tblDiscountSelect]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblDiscountSelect] 
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  

    BEGIN TRAN

    SELECT [idDiscount] 'identifiant Remise', [Discount] 'Montant de la remise', [Reason] ' la raison', [NumInscription] 'Numéro de Étudiant '
    FROM   [dbo].[tblDiscount] 

    COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_tblDiscountUpdate]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblDiscountUpdate] 
    @idDiscount bigint,
    @Discount decimal(18, 2),
    @Reason nvarchar(MAX) = NULL,
    @NumInscription nvarchar(50)
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  
    
    BEGIN TRAN

    UPDATE [dbo].[tblDiscount]
    SET    [Discount] = @Discount, [Reason] = @Reason, [NumInscription] = @NumInscription
    WHERE  [idDiscount] = @idDiscount
    
    -- Begin Return Select <- do not remove
    SELECT [idDiscount], [Discount], [Reason], [NumInscription]
    FROM   [dbo].[tblDiscount]
    WHERE  [idDiscount] = @idDiscount   
    -- End Return Select <- do not remove

    COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_tblFeesDelete]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblFeesDelete] 
    @idFees bigint
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  
    
    BEGIN TRAN

    DELETE
    FROM   [dbo].[tblFees]
    WHERE  [idFees] = @idFees

    COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_tblFeesInsert]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblFeesInsert] 
    @schoolYear nvarchar(50),
    @GrandTotal decimal(18, 2),
    @TotalPaid decimal(18, 2),
    @DuePaid decimal(18, 2) = NULL,
    @FeesDate datetime = NULL,
    @tblDetailPaimentTable tblDetailPaimentTable READONLY,
    @Note nvarchar(max)

AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  
    
    BEGIN TRAN
    Declare @idyear bigint
    set @idyear = (Select top 1 idyear from tblschoolYear where SchoolYear = @schoolYear)

    IF EXISTS (
        select f.idyear, idMonth, s.NumInscription from tblFees F join DetailPaiment dp on dp.idFacture = f.idFees
        join tblStudent s on s.NumInscription = dp.NumInscription
        join tblFeetype ft on ft.idFeesType = dp.idMonth
        where s.NumInscription = (select top 1 NumInscription from @tblDetailPaimentTable)
        And f.idyear = @idyear and idMonth = (select top 1 idMonth from @tblDetailPaimentTable)
        Group by f.idyear, idMonth, s.NumInscription
        Having count(*) > 0
    )
        BEGIN
            RAISERROR(N'Cette Frais a été payée', 16, 1);
            ROLLBACK;
            RETURN;
        END 
        update F set DuePaid = 0 from tblFees F Join DetailPaiment dp on dp.idFacture = f.idFees
        Where NumInscription = (select top 1 NumInscription from @tblDetailPaimentTable)
        INSERT INTO [dbo].[tblFees] ([idyear], [GrandTotal], [TotalPaid], [DuePaid], [FeesDate], Note)
    SELECT @idyear, @GrandTotal, @TotalPaid, @DuePaid, @FeesDate, @Note

    INSERT INTO DetailPaiment (idFacture, idMonth,NumInscription, idOtherFees)
    SELECT SCOPE_IDENTITY(), idMonth,NumInscription, idOtherFees FROM @tblDetailPaimentTable
    
    COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_tblFeesUpdate]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblFeesUpdate] 
    @idFees bigint,
    @GrandTotal decimal(18, 2),
    @TotalPaid decimal(18, 2),
    @DuePaid decimal(18, 2) = NULL,
    @Note nvarchar(MAX) = NULL
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  
    
    BEGIN TRAN

    UPDATE [dbo].[tblFees]
    SET    [GrandTotal] = @GrandTotal, [TotalPaid] = @TotalPaid, [DuePaid] = @DuePaid, [Note] = @Note
    WHERE  [idFees] = @idFees
    
    -- Begin Return Select <- do not remove
    SELECT [idFees], [idyear], [GrandTotal], [TotalPaid], [DuePaid], [FeesDate], [Note]
    FROM   [dbo].[tblFees]
    WHERE  [idFees] = @idFees   
    -- End Return Select <- do not remove

    COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_tblFeetypeSelect]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblFeetypeSelect] 
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  

    BEGIN TRAN

    SELECT [idFeesType], [labelFee] 
    FROM   [dbo].[tblFeetype] 

    COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_tblOtherFeesDelete]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblOtherFeesDelete] 
    @idOtherfees bigint
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  
    
    BEGIN TRAN

    DELETE
    FROM   [dbo].[tblOtherFees]
    WHERE  [idOtherfees] = @idOtherfees

    COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_tblOtherFeesInsert]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblOtherFeesInsert] 
    @Name nvarchar(50) = NULL,
    @Price decimal(18, 2) = NULL
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  
    
    BEGIN TRAN
    
    INSERT INTO [dbo].[tblOtherFees] ([Name], [Price])
    SELECT @Name, @Price
    
    -- Begin Return Select <- do not remove
    SELECT [idOtherfees], [Name], [Price]
    FROM   [dbo].[tblOtherFees]
    WHERE  [idOtherfees] = SCOPE_IDENTITY()
    -- End Return Select <- do not remove
               
    COMMIT
GO
/****** Object:  StoredProcedure [dbo].[usp_tblOtherFeesSelect]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblOtherFeesSelect] 
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  

    BEGIN TRAN

    SELECT [idOtherfees] 'ID Frais' , [Name] 'Nom de Frais', [Price] 'Montant de Frais'
    FROM   [dbo].[tblOtherFees] 

    COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_tblOtherFeesUpdate]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblOtherFeesUpdate] 
    @idOtherfees bigint,
    @Name nvarchar(50) = NULL,
    @Price decimal(18, 2) = NULL
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  
    
    BEGIN TRAN

    UPDATE [dbo].[tblOtherFees]
    SET    [Name] = @Name, [Price] = @Price
    WHERE  [idOtherfees] = @idOtherfees
    
    -- Begin Return Select <- do not remove
    SELECT [idOtherfees], [Name], [Price]
    FROM   [dbo].[tblOtherFees]
    WHERE  [idOtherfees] = @idOtherfees 
    -- End Return Select <- do not remove

    COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_tblStudentDelete]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblStudentDelete] 
    @NumInscription varchar(50)
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  
    
    BEGIN TRAN

    DELETE
    FROM   [dbo].[tblStudent]
    WHERE  [NumInscription] = @NumInscription

    COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_tblStudentSelect]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblStudentSelect]
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  

    BEGIN TRAN

    SELECT [NumInscription]'Num Inscription', [FullName] 'Nom Complet ', [Gender] 'Sexe', Convert(char, birthday, 105) 'Date de naissance', birthPlace 'Lieu de naissance',
     [Nationalite] 'Nationalité', [fatherName]'Nom du père', [fatherJob] 'Père métier', [adress] 'Adresse', [handphone] 'Téléphone mobile', [homephone] 'Téléphone Fixe', Convert(char, InscriptionDate, 105) 'Date Inscription',
      [Registrationfees] 'Frais inscription et assurance', [Monthlyfees] 'Montant mensuel', sy.SchoolYear 'Année scolaire', f.labelFiliere 'Filière', c.LabelC 'Section'

    FROM   [dbo].[tblStudent] S Inner join Classes C on c.idClass = s.classID
    JOIN tblFiliere f on f.idFiliere = c.idFiliere
    JOIN tblNivau N on n.idNiveau = f.idNiveau
    Join tblschoolYear sy on sy.idyear = s.idYear

    COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_tblStudentSelectByName]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblStudentSelectByName] 
    @search nvarchar(50)
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  

    BEGIN TRAN

    SELECT [NumInscription]'Num Inscription',  [FullName] 'Nom Complet ', [Gender] 'Sexe', Convert(char, birthday, 105) 'Date de naissance', birthPlace 'Lieu de naissance',
     [Nationalite] 'Nationalité', [fatherName]'Nom du père', [fatherJob] 'Père métier', [adress] 'Adresse', [handphone] 'Téléphone mobile', [homephone] 'Téléphone Fixe', Convert(char, InscriptionDate, 105) 'Date Inscription',
      [Registrationfees] 'Frais inscription et assurance', [Monthlyfees] 'Montant mensuel', sy.SchoolYear 'Année scolaire', f.labelFiliere 'Filière', c.LabelC 'Section'

    FROM   [dbo].[tblStudent] S Inner join Classes C on c.idClass = s.classID
    JOIN tblFiliere f on f.idFiliere = c.idFiliere
    JOIN tblNivau N on n.idNiveau = f.idNiveau
    Join tblschoolYear sy on sy.idyear = s.idYear
    WHERE  (FullName Like '%'+ @search+'%') 

    COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_tblStudentSelectByNumber]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblStudentSelectByNumber] 
    @NumInscription varchar(50)
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  

    BEGIN TRAN

    SELECT [NumInscription]'Num Inscription', [FullName] 'Nom Complet ', [Gender] 'Sexe', Convert(char, birthday, 105) 'Date de naissance', birthPlace 'Lieu de naissance',
     [Nationalite] 'Nationalité', [fatherName]'Nom du père', [fatherJob] 'Père métier', [adress] 'Adresse', [handphone] 'Téléphone mobile', [homephone] 'Téléphone Fixe', Convert(char, InscriptionDate, 105) 'Date Inscription',
      [Registrationfees] 'Frais inscription et assurance', [Monthlyfees] 'Montant mensuel', sy.SchoolYear 'Année scolaire', f.labelFiliere 'Filière', c.LabelC 'Section'

    FROM   [dbo].[tblStudent] S Inner join Classes C on c.idClass = s.classID
    JOIN tblFiliere f on f.idFiliere = c.idFiliere
    JOIN tblNivau N on n.idNiveau = f.idNiveau
    Join tblschoolYear sy on sy.idyear = s.idYear
    WHERE  ([NumInscription] Like '%'+ @NumInscription+'%') 

    COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_tblStudentUpdate]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblStudentUpdate] 
    @NumInscription varchar(50),
    @FullName nvarchar(50),
    @Gender nvarchar(50) = NULL,
    @birthday date = NULL,
    @birthPlace nvarchar(100) = NULL,
    @Nationalite nvarchar(50) = NULL,
    @fatherName nvarchar(50) = NULL,
    @fatherJob nvarchar(50) = NULL,
    @adress nvarchar(100) = NULL,
    @handphone nvarchar(50) = NULL,
    @homephone nvarchar(50) = NULL,
    @photo image = NULL,
    @status bit = NULL,
    @InscriptionDate datetime = NULL,
    @Registrationfees decimal(18, 2) = NULL,
    @Monthlyfees decimal(18, 2) = NULL,
    @classID bigint = NULL,
    @idyear bigint = NULL
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  
    
    BEGIN TRAN

    UPDATE [dbo].[tblStudent]
    SET    [NumInscription] = @NumInscription, [FullName] = @FullName, [Gender] = @Gender, [birthday] = @birthday, [birthPlace] = @birthPlace, [Nationalite] = @Nationalite, [fatherName] = @fatherName, [fatherJob] = @fatherJob, [adress] = @adress, [handphone] = @handphone, [homephone] = @homephone, [photo] = @photo, [status] = @status, [InscriptionDate] = @InscriptionDate, [Registrationfees] = @Registrationfees, [Monthlyfees] = @Monthlyfees, [classID] = @classID, [idyear] = @idyear
    WHERE  [NumInscription] = @NumInscription

    COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_tblUsersDelete]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblUsersDelete] 
    @username nvarchar(50)
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  
    
    BEGIN TRAN

    DELETE
    FROM   [dbo].[tblUsers]
    WHERE  [username] = @username

    COMMIT

GO
/****** Object:  StoredProcedure [dbo].[usp_tblUsersInsert]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblUsersInsert] 
    @username nvarchar(50),
    @FullName nvarchar(50) = NULL,
    @Email nvarchar(50) = NULL,
    @pswd nvarchar(50) = NULL
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  
    
    BEGIN TRAN
    
    INSERT INTO [dbo].[tblUsers] ([username], [FullName], [Email], [pswd])
    SELECT @username, @FullName, @Email, @pswd
    Commit

GO
/****** Object:  StoredProcedure [dbo].[usp_tblUsersSelect]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblUsersSelect] 
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  

    BEGIN TRAN

    SELECT [username] 'Nom d''utilisateur', [FullName] 'Nom Complet', 
    [Email] 'Email', [pswd] 'mot de pass'
    FROM   [dbo].[tblUsers] U
    COMMIT

GO

/****** Object:  StoredProcedure [dbo].[usp_tblUsersUpdate]    Script Date: 7/18/2017 4:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_tblUsersUpdate] 
    @username nvarchar(50),
    @FullName nvarchar(50) = NULL,
    @Email nvarchar(50) = NULL,
    @pswd nvarchar(50) = NULL
AS 
    SET NOCOUNT ON 
    SET XACT_ABORT ON  
    
    BEGIN TRAN

    UPDATE [dbo].[tblUsers]
    SET    [username] = @username, [FullName] = @FullName, [Email] = @Email, [pswd] = @pswd
    WHERE  [username] = @username
    
    -- Begin Return Select <- do not remove
    SELECT [username], [FullName], [Email], [pswd]
    FROM   [dbo].[tblUsers]
    WHERE  [username] = @username   
    -- End Return Select <- do not remove

    COMMIT


