CREATE DATABASE Examen
USE Examen

CREATE TABLE Autor
(
	IdAutor INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50)
)

CREATE TABLE Editorial
(
	IdEditorial INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50)
)

CREATE TABLE Genero
(
	IdGenero INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50)
)

CREATE TABLE Libro
(
	IdLibro INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50),
	IdAutor INT FOREIGN KEY REFERENCES Autor(IdAutor),
	NumeroPaginas INT, 
	FechaPublicacion DATE,
	IdEditorial INT FOREIGN KEY REFERENCES Editorial(IdEditorial),
	Edicion VARCHAR(50),
	IdGenero INT FOREIGN KEY REFERENCES Genero(IdGenero)
)



ALTER PROCEDURE LibroAdd
@Nombre VARCHAR(50),
@IdAutor INT,
@NumeroPaginas INT,
@FechaPublicacion DATE,
@IdEditorial INT,
@Edicion VARCHAR(50),
@IdGenero INT
AS
	INSERT INTO [dbo].[Libro]
           ([Nombre]
           ,[IdAutor]
           ,[NumeroPaginas]
           ,[FechaPublicacion]
           ,[IdEditorial]
           ,[Edicion]
           ,[IdGenero])
     VALUES
           (@Nombre
           ,@IdAutor
           ,@NumeroPaginas
           ,CONVERT (DATE,@FechaPublicacion,105)
           ,@IdEditorial
           ,@Edicion
           ,@IdGenero)
GO

CREATE PROCEDURE LibroGetAll
AS
	SELECT [IdLibro]
      ,Libro.[Nombre]
      ,Autor.[IdAutor]
	  ,Autor.[Nombre] AS NombreAutor
      ,Libro.[NumeroPaginas]
      ,Libro.[FechaPublicacion]
      ,Editorial.[IdEditorial]
	  ,Editorial.[Nombre] AS NombreEditorial
      ,Libro.[Edicion]
      ,Genero.[IdGenero]
	  ,Genero.[Nombre] AS NombreGenero
  FROM [Libro]
  INNER JOIN Autor ON Autor.IdAutor = Libro.IdAutor
  INNER JOIN Editorial ON Editorial.IdEditorial = Libro.IdEditorial
  INNER JOIN Genero ON Genero.IdGenero = Libro.IdGenero
GO

CREATE PROCEDURE LibroGetById
@IdLibro INT 
AS
	SELECT [IdLibro]
      ,Libro.[Nombre]
      ,Autor.[IdAutor]
	  ,Autor.[Nombre] AS NombreAutor
      ,Libro.[NumeroPaginas]
      ,Libro.[FechaPublicacion]
      ,Editorial.[IdEditorial]
	  ,Editorial.[Nombre] AS NombreEditorial
      ,Libro.[Edicion]
      ,Genero.[IdGenero]
	  ,Genero.[Nombre] AS NombreGenero
  FROM [Libro]
  INNER JOIN Autor ON Autor.IdAutor = Libro.IdAutor
  INNER JOIN Editorial ON Editorial.IdEditorial = Libro.IdEditorial
  INNER JOIN Genero ON Genero.IdGenero = Libro.IdGenero
  WHERE Libro.IdLibro = @IdLibro
GO

CREATE PROCEDURE LibroUpdate
@IdLibro INT,
@Nombre VARCHAR(50),
@IdAutor INT,
@NumeroPaginas INT,
@FechaPublicacion DATE,
@IdEditorial INT,
@Edicion VARCHAR(50),
@IdGenero INT
AS
	UPDATE [Libro]
   SET [Nombre] = @Nombre
      ,[IdAutor] = @IdAutor
      ,[NumeroPaginas] = @NumeroPaginas
      ,[FechaPublicacion] = CONVERT (DATE,@FechaPublicacion,105)
      ,[IdEditorial] = @IdEditorial
      ,[Edicion] = @Edicion
      ,[IdGenero] = @IdGenero
 WHERE Libro.IdLibro = @IdLibro
GO

CREATE PROCEDURE LibroDelete
@IdLibro INT
AS
	DELETE FROM [Libro]
      WHERE Libro.IdLibro = @IdLibro
GO

CREATE PROCEDURE AutorGetAll
AS
	SELECT [IdAutor]
      ,[Nombre]
  FROM [Autor]
GO

CREATE PROCEDURE EditorialGetAll
AS
	SELECT [IdEditorial]
      ,[Nombre]
  FROM [Editorial]
GO

CREATE PROCEDURE GeneroGetAll
AS
	SELECT [IdGenero]
      ,[Nombre]
  FROM [Genero]
GO

metadata=res://*/EYañezExamenEntities.csdl|res://*/EYañezExamenEntities.ssdl|res://*/EYañezExamenEntities.msl;provider=System.Data.SqlClient;provider connection string="data source=LAPTOP-6PGUJ6P1\SQLEXPRESS;initial catalog=Examen;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"