SET NOCOUNT ON;

IF NOT EXISTS(SELECT TOP 1 * FROM [dbo].[Continents])
BEGIN

PRINT 'Inserting data into [dbo].[Continents]'

INSERT INTO [dbo].[Continents] (ContinentID, ContinentCode, ContinentName) VALUES ('e21134c7-bfde-459a-8ac2-dcdecf5ae8ed', 'AF', 'Africa');
INSERT INTO [dbo].[Continents] (ContinentID, ContinentCode, ContinentName) VALUES ('8f767f57-2bf3-4586-9801-196304bb50df', 'AN', 'Antarctica');
INSERT INTO [dbo].[Continents] (ContinentID, ContinentCode, ContinentName) VALUES ('2fba2034-cf75-4d04-8a3f-43d71a54a66f', 'AS', 'Asia');
INSERT INTO [dbo].[Continents] (ContinentID, ContinentCode, ContinentName) VALUES ('c0114ffd-46bd-420a-b706-bf1b900f6fee', 'EU', 'Europe');
INSERT INTO [dbo].[Continents] (ContinentID, ContinentCode, ContinentName) VALUES ('c8ee8e53-92ef-43e8-92f6-858a4296a0f2', 'NA', 'North America');
INSERT INTO [dbo].[Continents] (ContinentID, ContinentCode, ContinentName) VALUES ('199d31d3-b6fb-4a7d-b5d6-889038079323', 'OC', 'Oceania');
INSERT INTO [dbo].[Continents] (ContinentID, ContinentCode, ContinentName) VALUES ('d4a2b1a0-1786-43d8-80ba-363d2f6892c2', 'SA', 'South America');

END
