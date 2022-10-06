create database bookclub;
use bookclub;

CREATE TABLE person (
    Id INT NOT NULL AUTO_INCREMENT,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(50),
    PRIMARY KEY (Id)
    
);

CREATE TABLE presentation (
    Id INT NOT NULL AUTO_INCREMENT,
    PersonId INT NOT NULL,
    PresentationDate DATETIME,
    BookTitle VARCHAR(50),
    BookAuthor VARCHAR(50),
    Genre VARCHAR(25),
    PRIMARY KEY (Id),
    FOREIGN KEY (PersonId) REFERENCES person(Id)
);

INSERT INTO person (FirstName, LastName, Email) VALUES ('William', 'Shakespeare', 'romeo.o.romeo@gmail.com');
INSERT INTO person (FirstName, LastName, Email) VALUES ('Agatha', 'Christie', 'whodunit@gmail.com');
