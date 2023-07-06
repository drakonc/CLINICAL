CREATE DATABASE CLINICAL

CREATE TABLE Analysis (
	AnalysisId int identity(1,1) primary key not null,
	Name varchar(50),
	State int not null,
	AuditCreateDate datetime2(7) not null
)
GO

/* 
--Insert rows into table 'Analysis' in schema '[dbo]'
INSERT INTO [dbo].[Analysis](Name,[State],AuditCreateDate)
VALUES('PRUEBA ANALISIS',1,GETDATE())
GO
 */