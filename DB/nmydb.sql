USE [master]
GO
/****** Object:  Database [NMY_DB]    Script Date: 2019/2/6 17:53:54 ******/
CREATE DATABASE [NMY_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NMY_DB', FILENAME = N'C:\Users\Hugo\Desktop\core\NmyBlog\DB\NMY_DB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NMY_DB_log', FILENAME = N'C:\Users\Hugo\Desktop\core\NmyBlog\DB\NMY_DB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NMY_DB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NMY_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NMY_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NMY_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NMY_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NMY_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NMY_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [NMY_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NMY_DB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [NMY_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NMY_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NMY_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NMY_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NMY_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NMY_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NMY_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NMY_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NMY_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NMY_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NMY_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NMY_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NMY_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NMY_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NMY_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NMY_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NMY_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [NMY_DB] SET  MULTI_USER 
GO
ALTER DATABASE [NMY_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NMY_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NMY_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NMY_DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [NMY_DB]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 2019/2/6 17:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nchar](64) NULL,
	[Password] [nchar](64) NULL,
	[CreateDate] [datetime] NOT NULL,
	[Remark] [nchar](2048) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
create datebase NMY_DB



/****** Object:  Table [dbo].[Blog]    Script Date: 2019/2/6 17:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Title] [nchar](256) NULL,
	[Body] [ntext] NULL,
	[Body_md] [ntext] NULL,
	[VisitNum] [int] NOT NULL,
	[CaBh] [nchar](64) NULL,
	[CaName] [nchar](64) NULL,
	[Remark] [nchar](2048) NULL,
	[Sort] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 2019/2/6 17:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CaName] [nchar](64) NULL,
	[Bh] [nchar](64) NULL,
	[Pbh] [nchar](64) NULL,
	[Remark] [nchar](2048) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([Id], [UserName], [Password], [CreateDate], [Remark]) VALUES (1, N'lsy                                                             ', N'b3bf78bda035fb8803f101a1eb19026a                                ', CAST(0x0000A9EC012534CD AS DateTime), NULL)
INSERT [dbo].[Admin] ([Id], [UserName], [Password], [CreateDate], [Remark]) VALUES (2, N'hugo                                                            ', N'f1f58e8c06b2a61ce13e0c0aa9473a72                                ', CAST(0x0000A9EC0125BDA5 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Admin] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [CreateDate], [CaName], [Bh], [Pbh], [Remark]) VALUES (1, CAST(0x0000A9EC0125EBC6 AS DateTime), N'ASP.NET                                                         ', N'01                                                              ', N'0                                                               ', NULL)
INSERT [dbo].[Category] ([Id], [CreateDate], [CaName], [Bh], [Pbh], [Remark]) VALUES (2, CAST(0x0000A9EC012600D4 AS DateTime), N'PHP                                                             ', N'02                                                              ', N'0                                                               ', NULL)
INSERT [dbo].[Category] ([Id], [CreateDate], [CaName], [Bh], [Pbh], [Remark]) VALUES (3, CAST(0x0000A9EC012622E7 AS DateTime), N'IOS                                                             ', N'03                                                              ', N'0                                                               ', NULL)
INSERT [dbo].[Category] ([Id], [CreateDate], [CaName], [Bh], [Pbh], [Remark]) VALUES (4, CAST(0x0000A9EC01262C05 AS DateTime), N'Java                                                            ', N'04                                                              ', N'0                                                               ', NULL)
INSERT [dbo].[Category] ([Id], [CreateDate], [CaName], [Bh], [Pbh], [Remark]) VALUES (5, CAST(0x0000A9EC012672AA AS DateTime), N'随笔                                                              ', N'09                                                              ', N'0                                                               ', NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
ALTER TABLE [dbo].[Admin] ADD  CONSTRAINT [DF_Admin_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Blog] ADD  CONSTRAINT [DF_Blog_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Blog] ADD  CONSTRAINT [DF_Blog_VisitNum]  DEFAULT ((0)) FOR [VisitNum]
GO
ALTER TABLE [dbo].[Blog] ADD  CONSTRAINT [DF_Blog_Sort]  DEFAULT ((0)) FOR [Sort]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'博客表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Blog', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Blog', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Blog', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Blog', @level2type=N'COLUMN',@level2name=N'Body'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Markdown内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Blog', @level2type=N'COLUMN',@level2name=N'Body_md'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'访问量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Blog', @level2type=N'COLUMN',@level2name=N'VisitNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Blog', @level2type=N'COLUMN',@level2name=N'CaBh'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Blog', @level2type=N'COLUMN',@level2name=N'CaName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Blog', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序，从小到大' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Blog', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'CaName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'Bh'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'Pbh'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'Remark'
GO
USE [master]
GO
ALTER DATABASE [NMY_DB] SET  READ_WRITE 
GO
