 Insert into [dbo].[Produits] (Nom,Description,Prix,IdSousCategorie,DateMiseEnVente,Promotion,CodePays,Stock)
	values ('Produit1','DescriptionProduit1',310,4,GETDATE(),1,'FRA',5),
		   ('Produit2','DescriptionProduit2',100,5,GETDATE(),0.50,'FRA',3),
		   ('Produit3','DescriptionProduit3',50,4,GETDATE(),1,'FRA',0);