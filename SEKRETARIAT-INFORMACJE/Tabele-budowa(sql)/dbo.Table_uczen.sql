CREATE TABLE [dbo].[Table-uczen] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [Imie]               NVARCHAR (50) NOT NULL,
    [DrugieImie]         NVARCHAR (50) NULL,
    [Nazwisko]           NVARCHAR (50) NOT NULL,
    [NazwiskoPanienskie] NVARCHAR (50) NULL,
    [ImieMatki]          NVARCHAR (50) NULL,
    [ImieOjca]           NVARCHAR (50) NULL,
    [DataUrodzenia]      DATE          NULL,
    [Pesel]              NVARCHAR (50) NOT NULL,
    [Plec]               NVARCHAR (50) NULL,
    [Klasa]              NVARCHAR (50) NOT NULL,
    [Grupa]              NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

