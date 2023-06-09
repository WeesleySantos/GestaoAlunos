USE [GestaoDeTurmas]
GO
/****** Object:  Table [dbo].[Aluno]    Script Date: 24/05/2023 16:45:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aluno](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NULL,
	[Usuario] [varchar](45) NULL,
	[Senha] [varbinary](60) NULL,
	[Ativo] [bit] NULL,
	[ConfirmarSenha] [varchar](60) NULL,
 CONSTRAINT [PK_Aluno] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Aluno_Turma]    Script Date: 24/05/2023 16:45:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aluno_Turma](
	[Aluno_Id] [int] NOT NULL,
	[Turma_Id] [int] NOT NULL,
	[Ativo] [bit] NULL,
 CONSTRAINT [PK_Aluno_Turma] PRIMARY KEY CLUSTERED 
(
	[Aluno_Id] ASC,
	[Turma_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turma]    Script Date: 24/05/2023 16:45:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turma](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Curso_Id] [int] NULL,
	[Turma] [varchar](45) NULL,
	[Ano] [int] NULL,
	[Ativo] [bit] NULL,
 CONSTRAINT [PK_Turma] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Aluno_Turma]  WITH CHECK ADD  CONSTRAINT [FK_Aluno_Turma_Turma] FOREIGN KEY([Turma_Id])
REFERENCES [dbo].[Turma] ([Id])
GO
ALTER TABLE [dbo].[Aluno_Turma] CHECK CONSTRAINT [FK_Aluno_Turma_Turma]
GO
ALTER TABLE [dbo].[Turma]  WITH CHECK ADD  CONSTRAINT [FK_Turma_1_idx] FOREIGN KEY([Id])
REFERENCES [dbo].[Turma] ([Id])
GO
ALTER TABLE [dbo].[Turma] CHECK CONSTRAINT [FK_Turma_1_idx]
GO
