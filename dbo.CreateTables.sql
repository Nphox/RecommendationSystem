CREATE TABLE [dbo].[Games]
(
    [ZeroBasedScale] INT NULL, 
    [Title] NVARCHAR(110) NOT NULL, 
    [Complexity] INT NULL, 
    [Activity] INT NULL, 
    [Planning] INT NULL, 
    [MinTime] INT NULL, 
    [MaxTime] INT NULL, 
    [MinAge] INT NULL, 
    [MaxAge] INT NULL, 
    [MinPlayers] INT NULL, 
    [MaxPlayers] INT NULL 
)

CREATE TABLE [dbo].[Categories]
(
    [Title] NVARCHAR(110) NOT NULL, 
    [Categories] NVARCHAR(50) NULL
)

CREATE TABLE [dbo].[Series]
(
    [Title] NVARCHAR(110) NOT NULL,
    [Series] NVARCHAR(50) NULL
)

CREATE TABLE [dbo].[Tags]
(
    [Title] NVARCHAR(110) NOT NULL,
    [Tag] NVARCHAR(50) NULL
)

CREATE TABLE [dbo].[Thematic]
(
    [Title] NVARCHAR(110) NOT NULL, 
    [Thematic] NVARCHAR(50) NULL
)
