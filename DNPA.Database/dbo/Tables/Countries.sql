CREATE TABLE [dbo].[Countries] (
    [CountryID]         UNIQUEIDENTIFIER DEFAULT NEWID(),
    [CountryName]       NVARCHAR (100) NOT NULL,
    [CountryCode]       NVARCHAR (2) NOT NULL,
    [CountryCode3]      NVARCHAR (3) NOT NULL,
    [Capital]           NVARCHAR (100) NOT NULL,
    [ContinentCode]     NVARCHAR (2) NOT NULL,
    [Area]              INT NOT NULL, 
    [Population]        INT NOT NULL,
    [Latitude]          DECIMAL(10,6) NULL,
    [Longitude]         DECIMAL(10,6) NULL,
    [CurrencyCode]      NVARCHAR (3) NULL,
    [CurrencyName]      NVARCHAR (50) NULL,
    [Languages]         NVARCHAR (255) NULL
    CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([CountryID] ASC)
);

