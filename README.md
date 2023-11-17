# Prueba-de-desarrollo---Back-End-junior
El cliente necesita un sistema de información que le permita gestionar información de bovinos de una granja. Se desarrolla una API REST 

# Datos
## Animal
  - Id, Nombre, Fecha de nacimiento, Sexo, Precio, Estado (activo, inactivo), Comentarios
  - Los animales bovinos tendrán un tipo de raza, que podrá ser compartida con otros
    animales. El diligenciamiento de la raza es obligatorio
  - Crear una base de datos falsa con al menos 20 animales
  - Reglas de negocio:
    -- El nombre de cada animal debe ser único
    -- El precio de cada animal debe ser mayor a 0

# Back End

## Animal
  - Crear un controlador para realizar las siguientes tareas
    - Obtener una entidad por identificador
    - Obtener todas las entidades (usando paginación del lado del servidor)
    - Crear una entidad nueva
    - Editar una entidad existente
    - Eliminar un entidad existente
    - Obtener un servicio que retorne el número de animales activos agrupados por su
      raza
  
## Raza
  - Crear un controlador para realizar las siguientes tareas
    - Obtener una entidad por identificador
    - Obtener todas las entidades (usando paginación del lado del servidor)
    - Crear una entidad nueva
    - Editar una entidad existente
    - Eliminar un entidad existente


# Sistema
- net6.0
- FluentValidation.AspNetCore Version = 6.4.0
- Microsoft.EntityFrameworkCore.Proxies Version = 6.0.0
- Microsoft.EntityFrameworkCore.SqlServer Version = 6.0.0
- Microsoft.EntityFrameworkCore.Tools. Version = 6.0.0
- MySQL WorkBench

# Instalación

1. Clona este repositorio:
   ```bash
   git clone https://github.com/marciniegas/Prueba-de-desarrollo---Back-End-junior.git
2. Navega al directorio del proyecto: cd Bovinos
3. Instala los paquetes anteriormente mencionados, con "Administrador de paquetes NuGet" (verifica las versiones)

# Configuración
- Utilizando MySQL Workbench crea una base de datos, para el ejemplo se utilizó el nombre "bovino_informacion"
- Configura la conexión de la base de datos en el archivo appsettings.json:
  ```bash
    Server=localhost;Database=bovino_informacion;User=xxxxxxx;Password=xxxxxx;Port=3306
-Utiliza la terminal de Visual Basic y escribe el comando para exportar las tablas a MySQL.
  ```bash
    dotnet ef database update
- Se comparte un archivo con el nombre "ScripDatosBovinos.sql" para utilizarlo en MySQL Workbench y llenar las tablas con datos de ejemplo.
-Inicia la depuración del proyecto (en la prueba se utilizó https://localhost:7091/swagger/index.html).
- El siguiente paso ya es verificar los controladores, por ejemplo, en "Obtener un animal por identificador":
-- Haz clic sobre él.
-- Haz clic en Try it out.
-- Coloca un Id (int).
-- Haz clic en Execute
-- Mostrará el resultado de la tarea en la parte inferior- 



