-- Insertar 7 razas
INSERT INTO Razas (id, nombre) VALUES
    (1, 'Holstein'), (2, 'Angus'), (3, 'Hereford'),
    (4, 'Jersey'), (5, 'Charolais'), (6, 'Limousin'), (7, 'Simmental');

-- Insertar 20 animales
INSERT INTO animals (id, nombre, fechaNacimiento, sexo, precio, estado, comentarios, razaId) VALUES
    (1, 'Bola', '2021-01-10', 'M', 1500.00, 'activo', 'Animal joven', 1),
    (2, 'Luna', '2019-05-20', 'H', 2000.00, 'activo', 'Animal robusto', 2),
    (3, 'Max', '2020-11-15', 'M', 1800.00, 'activo', 'Buena salud', 3),
    (4, 'Daisy', '2018-08-05', 'H', 2500.00, 'inactivo', 'Se retiró del servicio', 4),
    (5, 'Molly', '2017-12-22', 'H', 2200.00, 'activo', 'Excelente productora de leche', 1),
    (6, 'Rocky', '2019-03-14', 'M', 1700.00, 'activo', 'Animal joven y fuerte', 5),
    (7, 'Coco', '2018-06-30', 'H', 1900.00, 'inactivo', 'Vendido a un criador', 3),
    (8, 'Charlie', '2020-09-18', 'M', 1600.00, 'activo', 'Animal amigable', 2),
    (9, 'Lucy', '2017-11-05', 'H', 2100.00, 'activo', 'Ganadora de concursos', 6),
    (10, 'Buddy', '2019-02-10', 'M', 2300.00, 'activo', 'Mascota cariñosa', 7),
    (11, 'Duke', '2020-04-27', 'M', 2000.00, 'inactivo', 'Se vendió a un ganadero', 2),
    (12, 'Mia', '2018-10-12', 'H', 2400.00, 'activo', 'Buena para la reproducción', 1),
    (13, 'Shadow', '2019-07-08', 'M', 1750.00, 'activo', 'Animal ágil y fuerte', 3),
    (14, 'Sophie', '2017-09-03', 'H', 1950.00, 'inactivo', 'Jubilada del ordeño', 4),
    (15, 'Maximus', '2020-01-22', 'M', 1850.00, 'activo', 'Animal de exposición', 5),
    (16, 'Zoe', '2018-04-16', 'H', 2150.00, 'activo', 'Buena genética', 6),
    (17, 'Bentley', '2019-06-25', 'M', 2250.00, 'inactivo', 'Vendido a un comprador privado', 7),
    (18, 'Cleo', '2017-08-11', 'H', 2600.00, 'activo', 'Excelente salud y temperamento', 1),
    (19, 'Leo', '2018-12-03', 'M', 1700.00, 'activo', 'Animal juguetón', 2),
    (20, 'Oscar', '2019-10-05', 'M', 1950.00, 'inactivo', 'Se mudó a una reserva natural', 3);
