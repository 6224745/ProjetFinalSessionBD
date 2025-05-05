USE master 
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='BD_Gymnastique')
BEGIN
    DROP DATABASE BD_Gymnastique
END
CREATE DATABASE BD_Gymnastique
GO
-- CREATION de la BD R22_Billeterie

USE BD_Gymnastique
GO

-- Configuration de FILESTREAM
-- nous avons vu ça lors de la rencontre 19

EXEC sp_configure filestream_access_level, 2 RECONFIGURE
GO

ALTER DATABASE BD_Gymnastique
ADD FILEGROUP FG_Images_6224745 CONTAINS FILESTREAM;
GO
ALTER DATABASE BD_Gymnastique
ADD FILE(
    NAME = FG_Images,
    FILENAME = 'C:\EspaceLabo\FG_Images_6224745'
)
TO FILEGROUP FG_Images_6224745
GO

-- Configuration des clés symétriques
-- il s'agit de créer la clé master, le certificat et enfin la clé symmétrique

CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'M0nP4s5w0rdL0ng!';
GO
CREATE CERTIFICATE MonCertificat WITH SUBJECT = 'ChiffrementCarteBanc';
GO
CREATE SYMMETRIC KEY MaSuperCle WITH ALGORITHM = AES_256 ENCRYPTION BY CERTIFICATE MonCertificat;
GO