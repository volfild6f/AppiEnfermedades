CREATE TABLE [Enfermedad] (
  [id_enfermedad]  int IDENTITY(1,1) PRIMARY KEY,
  [nombre_enfermedad] nvarchar(255)
)
GO

CREATE TABLE [Detalle_enfermedad] (
  [id_detalle_enfermedad] int IDENTITY(1,1) PRIMARY KEY,
  [id_enfermedad] int,
  [id_categoria] int,
  [id_sintoma] int
)
GO

CREATE TABLE [Categoria] (
  [id_categoria] int IDENTITY(1,1) PRIMARY KEY,
  [nombre_categoria] nvarchar(255)
)
GO

CREATE TABLE [Sintoma] (
  [id_sintoma] int IDENTITY(1,1) PRIMARY KEY,
  [nombre_sintoma] nvarchar(255),
  [detalle_sintoma] nvarchar(255)
)
GO

ALTER TABLE [Detalle_enfermedad] ADD FOREIGN KEY ([id_enfermedad]) REFERENCES [enfermedad] ([id_enfermedad])
GO

ALTER TABLE [Detalle_enfermedad] ADD FOREIGN KEY ([id_sintoma]) REFERENCES [sintoma] ([id_sintoma])
GO

ALTER TABLE [Detalle_enfermedad] ADD FOREIGN KEY ([id_categoria]) REFERENCES [Categoria] ([id_categoria])
GO
