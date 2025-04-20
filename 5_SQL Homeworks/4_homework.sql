SELECT 
    TeacherID,
    COUNT(*) AS GradeCount
FROM Grade
GROUP BY TeacherID;

SELECT 
    TeacherID,
    COUNT(*) AS GradeCount
FROM Grade
WHERE StudentID < 100
GROUP BY TeacherID;

SELECT 
    StudentID,
    MAX(Grade) AS MaxGrade,
    AVG(Grade * 1.0) AS AvgGrade
FROM Grade
GROUP BY StudentID;

SELECT 
    TeacherID,
    COUNT(*) AS GradeCount
FROM Grade
GROUP BY TeacherID
HAVING COUNT(*) > 200;

SELECT 
    StudentID,
    COUNT(*) AS GradeCount,
    MAX(Grade) AS MaxGrade,
    AVG(Grade * 1.0) AS AvgGrade
FROM Grade
GROUP BY StudentID
HAVING MAX(Grade) = AVG(Grade * 1.0);

SELECT 
    S.FirstName,
    S.LastName,
    GStats.GradeCount,
    GStats.MaxGrade,
    GStats.AvgGrade
FROM (
    SELECT 
        StudentID,
        COUNT(*) AS GradeCount,
        MAX(Grade) AS MaxGrade,
        AVG(Grade * 1.0) AS AvgGrade
    FROM Grade
    GROUP BY StudentID
    HAVING MAX(Grade) = AVG(Grade * 1.0)
) AS GStats
JOIN Student S ON S.ID = GStats.StudentID;

CREATE VIEW vv_StudentGrades AS
SELECT 
    S.FirstName,
    S.LastName,
    COUNT(G.ID) AS GradeCount
FROM Grade G
JOIN Student S ON S.ID = G.StudentID
GROUP BY S.FirstName, S.LastName;
GO

SELECT *
FROM vv_StudentGrades
ORDER BY GradeCount DESC;
