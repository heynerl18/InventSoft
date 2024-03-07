# Update Commit - 7/03/2024

## ProductoBL

- `obtenerProductosConCategoria()`: Retorna una lista de productos con sus categorías.
- `obtenerProductosPorCategorias(List<int> idsCategorias)`: Retorna una lista de productos filtrados por categorías especificadas.
- `InsertarProducto(producto nuevoProducto)`: Inserta un nuevo producto en la base de datos.
- `ActualizarProducto(producto productoActualizado)`: Actualiza la información de un producto existente en la base de datos.
- `EliminarProducto(int idProducto)`: Elimina un producto de la base de datos según su ID.
- `obtenerProductosConIva(decimal? porcentajeIva = null)`: Retorna una lista de productos con su respectivo IVA, opcionalmente filtrados por un porcentaje de IVA.
- `ReducirStock(List<ProductoVenta> productosVendidos)`: Reduce el stock de los productos vendidos.
- `GenerarReporteVenta(DateTime fechaHora, decimal subtotal, decimal ivaTotal, decimal totalPagado)`: Genera un reporte de venta con la información proporcionada. (Pendiente de análisis)
- `GenerarReporteInventario(List<int> idsCategorias, decimal porcentajeIva)`: Método comentado que aún no ha sido implementado para generar un reporte de inventario. (Pendiente de análisis)

## CategoriaBL

- `guardarCategoria(categoria modelo)`: Guarda una nueva categoría en la base de datos.
- `actualizarCategoria(categoria modelo)`: Actualiza la información de una categoría existente en la base de datos.
- `eliminarCategoria(int id)`: Elimina una categoría de la base de datos según su ID.
- `consultarCategorias()`: Retorna una lista de todas las categorías almacenadas en la base de datos.

## Modelos auxiliares

- `ProductoVenta`: Para posteriormente utilizarlos como ayuda para las ventas
- `ProductoReporte`: Para posteriormente utilizarlos como ayuda para los reportes
