USE BD_Gymnastique

GO
CREATE OR ALTER VIEW Appareil.vw_DetailAgres
AS
	SELECT A.AgreID, A.Nom, M.Difficulte, COUNT(M.MouvementID) AS[Nombre de mouvement par difficulté]
	FROM Appareil.Agre A
	INNER JOIN Appareil.Mouvement M
	ON A.AgreID = M.AgreID
	GROUP BY A.AgreID, M.Difficulte, A.Nom
GO