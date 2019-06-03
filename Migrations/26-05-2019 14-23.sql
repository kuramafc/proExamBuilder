CREATE DATABASE ExamBuilder

USE ExamBuilder

CREATE TABLE Subjects (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Subject varchar(40) NOT NULL,
)

CREATE TABLE Matters (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Matter varchar(40) NOT NULL,
)

CREATE TABLE MatSub (
	Id INT PRIMARY KEY IDENTITY(1,1),
	MatterId int,
	SubjectId int,
	FOREIGN KEY(MatterId) REFERENCES Matters(Id),
	FOREIGN KEY(SubjectId) REFERENCES Subjects(Id)
)

CREATE TABLE UserTypes (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Description varchar(40) NOT NULL
)

INSERT INTO UserTypes (Description) values ('Professor')
INSERT INTO UserTypes (Description) values ('Diretor')

CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY(1,1),
	UserName varchar(40) NOT NULL,
	Password varchar(40) NOT NULL,
	Email varchar(40) NOT NULL,
	Type INT NOT NULL,
	Code varchar(40) NOT NULL,
	FOREIGN KEY(Type) REFERENCES UserTypes(Id)
) 

CREATE TABLE Questions (
	Id INT PRIMARY KEY IDENTITY(1,1),
	QuestionName varchar(1000) NOT NULL,
	Difficult INT NOT NULL,
	RightQuestion varchar(40) NOT NULL,
	Used BIT,
	Image varchar(40) NOT NULL,
	Author varchar(40) NOT NULL,
	HasOption BIT NOT NULL,
	Code BIGINT NOT NULL,
	MatterId int,
	SubjectId int,
	FOREIGN KEY(MatterId) REFERENCES Matters(Id),
	FOREIGN KEY(SubjectId) REFERENCES Subjects(Id)
)

CREATE TABLE QuestionsOptions (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Description varchar(40) NOT NULL,
	QuestionCode BIGINT
)

CREATE TABLE Historic (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Exam BIGINT NOT NULL,
	PDF varchar(40),
	DOCX varchar(40),
	Author varchar(10)
)

