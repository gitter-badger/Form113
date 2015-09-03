USE [Form113]

if exists (select * from sysobjects where name = 'Administrateurs' and type = 'U')
	drop table Administrateurs;
if exists (select * from sysobjects where name = 'Commandes_details' and type = 'U')
	drop table Commandes_details;
if exists (select * from sysobjects where name = 'Commandes' and type = 'U')
	drop table Commandes;
if exists (select * from sysobjects where name = 'Photos' and type = 'U')
	drop table Photos;
if exists (select * from sysobjects where name = 'Utilisateurs' and type = 'U')
	drop table Utilisateurs;
if exists (select * from sysobjects where name = 'Produits' and type = 'U')
	drop table Produits;
if exists (select * from sysobjects where name = 'SousCategories' and type = 'U')
	drop table SousCategories;
if exists (select * from sysobjects where name = 'Categories' and type = 'U')
	drop table Categories;
if exists (select * from sysobjects where name = 'Identites' and type = 'U')
	drop table Identites;
if exists (select * from sysobjects where name = 'Adresses' and type = 'U')
	drop table Adresses;
if exists (select * from sysobjects where name = 'StatusCommande' and type = 'U')
	drop table StatusCommande;
if exists (select * from sysobjects where name = 'Marketing' and type = 'U')
	drop table Marketing;
	
GO
CREATE TABLE [dbo].[Administrateurs](
	[IdAdministrateur] [int] NOT NULL,
 CONSTRAINT [Pk_Administrateurs] PRIMARY KEY CLUSTERED 
(
	[IdAdministrateur] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Adresses]    Script Date: 24-Aug-15 5:09:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Adresses](
	[IdAdresse] [int] IDENTITY(1,1) NOT NULL,
	[Ligne1] [varchar](36) NOT NULL,
	[Ligne2] [varchar](36) NULL,
	[Ligne3] [varchar](36) NULL,
	[CodePostal] [char](5) NOT NULL,
	[CodeINSEE] [char](5) NULL,
 CONSTRAINT [Pk_Adresse] PRIMARY KEY CLUSTERED 
(
	[IdAdresse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [Idx_Adresse_0] UNIQUE NONCLUSTERED 
(
	[Ligne1] ASC,
	[Ligne2] ASC,
	[Ligne3] ASC,
	[CodePostal] ASC,
	[CodeINSEE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 24-Aug-15 5:09:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[IdCategorie] [int] IDENTITY(1,1) NOT NULL,
	[Libelle] [nvarchar](100) NOT NULL,
	[Photo] [nvarchar](100) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[IdCategorie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departements]    Script Date: 24-Aug-15 5:09:46 PM ******/

/****** Object:  Table [dbo].[Identites]    Script Date: 24-Aug-15 5:09:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Identites](
	[IdIdentite] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](50) NULL,
	[Prenom] [varchar](30) NULL,
	[Identifiant] [char](10) NULL,
	[Password] [char](10) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [Pk_Utilisateur_0] PRIMARY KEY CLUSTERED 
(
	[IdIdentite] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pays]    Script Date: 24-Aug-15 5:09:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON

/****** Object:  Table [dbo].[Photos]    Script Date: 24-Aug-15 5:09:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Photos](
	[PhotoName] [varchar](100) NOT NULL,
	[IdProduit] [int] NOT NULL,
	[IdPhoto] [int] IDENTITY NOT NULL,
 CONSTRAINT [Pk_Photos] PRIMARY KEY CLUSTERED 
(
	[IdPhoto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Produits]    Script Date: 24-Aug-15 5:09:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Produits](
	[IdProduit] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](30) NOT NULL,
	[Couleur] [varchar](10) NULL,
	[Description] [text] NULL,
	[Prix] [int] NOT NULL,
	[IdSousCategorie] [int] NOT NULL,
	[DateMiseEnVente] [datetime] NOT NULL,
	[Promotion] [float] NULL,
	[MisEnAvant] [tinyint] default 0 not null,
	[CodePays] character(3) NULL,
	[Stock] [int] NULL,
	[NbVues] [int] default 0,
 CONSTRAINT [Pk_Produits] PRIMARY KEY CLUSTERED 
(
	[IdProduit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 24-Aug-15 5:09:46 PM ******/

/****** Object:  Table [dbo].[SousCategories]    Script Date: 24-Aug-15 5:09:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SousCategories](
	[IdSousCategorie] [int] IDENTITY (1,1) NOT NULL,
	[Nom] [nchar](30) NULL,
	[IdCategorie] [int] NULL,
	[Photo] [nvarchar](100) NULL,
 CONSTRAINT [PK_SousCategorie] PRIMARY KEY CLUSTERED 
(
	[IdSousCategorie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Utilisateurs]    Script Date: 24-Aug-15 5:09:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilisateurs](
	[IdUtilisateur] [int] IDENTITY(1,1) NOT NULL,
	[IdAsp] [nvarchar](128) NOT NULL,
	[IdAdresse] [int] NOT NULL,
	[NbCommande] [int] default 0,
	[DateInscription] [datetime2](7) NOT NULL,
	[LastConnection] [datetime2](7) NULL,
	[IdIdentite] [int] NULL,
 CONSTRAINT [Pk_Utilisateur] PRIMARY KEY CLUSTERED 
(
	[IdUtilisateur] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Villes]    Script Date: 24-Aug-15 5:09:46 PM ******/


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Commandes](
	[IdCommande] [int] IDENTITY(1,1) NOT NULL,
	[IdAcheteur] [int] NULL,
	[EtatCommande] [nvarchar](30) NULL,
	[DateCommande] [datetime] NULL,
	[DateLivraison] [datetime] NULL,
	[IdAdresse] [int] NULL,
	
CONSTRAINT [Pk_Commande] PRIMARY KEY CLUSTERED 
(
	[IdCommande] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Commandes_details](
	[IdCommande] [int]  NOT NULL,
	[IdProduit] [int] NOT NULL,
	[prix_unitaire] [float] NULL,
	[Promotion] [float] NULL,
	[quantite] [int] NULL,
	
CONSTRAINT [Idx_Commandes_details] PRIMARY KEY CLUSTERED 
(
	[IdCommande] ASC,
	[IdProduit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

go
create table StatusCommande (
	IdStatusCommande int Primary key not null,
	StatusCommande nvarchar(30) not null
)
insert StatusCommande (IdStatusCommande,StatusCommande)
values (1,'Commandé')
insert StatusCommande (IdStatusCommande,StatusCommande)
values (2,'Envoyé')
insert StatusCommande (IdStatusCommande,StatusCommande)
values (3,'Reçu')

go 
create table Marketing (
	NbreCommandePourReduc int,
)

go

Alter table Commandes alter column EtatCommande INT;
alter table Commandes
add constraint fk_EtatCommande
foreign key (EtatCommande)
references StatusCommande(IdStatusCommande)

GO
SET ANSI_PADDING OFF

GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([IdCategorie], [Libelle], [Photo]) VALUES (1, N'Arts de la table', N'ArtDeLaTable.jpg')
INSERT [dbo].[Categories] ([IdCategorie], [Libelle], [Photo]) VALUES (2, N'Décorations', N'Decoration.jpg')
INSERT [dbo].[Categories] ([IdCategorie], [Libelle], [Photo]) VALUES (3, N'Bijoux Ethnique', N'bijoux.jpg')
INSERT [dbo].[Categories] ([IdCategorie], [Libelle], [Photo]) VALUES (4, N'Bagagerie', N'sac.jpg')
INSERT [dbo].[Categories] ([IdCategorie], [Libelle], [Photo]) VALUES (5, N'Bien-être', N'entete-bienetre.jpg')
INSERT [dbo].[Categories] ([IdCategorie], [Libelle], [Photo]) VALUES (6, N'Mode', N'mode.jpg')
INSERT [dbo].[Categories] ([IdCategorie], [Libelle], [Photo]) VALUES (7, N'Jeux', N'jeux.jpg')
INSERT [dbo].[Categories] ([IdCategorie], [Libelle], [Photo]) VALUES (8, N'Bazar', N'bazar.jpg')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[SousCategories] ON 

INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (1, N'Services à thé                ', 1, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (2, N'Plateaux                      ', 1, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (3, N'Plats                         ', 1, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (4, N'Bols et tasses                ', 1, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (5, N'Verres                        ', 1, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (6, N'Assiettes                     ', 1, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (7, N'Couvert                       ', 1, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (8, N'Linge de table                ', 1, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (9, N'Accessoires                   ', 1, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (10, N'Corbeilles                    ', 2, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (11, N'Vases                         ', 2, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (12, N'Boîtes                        ', 2, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (13, N'Bureau et papeterie           ', 2, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (14, N'Petit mobilier                ', 2, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (15, N'Tentures                      ', 2, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (16, N'Statues et figurines          ', 2, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (17, N'Décorations de Noël           ', 2, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (18, N'Colliers et médailles         ', 3, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (19, N'Broches et barrettes          ', 3, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (20, N'Bagues                        ', 3, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (21, N'Bracelets                     ', 3, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (22, N'Boucles d''oreilles            ', 3, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (23, N'Accessoires                   ', 3, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (24, N'Sacs et paniers               ', 4, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (25, N'Maroquinerie                  ', 4, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (26, N'Trousses et étuis             ', 4, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (27, N'Porte-clefs                   ', 4, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (28, N'Bougies                       ', 5, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (29, N'Photophore et bougeoirs       ', 5, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (30, N'Encens et supports            ', 5, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (31, N'Bien-être                     ', 5, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (32, N'Mode femme                    ', 6, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (33, N'Mode homme                    ', 6, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (34, N'Mode enfant                   ', 6, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (35, N'Echarpes et etoles            ', 6, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (36, N'Accessoires                   ', 6, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (37, N'Jeux                          ', 7, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (38, N'Jouets en bois                ', 7, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (39, N'Instruments                   ', 7, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (40, N'Poupées et animaux            ', 7, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (41, N'Mobiles                       ', 7, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (42, N'Décoration                    ', 7, NULL)
INSERT [dbo].[SousCategories] ([IdSousCategorie], [Nom], [IdCategorie], [Photo]) VALUES (43, N'Divers                        ', 8, NULL)
SET IDENTITY_INSERT [dbo].[SousCategories] OFF
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
SET IDENTITY_INSERT [dbo].[Photos] ON 

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

GO
ALTER TABLE [dbo].[Administrateurs]  WITH CHECK ADD  CONSTRAINT [fk_administrateurs_identites] FOREIGN KEY([IdAdministrateur])
REFERENCES [dbo].[Identites] ([IdIdentite])
GO
ALTER TABLE [dbo].[Administrateurs] CHECK CONSTRAINT [fk_administrateurs_identites]
GO

ALTER TABLE [dbo].[Photos]  WITH NOCHECK ADD  CONSTRAINT [fk_photos_produits] FOREIGN KEY([IdProduit])
REFERENCES [dbo].[Produits] ([IdProduit])
GO
ALTER TABLE [dbo].[Photos] CHECK CONSTRAINT [fk_photos_produits]
GO
ALTER TABLE [dbo].[Produits]  WITH CHECK ADD  CONSTRAINT [FK_Produits_SousCategorie] FOREIGN KEY([IdSousCategorie])
REFERENCES [dbo].[SousCategories] ([IdSousCategorie])
GO
ALTER TABLE [dbo].[Produits] CHECK CONSTRAINT [FK_Produits_SousCategorie]
GO
ALTER TABLE [dbo].[SousCategories]  WITH CHECK ADD  CONSTRAINT [FK_SousCategory_Categories] FOREIGN KEY([IdCategorie])
REFERENCES [dbo].[Categories] ([IdCategorie])
GO
ALTER TABLE [dbo].[SousCategories] CHECK CONSTRAINT [FK_SousCategory_Categories]
GO
ALTER TABLE [dbo].[Utilisateurs]  WITH CHECK ADD  CONSTRAINT [fk_utilisateurs_adresse] FOREIGN KEY([IdAdresse])
REFERENCES [dbo].[Adresses] ([IdAdresse])
GO
ALTER TABLE [dbo].[Utilisateurs] CHECK CONSTRAINT [fk_utilisateurs_adresse]
GO
ALTER TABLE [dbo].[Utilisateurs]  WITH CHECK ADD  CONSTRAINT [fk_utilisateurs_identites] FOREIGN KEY([IdIdentite])
REFERENCES [dbo].[Identites] ([IdIdentite])
GO
ALTER TABLE [dbo].[Utilisateurs] CHECK CONSTRAINT [fk_utilisateurs_identites]
GO
ALTER TABLE [dbo].[Adresses]  WITH CHECK ADD  CONSTRAINT [fk_adresses_zipcodes] FOREIGN KEY([CodePostal], [CodeINSEE])
REFERENCES [dbo].[ZipCodes] ([CodePostal], [CodeINSEE])
GO
ALTER TABLE [dbo].[Adresses] CHECK CONSTRAINT [fk_adresses_zipcodes]
GO
ALTER TABLE [dbo].[Produits]  WITH CHECK ADD  CONSTRAINT [fk_produits_pays] FOREIGN KEY([CodePays])
REFERENCES [dbo].[Pays] ([CodeIso3])
GO
ALTER TABLE [dbo].[Utilisateurs] CHECK CONSTRAINT [fk_utilisateurs_adresse]
GO

ALTER TABLE [dbo].[Commandes]  WITH CHECK ADD  CONSTRAINT [fk_commande_utilisateur] FOREIGN KEY([IdAcheteur])
REFERENCES [dbo].[Utilisateurs] ([IdUtilisateur])
GO
ALTER TABLE [dbo].[Commandes] CHECK CONSTRAINT [fk_commande_utilisateur]
GO

ALTER TABLE [dbo].[Commandes_details]  WITH CHECK ADD  CONSTRAINT [fk_commande_details_produit] FOREIGN KEY([IdProduit])
REFERENCES [dbo].[Produits] ([IdProduit])
GO
ALTER TABLE [dbo].[Commandes_details] CHECK CONSTRAINT [fk_commande_details_produit]
GO

ALTER TABLE [dbo].[Commandes_details]  WITH CHECK ADD  CONSTRAINT [fk_commande_details_commande] FOREIGN KEY([IdCommande])
REFERENCES [dbo].[Commandes] ([IdCommande])
GO
ALTER TABLE [dbo].[Commandes_details] CHECK CONSTRAINT [fk_commande_details_commande]
GO

ALTER TABLE [dbo].[Utilisateurs]  WITH CHECK ADD  CONSTRAINT [fk_utilisateurs_ASPusers] FOREIGN KEY([IdAsp])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Utilisateurs] CHECK CONSTRAINT [fk_utilisateurs_identites]
GO

