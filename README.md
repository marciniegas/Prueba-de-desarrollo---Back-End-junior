<script src="https://cdnjs.cloudflare.com/ajax/libs/clipboard.js/2.0.8/clipboard.min.js"></script>


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

1. Clona este repositorio: `git clone https://github.com/marciniegas/Prueba-de-desarrollo---Back-End-junior.git
2. Navega al directorio del proyecto: `cd Bovinos`
3. Instalar los paquetes anteriormente mencionados, con "Administrador de paquetes NuGet" (verificar las versiones)

## Configuración

- Utilizando MySQL Workbench crear una base de datos, para el ejemplo se utilizo el nombre "bovino_informacion"
- Se debe configurar la conexion de base de datos, en el archivo appsettings.json =>
  -- Server=localhost;Database=bovino_informacion;User=xxxxxxx;Password=xxxxxx;Port=3306"
- Utilizando la terminal de visual Basic, escribir el comando  
<button class="copy-button" data-clipboard-target="#codigo-ejemplo">Copiar Código</button>
<div id="codigo-ejemplo">
def ejemplo():
    dotnet ef database update

ejemplo()
</div>
## Uso

Instrucciones sobre cómo utilizar el proyecto una vez que esté instalado y configurado.

## Contribución

Indica cómo los desarrolladores pueden contribuir al proyecto. Puedes incluir información sobre la presentación de problemas, solicitudes de funciones y pautas de estilo de código.

## Licencia

Este proyecto está bajo la Licencia [Nombre de la Licencia]. Consulta el archivo `LICENSE.md` para obtener más detalles.

<script>
document.addEventListener('DOMContentLoaded', function() {
    var clipboard = new ClipboardJS('.copy-button');

    clipboard.on('success', function(e) {
        alert('¡Código copiado con éxito!');
    });

    clipboard.on('error', function(e) {
        alert('Error al intentar copiar el código.');
    });
});
</script>
