USE [FragorTeste]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 11/04/2022 10:42:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](30) NOT NULL,
	[Sobrenome] [varchar](100) NOT NULL,
	[CPF] [varchar](11) NOT NULL,
	[DataNasc] [date] NOT NULL,
	[Profissao] [int] NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
