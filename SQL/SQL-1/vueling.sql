-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Temps de generació: 07-02-2020 a les 12:45:08
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
-- Base de dades: `vueling`
--

-- --------------------------------------------------------

--
-- Estructura de la taula `avions`
--

CREATE TABLE `avions` (
  `idavio` int(11) NOT NULL,
  `capacitat` int(11) NOT NULL,
  `model` varchar(50) DEFAULT NULL,
  `seients` int(11) DEFAULT NULL,
  `categoria` enum('small','medium','big') NOT NULL DEFAULT 'medium',
  `gruposAsientos` set('1','2','3','4','5','6','7','8') DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Bolcament de dades per a la taula `avions`
--

INSERT INTO `avions` (`idavio`, `capacitat`, `model`, `seients`, `categoria`, `gruposAsientos`) VALUES
(1, 300, 'BOING 747', 250, 'medium', '2,3,4,8'),
(2, 400, 'Concorde', 350, 'big', '4,6,8'),
(3, 887, 'AIRBUS A380 ', 600, 'big', '2,3,4,8'),
(4, 26, 'Bombardier XP', 20, 'small', '1,2,3'),
(5, 20, 'Bombardier XPS ', 16, 'small', '1,2');

--
-- Índexs per a les taules bolcades
--

--
-- Índexs per a la taula `avions`
--
ALTER TABLE `avions`
  ADD PRIMARY KEY (`idavio`);

--
-- AUTO_INCREMENT per les taules bolcades
--

--
-- AUTO_INCREMENT per la taula `avions`
--
ALTER TABLE `avions`
  MODIFY `idavio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
