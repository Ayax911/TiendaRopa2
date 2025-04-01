CREATE DATABASE db_tiendaropa;
GO
USE db_tiendaropa;
GO

CREATE TABLE [Clientes] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Cedula] NVARCHAR(150) NOT NULL,
	[Nombre] NVARCHAR(150) NOT NULL,
	[Telefono] NVARCHAR(150) NOT NULL
);

CREATE TABLE [Sucursales] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(150) NOT NULL,
	[Direccion] NVARCHAR(150) NOT NULL,
);

CREATE TABLE [Lugares] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(150) NOT NULL,
	[CodigoPostal] NVARCHAR(150) NOT NULL
);

CREATE TABLE [MetodosPagos] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(150) NOT NULL,
	[Estado] BIT NOT NULL
);

CREATE TABLE [Compras] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Fecha] DATETIME NOT NULL,
	[Codigo] NVARCHAR(150) NOT NULL,
	[ValorTotal] DECIMAL(10,2) NOT NULL,
	[Cliente] INT REFERENCES [Clientes]([Id]),
	[Sucursal] INT REFERENCES [Sucursales]([Id]),
	[MetodoPago] INT REFERENCES [MetodosPagos]([Id]),
	[Lugar] INT REFERENCES [Lugares]([Id])
);

CREATE TABLE [Marcas] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(150) NOT NULL,
	[Nit] NVARCHAR(150) NOT NULL
);

CREATE TABLE [Productos] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(150) NOT NULL,
	[Material] NVARCHAR(150) NOT NULL,
	[ValorUnitario] DECIMAL(10,2) NOT NULL,
	[Marca] INT REFERENCES [Marcas]([Id])
);

CREATE TABLE [DetallesCompras] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Cantidad] INT NOT NULL,
	[ValorBruto] DECIMAL(10,2) NOT NULL,
	[Compra] INT REFERENCES [Compras]([Id]),
	[Producto] INT REFERENCES [Productos]([Id])
);

-- Insertar en Clientes
INSERT INTO Clientes (Cedula, Nombre, Telefono)  
VALUES ('1012345678', 'Juan Pérez', '3204567890');  

-- Insertar en Sucursales
INSERT INTO Sucursales (Nombre, Direccion)  
VALUES ('Tienda Bogotá Centro', 'Cra 7 #12-34, Bogotá');  

-- Insertar en Lugares
INSERT INTO Lugares (Nombre, CodigoPostal)  
VALUES ('Bogotá', '110111');  

-- Insertar en Métodos de Pago
INSERT INTO MetodosPagos (Nombre, Estado)  
VALUES ('Tarjeta de Crédito', 1);  

-- Insertar en Compras (corregida la fecha)
INSERT INTO Compras (Fecha, Codigo, ValorTotal, Cliente, Sucursal, MetodoPago, Lugar)  
VALUES ('2025-03-28T00:00:00', 'COMP-001', 150000.00,  
        (SELECT TOP 1 Id FROM Clientes ORDER BY Id DESC),  
        (SELECT TOP 1 Id FROM Sucursales ORDER BY Id DESC),  
        (SELECT TOP 1 Id FROM MetodosPagos ORDER BY Id DESC),  
        (SELECT TOP 1 Id FROM Lugares ORDER BY Id DESC)); 

-- Insertar en Marcas
INSERT INTO Marcas (Nombre, Nit)  
VALUES ('RopaFina', '900123456');  

-- Insertar en Productos
INSERT INTO Productos (Nombre, Material, ValorUnitario, Marca)  
VALUES ('Camiseta Polo', 'Algodón', 50000.00, 1);  

-- Insertar en DetallesCompras
INSERT INTO DetallesCompras (Cantidad, ValorBruto, Compra, Producto)  
    VALUES (3, 150000.00,  
            (SELECT TOP 1 Id FROM Compras ORDER BY Id DESC),  
            (SELECT TOP 1 Id FROM Productos ORDER BY Id DESC)); 
