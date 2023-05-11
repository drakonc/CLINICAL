CREATE or ALTER PROCEDURE uspAnalysisList
AS
BEGIN
    SET NOCOUNT ON;
    SELECT AnalysisId,Name,[State],AuditCreateDate FROM Analysis
END
GO

CREATE or ALTER  PROCEDURE uspAnalysisById
	@AnalysisId INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT AnalysisId, Name 
	FROM Analysis 
	WHERE AnalysisId = @AnalysisId
END

CREATE or ALTER PROCEDURE uspAnalysisRegister
	@Name VARCHAR(100),
	@State int,
	@AuditCreateDate DATETIME
AS
BEGIN
	INSERT INTO Analysis (Name,State,AuditCreateDate)
	VALUES (@Name,@State,@AuditCreateDate);
END

CREATE or ALTER PROCEDURE uspAnalysisEdid
	@AnalysisId int,
	@Name VARCHAR(100)
AS
BEGIN
	UPDATE Analysis
	SET Name = @Name
	WHERE AnalysisId = @AnalysisId
END

CREATE or ALTER PROCEDURE uspAnalysisRemove
	@AnalysisId int
AS
BEGIN
	DELETE Analysis
	WHERE AnalysisId = @AnalysisId
END
