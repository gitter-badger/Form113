USE [Form113]




  

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

GO
SET ANSI_PADDING OFF
GO



SET IDENTITY_INSERT Categories ON
INSERT [dbo].[Categories] ([idCategorie],[Libelle]) VALUES (1,'Arts de la table') 
INSERT [dbo].[Categories] ([idCategorie],[Libelle]) VALUES (2,'Décorations')
INSERT [dbo].[Categories] ([idCategorie],[Libelle]) VALUES (3,'Bijoux Ethnique')
INSERT [dbo].[Categories] ([idCategorie],[Libelle]) VALUES (4,'Bagagerie')
INSERT [dbo].[Categories] ([idCategorie],[Libelle]) VALUES (5,'Bien-être')
INSERT [dbo].[Categories] ([idCategorie],[Libelle]) VALUES (6,'Mode')
INSERT [dbo].[Categories] ([idCategorie],[Libelle]) VALUES (7,'Jeux')
INSERT [dbo].[Categories] ([idCategorie],[Libelle]) VALUES (8,'Bazar')
SET IDENTITY_INSERT Categories OFF


INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (1,'Services à thé')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (1,'Plateaux')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (1,'Plats')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (1,'Bols et tasses')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (1,'Verres')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (1,'Assiettes')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (1,'Couvert')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (1,'Linge de table')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (1,'Accessoires')
	
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (2,'Corbeilles')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (2,'Vases')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (2,'Boîtes')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (2,'Bureau et papeterie')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (2,'Petit mobilier')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (2,'Tentures')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (2,'Statues et figurines')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (2,'Décorations de Noël')

INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (3,'Colliers et médailles')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (3,'Broches et barrettes')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (3,'Bagues')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (3,'Bracelets')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (3,'Boucles d''oreilles')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (3,'Accessoires')




INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (4,'Sacs et paniers')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (4,'Maroquinerie')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (4,'Trousses et étuis')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (4,'Porte-clefs')


INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (5,'Bougies')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (5,'Photophore et bougeoirs')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (5,'Encens et supports')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (5,'Bien-être')


INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (6,'Mode femme')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (6,'Mode homme')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (6,'Mode enfant')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (6,'Echarpes et etoles')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (6,'Accessoires')

INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (7,'Jeux')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (7,'Jouets en bois')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (7,'Instruments')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (7,'Poupées et animaux')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (7,'Mobiles')
INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (7,'Décoration')

INSERT [dbo].[SousCategories] ([idCategorie],[nom]) VALUES (8,'Divers')













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

