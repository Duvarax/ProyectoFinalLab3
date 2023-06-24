-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 25-06-2023 a las 00:53:02
-- Versión del servidor: 10.4.27-MariaDB
-- Versión de PHP: 8.0.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `gameraskdb`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `comentarios`
--

CREATE TABLE `comentarios` (
  `Id` int(11) NOT NULL,
  `Texto` varchar(200) NOT NULL,
  `fechaCreacion` datetime NOT NULL,
  `id_respuesta` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `juegos`
--

CREATE TABLE `juegos` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(45) NOT NULL,
  `Portada` varchar(150) NOT NULL,
  `Descripcion` varchar(200) NOT NULL,
  `Autor` varchar(45) NOT NULL,
  `fechaLanzamiento` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `juegos`
--

INSERT INTO `juegos` (`Id`, `Nombre`, `Portada`, `Descripcion`, `Autor`, `fechaLanzamiento`) VALUES
(115, 'League of Legends', 'https://images.igdb.com/igdb/image/upload/t_cover_big/co49wj.jpg', 'League of Legends is a fast-paced, competitive online game that blends the speed and intensity of an RTS with RPG elements. Two teams of powerful champions, each with a unique design and playstyle, ba', 'GOA Games Services Ltd.', '1970-01-15 00:00:00'),
(142, 'Star Wars: Battlefront II', 'https://images.igdb.com/igdb/image/upload/t_cover_big/co1nsg.jpg', 'Star Wars: Battlefront II is the sequel to Star Wars: Battlefront. It is a high-selling Star Wars video game following the many adventures of several characters. The two games are very similar, as bot', 'Pandemic Studios', '1970-01-14 00:00:00'),
(1372, 'Counter-Strike: Global Offensive', 'https://images.igdb.com/igdb/image/upload/t_cover_big/co6996.jpg', 'Counter-Strike: Global Offensive expands upon the team-based action gameplay that it pioneered when it was launched 19 years ago. CS: GO features new maps, characters, weapons, and game modes, and del', 'Hidden Path Entertainment', '1970-01-16 00:00:00'),
(2254, 'Dragon Ball Z: Budokai Tenkaichi 3', 'https://images.igdb.com/igdb/image/upload/t_cover_big/co3r52.jpg', 'Budokai Tenkaichi 3 is a 1vs1 fighting game based on the anime/manga Dragon Ball by Akira Toriyama. It includes the apocalyptic battles and the essence of the Dragon Ball series following the main sto', 'Spike', '1970-01-14 00:00:00'),
(84920, 'Super Mario All-Stars: Limited Edition', 'https://images.igdb.com/igdb/image/upload/t_cover_big/co2vvc.jpg', 'Super Mario All-Stars Limited Edition is a Mario special edition pack for the Wii released as a Wii emulation of the SNES game Super Mario All-Stars. The game is a tribute to the 25th anniversary of S', 'Nintendo', '1970-01-15 00:00:00'),
(126459, 'Valorant', 'https://images.igdb.com/igdb/image/upload/t_cover_big/co2mvt.jpg', 'Valorant is a character-based 5v5 tactical shooter set on the global stage. Outwit, outplay, and outshine your competition with tactical abilities, precise gunplay, and adaptive teamwork.', 'Riot Games', '1970-01-19 00:00:00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `preguntas`
--

CREATE TABLE `preguntas` (
  `Id` int(11) NOT NULL,
  `Texto` varchar(200) NOT NULL,
  `fechaCreacion` datetime NOT NULL,
  `id_usuario` int(11) NOT NULL,
  `Captura` varchar(200) DEFAULT NULL,
  `id_juego` int(11) NOT NULL,
  `publicIdCaptura` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `recientes`
--

CREATE TABLE `recientes` (
  `id_usuario` int(11) NOT NULL,
  `id_juego` int(11) NOT NULL,
  `Id` int(11) NOT NULL,
  `cantidad` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `recientes`
--

INSERT INTO `recientes` (`id_usuario`, `id_juego`, `Id`, `cantidad`) VALUES
(1, 115, 3, 2),
(1, 2254, 4, 1),
(1, 142, 5, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `respuestas`
--

CREATE TABLE `respuestas` (
  `Id` int(11) NOT NULL,
  `Texto` varchar(200) NOT NULL,
  `fechaCreacion` datetime NOT NULL,
  `id_pregunta` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(45) NOT NULL,
  `Apellido` varchar(45) NOT NULL,
  `NombreUsuario` varchar(45) NOT NULL,
  `Email` varchar(45) NOT NULL,
  `Clave` varchar(150) NOT NULL,
  `Imagen` varchar(500) DEFAULT NULL,
  `Portada` varchar(500) DEFAULT NULL,
  `publicIdImagen` varchar(50) DEFAULT NULL,
  `publicIdPortada` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`Id`, `Nombre`, `Apellido`, `NombreUsuario`, `Email`, `Clave`, `Imagen`, `Portada`, `publicIdImagen`, `publicIdPortada`) VALUES
(1, 'Javier', 'Duvara', 'Duvarax', 'duvara@gmail.com', 'QoAY4q9t5kcEdi8Wk8txbdGar9eutN/uZiErmXORarY=', 'http://res.cloudinary.com/dhg4fafod/image/upload/v1686865615/gamerask_/c1i0fg0e3zqjkz9f5tm5.jpg', 'http://res.cloudinary.com/dhg4fafod/image/upload/v1686801839/gamerask_/cdxf0g7qihql5v1vsuo8.jpg', 'gamerask_/c1i0fg0e3zqjkz9f5tm5', 'gamerask_/cdxf0g7qihql5v1vsuo8'),
(3, 'laura', 'albornoz', 'laurinha', 'laura@gmail.com', 'QoAY4q9t5kcEdi8Wk8txbdGar9eutN/uZiErmXORarY=', NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `valoraciones`
--

CREATE TABLE `valoraciones` (
  `Id` int(11) NOT NULL,
  `id_respuesta` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `comentarios`
--
ALTER TABLE `comentarios`
  ADD PRIMARY KEY (`Id`,`id_respuesta`,`id_usuario`),
  ADD KEY `id_respuesta` (`id_respuesta`),
  ADD KEY `id_usuario` (`id_usuario`);

--
-- Indices de la tabla `juegos`
--
ALTER TABLE `juegos`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `preguntas`
--
ALTER TABLE `preguntas`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `id_usuario` (`id_usuario`,`id_juego`),
  ADD KEY `id_usuario_2` (`id_usuario`,`id_juego`),
  ADD KEY `id_juego` (`id_juego`);

--
-- Indices de la tabla `recientes`
--
ALTER TABLE `recientes`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `id_usuario` (`id_usuario`),
  ADD KEY `id_juego` (`id_juego`);

--
-- Indices de la tabla `respuestas`
--
ALTER TABLE `respuestas`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `id_pregunta` (`id_pregunta`,`id_usuario`),
  ADD KEY `id_usuario` (`id_usuario`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `valoraciones`
--
ALTER TABLE `valoraciones`
  ADD PRIMARY KEY (`Id`,`id_respuesta`,`id_usuario`),
  ADD KEY `id_respuesta` (`id_respuesta`),
  ADD KEY `id_usuario` (`id_usuario`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `comentarios`
--
ALTER TABLE `comentarios`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `juegos`
--
ALTER TABLE `juegos`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=126460;

--
-- AUTO_INCREMENT de la tabla `preguntas`
--
ALTER TABLE `preguntas`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT de la tabla `recientes`
--
ALTER TABLE `recientes`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `respuestas`
--
ALTER TABLE `respuestas`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `valoraciones`
--
ALTER TABLE `valoraciones`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `comentarios`
--
ALTER TABLE `comentarios`
  ADD CONSTRAINT `comentarios_ibfk_1` FOREIGN KEY (`id_respuesta`) REFERENCES `respuestas` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `comentarios_ibfk_2` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `preguntas`
--
ALTER TABLE `preguntas`
  ADD CONSTRAINT `preguntas_ibfk_1` FOREIGN KEY (`id_juego`) REFERENCES `juegos` (`Id`),
  ADD CONSTRAINT `preguntas_ibfk_2` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `recientes`
--
ALTER TABLE `recientes`
  ADD CONSTRAINT `recientes_ibfk_1` FOREIGN KEY (`id_juego`) REFERENCES `juegos` (`Id`),
  ADD CONSTRAINT `recientes_ibfk_2` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `respuestas`
--
ALTER TABLE `respuestas`
  ADD CONSTRAINT `respuestas_ibfk_1` FOREIGN KEY (`id_pregunta`) REFERENCES `preguntas` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `respuestas_ibfk_2` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `valoraciones`
--
ALTER TABLE `valoraciones`
  ADD CONSTRAINT `valoraciones_ibfk_1` FOREIGN KEY (`id_respuesta`) REFERENCES `respuestas` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `valoraciones_ibfk_2` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
