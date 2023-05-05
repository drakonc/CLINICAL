--EXEC uspAnalysisList
CREATE PROCEDURE uspAnalysisList
AS
BEGIN
    SET NOCOUNT ON;
    SELECT AnalysisId,Name,[State],AuditCreateDate FROM Analysis
END
GO
