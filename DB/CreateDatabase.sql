-- Project Management - Database creation script (MySQL 8.0)
-- Matches EF Core migration: InitialCreate (20260621130133)

CREATE DATABASE IF NOT EXISTS ProjectManagement
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_unicode_ci;

USE ProjectManagement;

-- Drop tables in dependency order (safe re-run)
DROP TABLE IF EXISTS TaskItems;
DROP TABLE IF EXISTS Projects;
DROP TABLE IF EXISTS Statuses;
DROP TABLE IF EXISTS Users;

CREATE TABLE Statuses (
    Id   INT          NOT NULL AUTO_INCREMENT,
    Name VARCHAR(50)  NOT NULL,
    PRIMARY KEY (Id)
) CHARACTER SET utf8mb4;

CREATE TABLE Users (
    Id    INT           NOT NULL AUTO_INCREMENT,
    Name  VARCHAR(100)  NOT NULL,
    Email VARCHAR(255)  NOT NULL,
    PRIMARY KEY (Id)
) CHARACTER SET utf8mb4;

CREATE TABLE Projects (
    Id          INT            NOT NULL AUTO_INCREMENT,
    Name        VARCHAR(200)   NOT NULL,
    Description VARCHAR(1000)  NOT NULL,
    UserId      INT            NOT NULL,
    PRIMARY KEY (Id),
    INDEX IX_Projects_UserId (UserId),
    CONSTRAINT FK_Projects_Users_UserId
        FOREIGN KEY (UserId) REFERENCES Users (Id)
        ON DELETE RESTRICT
) CHARACTER SET utf8mb4;

CREATE TABLE TaskItems (
    Id          INT            NOT NULL AUTO_INCREMENT,
    Title       VARCHAR(200)   NOT NULL,
    Description VARCHAR(1000)  NOT NULL,
    DueDate     DATETIME(6)    NULL,
    StatusId    INT            NOT NULL,
    ProjectId   INT            NOT NULL,
    PRIMARY KEY (Id),
    INDEX IX_TaskItems_ProjectId (ProjectId),
    INDEX IX_TaskItems_StatusId (StatusId),
    CONSTRAINT FK_TaskItems_Projects_ProjectId
        FOREIGN KEY (ProjectId) REFERENCES Projects (Id)
        ON DELETE CASCADE,
    CONSTRAINT FK_TaskItems_Statuses_StatusId
        FOREIGN KEY (StatusId) REFERENCES Statuses (Id)
        ON DELETE RESTRICT
) CHARACTER SET utf8mb4;

-- Optional seed data for demo / Postman testing
INSERT INTO Statuses (Name) VALUES
    ('To Do'),
    ('In Progress'),
    ('Done');

INSERT INTO Users (Name, Email) VALUES
    ('Rivka Weinstock', 'rivka@example.com');

INSERT INTO Projects (Name, Description, UserId) VALUES
    ('Course Final Project', 'ASP.NET Core Web API project management system', 1);

INSERT INTO TaskItems (Title, Description, DueDate, StatusId, ProjectId) VALUES
    ('Write README', 'Add installation and entity documentation', '2026-07-01 00:00:00.000000', 1, 1),
    ('Prepare SQL script', 'Database creation script for submission', '2026-06-25 00:00:00.000000', 2, 1);

-- EF Core migrations history (only if using this script instead of "dotnet ef database update")
CREATE TABLE IF NOT EXISTS __EFMigrationsHistory (
    MigrationId    VARCHAR(150) NOT NULL,
    ProductVersion VARCHAR(32)  NOT NULL,
    PRIMARY KEY (MigrationId)
) CHARACTER SET utf8mb4;

INSERT IGNORE INTO __EFMigrationsHistory (MigrationId, ProductVersion)
VALUES ('20260621130133_InitialCreate', '8.0.13');
