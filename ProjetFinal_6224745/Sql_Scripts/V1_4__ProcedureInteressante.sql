USE BD_Gymnastique
GO
CREATE OR ALTER PROCEDURE Appareil.usp_FiltrageMouvements
(@Agres nvarchar(25),
@Difficulte nvarchar(25))
AS
BEGIN
    BEGIN
        SELECT m.Nom AS NomMouvement,m.Difficulte, m.Valeur, m.Description, a.Nom AS NomAgre
        FROM Appareil.Mouvement m
        INNER JOIN Appareil.Agre a ON m.AgreID = a.AgreID
        WHERE a.Nom = @Agres AND (@Difficulte = 'Tous' OR m.Difficulte = @Difficulte OR @Difficulte IS NULL 
        )
    END
END
GO