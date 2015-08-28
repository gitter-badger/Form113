
SET IDENTITY_INSERT [dbo].[Produits] ON 

INSERT [dbo].[Produits] ([IdProduit], [Nom], [Couleur], [Description], [Prix], [IdSousCategorie], [DateMiseEnVente], [Promotion], [MisEnAvant], [CodePays], [Stock], [NbVues]) VALUES (1, N'cacao', N'bleu', N'Restabat ut Caesar post haec properaret accitus et abstergendae causa suspicionis sororem suam, eius uxorem, Constantius ad se tandem desideratam venire multis fictisque blanditiis hortabatur. quae licet ambigeret metuens saepe cruentum, spe tamen quod eum lenire poterit ut germanum profecta, cum Bithyniam introisset, in statione quae Caenos Gallicanos appellatur, absumpta est vi febrium repentina. cuius post obitum maritus contemplans cecidisse fiduciam qua se fultum existimabat, anxia cogitatione, quid moliretur haerebat.', 500, 1, CAST(N'1984-10-15 00:00:00.000' AS DateTime), 0.2, 1, N'AIA', 50, NULL)
INSERT [dbo].[Produits] ([IdProduit], [Nom], [Couleur], [Description], [Prix], [IdSousCategorie], [DateMiseEnVente], [Promotion], [MisEnAvant], [CodePays], [Stock], [NbVues]) VALUES (2, N'Théière Coeurs', N'bleu', N'Véritable objet de collection du commerce équitable, cette théière coeur est confectionnée de manière artisanale par les artisans de l''association for craft producers, qui officie au Népal depuis 1984 et dont l''objectif est d''améliorer les conditions de vie des artisans en visant plus partiulièrement les femmes.  Fabriqué à partir de céramique.  Information utile : ce produit est adapté au lave-vaiselle et au micro-ondes !', 43, 1, CAST(N'1984-10-15 00:00:00.000' AS DateTime), 1, 0, N'NPL', 50, NULL)
INSERT [dbo].[Produits] ([IdProduit], [Nom], [Couleur], [Description], [Prix], [IdSousCategorie], [DateMiseEnVente], [Promotion], [MisEnAvant], [CodePays], [Stock], [NbVues]) VALUES (3, N'Théière Sen', N'Blanc', N'Céramique. Turquoise et blanc. H 15 x 19cm Lavage à la main. Non adapté au micro-ondes...', 30, 1, CAST(N'1984-10-10 00:00:00.000' AS DateTime), 1, 0, N'VNM', 500, NULL)
INSERT [dbo].[Produits] ([IdProduit], [Nom], [Couleur], [Description], [Prix], [IdSousCategorie], [DateMiseEnVente], [Promotion], [MisEnAvant], [CodePays], [Stock], [NbVues]) VALUES (4, N'Service à thé', N'blanc Rose', N'Bois d''alstonia (service 10 pièces), eucalyptus (plateau) et coton (2 serviettes) Plateau: 34 x 25cm. Service: approx: 5 x 4cm.', 40, 1, CAST(N'1984-10-10 00:00:00.000' AS DateTime), 1, 0, N'EST', 500, NULL)
INSERT [dbo].[Produits] ([IdProduit], [Nom], [Couleur], [Description], [Prix], [IdSousCategorie], [DateMiseEnVente], [Promotion], [MisEnAvant], [CodePays], [Stock], [NbVues]) VALUES (5, N'Théière blanc et noir', N'blanc noir', N'Diam. 15 x H14/16cm, contenance 1 litre Micro-ondes et laive-vaisselle déconseillé Céramique...', 13, 1, CAST(N'1984-10-15 00:00:00.000' AS DateTime), 1, 0, N'AUS', 10, NULL)
INSERT [dbo].[Produits] ([IdProduit], [Nom], [Couleur], [Description], [Prix], [IdSousCategorie], [DateMiseEnVente], [Promotion], [MisEnAvant], [CodePays], [Stock], [NbVues]) VALUES (6, N'Théière Dao', N'blanc', N'Céramique.Blanc et pois multicolores. Diam 11 x H13cm. Capacité 0,7l Non-adapté au lave-vaisselle', 40, 1, CAST(N'1984-10-15 00:00:00.000' AS DateTime), 1, 0, N'CHN', 500, NULL)
INSERT [dbo].[Produits] ([IdProduit], [Nom], [Couleur], [Description], [Prix], [IdSousCategorie], [DateMiseEnVente], [Promotion], [MisEnAvant], [CodePays], [Stock], [NbVues]) VALUES (8, N'Passoire à thé en bambou', NULL, N'Passoire à thé en bambou - Inde', 4, 1, CAST(N'1984-10-15 00:00:00.000' AS DateTime), 1, 0, N'IND', 500, NULL)
INSERT [dbo].[Produits] ([IdProduit], [Nom], [Couleur], [Description], [Prix], [IdSousCategorie], [DateMiseEnVente], [Promotion], [MisEnAvant], [CodePays], [Stock], [NbVues]) VALUES (9, N'Théière Aube rouge', N'blanc', N'Théière Aube rouge - Ceramique - Vietnam', 28, 1, CAST(N'1984-10-10 00:00:00.000' AS DateTime), 1, 0, N'VNM', 500, NULL)
INSERT [dbo].[Produits] ([IdProduit], [Nom], [Couleur], [Description], [Prix], [IdSousCategorie], [DateMiseEnVente], [Promotion], [MisEnAvant], [CodePays], [Stock], [NbVues]) VALUES (10, N'Théière Aube rouge', N'blanc', N'Théière Aube rouge - Ceramique - Vietnam', 28, 1, CAST(N'1984-10-10 00:00:00.000' AS DateTime), 1, 0, N'VNM', 500, NULL)
SET IDENTITY_INSERT [dbo].[Produits] OFF

INSERT [dbo].[Photos] ([PhotoName], [IdProduit], [IdPhoto]) VALUES (N'Need Code By PCbots.png', 1, 1)
INSERT [dbo].[Photos] ([PhotoName], [IdProduit], [IdPhoto]) VALUES (N'SiliconeValley400_300.jpg', 1, 2)
INSERT [dbo].[Photos] ([PhotoName], [IdProduit], [IdPhoto]) VALUES (N'acp417.jpg', 2, 3)
INSERT [dbo].[Photos] ([PhotoName], [IdProduit], [IdPhoto]) VALUES (N'clk029.jpg', 3, 4)
INSERT [dbo].[Photos] ([PhotoName], [IdProduit], [IdPhoto]) VALUES (N'shutterstock_197353127_6.jpg', 3, 5)
INSERT [dbo].[Photos] ([PhotoName], [IdProduit], [IdPhoto]) VALUES (N'GPH025_1.jpg', 4, 6)
INSERT [dbo].[Photos] ([PhotoName], [IdProduit], [IdPhoto]) VALUES (N'MAI134_3.jpg', 5, 7)
INSERT [dbo].[Photos] ([PhotoName], [IdProduit], [IdPhoto]) VALUES (N'MAI289_1.jpg', 6, 8)
INSERT [dbo].[Photos] ([PhotoName], [IdProduit], [IdPhoto]) VALUES (N'SIL200_2.jpg', 8, 9)
INSERT [dbo].[Photos] ([PhotoName], [IdProduit], [IdPhoto]) VALUES (N'mai352.jpg', 10, 10)
INSERT [dbo].[Photos] ([PhotoName], [IdProduit], [IdPhoto]) VALUES (N'shutterstock_97516112.jpg', 10, 11)
INSERT [dbo].[Photos] ([PhotoName], [IdProduit], [IdPhoto]) VALUES (N'shutterstock_136795478.jpg', 10, 12)
INSERT [dbo].[Photos] ([PhotoName], [IdProduit], [IdPhoto]) VALUES (N'MAI134_3.jpg', 9, 13)
INSERT [dbo].[Photos] ([PhotoName], [IdProduit], [IdPhoto]) VALUES (N'shutterstock_197353127_6.jpg', 9, 14)
SET IDENTITY_INSERT [dbo].[Photos] OFF
