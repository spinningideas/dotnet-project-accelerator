CREATE TABLE [dbo].[Continents] (
    [ContinentID]       UNIQUEIDENTIFIER DEFAULT NEWID(),
    [ContinentCode]     NVARCHAR (2) NOT NULL,
    [ContinentName]     NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED ([ContinentID] ASC)
);

