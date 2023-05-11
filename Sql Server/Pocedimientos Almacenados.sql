--EXEC uspAnalysisList
CREATE or ALTER PROCEDURE uspAnalysisList
AS
BEGIN
    SET NOCOUNT ON;
    SELECT AnalysisId,Name,[State],AuditCreateDate FROM Analysis
END
GO

--EXEC uspAnalysisById 1 
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
	SET NOCOUNT ON;
	INSERT INTO Analysis (Name,State,AuditCreateDate)
	VALUES (@Name,@State,@AuditCreateDate);
END

