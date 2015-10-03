-- --------------------------------------------------------
-- Host:                         localhost
-- Server version:               5.6.26 - MySQL Community Server (GPL)
-- Server OS:                    Win32
-- HeidiSQL Version:             9.3.0.4984
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Dumping database structure for shopping_cart
CREATE DATABASE IF NOT EXISTS `shopping_cart` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `shopping_cart`;


-- Dumping structure for table shopping_cart.categories
CREATE TABLE IF NOT EXISTS `categories` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Dumping data for table shopping_cart.categories: ~8 rows (approximately)
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
REPLACE INTO `categories` (`id`, `name`) VALUES
	(1, 'books'),
	(2, 'electronics'),
	(3, 'cars'),
	(4, 'fashion'),
	(5, 'hobby'),
	(6, 'services'),
	(7, 'work'),
	(8, 'properties');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;


-- Dumping structure for table shopping_cart.products
CREATE TABLE IF NOT EXISTS `products` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `description` text COLLATE utf8_unicode_ci NOT NULL,
  `price` decimal(10,0) NOT NULL,
  `quantity` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Dumping data for table shopping_cart.products: ~9 rows (approximately)
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
REPLACE INTO `products` (`id`, `name`, `description`, `price`, `quantity`) VALUES
	(1, 'BMW е46', 'пълна скраб', 1, 0),
	(2, 'Opel Vectra', 'чисто нова', 1111, 1),
	(3, 'Audi A4', 'бива', 999, 1),
	(4, 'Golf', 'от Перник!!!', 1234, 1),
	(5, 'mac', 'brand old', 2456, 18),
	(6, 'lenovo', 'slow one', 324, 5),
	(7, 'nakov', 'good book', 10, 10000),
	(8, 'game of thrones', 'your favourite character dies', 21, 17),
	(9, 'bmw e36', 'best car', 2312, 1);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;


-- Dumping structure for table shopping_cart.products_categories
CREATE TABLE IF NOT EXISTS `products_categories` (
  `productId` int(11) NOT NULL,
  `categoryId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Dumping data for table shopping_cart.products_categories: ~9 rows (approximately)
/*!40000 ALTER TABLE `products_categories` DISABLE KEYS */;
REPLACE INTO `products_categories` (`productId`, `categoryId`) VALUES
	(1, 3),
	(2, 3),
	(3, 3),
	(4, 3),
	(5, 2),
	(6, 2),
	(7, 1),
	(8, 1),
	(9, 3);
/*!40000 ALTER TABLE `products_categories` ENABLE KEYS */;


-- Dumping structure for table shopping_cart.promotions
CREATE TABLE IF NOT EXISTS `promotions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `productId` int(11) NOT NULL,
  `percentage` double NOT NULL,
  `endDate` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Dumping data for table shopping_cart.promotions: ~1 rows (approximately)
/*!40000 ALTER TABLE `promotions` DISABLE KEYS */;
REPLACE INTO `promotions` (`id`, `name`, `productId`, `percentage`, `endDate`) VALUES
	(1, 'Opel Vectra', 2, 13, '2015-06-10'),
	(2, 'Opel Vectra', 2, 13, '2015-12-12');
/*!40000 ALTER TABLE `promotions` ENABLE KEYS */;


-- Dumping structure for table shopping_cart.reviews
CREATE TABLE IF NOT EXISTS `reviews` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `message` text COLLATE utf8_unicode_ci NOT NULL,
  `userId` int(11) NOT NULL,
  `productId` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Dumping data for table shopping_cart.reviews: ~0 rows (approximately)
/*!40000 ALTER TABLE `reviews` DISABLE KEYS */;
REPLACE INTO `reviews` (`id`, `message`, `userId`, `productId`) VALUES
	(1, 'review edited', 1, 2);
/*!40000 ALTER TABLE `reviews` ENABLE KEYS */;


-- Dumping structure for table shopping_cart.users
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Cash` decimal(10,0) NOT NULL,
  `isAdmin` tinyint(4) NOT NULL DEFAULT '0',
  `isEditor` tinyint(11) NOT NULL DEFAULT '0',
  `isModerator` tinyint(4) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Dumping data for table shopping_cart.users: ~4 rows (approximately)
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
REPLACE INTO `users` (`id`, `username`, `password`, `Cash`, `isAdmin`, `isEditor`, `isModerator`) VALUES
	(1, 'ivzb', '$2y$10$4iSdqJDlxYkhsCWbwP7.q.RaC6EvODO/TpQ1gxxtua9f2MsEnzdcW', 9999, 1, 0, 0),
	(2, 'ivan', '$2y$10$XKdKHJ72MvighU1Q28FsJeke5Z3CehpGF0mKJjt1B83ItlITmX6w.', 10000, 0, 1, 0),
	(3, 'admin', '$2y$10$xEWf4B.Vklcb0CsAdG8glecungMCM0OMvJ3dD65ZOlJdpdSzAr8N.', 10000, 1, 0, 0),
	(4, 'test', '$2y$10$2reN.ppmfSlUjt3W7PpH0eXmxf4lGtx.ucC6vYzPTwUvaq62Xygnq', 10000, 0, 0, 0);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
