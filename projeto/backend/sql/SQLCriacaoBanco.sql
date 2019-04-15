USE [master]
GO
/****** Object:  Database [walter_teste]    Script Date: 2/26/2019 1:56:47 PM ******/
CREATE DATABASE [walter_teste]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'walter_teste', FILENAME = N'C:\caminho\walter_teste.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'walter_teste_log', FILENAME = N'C:\caminho\walter_teste_log.ldf' , SIZE = 13312KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [walter_teste] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [walter_teste].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [walter_teste] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [walter_teste] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [walter_teste] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [walter_teste] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [walter_teste] SET ARITHABORT OFF 
GO
ALTER DATABASE [walter_teste] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [walter_teste] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [walter_teste] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [walter_teste] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [walter_teste] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [walter_teste] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [walter_teste] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [walter_teste] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [walter_teste] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [walter_teste] SET  DISABLE_BROKER 
GO
ALTER DATABASE [walter_teste] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [walter_teste] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [walter_teste] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [walter_teste] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [walter_teste] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [walter_teste] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [walter_teste] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [walter_teste] SET RECOVERY FULL 
GO
ALTER DATABASE [walter_teste] SET  MULTI_USER 
GO
ALTER DATABASE [walter_teste] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [walter_teste] SET DB_CHAINING OFF 
GO
ALTER DATABASE [walter_teste] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [walter_teste] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [walter_teste] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'walter_teste', N'ON'
GO
ALTER DATABASE [walter_teste] SET QUERY_STORE = OFF
GO
USE [walter_teste]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [walter_teste]
GO
/****** Object:  Table [dbo].[AcademicPeriod]    Script Date: 2/26/2019 1:56:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcademicPeriod](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[Start] [datetime] NOT NULL,
	[Finish] [datetime] NOT NULL,
 CONSTRAINT [PK_AcademicPeriod] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 2/26/2019 1:56:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[CourseId] [int] NOT NULL,
	[AcademicPeriodId] [int] NOT NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2/26/2019 1:56:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 2/26/2019 1:56:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Class]    Script Date: 2/26/2019 1:56:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Class](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClassId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_Student_Class] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_Class_AcademicPeriod] FOREIGN KEY([AcademicPeriodId])
REFERENCES [dbo].[AcademicPeriod] ([Id])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_Class_AcademicPeriod]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_Class_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_Class_Course]
GO
ALTER TABLE [dbo].[Student_Class]  WITH CHECK ADD  CONSTRAINT [FK_Student_Class_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([Id])
GO
ALTER TABLE [dbo].[Student_Class] CHECK CONSTRAINT [FK_Student_Class_Class]
GO
ALTER TABLE [dbo].[Student_Class]  WITH CHECK ADD  CONSTRAINT [FK_Student_Class_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[Student_Class] CHECK CONSTRAINT [FK_Student_Class_Student]
GO
USE [master]
GO
ALTER DATABASE [walter_teste] SET  READ_WRITE 
GO

USE [walter_teste]
GO

--- COURSE
Insert Into Course Values('Matemática')
Insert Into Course Values('Português')
Insert Into Course Values('Física')
Insert Into Course Values('Quimica')

--- ALUNOS
Insert Into Student values('José Silva')
Insert Into Student values('Marcos Data')
Insert Into Student values('Naubert Souza')
Insert Into Student values('Augusto Mares')
Insert Into Student values('Joana Fon')
Insert Into Student values('Marcio Alves')
Insert Into Student values('Walter Maia')
Insert Into Student values('Adriana Silva')
Insert Into Student values('Felipe Vilela')
Insert Into Student values('João Vitor')
Insert Into Student values('Natalia Vinci')
Insert Into Student values('Alberto Nunes')
Insert Into Student values('John Jones')
Insert Into Student values('KELLY NERI')
Insert Into Student values('EDSON SIMONIN')
Insert Into Student values('FABIO LUIZ FONTES')
Insert Into Student values('COORDENADOR ALUNO')
Insert Into Student values('FLAVIO FERNANDES DE FREITAS')
Insert Into Student values('FELIPE LIMA SALVIA')
Insert Into Student values('IGOR JOSE')
Insert Into Student values('DENISE S. SLUTZKY')
Insert Into Student values('JAQUELINE TAVARES NOGUEIRA')
Insert Into Student values('GILSON MATTA')
Insert Into Student values('JULIANA MACHADO')
Insert Into Student values('DEBORA CARUSO')
Insert Into Student values('ANDRÉ UCHÔA')
Insert Into Student values('MARIA ANTONIETA')
Insert Into Student values('MARCUS TÚLIO')
Insert Into Student values('ANA FLÁVIA')
Insert Into Student values('JOÃO ARROYO')
Insert Into Student values('LUIZ SEBASTIÃO')
Insert Into Student values('GIOVANA')
Insert Into Student values('ADRIANO')
Insert Into Student values('MARIA ÂNGELA')
Insert Into Student values('JULIANA VALLE')
Insert Into Student values('ÂNGELA MARINHO')
Insert Into Student values('DIVINA MARCIA')
Insert Into Student values('MARCIA')
Insert Into Student values('DEMONSTRAÇÃO')
Insert Into Student values('LUIZIANA REZENDE')
Insert Into Student values('JUAREZ MORAES RAMOS JUNIOR')
Insert Into Student values('LUÍS FIGUEIRA')
Insert Into Student values('MARCELO MARIANO')
Insert Into Student values('FERNANDO UCHÔA')
Insert Into Student values('SÉRGIO MAURO GOMES')
Insert Into Student values('PAULO HIRANO')
Insert Into Student values('REINALDO PORTO')
Insert Into Student values('DR. CELSO COUTO')
Insert Into Student values('LAURA ROCHA MIRANDA')
Insert Into Student values('JOÃO CARLOS BALAGUER')
Insert Into Student values('MARCUS CARRUTHERS')
Insert Into Student values('ALBERTO COUTINHO')
Insert Into Student values('FERNANDO MALHEIROS')
Insert Into Student values('ANTÔNIO CARLOS ROCHA')
Insert Into Student values('MIGUEL JORGE RAMOS')
Insert Into Student values('JOSÉ ALBERTO S. BORGES')
Insert Into Student values('ANA LAURIDES')

---Periodo Academico
Insert Into AcademicPeriod Values('2019.1','2019-01-01 00:00:00','2019-03-30 23:59:59')
Insert Into AcademicPeriod Values('2019.2','2019-04-01 00:00:00','2019-06-30 23:59:59')
Insert Into AcademicPeriod Values('2019.3','2019-07-01 00:00:00','2019-09-30 23:59:59')
Insert Into AcademicPeriod Values('2019.4','2019-10-01 00:00:00','2019-12-30 23:59:59')
Insert Into AcademicPeriod Values('2020.1','2020-01-01 00:00:00','2020-03-30 23:59:59')
Insert Into AcademicPeriod Values('2020.2','2020-04-01 00:00:00','2020-06-30 23:59:59')
Insert Into AcademicPeriod Values('2020.3','2020-07-01 00:00:00','2020-09-30 23:59:59')
Insert Into AcademicPeriod Values('2020.4','2020-10-01 00:00:00','2020-12-30 23:59:59')

--- Turmas
Insert Into Class Values('Turma M-1',1,1)
Insert Into Class Values('Turma M-2',1,3)
Insert Into Class Values('Turma M-3',1,4)
Insert Into Class Values('Turma M-4',1,5)
Insert Into Class Values('Turma P-1',2,1)
Insert Into Class Values('Turma P-2',2,3)
Insert Into Class Values('Turma P-3',2,4)
Insert Into Class Values('Turma P-4',2,5)
Insert Into Class Values('Turma F-1',3,1)
Insert Into Class Values('Turma F-2',3,3)
Insert Into Class Values('Turma F-3',3,4)
Insert Into Class Values('Turma F-4',3,5)
Insert Into Class Values('Turma B-1',4,1)
Insert Into Class Values('Turma B-2',4,3)
Insert Into Class Values('Turma B-3',4,4)
Insert Into Class Values('Turma B-4',4,5)

---Turmas_Alunos
Insert Into Student_Class Values(1,1)
Insert Into Student_Class Values(1,2)
Insert Into Student_Class Values(1,3)
Insert Into Student_Class Values(1,4)
Insert Into Student_Class Values(3,8)
Insert Into Student_Class Values(3,9)
Insert Into Student_Class Values(3,10)
Insert Into Student_Class Values(3,11)
Insert Into Student_Class Values(4,12)
Insert Into Student_Class Values(4,13)
Insert Into Student_Class Values(4,14)
Insert Into Student_Class Values(4,15)
Insert Into Student_Class Values(5,16)
Insert Into Student_Class Values(5,17)
Insert Into Student_Class Values(5,18)
Insert Into Student_Class Values(6,19)
Insert Into Student_Class Values(6,20)
Insert Into Student_Class Values(6,21)
Insert Into Student_Class Values(6,22)
Insert Into Student_Class Values(8,27)
Insert Into Student_Class Values(8,28)
Insert Into Student_Class Values(8,29)
Insert Into Student_Class Values(9,30)
Insert Into Student_Class Values(9,31)
Insert Into Student_Class Values(9,32)
Insert Into Student_Class Values(9,33)
Insert Into Student_Class Values(10,34)
Insert Into Student_Class Values(10,35)
Insert Into Student_Class Values(10,36)
Insert Into Student_Class Values(10,37)
Insert Into Student_Class Values(11,38)
Insert Into Student_Class Values(11,39)
Insert Into Student_Class Values(11,40)
Insert Into Student_Class Values(12,41)
Insert Into Student_Class Values(12,42)
Insert Into Student_Class Values(12,43)
Insert Into Student_Class Values(12,44)
Insert Into Student_Class Values(13,45)
Insert Into Student_Class Values(13,46)
Insert Into Student_Class Values(13,47)
Insert Into Student_Class Values(14,48)
Insert Into Student_Class Values(14,49)
Insert Into Student_Class Values(14,50)
Insert Into Student_Class Values(15,51)
Insert Into Student_Class Values(15,52)
Insert Into Student_Class Values(15,53)
Insert Into Student_Class Values(15,54)
Insert Into Student_Class Values(17,5)
Insert Into Student_Class Values(17,6)
Insert Into Student_Class Values(17,7)
Insert Into Student_Class Values(18,23)
Insert Into Student_Class Values(18,24)
Insert Into Student_Class Values(18,25)
Insert Into Student_Class Values(18,26)
Insert Into Student_Class Values(19,55)
Insert Into Student_Class Values(19,56)
Insert Into Student_Class Values(19,57)

