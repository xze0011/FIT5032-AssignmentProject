
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/30/2020 12:08:01
-- Generated from EDMX file: C:\Users\10230\source\repos\FIT5032 AssignmentProject\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'StudentSet'
CREATE TABLE [dbo].[StudentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Gender] nvarchar(max)  NOT NULL,
    [Age] nvarchar(max)  NOT NULL,
    [Dob] datetime  NOT NULL,
    [PhoneNumber] int  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'UnitSet'
CREATE TABLE [dbo].[UnitSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UnitName] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [PriceAud] decimal(18,0)  NOT NULL,
    [UserId] int  NOT NULL,
    [ModuleId] int  NOT NULL,
    [TutorId] int  NOT NULL,
    [ClassRoomId] int  NOT NULL
);
GO

-- Creating table 'ClassRoomSet'
CREATE TABLE [dbo].[ClassRoomSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClassRoomName] nvarchar(max)  NOT NULL,
    [Latitude] decimal(18,0)  NOT NULL,
    [Longitude] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'ModuleSet'
CREATE TABLE [dbo].[ModuleSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ModuleName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EnrolmentSet'
CREATE TABLE [dbo].[EnrolmentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EnrolmentDate] datetime  NOT NULL,
    [Grade] decimal(18,0)  NOT NULL,
    [UserId] int  NOT NULL,
    [StudentId] int  NOT NULL,
    [UnitId] int  NOT NULL
);
GO

-- Creating table 'TutorSet'
CREATE TABLE [dbo].[TutorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TutorName] nvarchar(max)  NOT NULL,
    [Gender] nvarchar(max)  NOT NULL,
    [Age] nvarchar(max)  NOT NULL,
    [PhoneNumber] int  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'StudentSet'
ALTER TABLE [dbo].[StudentSet]
ADD CONSTRAINT [PK_StudentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UnitSet'
ALTER TABLE [dbo].[UnitSet]
ADD CONSTRAINT [PK_UnitSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClassRoomSet'
ALTER TABLE [dbo].[ClassRoomSet]
ADD CONSTRAINT [PK_ClassRoomSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ModuleSet'
ALTER TABLE [dbo].[ModuleSet]
ADD CONSTRAINT [PK_ModuleSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EnrolmentSet'
ALTER TABLE [dbo].[EnrolmentSet]
ADD CONSTRAINT [PK_EnrolmentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TutorSet'
ALTER TABLE [dbo].[TutorSet]
ADD CONSTRAINT [PK_TutorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [StudentId] in table 'EnrolmentSet'
ALTER TABLE [dbo].[EnrolmentSet]
ADD CONSTRAINT [FK_StudentEnrolment]
    FOREIGN KEY ([StudentId])
    REFERENCES [dbo].[StudentSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentEnrolment'
CREATE INDEX [IX_FK_StudentEnrolment]
ON [dbo].[EnrolmentSet]
    ([StudentId]);
GO

-- Creating foreign key on [UnitId] in table 'EnrolmentSet'
ALTER TABLE [dbo].[EnrolmentSet]
ADD CONSTRAINT [FK_UnitEnrolment]
    FOREIGN KEY ([UnitId])
    REFERENCES [dbo].[UnitSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UnitEnrolment'
CREATE INDEX [IX_FK_UnitEnrolment]
ON [dbo].[EnrolmentSet]
    ([UnitId]);
GO

-- Creating foreign key on [ModuleId] in table 'UnitSet'
ALTER TABLE [dbo].[UnitSet]
ADD CONSTRAINT [FK_ModuleUnit]
    FOREIGN KEY ([ModuleId])
    REFERENCES [dbo].[ModuleSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModuleUnit'
CREATE INDEX [IX_FK_ModuleUnit]
ON [dbo].[UnitSet]
    ([ModuleId]);
GO

-- Creating foreign key on [TutorId] in table 'UnitSet'
ALTER TABLE [dbo].[UnitSet]
ADD CONSTRAINT [FK_TutorUnit]
    FOREIGN KEY ([TutorId])
    REFERENCES [dbo].[TutorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TutorUnit'
CREATE INDEX [IX_FK_TutorUnit]
ON [dbo].[UnitSet]
    ([TutorId]);
GO

-- Creating foreign key on [ClassRoomId] in table 'UnitSet'
ALTER TABLE [dbo].[UnitSet]
ADD CONSTRAINT [FK_ClassRoomUnit]
    FOREIGN KEY ([ClassRoomId])
    REFERENCES [dbo].[ClassRoomSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassRoomUnit'
CREATE INDEX [IX_FK_ClassRoomUnit]
ON [dbo].[UnitSet]
    ([ClassRoomId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------