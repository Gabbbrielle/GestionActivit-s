# GestionActivit-s

Définitions des tables

CREATE TABLE [dbo].[Activitées] (
    [Id]           INT         NOT NULL,
    [NomActivité]  NCHAR (50)  NOT NULL,
    [Emplacement]  NCHAR (100) NOT NULL,
    [DateActivité] DATETIME    NOT NULL,
    [Début]        DATETIME    NOT NULL,
    [Fin]          DATETIME    NOT NULL,
    [Vote]         INT         DEFAULT ((0)) NOT NULL,
    [Covoiturage]  INT         DEFAULT ((0)) NOT NULL,
    [PlaceVoiture] INT         DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[Participants] (
    [Id]           INT         NOT NULL,
    [Prénom]       NCHAR (50)  NOT NULL,
    [Nom]          NCHAR (50)  NOT NULL,
    [Age]          INT         NOT NULL,
    [Voiture]      INT         DEFAULT ((0)) NOT NULL,
    [PlaceVoiture] INT         DEFAULT ((0)) NOT NULL,
    [PickUp]       NCHAR (200) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

