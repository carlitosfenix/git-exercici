-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Temps de generació: 07-02-2020 a les 13:00:36
-- Versió del servidor: 10.4.8-MariaDB
-- Versió de PHP: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de dades: `catalegllibres`
--

-- --------------------------------------------------------

--
-- Estructura de la taula `autors`
--

CREATE TABLE `autors` (
  `id` int(11) NOT NULL,
  `direccio` varchar(60) DEFAULT NULL,
  `email` varchar(40) DEFAULT NULL,
  `url` varchar(255) DEFAULT NULL,
  `numeroPublicaciones` int(11) NOT NULL,
  `nombre` varchar(40) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Bolcament de dades per a la taula `autors`
--

INSERT INTO `autors` (`id`, `direccio`, `email`, `url`, `numeroPublicaciones`, `nombre`) VALUES
(1, 'Carrer dels musics', 'manel@gmail.com', 'https://autordivino.com', 10, 'Cervantes'),
(2, 'Carrer del Miguel', 'miguel@gmail.com', 'https://autornew.com', 20, 'Miguel'),
(3, 'Carrer del Josele', 'josele@gmail.com', 'https://joselito.com', 18, 'José'),
(4, 'Carrer del Grand', 'manel@gmail.com', 'https://grand.com', 15, 'Grande'),
(5, 'Carrer dels nomades', 'manel@gmail.com', 'https://nomada.com', 12, 'Nómada'),
(6, 'Carrer platon', 'platon@gmail.com', 'https://platon.com', 25, 'Platón');

-- --------------------------------------------------------

--
-- Estructura de la taula `detalls`
--

CREATE TABLE `detalls` (
  `id` int(11) NOT NULL,
  `idLlibre` int(11) DEFAULT NULL,
  `idFactura` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de la taula `facturas`
--

CREATE TABLE `facturas` (
  `id` int(11) NOT NULL,
  `idUsuari` int(11) DEFAULT NULL,
  `dateHour` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de la taula `llibres`
--

CREATE TABLE `llibres` (
  `id` int(11) NOT NULL,
  `editorial` varchar(30) DEFAULT NULL,
  `idAutor` int(11) NOT NULL,
  `titulo` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de la taula `usuaris`
--

CREATE TABLE `usuaris` (
  `id` int(11) NOT NULL,
  `nombre` varchar(40) DEFAULT NULL,
  `email` varchar(40) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Índexs per a les taules bolcades
--

--
-- Índexs per a la taula `autors`
--
ALTER TABLE `autors`
  ADD PRIMARY KEY (`id`);

--
-- Índexs per a la taula `detalls`
--
ALTER TABLE `detalls`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idLlibre` (`idLlibre`),
  ADD KEY `idFactura` (`idFactura`);

--
-- Índexs per a la taula `facturas`
--
ALTER TABLE `facturas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idUsuari` (`idUsuari`);

--
-- Índexs per a la taula `llibres`
--
ALTER TABLE `llibres`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idAutor` (`idAutor`);

--
-- Índexs per a la taula `usuaris`
--
ALTER TABLE `usuaris`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT per les taules bolcades
--

--
-- AUTO_INCREMENT per la taula `autors`
--
ALTER TABLE `autors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT per la taula `detalls`
--
ALTER TABLE `detalls`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT per la taula `facturas`
--
ALTER TABLE `facturas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT per la taula `llibres`
--
ALTER TABLE `llibres`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT per la taula `usuaris`
--
ALTER TABLE `usuaris`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restriccions per a les taules bolcades
--

--
-- Restriccions per a la taula `detalls`
--
ALTER TABLE `detalls`
  ADD CONSTRAINT `detalls_ibfk_1` FOREIGN KEY (`idLlibre`) REFERENCES `llibres` (`id`),
  ADD CONSTRAINT `detalls_ibfk_2` FOREIGN KEY (`idFactura`) REFERENCES `facturas` (`id`);

--
-- Restriccions per a la taula `facturas`
--
ALTER TABLE `facturas`
  ADD CONSTRAINT `facturas_ibfk_1` FOREIGN KEY (`idUsuari`) REFERENCES `usuaris` (`id`);

--
-- Restriccions per a la taula `llibres`
--
ALTER TABLE `llibres`
  ADD CONSTRAINT `llibres_ibfk_1` FOREIGN KEY (`idAutor`) REFERENCES `autors` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
