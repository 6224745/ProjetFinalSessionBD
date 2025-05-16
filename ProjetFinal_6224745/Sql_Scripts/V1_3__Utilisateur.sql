USE BD_Gymnastique
GO

CREATE TABLE Utilisateurs.Utilisateur(
	UtilisateurID int IDENTITY (1,1),
	Pseudonyme nvarchar(50) NOT NULL,
	MotDePasseHache varbinary(32) NOT NULL,
	MdpSel varbinary(16) NOT NULL,
	Email nvarchar(256) NOT NULL,
	CONSTRAINT PK_Utilisateur_UtilisateurID PRIMARY KEY (UtilisateurID)
);
GO

CREATE PROCEDURE  Utilisateurs.USP_CreerUtilisateur
	@Pseudonyme nvarchar(50),
	@MotDePasse nvarchar(100),
	@Email nvarchar(256)
AS
BEGIN
	DECLARE @MdpSel varbinary(16) = CRYPT_GEN_RANDOM(16);
	DECLARE @MdpEtSel nvarchar(116) = CONCAT(@MotDePasse, @MdpSel);
	DECLARE @MdpHachage varbinary(32) = HASHBYTES('SHA2_256', @MdpEtSel);

	INSERT INTO Utilisateurs.Utilisateur (Pseudonyme, MotDePasseHache, MdpSel, Email)
	VALUES
	(@Pseudonyme, @MdpHachage, @MdpSel, @Email);
END
GO

CREATE PROCEDURE  Utilisateurs.USP_AuthUtilisateur
	@Pseudo nvarchar(50),
	@MotDePasse nvarchar(50)
AS
BEGIN
	DECLARE @Sel varbinary(16);
	DECLARE @MdpHache varbinary(32);

	SELECT @Sel = MdpSel, @MdpHache = MotDePasseHache
	FROM Utilisateurs.Utilisateur
	WHERE Pseudonyme = @Pseudo;

	IF HASHBYTES('SHA2_256', CONCAT(@MotDePasse, @Sel)) = @MdpHache
	BEGIN
		SELECT * FROM Utilisateurs.Utilisateur WHERE Pseudonyme = @Pseudo;
	END
	ELSE
	BEGIN
		SELECT TOP 0 * FROM Utilisateurs.Utilisateur;
	END
END
GO