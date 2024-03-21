# Update Commit - 9/03/2024

Pasos de instalación de dependencias:

- Instalar MySql Connector mysql-connector-net-8.0.18 (Obligatorio)
- Instalar Mysql for visual studio 1.2.9 (Obligatorio)
- Instalar por paquetes de NuGet la versión MySql.Data.EntityFramework 8.0.18 en la capa DAL (Solo cuando se hace desde cero)

Para descargar estas dependencias: https://drive.google.com/drive/u/0/folders/1TdiuDEtZMRDe4phHmwZxJXBgOUmeh37W

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

## Pasos para parte de ventas
- Diseño de la interfaz de usuario: Crea una página web con controles para mostrar los productos disponibles, permitir al usuario seleccionar la cantidad deseada, calcular el subtotal, el IVA total y el total a pagar. También incluye un botón de "Pagar" para finalizar la compra.

- Obtener productos del inventario: Utiliza el método ObtenerProductos del servicio ProductoService para obtener la lista de productos disponibles en el inventario. Puedes mostrar estos productos en una cuadrícula o lista en la interfaz de usuario.

- Selección de productos y cálculos de precios: Permite al usuario seleccionar productos del inventario y especificar la cantidad deseada. Con cada selección de producto y cantidad, calcula el subtotal, el IVA total y el total a pagar. Puedes hacer estos cálculos en el lado del cliente utilizando JavaScript o en el lado del servidor en el código detrás de la página web.

- Reducción del stock al pagar: Cuando el usuario hace clic en el botón "Pagar", utiliza el servicio ProductoService para reducir el stock disponible de cada producto vendido. Puedes llamar al método ModificarProducto del servicio para actualizar la cantidad de stock de cada producto.

- Generación de reporte: Después de que se haya completado la transacción de compra, genera un reporte que incluya la fecha y hora actual, el subtotal, el IVA total y el total pagado. Puedes guardar estos detalles en una base de datos o en un archivo de registro.

- Interacción con la base de datos: Asegúrate de tener un acceso adecuado a la base de datos para realizar operaciones como obtener productos, modificar el stock y guardar detalles de la transacción.


