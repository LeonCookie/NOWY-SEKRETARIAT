CREATE TABLE [dbo].[Table-Ubsluga]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Imie] NVARCHAR(50) NOT NULL, 
    [DrugieImie] NVARCHAR(50) NULL, 
    [Nazwisko] NVARCHAR(50) NOT NULL, 
    [NazwiskoPanienskie] NVARCHAR(50) NULL, 
    [ImieMatki] NVARCHAR(50) NULL, 
    [ImieOjca] NVARCHAR(50) NULL, 
    [DataUrodzenia] DATE NOT NULL, 
    [Pesel] NVARCHAR(50) NOT NULL, 
    [Plec] NVARCHAR(50) NULL, 
    [InformacjaEtat] NVARCHAR(MAX) NOT NULL, 
    [OpisStanowiska] NVARCHAR(MAX) NOT NULL, 
    [DataZatrudnienia] DATE NOT NULL
)
