CREATE TABLE [dbo].[Toggles]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ToggleName] VARCHAR(50) NOT NULL, 
    [ToggleValue] BIT NOT NULL
)
