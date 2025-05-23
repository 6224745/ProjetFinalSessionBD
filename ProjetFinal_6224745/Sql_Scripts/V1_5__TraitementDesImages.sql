CREATE TABLE Appareil.Affiche(
	AfficheID int IDENTITY(1,1) NOT NULL,
	Identifiant uniqueidentifier NOT NULL ROWGUIDCOL,
	AgreID int NOT NULL,
	CONSTRAINT PK_Appareil_AfficheID PRIMARY KEY (AfficheID)
)
GO

ALTER TABLE Appareil.Affiche ADD CONSTRAINT FK_Affiche_Agre FOREIGN KEY (AgreID) 
REFERENCES Appareil.Agre(AgreID);
GO

ALTER TABLE Appareil.Affiche ADD CONSTRAINT UC_Appareil_Identifiant UNIQUE(Identifiant)
GO

ALTER TABLE Appareil.Affiche ADD CONSTRAINT DF_Appareil_Identifiant DEFAULT newid() FOR Identifiant
GO

ALTER TABLE Appareil.Affiche ADD AfficheContent varbinary(max) FILESTREAM NULL
GO

INSERT INTO Appareil.Affiche(AgreID, AfficheContent)
SELECT 1, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\GERI\Desktop\ProjetFinal_6224745\Images\Sol.png', SINGLE_BLOB) AS myfile

INSERT INTO Appareil.Affiche(AgreID, AfficheContent)
SELECT 2, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\GERI\Desktop\ProjetFinal_6224745\Images\Arcon.png', SINGLE_BLOB) AS myfile

INSERT INTO Appareil.Affiche(AgreID, AfficheContent)
SELECT 3, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\GERI\Desktop\ProjetFinal_6224745\Images\Anneaux.png', SINGLE_BLOB) AS myfile

INSERT INTO Appareil.Affiche(AgreID, AfficheContent)
SELECT 4, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\GERI\Desktop\ProjetFinal_6224745\Images\Saut.png', SINGLE_BLOB) AS myfile

INSERT INTO Appareil.Affiche(AgreID, AfficheContent)
SELECT 5, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\GERI\Desktop\ProjetFinal_6224745\Images\Parra.png', SINGLE_BLOB) AS myfile

INSERT INTO Appareil.Affiche(AgreID, AfficheContent)
SELECT 6, BulkColumn FROM OPENROWSET(
	BULK 'C:\Users\GERI\Desktop\ProjetFinal_6224745\Images\Fixe.png', SINGLE_BLOB) AS myfile