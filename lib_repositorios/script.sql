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

-- VALORES PRUEBA

INSERT INTO [Clientes](Cedula, Nombre, Telefono) VALUES
('111', 'Carlos Romero', '3157894562'),
('222', 'Marco Polo', '3164568582'),
('333', 'Alan Turing', '3125469887'),
('444', 'Ada Lovelace', '3225648213');

INSERT INTO [Sucursales]( Nombre, Direccion) VALUES
('A1', 'Calle 1'),
('A2', 'Calle 2'),
('A3', 'Calle 3'),
('A4', 'Calle 4');

INSERT INTO [MetodosPagos](Nombre, Estado) VALUES
('Credito', 1),
('Debito', 1),
('Efectivo', 1);

INSERT INTO [Lugares](Nombre, CodigoPostal) VALUES
('San Antonio', '5001'),
('Poblado', '5002'),
('Las Americas', '5003');

INSERT INTO [Marcas](Nombre, Nit) VALUES
('Arturo Calle', 123),
('Patprimo', 456),
('Estudio F', 101);

INSERT INTO [Productos](Nombre, Material, ValorUnitario, Marca) VALUES 
('Blazer', 'Algodón', 300000, 1),
('Camisa', 'Seda', 400000, 2),
('Blusa', 'Algodón', 500000, 3);

INSERT INTO [Compras] (Fecha, Codigo, ValorTotal, Cliente, Sucursal, MetodoPago, Lugar) VALUES
('2024-03-01 10:30:00', 'C001', 850000.00, 1, 1, 1, 1),
('2024-03-02 15:45:00', 'C002', 1200000.50, 2, 2, 2, 2),
('2024-03-03 12:20:00', 'C003', 650000.00, 3, 3, 3, 3),
('2024-03-04 09:10:00', 'C004', 950000.00, 4, 4, 1, 1),
('2024-03-05 14:30:00', 'C005', 1340000.75, 1, 2, 2, 3),
('2024-03-06 11:55:00', 'C006', 770000.00, 2, 3, 3, 2),
('2024-03-07 17:15:00', 'C007', 930000.20, 3, 1, 1, 3),
('2024-03-08 13:40:00', 'C008', 1100000.00, 4, 4, 2, 1),
('2024-03-09 16:05:00', 'C009', 890000.99, 1, 3, 3, 2),
('2024-03-10 08:50:00', 'C010', 1025000.60, 2, 2, 1, 3);

INSERT INTO [DetallesCompras] (Cantidad, ValorBruto, Compra, Producto) VALUES
(2, 600000.00, 1, 1),
(1, 400000.00, 1, 2),
(3, 1500000.00, 2, 3),
(2, 800000.00, 2, 1),
(1, 500000.00, 3, 3),
(4, 1200000.00, 4, 2),
(2, 1000000.00, 5, 1),
(1, 500000.00, 6, 3),
(3, 900000.00, 7, 2),
(2, 600000.00, 8, 1);


