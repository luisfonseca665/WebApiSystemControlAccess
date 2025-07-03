use SecureAccess;

CREATE TABLE Usuarios (
    id_usuario INT PRIMARY KEY IDENTITY,
    nombre VARCHAR(100) NOT NULL,
    apellido_paterno VARCHAR(100) NOT NULL,
    apellido_materno VARCHAR(100) NOT NULL,
    usuario VARCHAR(100) NOT NULL UNIQUE,
    password NVARCHAR(255) NOT NULL,
    numero_casa VARCHAR(50),
    calle VARCHAR(150),
    correo VARCHAR(150) NOT NULL UNIQUE,
    telefono VARCHAR(20),
    imagen VARBINARY(MAX),
    fecha_registro DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Invitados (
    invitado_id INT IDENTITY PRIMARY KEY,
    nombre VARCHAR(100),
    apellido_paterno VARCHAR(100),
    apellido_materno VARCHAR(100),
    fecha_vigencia DATETIME,
    estatus BIT,
    id_usuario INT,
    FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario)
);
GO

CREATE TABLE Historiales (
    id_historial INT IDENTITY(1,1) PRIMARY KEY,
    fecha_entrada DATETIME,
    fecha_salida DATETIME,
    id_usuario INT,
    FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario)
);
GO