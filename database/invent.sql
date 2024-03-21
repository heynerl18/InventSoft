-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 21-03-2024 a las 21:02:48
-- Versión del servidor: 10.4.20-MariaDB
-- Versión de PHP: 7.4.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `invent`
--
CREATE DATABASE IF NOT EXISTS `invent` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `invent`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categoria`
--

DROP TABLE IF EXISTS `categoria`;
CREATE TABLE `categoria` (
  `id` int(11) NOT NULL,
  `nombre` varchar(100) DEFAULT NULL,
  `iva` decimal(5,2) DEFAULT NULL,
  `grupoAlimentos` varchar(150) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `categoria`
--

INSERT INTO `categoria` (`id`, `nombre`, `iva`, `grupoAlimentos`) VALUES
(1, 'Lácteos', '0.12', 'Lácteos'),
(2, 'Hogar', '0.16', 'Hogar'),
(3, 'Carnes', '0.10', 'Carnes'),
(4, 'Verduras y Frutas', '0.08', 'Frutas y Verduras'),
(5, 'Pastas', '0.12', 'Pastas'),
(6, 'Enlatados', '0.12', 'Enlatados'),
(7, 'Nueva Categoria', '0.16', 'Grupo de Alimentos'),
(8, 'Nueva Categoria', '0.16', 'Grupo de Alimentos'),
(9, 'Nueva Categoria', '0.16', 'Grupo de Alimentos'),
(10, 'Categoria de prueba', '0.16', 'Grupo de prueba');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `producto`
--

DROP TABLE IF EXISTS `producto`;
CREATE TABLE `producto` (
  `id` int(11) NOT NULL,
  `nombre` varchar(100) DEFAULT NULL,
  `categoriaid` int(11) DEFAULT NULL,
  `precioSinIva` decimal(10,2) DEFAULT NULL,
  `Iva` decimal(10,2) DEFAULT NULL,
  `unidadVenta` varchar(20) DEFAULT NULL,
  `stock` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `producto`
--

INSERT INTO `producto` (`id`, `nombre`, `categoriaid`, `precioSinIva`, `Iva`, `unidadVenta`, `stock`) VALUES
(1, 'Leche Entera', 1, '2.50', '0.12', 'Litros', 100),
(2, 'Queso Fresco', 1, '4.00', NULL, 'Unidades', 50),
(3, 'Detergente', 2, '5.75', '0.16', 'Litros', 200),
(4, 'Carne de Res', 3, '10.50', '0.10', 'Kilos', 30),
(5, 'Manzanas', 4, '2.00', '0.08', 'Kilos', 80),
(6, 'Espaguetis', 5, '1.50', '0.12', 'Kilos', 100),
(7, 'Atún en Conserva', 6, '1.80', NULL, 'Unidades', 120),
(9, 'Nuevo Producto', 1, '10.50', '0.16', 'unidad', 100),
(10, 'Nuevo Producto', 1, '10.50', '0.16', 'unidad', 100),
(11, 'Nuevo Producto', 1, '10.50', '0.16', 'unidad', 100),
(12, 'Nuevo Producto', 1, '10.50', '0.16', 'unidad', 100),
(13, 'Nuevo Producto', 1, '10.50', '0.16', 'unidad', 100);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `categoria`
--
ALTER TABLE `categoria`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `producto`
--
ALTER TABLE `producto`
  ADD PRIMARY KEY (`id`),
  ADD KEY `categoriaid` (`categoriaid`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `categoria`
--
ALTER TABLE `categoria`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de la tabla `producto`
--
ALTER TABLE `producto`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `producto`
--
ALTER TABLE `producto`
  ADD CONSTRAINT `producto_ibfk_1` FOREIGN KEY (`categoriaid`) REFERENCES `categoria` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
