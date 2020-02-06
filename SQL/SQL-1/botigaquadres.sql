-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 06-02-2020 a las 13:49:02
-- Versión del servidor: 10.4.8-MariaDB
-- Versión de PHP: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `botigaquadres`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `compradors`
--

CREATE TABLE `compradors` (
  `dni` char(9) NOT NULL,
  `nombre` varchar(40) DEFAULT NULL,
  `email` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `compradors`
--

INSERT INTO `compradors` (`dni`, `nombre`, `email`) VALUES
('11010111K', 'Nicalás Westerms', 'nicalas@mail.es'),
('22010122H', 'Altón Nieva', 'anton@mail.es'),
('33010133L', 'Junicar Lowns', 'junicar@mail.es'),
('55010155P', 'Picard Jean Luc', 'picard@mail.es'),
('99010199L', 'Junicar Lowns', 'junicar@mail.es');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalle`
--

CREATE TABLE `detalle` (
  `id` int(11) NOT NULL,
  `idVenta` int(11) NOT NULL,
  `idQuadre` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `detalle`
--

INSERT INTO `detalle` (`id`, `idVenta`, `idQuadre`) VALUES
(1, 2, 1),
(2, 4, 2),
(3, 1, 3),
(4, 3, 4),
(5, 5, 5),
(6, 6, 6),
(7, 7, 7),
(8, 8, 8),
(9, 9, 10);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `quadres`
--

CREATE TABLE `quadres` (
  `id` int(11) NOT NULL,
  `preu` float NOT NULL,
  `autor` varchar(50) DEFAULT NULL,
  `titulo` varchar(50) DEFAULT NULL,
  `descripcion` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `quadres`
--

INSERT INTO `quadres` (`id`, `preu`, `autor`, `titulo`, `descripcion`) VALUES
(1, 30.3, 'Data', 'Mi hija', 'lienzo en el que Data pintó a su futura hija'),
(2, 12.5, 'Logan', 'Lo conseguí', 'Escena en la que Logan consigue escapar'),
(3, 10.4, 'Jurado', 'Mi legado', 'Los que se quedaron con todo viviendo a su costa'),
(4, 10.4, 'Vicen Van Gogh', 'Girasoles', 'Me valorais cuando me he ido, la madre que os parí'),
(5, 15.5, 'Logando', 'Lo mismo más 2', 'Escena en la que Logan consigue escapar'),
(6, 14.4, 'Jurado', 'Mi legado 2', 'Los que se quedaron con todo viviendo a su costa'),
(7, 22.4, 'Vicen Van Gogh', 'Bonita noche', 'Me valorais cuando me he ido, la madre que os pari'),
(8, 100.2, 'Logando', 'Lo mismo más 3', 'Escena en la que Logan consigue escapar'),
(9, 10.2, 'Jurado', 'Noche loca', 'salimos de fiesta whuaaaaaauuuuu!!!'),
(10, 8.2, 'Vicen Van Gogh', 'El campo', 'Me valorais cuando me he ido, la madre que os pari');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventas`
--

CREATE TABLE `ventas` (
  `id` int(11) NOT NULL,
  `fechaHora` datetime NOT NULL,
  `dniComprador` char(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ventas`
--

INSERT INTO `ventas` (`id`, `fechaHora`, `dniComprador`) VALUES
(1, '2020-02-06 11:20:10', '99010199L'),
(2, '2020-02-05 10:10:10', '55010155P'),
(3, '2020-02-06 11:20:10', '99010199L'),
(4, '2020-02-05 10:10:10', '55010155P'),
(5, '2020-01-07 11:20:10', '11010111K'),
(6, '2020-01-07 23:10:10', '22010122H'),
(7, '2020-01-07 23:10:10', '22010122H'),
(8, '2020-01-08 12:20:10', '33010133L'),
(9, '2020-01-08 12:20:10', '33010133L');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `compradors`
--
ALTER TABLE `compradors`
  ADD PRIMARY KEY (`dni`);

--
-- Indices de la tabla `detalle`
--
ALTER TABLE `detalle`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idVenta` (`idVenta`),
  ADD KEY `idQuadre` (`idQuadre`);

--
-- Indices de la tabla `quadres`
--
ALTER TABLE `quadres`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `ventas`
--
ALTER TABLE `ventas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `dniComprador` (`dniComprador`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `detalle`
--
ALTER TABLE `detalle`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de la tabla `quadres`
--
ALTER TABLE `quadres`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `ventas`
--
ALTER TABLE `ventas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `detalle`
--
ALTER TABLE `detalle`
  ADD CONSTRAINT `detalle_ibfk_1` FOREIGN KEY (`idVenta`) REFERENCES `ventas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `detalle_ibfk_2` FOREIGN KEY (`idQuadre`) REFERENCES `quadres` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `ventas`
--
ALTER TABLE `ventas`
  ADD CONSTRAINT `ventas_ibfk_1` FOREIGN KEY (`dniComprador`) REFERENCES `compradors` (`dni`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
