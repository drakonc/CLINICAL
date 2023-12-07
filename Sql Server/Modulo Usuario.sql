IF OBJECT_ID('dbo.DocumentTypes', 'U') IS NOT NULL
DROP TABLE dbo.DocumentTypes
GO
CREATE TABLE dbo.DocumentTypes
(
    DocumentTypeId INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    Document VARCHAR(50) NOT NULL,
    State INT NOT NULL
);
GO


IF OBJECT_ID('dbo.TypeAges', 'U') IS NOT NULL
DROP TABLE dbo.TypeAges
GO
CREATE TABLE dbo.TypeAges
(
    TypeAgeId INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    TypeAge VARCHAR(15) NOT NULL,
    State INT NOT NULL
);
GO

IF OBJECT_ID('dbo.Genders', 'U') IS NOT NULL
DROP TABLE dbo.Genders
GO
CREATE TABLE dbo.Genders
(
    GenderId INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    Gender VARCHAR(50) NOT NULL,
    State INT NOT NULL
);
GO

IF OBJECT_ID('dbo.Patients', 'U') IS NOT NULL
DROP TABLE dbo.Patients
GO
CREATE TABLE dbo.Patients
(
    PatientId INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    Names VARCHAR(100),
    LastName VARCHAR(50),
    MotherMaidenName VARCHAR(50),
    DocumentTypeId INT,
    DocumentNumber VARCHAR(25),
    Phone VARCHAR(15),
    TypeAgeId INT,
    Age INT,
    GenderId INT,
    State INT,
    AuditCreateDate DATETIME2(7),
    FOREIGN KEY (DocumentTypeId) REFERENCES DocumentTypes(DocumentTypeId),
    FOREIGN KEY (TypeAgeId) REFERENCES TypeAges(TypeAgeId),
    FOREIGN KEY (GenderId) REFERENCES Genders(GenderId)
);
GO


CREATE OR ALTER PROCEDURE dbo.uspPatientList
AS
BEGIN
    SELECT pa.PatientId,pa.Names,CONCAT_WS(' ',pa.LastName,pa.MotherMaidenName) AS Surnames,
           dt.Document As DocumentType,pa.DocumentNumber,pa.Phone,
           CONCAT_WS(' ',pa.Age,ta.TypeAge) AS Age,Gender,
           CASE pa.State WHEN 1 THEN 'ACTIVO' ELSE 'INACTIVO' END AS StatePatient,
           pa.AuditCreateDate 
    FROM Patients pa
    INNER JOIN DocumentTypes dt ON pa.DocumentTypeId = dt.DocumentTypeId
    INNER JOIN TypeAges ta ON pa.TypeAgeId = ta.TypeAgeId
    INNER JOIN Genders g ON g.GenderId = pa.GenderId
END
GO

CREATE OR ALTER PROCEDURE dbo.uspPatientById --dbo.uspPatientById 1
    @PatienId INT
AS
BEGIN
    SELECT pa.PatientId,
           pa.Names,
           pa.LastName,
           pa.MotherMaidenName,
           pa.DocumentTypeId,
           pa.DocumentNumber,
           pa.Phone,
           pa.TypeAgeId,
           pa.Age,
           pa.GenderId
    FROM Patients pa
    WHERE pa.PatientId = @PatienId
END
GO

select * from DocumentTypes
select * from Genders
select * from TypeAges
select * from Patients