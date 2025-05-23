CREATE NONCLUSTERED INDEX IX_Agre_Nom
ON Appareil.Agre (Nom);

CREATE NONCLUSTERED INDEX IX_Mouvement_AgreID_Difficulte
ON Appareil.Mouvement (AgreID, Difficulte);