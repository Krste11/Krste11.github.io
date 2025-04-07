create database sedc_academy_homework;
go

use sedc_academy_homework;
go

create table Student (
    Id int identity(1,1) primary key,
    FirstName nvarchar(100) null,
    LastName nvarchar(100) null,
    DateOfBirth date null,
    EnrolledDate date null,
    Gender nchar(1) null,
    NationalIdNumber bigint null,
    StudentCardNumber nvarchar(100) null
);

create table Teacher (
    Id int identity(1,1) primary key,
    FirstName nvarchar(100) null,
    LastName nvarchar(100) null,
    DateOfBirth date null,
    AcademicRank nvarchar(100) null,
    HireDate date null
);

create table Course (
    Id int identity(1,1) primary key,
    Name nvarchar(200) null,
    Credit tinyint null,
    AcademicYear tinyint null,
    Semester tinyint null
);

create table Grade (
    Id int identity(1,1) primary key,
    StudentId int null,
    CourseId int null,
    TeacherId int null,
    Grade tinyint null,
    Comment nvarchar(max) null,
    CreatedDate datetime null,
    constraint FK_Grade_Student foreign key (StudentId) references Student(Id),
    constraint FK_Grade_Course foreign key (CourseId) references Course(Id),
    constraint FK_Grade_Teacher foreign key (TeacherId) references Teacher(Id)
);

create table AchievementType (
    Id int identity(1,1) primary key,
    Name nvarchar(150) null,
    Description nvarchar(max) null,
    ParticipationRate int null
);

create table GradeDetails (
    Id int identity(1,1) primary key,
    GradeId int null,
    AchievementTypeId int null,
    AchievementPoints smallint null,
    AchievementMaxPoints smallint null,
    AchievementDate date null,
    constraint FK_GradeDetails_Grade foreign key (GradeId) references Grade(Id),
    constraint FK_GradeDetails_AchievementType foreign key (AchievementTypeId) references AchievementType(Id)
);
