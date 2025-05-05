
CREATE TABLE Appareil.Agre(
AgreID int IDENTITY (1,1) NOT NULL,
Nom nvarchar(50) NOT NULL,
CONSTRAINT PK_Agre_AgreID PRIMARY KEY (AgreID)
)
GO

CREATE TABLE Appareil.Mouvement(
MouvementID int IDENTITY (1,1) NOT NULL,
Nom nvarchar(50),
Difficulte nvarchar(1),
Valeur decimal(3,1) NOT NULL,
[Description] nvarchar(255) NOT NULL,
AgreID int NOT NULL,
CONSTRAINT PK_Agre_MouvementID PRIMARY KEY (MouvementID)
)
GO

CREATE TABLE Performances.Gymnaste(
GymnasteID int IDENTITY (1,1) NOT NULL,
Nom nvarchar(50) NOT NULL,
Prenom nvarchar(50) NOT NULL,
DateNaissance date NOT NULL,
Pays nvarchar(50) NOT NULL,
NBMedailles int NOT NULL,
CONSTRAINT PK_Performances_GymnasteID PRIMARY KEY (GymnasteID)
)
GO

CREATE TABLE Performances.Competition(
CompetitionID int IDENTITY (1,1) NOT NULL,
Nom nvarchar(50) NOT NULL,
[Date] date NOT NULL,
Lieu nvarchar(50) NOT NULL,
CONSTRAINT PK_Performances_CompetitionID PRIMARY KEY (CompetitionID)
)
GO

CREATE TABLE Performances.Performance(
PerformanceID int IDENTITY (1,1) NOT NULL,
NoteObtenue decimal(4,2) NOT NULL,
GymnasteID int NOT NULL,
CompetitionID int NOT NULL,
AgresID int NOT NULL,
MouvementID int,
CONSTRAINT PK_Performances_PerformanceID PRIMARY KEY (PerformanceID)
)
GO
---Constraint de clés étrangères
ALTER TABLE Appareil.Mouvement ADD CONSTRAINT FK_AgreID_AgreID FOREIGN KEY (AgreID) REFERENCES Appareil.Agre(AgreID) ON DELETE CASCADE
GO
ALTER TABLE Performances.Performance ADD CONSTRAINT FK_GymnasteID_GymnasteID FOREIGN KEY (GymnasteID) REFERENCES Performances.Gymnaste(GymnasteID) ON DELETE CASCADE
GO
ALTER TABLE Performances.Performance ADD CONSTRAINT FK_CompetitionID_CompetitionID FOREIGN KEY (CompetitionID) REFERENCES Performances.Competition(CompetitionID) ON DELETE CASCADE
GO
ALTER TABLE Performances.Performance ADD CONSTRAINT FK_MouvementID_MouvementID FOREIGN KEY (MouvementID) REFERENCES Appareil.Mouvement(MouvementID) ON DELETE CASCADE
GO
ALTER TABLE Performances.Performance ADD CONSTRAINT FK_AgresID_AgresID FOREIGN KEY (AgresID) REFERENCES Appareil.Agre(AgreID) ON DELETE NO ACTION
GO
---Constraint de Unique, Default et Check
ALTER TABLE Performances.Gymnaste ADD CONSTRAINT DF_Gymnaste_NBMedailles DEFAULT 0 FOR NBMedailles
GO
ALTER TABLE Performances.Gymnaste ADD CONSTRAINT CHK_Gymnaste_NBMedailles CHECK (NBMedailles >= 0)
GO
ALTER TABLE Appareil.Mouvement ADD CONSTRAINT CHK_Mouvement_Valeur CHECK (Valeur >= 0.1)
GO
ALTER TABLE Performances.Competition ADD CONSTRAINT UQ_Competition_Nom UNIQUE (Nom)
GO
ALTER TABLE Performances.Performance ADD CONSTRAINT CHK_Performance_NoteObtenue CHECK (NoteObtenue >= 0)
GO
ALTER TABLE Appareil.Agre ADD CONSTRAINT UQ_Agre_Nom UNIQUE (Nom)
GO