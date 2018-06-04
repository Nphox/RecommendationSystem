CREATE TABLE [dbo].[Games]
(
    [ZeroBasedScale] INT NULL, 
    [Title] NCHAR(50) NOT NULL PRIMARY KEY, 
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
