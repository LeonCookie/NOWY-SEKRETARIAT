CREATE TABLE [dbo].[Table-Nauczyciel] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [Imie]               NVARCHAR (50)  NOT NULL,
    [DrugieImie]         NVARCHAR (50)  NULL,
    [Nazwisko]           NVARCHAR (50)  NOT NULL,
    [NazwiskoPanienskie] NVARCHAR (50)  NULL,
    [ImieMatki]          NVARCHAR (50)  NULL,
    [ImieOjca]           NVARCHAR (50)  NULL,
    [DataUrodzenia]      DATE           NOT NULL,
    [Pesel]              NVARCHAR (50)  NOT NULL,
    [Plec]               NVARCHAR (50)  NULL,
    [Wychowawstwo]       NVARCHAR (MAX) NULL,
    [PrzedmiotyNauczane] NVARCHAR (MAX) NULL,
    [JakieKlasyUczy]     NVARCHAR (MAX) NULL,
    [DataZatrudnienia]   DATE           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

