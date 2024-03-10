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

## ProductoBL
- `ObtenerProductos()`: Retorna una lista de todos los productos almacenados en la base de datos.
- `ConsultarProducto(int id)`: Retorna un producto específico buscado por su ID.
- `AgregarProducto(producto producto)`: Agrega un nuevo producto a la base de datos.
- `ModificarProducto(producto producto)`: Modifica la información de un producto existente en la base de datos.
- `EliminarProducto(int id)`: Elimina un producto de la base de datos según su ID.
- `ObtenerProductosPorCategorias(List<int> categoriasSeleccionadas)`: Este método retorna una lista de productos filtrados por las categorías seleccionadas. Recibe como parámetro una lista de enteros que representan los IDs de las categorías seleccionadas por el usuario.
- `ObtenerProductosPorIva(decimal? porcentajeIva = null)`: Este método retorna una lista de productos filtrados por un porcentaje de IVA especificado. Si no se proporciona ningún valor para el porcentaje de IVA, devuelve todos los productos. El parámetro porcentajeIva es opcional y representa el porcentaje de IVA deseado, expresado como un número decimal.


