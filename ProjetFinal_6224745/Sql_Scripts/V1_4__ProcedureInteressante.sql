USE BD_Gymnastique
GO
CREATE OR ALTER PROCEDURE Appareil.usp_FiltrageMouvements
(@Agres nvarchar(25),
@Difficulte nvarchar(25))
AS
BEGIN
	SELECT m.MouvementID, m.Nom AS [NomMouvement], m.Difficulte, m.Valeur, m.Description, a.Nom AS[NomAgre], a.AgreID
	FROM Appareil.Mouvement m
	INNER JOIN Appareil.Agre a
	ON m.AgreID = a.AgreID
	WHERE @Agres = a.Nom AND @Difficulte = m.Difficulte
END
GO