CREATE PROCEDURE CreateGrade 
    @StudentID INT,
    @TeacherID INT
AS
BEGIN
    INSERT INTO Grade (StudentID, TeacherID, Grade, CreatedDate)
    VALUES (@StudentID, @TeacherID, NULL, GETDATE());

    SELECT COUNT(*) AS TotalGrades
    FROM Grade
    WHERE StudentID = @StudentID;

    SELECT 
        MAX(Grade) AS MaxGrade
    FROM Grade
    WHERE StudentID = @StudentID AND TeacherID = @TeacherID;
END;
GO

CREATE PROCEDURE CreateGradeDetail 
    @GradeID INT,
    @AchievementTypeID INT,
    @AchievementPoints SMALLINT,
    @AchievementMaxPoints SMALLINT,
    @AchievementDate DATE
AS
BEGIN
    INSERT INTO GradeDetails (GradeID, AchievementTypeID, AchievementPoints, AchievementMaxPoints, AchievementDate)
    VALUES (@GradeID, @AchievementTypeID, @AchievementPoints, @AchievementMaxPoints, @AchievementDate);

    SELECT 
        SUM(CAST(AchievementPoints AS FLOAT) / AchievementMaxPoints * ParticipationRate) AS TotalGradePoints
    FROM GradeDetails GD
    JOIN AchievementType AT ON GD.AchievementTypeID = AT.ID
    WHERE GD.GradeID = @GradeID;
END;
GO
