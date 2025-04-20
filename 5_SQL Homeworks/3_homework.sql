SELECT *
FROM Student
WHERE FirstName = 'Antonio'

SELECT *
FROM Student
WHERE DateOfBirth > '1999-01-01'

SELECT *
FROM Student
WHERE LastName LIKE 'J%'
AND EnrolledDate >= '1998-01-01'
AND EnrolledDate < '1998-02-01'

SELECT *
FROM Student
ORDER BY FirstName

SELECT DISTINCT LastName
FROM (
    SELECT LastName FROM Teacher
    UNION
    SELECT LastName FROM Student
) AS CombinedLastNames

ALTER TABLE Student
ADD CONSTRAINT FK_Student_Course
FOREIGN KEY (CourseID)
REFERENCES Course(CourseID)

ALTER TABLE Teacher
ADD CONSTRAINT FK_Teacher_Course
FOREIGN KEY (CourseID)
REFERENCES Course(CourseID)

ALTER TABLE Exam
ADD CONSTRAINT FK_Exam_Student
FOREIGN KEY (StudentID)
REFERENCES Student(StudentID)

ALTER TABLE Exam
ADD CONSTRAINT FK_Exam_Teacher
FOREIGN KEY (TeacherID)
REFERENCES Teacher(TeacherID)

SELECT C.CourseName, A.AchievementTypeName
FROM Course C
CROSS JOIN AchievementType A

SELECT T.*
FROM Teacher T
LEFT JOIN Exam E ON T.TeacherID = E.TeacherID
WHERE E.Grade IS NULL
