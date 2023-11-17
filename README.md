# Prueba-de-desarrollo---Back-End-junior
El cliente necesita un sistema de información que le permita gestionar información de bovinos de una granja. Se desarrolla una API REST 

## Datos
# Animal
  - Id, Nombre, Fecha de nacimiento, Sexo, Precio, Estado (activo, inactivo), Comentarios
  - Los animales bovinos tendrán un tipo de raza, que podrá ser compartida con otros
    animales. El diligenciamiento de la raza es obligatorio
  - Crear una base de datos falsa con al menos 20 animales
  - Reglas de negocio:
    -- El nombre de cada animal debe ser único
    -- El precio de cada animal debe ser mayor a 0

## Back End

# Animal
  - Crear un controlador para realizar las siguientes tareas
    - Obtener una entidad por identificador
    - Obtener todas las entidades (usando paginación del lado del servidor)
    - Crear una entidad nueva
    - Editar una entidad existente
    - Eliminar un entidad existente
    - Obtener un servicio que retorne el número de animales activos agrupados por su
      raza
  
# Raza
  - Crear un controlador para realizar las siguientes tareas
    - Obtener una entidad por identificador
    - Obtener todas las entidades (usando paginación del lado del servidor)
    - Crear una entidad nueva
    - Editar una entidad existente
    - Eliminar un entidad existente


## Sistema
- net6.0
- FluentValidation.AspNetCore Version = 6.4.0
- Microsoft.EntityFrameworkCore.Proxies Version = 6.0.0
- Microsoft.EntityFrameworkCore.SqlServer Version = 6.0.0
- Microsoft.EntityFrameworkCore.Tools. Version = 6.0.0
- MySQL WorkBench

## Instalación

1. Clona este repositorio:
   ```bash
   git clone https://github.com/marciniegas/Prueba-de-desarrollo---Back-End-junior.git
