
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/30/2012 03:28:26
-- Generated from EDMX file: D:\VnDorm\SourceCode\Enrollment_DSS.Data\Entities\Enrollment_DSS.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Enrollment_DSS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_RowRoomRoom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rooms] DROP CONSTRAINT [FK_RowRoomRoom];
GO
IF OBJECT_ID(N'[dbo].[FK_Account_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_Account_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Students] DROP CONSTRAINT [FK_RoomStudent];
GO
IF OBJECT_ID(N'[dbo].[FK_FacultyStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Students] DROP CONSTRAINT [FK_FacultyStudent];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Logs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Logs];
GO
IF OBJECT_ID(N'[dbo].[Faculties]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Faculties];
GO
IF OBJECT_ID(N'[dbo].[Students]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Students];
GO
IF OBJECT_ID(N'[dbo].[ImageStores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImageStores];
GO
IF OBJECT_ID(N'[dbo].[Rooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rooms];
GO
IF OBJECT_ID(N'[dbo].[RowRooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RowRooms];
GO
IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[NhanViens]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NhanViens];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Logs'
CREATE TABLE [dbo].[Logs] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(150)  NOT NULL,
    [Time] datetime  NULL,
    [NoiDung] nvarchar(max)  NULL,
    [PhanHe] nvarchar(50)  NULL
);
GO

-- Creating table 'Faculties'
CREATE TABLE [dbo].[Faculties] (
    [FacultyID] nvarchar(50)  NOT NULL,
    [FacultyName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Students'
CREATE TABLE [dbo].[Students] (
    [StudentID] nvarchar(20)  NOT NULL,
    [FirstName] nvarchar(max)  NULL,
    [LastName] nvarchar(max)  NULL,
    [Sex] nvarchar(5)  NULL,
    [BirthDay] datetime  NULL,
    [ClassID] nvarchar(20)  NULL,
    [Address] nvarchar(max)  NULL,
    [Ethnic] nvarchar(100)  NULL,
    [Religion] nvarchar(100)  NULL,
    [Phone] nvarchar(20)  NULL,
    [IntoSchoolYear] varchar(4)  NULL,
    [FacultyID] nvarchar(50)  NOT NULL,
    [IdentityNo] varchar(20)  NOT NULL,
    [ValidityDate] datetime  NOT NULL,
    [Province] nvarchar(200)  NOT NULL,
    [RoomID] varchar(50)  NOT NULL
);
GO

-- Creating table 'ImageStores'
CREATE TABLE [dbo].[ImageStores] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OriginalPath] nvarchar(max)  NULL,
    [ImageData] varbinary(max)  NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [RoomID] varchar(50)  NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Note] nvarchar(50)  NULL,
    [RowID] varchar(50)  NULL,
    [MaxStudent] int  NULL,
    [Status] bit  NOT NULL
);
GO

-- Creating table 'RowRooms'
CREATE TABLE [dbo].[RowRooms] (
    [ID] varchar(50)  NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Block] varchar(50)  NULL,
    [Floor] int  NULL,
    [Note] nvarchar(50)  NULL
);
GO

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [UserName] nvarchar(150)  NOT NULL,
    [Password] varchar(32)  NULL,
    [RoleID] int  NULL
);
GO

-- Creating table 'NhanViens'
CREATE TABLE [dbo].[NhanViens] (
    [ID] int  NOT NULL,
    [HoTen] nvarchar(max)  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleID] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(250)  NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Logs'
ALTER TABLE [dbo].[Logs]
ADD CONSTRAINT [PK_Logs]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [FacultyID] in table 'Faculties'
ALTER TABLE [dbo].[Faculties]
ADD CONSTRAINT [PK_Faculties]
    PRIMARY KEY CLUSTERED ([FacultyID] ASC);
GO

-- Creating primary key on [StudentID] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [PK_Students]
    PRIMARY KEY CLUSTERED ([StudentID] ASC);
GO

-- Creating primary key on [ID] in table 'ImageStores'
ALTER TABLE [dbo].[ImageStores]
ADD CONSTRAINT [PK_ImageStores]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [RoomID] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([RoomID] ASC);
GO

-- Creating primary key on [ID] in table 'RowRooms'
ALTER TABLE [dbo].[RowRooms]
ADD CONSTRAINT [PK_RowRooms]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [UserName] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([UserName] ASC);
GO

-- Creating primary key on [ID] in table 'NhanViens'
ALTER TABLE [dbo].[NhanViens]
ADD CONSTRAINT [PK_NhanViens]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [RoleID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RowID] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [FK_RowRoomRoom]
    FOREIGN KEY ([RowID])
    REFERENCES [dbo].[RowRooms]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RowRoomRoom'
CREATE INDEX [IX_FK_RowRoomRoom]
ON [dbo].[Rooms]
    ([RowID]);
GO

-- Creating foreign key on [RoleID] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [FK_Account_Role]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[Roles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Account_Role'
CREATE INDEX [IX_FK_Account_Role]
ON [dbo].[Accounts]
    ([RoleID]);
GO

-- Creating foreign key on [RoomID] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [FK_RoomStudent]
    FOREIGN KEY ([RoomID])
    REFERENCES [dbo].[Rooms]
        ([RoomID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomStudent'
CREATE INDEX [IX_FK_RoomStudent]
ON [dbo].[Students]
    ([RoomID]);
GO

-- Creating foreign key on [FacultyID] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [FK_FacultyStudent]
    FOREIGN KEY ([FacultyID])
    REFERENCES [dbo].[Faculties]
        ([FacultyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FacultyStudent'
CREATE INDEX [IX_FK_FacultyStudent]
ON [dbo].[Students]
    ([FacultyID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------