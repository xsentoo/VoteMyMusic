-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : mer. 25 déc. 2024 à 19:42
-- Version du serveur : 10.4.32-MariaDB
-- Version de PHP : 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `votemymusic`
--

-- --------------------------------------------------------

--
-- Structure de la table `musics`
--

CREATE TABLE `musics` (
  `MusicID` int(11) NOT NULL,
  `Title` varchar(255) NOT NULL,
  `Link` varchar(255) NOT NULL,
  `Username` varchar(255) NOT NULL,
  `Votes` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `musics`
--

INSERT INTO `musics` (`MusicID`, `Title`, `Link`, `Username`, `Votes`) VALUES
(1, 'lala', 'vic', 'sen', 1),
(3, 'vico', 'pa', 'sen', 0),
(4, 'rajju', 'ill', 'sen', 0),
(5, 'add', 'music', 'sen', 1),
(6, 'hugo', 'hi', 'sen', 0),
(7, 'lololo', 'hohoho', 'vote', 2),
(8, 'opo', 'pop', 'sen', 1);

-- --------------------------------------------------------

--
-- Structure de la table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `date_created` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `date_created`) VALUES
(1, 'sen', '12', '2024-11-29 20:15:00'),
(2, 'victor', '0', '2024-11-29 20:19:09'),
(3, 'raju', '0', '2024-12-09 18:12:28'),
(4, 'rajuss', 'raju12@', '2024-12-09 18:16:47'),
(5, 'vote', 'music', '2024-12-25 17:51:04');

-- --------------------------------------------------------

--
-- Structure de la table `votes`
--

CREATE TABLE `votes` (
  `Id` int(11) NOT NULL,
  `Username` varchar(255) NOT NULL,
  `Title` varchar(255) NOT NULL,
  `VoteDate` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `votes`
--

INSERT INTO `votes` (`Id`, `Username`, `Title`, `VoteDate`) VALUES
(1, 'sen', 'lala', '2024-12-25 18:18:22'),
(2, 'sen', 'vico', '2024-12-25 18:18:26'),
(3, 'sen', 'lololo', '2024-12-25 18:21:01'),
(4, 'sen', 'add', '2024-12-25 18:27:58'),
(5, 'sen', 'opo', '2024-12-25 18:28:07'),
(6, 'vote', 'lala', '2024-12-25 18:35:38'),
(7, 'vote', 'lololo', '2024-12-25 18:35:44');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `musics`
--
ALTER TABLE `musics`
  ADD PRIMARY KEY (`MusicID`),
  ADD UNIQUE KEY `Title` (`Title`);

--
-- Index pour la table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- Index pour la table `votes`
--
ALTER TABLE `votes`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Username` (`Username`,`Title`),
  ADD KEY `Title` (`Title`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `musics`
--
ALTER TABLE `musics`
  MODIFY `MusicID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT pour la table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT pour la table `votes`
--
ALTER TABLE `votes`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `votes`
--
ALTER TABLE `votes`
  ADD CONSTRAINT `votes_ibfk_1` FOREIGN KEY (`Username`) REFERENCES `users` (`username`) ON DELETE CASCADE,
  ADD CONSTRAINT `votes_ibfk_2` FOREIGN KEY (`Title`) REFERENCES `musics` (`Title`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
