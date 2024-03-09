# Update Commit - 9/03/2024

Pasos de instalación de dependencias:

- Instalar MySql Connector mysql-connector-net-8.0.18 (Obligatorio)
- Instalar Mysql for visual studio 1.2.9 (Obligatorio)
- Instalar por paquetes de NuGet la versión MySql.Data.EntityFramework 8.0.18 en la capa DAL (Solo cuando se hace desde cero)
- 
## CategoriaBL

- `guardarCategoria(categoria modelo)`: Guarda una nueva categoría en la base de datos.
- `actualizarCategoria(categoria modelo)`: Actualiza la información de una categoría existente en la base de datos.
- `eliminarCategoria(int id)`: Elimina una categoría de la base de datos según su ID.
- `consultarCategorias()`: Retorna una lista de todas las categorías almacenadas en la base de datos.
- `consultarCategoria(long  id)`: Retorna una categoria por id


