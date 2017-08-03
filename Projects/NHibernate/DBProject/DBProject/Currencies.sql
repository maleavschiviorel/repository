CREATE TABLE [dbo].[Currencies]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY,
	name nvarchar(20),
	charcode nvarchar(10)
)
