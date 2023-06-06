-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 07-06-2023 a las 00:23:38
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
-- Base de datos: `forogamesdb`
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
(84920, 'Super Mario All-Stars: Limited Edition', 'https://images.igdb.com/igdb/image/upload/t_cover_big/co2vvc.jpg', 'Super Mario All-Stars Limited Edition is a Mario special edition pack for the Wii released as a Wii emulation of the SNES game Super Mario All-Stars. The game is a tribute to the 25th anniversary of S', 'Nintendo', '1970-01-15 00:00:00');

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
  `id_juego` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `preguntas`
--

INSERT INTO `preguntas` (`Id`, `Texto`, `fechaCreacion`, `id_usuario`, `Captura`, `id_juego`) VALUES
(1, 'Como pasar x nivel?', '2012-04-23 18:25:43', 1, 'https://images.igdb.com/igdb/image/upload/t_cover_big/co2vvc.jpg', 84920),
(2, 'Como derrotar a x?', '2023-06-06 21:33:51', 1, NULL, 84920);

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

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `respuestas`
--

CREATE TABLE `respuestas` (
  `Id` int(11) NOT NULL,
  `Texto` varchar(200) NOT NULL,
  `fechaCreacion` datetime NOT NULL,
  `id_pregunta` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL,
  `captura` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `respuestas`
--

INSERT INTO `respuestas` (`Id`, `Texto`, `fechaCreacion`, `id_pregunta`, `id_usuario`, `captura`) VALUES
(1, 'Jugando bien', '2023-06-03 21:43:29', 1, 1, NULL),
(3, 'Como x arma', '2023-06-06 21:34:26', 2, 1, NULL),
(4, 'Con paciencia', '2023-06-06 21:40:11', 1, 1, NULL),
(5, 'No se', '2023-06-06 22:24:30', 1, 1, NULL);

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
  `Imagen` varchar(150) DEFAULT NULL,
  `Portada` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`Id`, `Nombre`, `Apellido`, `NombreUsuario`, `Email`, `Clave`, `Imagen`, `Portada`) VALUES
(1, 'Claudio', 'Duvara', 'Duvarax', 'duvara@gmail.com', 'QoAY4q9t5kcEdi8Wk8txbdGar9eutN/uZiErmXORarY=', NULL, NULL);

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
-- Volcado de datos para la tabla `valoraciones`
--

INSERT INTO `valoraciones` (`Id`, `id_respuesta`, `id_usuario`) VALUES
(1, 1, 1),
(2, 1, 1),
(3, 1, 1),
(4, 4, 1),
(5, 5, 1),
(6, 5, 1);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `comentarios`
--
ALTER TABLE `comentarios`
  ADD PRIMARY KEY (`Id`,`id_respuesta`,`id_usuario`),
  ADD KEY `fk_comentarios_respuestas1` (`id_respuesta`),
  ADD KEY `fk_comentarios_usuarios2` (`id_usuario`);

--
-- Indices de la tabla `juegos`
--
ALTER TABLE `juegos`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `preguntas`
--
ALTER TABLE `preguntas`
  ADD PRIMARY KEY (`Id`,`id_usuario`,`id_juego`),
  ADD KEY `fk_reseñas_usuarios1` (`id_usuario`),
  ADD KEY `fk_preguntas_juegos1` (`id_juego`);

--
-- Indices de la tabla `recientes`
--
ALTER TABLE `recientes`
  ADD PRIMARY KEY (`id_usuario`,`id_juego`,`Id`),
  ADD KEY `fk_usuarios_has_juegos_juegos1` (`id_juego`);

--
-- Indices de la tabla `respuestas`
--
ALTER TABLE `respuestas`
  ADD PRIMARY KEY (`Id`,`id_pregunta`,`id_usuario`),
  ADD KEY `fk_comentarios_reseñas1` (`id_pregunta`),
  ADD KEY `fk_comentarios_usuarios1` (`id_usuario`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `valoraciones`
--
ALTER TABLE `valoraciones`
  ADD PRIMARY KEY (`Id`,`id_respuesta`),
  ADD KEY `fk_valoraciones_respuestas1` (`id_respuesta`),
  ADD KEY `indice` (`id_usuario`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `preguntas`
--
ALTER TABLE `preguntas`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `respuestas`
--
ALTER TABLE `respuestas`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `valoraciones`
--
ALTER TABLE `valoraciones`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
