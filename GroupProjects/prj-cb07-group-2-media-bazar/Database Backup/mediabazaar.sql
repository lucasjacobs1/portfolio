-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 22, 2022 at 04:24 PM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 7.4.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `mediabazaar`
--

-- --------------------------------------------------------

--
-- Table structure for table `absence_employee`
--

CREATE TABLE `absence_employee` (
  `id` int(11) NOT NULL,
  `employee_id` int(11) NOT NULL,
  `date` date NOT NULL,
  `reason` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `absence_employee`
--

INSERT INTO `absence_employee` (`id`, `employee_id`, `date`, `reason`) VALUES
(8, 1, '2022-05-12', 'Im sick on this day'),
(9, 1, '2022-05-13', 'Im sick on this day');

-- --------------------------------------------------------

--
-- Table structure for table `absence_vacation`
--

CREATE TABLE `absence_vacation` (
  `id` int(11) NOT NULL,
  `employee_id` int(11) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL,
  `Reason` varchar(200) NOT NULL DEFAULT 'Holiday',
  `pending` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `absence_vacation`
--

INSERT INTO `absence_vacation` (`id`, `employee_id`, `start_date`, `end_date`, `Reason`, `pending`) VALUES
(0, 1, '2022-05-04', '2022-05-18', 'nice week offfffffff', 0),
(0, 1, '2022-05-12', '2022-05-19', 'Vacation boysssss', 0);

-- --------------------------------------------------------

--
-- Table structure for table `acceptedreshelfrequest`
--

CREATE TABLE `acceptedreshelfrequest` (
  `id` int(11) NOT NULL,
  `productid` int(11) NOT NULL,
  `message` text DEFAULT NULL,
  `sender` varchar(50) NOT NULL,
  `datesent` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `acceptedreshelfrequest`
--

INSERT INTO `acceptedreshelfrequest` (`id`, `productid`, `message`, `sender`, `datesent`) VALUES
(1, 1, 'please refill this one, thanks! :)', 'Christan', '2022-06-17 09:23:46'),
(2, 2, 'yeah i broke quite a few, sorry', 'Ronaldo', '2022-06-22 09:23:50'),
(4, 8, 'I want to play games for myself!', 'Tom', '2022-06-14 11:38:22');

-- --------------------------------------------------------

--
-- Table structure for table `complaints`
--

CREATE TABLE `complaints` (
  `id` int(11) NOT NULL,
  `complainerID` int(11) NOT NULL DEFAULT -1,
  `receiverID` int(11) NOT NULL DEFAULT -1,
  `topic` varchar(50) NOT NULL,
  `complain` varchar(50) NOT NULL,
  `anonymous` int(11) NOT NULL DEFAULT 0,
  `toALL` int(11) NOT NULL DEFAULT 0,
  `solved` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `complaints`
--

INSERT INTO `complaints` (`id`, `complainerID`, `receiverID`, `topic`, `complain`, `anonymous`, `toALL`, `solved`) VALUES
(1, 1, 3, 'Brexit', 'Test Complain', 1, 0, 0),
(2, 2, 1, 'Next try', 'trstgsgdfgdfgdfgdf', 0, 0, 1),
(3, 2, 1, 'TestToPerson1', 'TestToPerson1', 0, 0, 0),
(4, 2, 1, 'TestToPerson2', 'TestToPerson2', 1, 0, 1),
(6, 2, 1, 'Tester123', 'tester123', 1, 1, 0),
(7, 2, 3, 'LIVE TEST', 'Live test', 0, 0, 0),
(8, 2, 3, 'LIVE TEST1', 'Live test1', 1, 0, 0),
(9, 2, 1, 'LIVE TEST2', 'Live test2', 0, 1, 1),
(10, 2, 3, 'LIVE TEST3', 'Live test3', 0, 0, 0),
(11, 9, 3, 'Testing', 'test', 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `contact_person`
--

CREATE TABLE `contact_person` (
  `id` int(11) NOT NULL,
  `employee_id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `phone` int(50) NOT NULL,
  `email` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `contact_person`
--

INSERT INTO `contact_person` (`id`, `employee_id`, `name`, `phone`, `email`) VALUES
(1, 1, 'HEnk', 6879587, 'lana@gmail.com'),
(3, 7, 'HEnk', 6879587, 'lana@gmail.com'),
(4, 3, 'HEnk', 6879587, 'lana@gmail.com'),
(5, 2, 'HEnk', 6879587, 'lana@gmail.com'),
(6, 12, 'HEnk', 6879587, 'lana@gmail.com'),
(7, 9, 'HEnk', 6879587, 'lana@gmail.com'),
(8, 11, 'HEnk', 6879587, 'lana@gmail.com');

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `id` int(50) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `street` varchar(50) NOT NULL,
  `city` varchar(50) NOT NULL,
  `housenumber` varchar(50) NOT NULL,
  `postalcode` varchar(50) NOT NULL,
  `salary` double NOT NULL,
  `bsn` int(11) NOT NULL,
  `phone` int(11) NOT NULL,
  `fte` double NOT NULL,
  `role` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`id`, `first_name`, `last_name`, `email`, `password`, `street`, `city`, `housenumber`, `postalcode`, `salary`, `bsn`, `phone`, `fte`, `role`) VALUES
(1, 'Alex', 'Vartic', 'alex@mediabazaar.com', '098f6bcd4621d373cade4e832627b4f6', 'Rachelsmolen ', 'Eindhoven', '10', '4675FG', 255, 324524354, 612345678, 0, 0),
(2, 'Johnny', 'Sins', 'johnny@mediabazaar.com', '098f6bcd4621d373cade4e832627b4f6', 'Red Light Street', 'Eindhoven', '113', '5674SD', 32, 232454, 354245243, 0, 4),
(3, 'John ', 'McClain', 'john@mediabazaar.com', '098f6bcd4621d373cade4e832627b4f6', 'Plaza ', 'Eindhoven', '1', '6545AS', 23, 232454, 5312315, 0, 2),
(7, 'Emily ', 'Ratajkowski', 'emily@mediabazaar.com', '098f6bcd4621d373cade4e832627b4f6', 'Hofstreet', 'Eindhoven', '34', '5643AS', 34, 3435, 34, 0, 4),
(9, 'Metodi ', 'Tarnev', 'metodi@mediabazaar.com', '098f6bcd4621d373cade4e832627b4f6', 'Wattstraat ', 'Eindhoven', '35', '3456FD', 35, 134244, 324234, 0, 3),
(11, 'Michael ', 'Doe', 'michael@mediabazaar.com', '098f6bcd4621d373cade4e832627b4f6', 'Teststraat ', 'Eindhoven', '3', '6543SD', 35, 25443, 23533, 0, 3),
(12, 'Makaela ', 'Dominos', 'makaela@mediabazaar.com', '098f6bcd4621d373cade4e832627b4f6', 'Makaelastraat ', 'Eindhoven', '36', '5676SD', 35, 34545, 33323, 0, 4);

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `id` int(11) NOT NULL,
  `name` varchar(60) NOT NULL,
  `description` text NOT NULL,
  `price` double NOT NULL,
  `amountinstock` int(11) NOT NULL DEFAULT 0,
  `amountsold` int(11) NOT NULL DEFAULT 0,
  `barcode` varchar(13) NOT NULL,
  `weight` float NOT NULL,
  `height` float NOT NULL,
  `length` float NOT NULL,
  `width` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`id`, `name`, `description`, `price`, `amountinstock`, `amountsold`, `barcode`, `weight`, `height`, `length`, `width`) VALUES
(1, 'JBL Bluetooth Speaker', 'A smooth JBL bluetooth speaker with bass-boost.', 40, 100, 0, '9876565645687', 10, 5, 10, 5),
(2, 'Samsung TV', 'ful ultra 12k max pro', 500, 503, 0, '5693245697521', 50, 50, 70, 5),
(3, 'Philips HeadPhones', 'White Bass-Boosted headphones', 20, 550, 0, '9651357465211', 1, 5, 3, 2),
(8, 'Lenovo PC', 'Fast gaming pc', 800, 50, 0, '', 5, 1, 10, 15);

-- --------------------------------------------------------

--
-- Table structure for table `register_keys`
--

CREATE TABLE `register_keys` (
  `id` int(11) NOT NULL,
  `register_key` varchar(32) NOT NULL,
  `used_by` varchar(50) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `register_keys`
--

INSERT INTO `register_keys` (`id`, `register_key`, `used_by`) VALUES
(3, 'C8K3S8kDmPuPp5KAoo2zfPOb1JZKQWM2', 'Michael Doe'),
(4, 'bqotlXsesAnTWZZMBWROJ1idIs7LCXQK', 'Emily Ratajkowski'),
(5, 'QTouaS2nt8LIF15hyOXHB8OKst54oB2w', 'Metodi Tarnev'),
(6, 'Zcb71JduZ9ayxlbpDOLOYEEm79xwskM1', 'Daniel Hawker'),
(7, 'ornbMyqHheRMAwcDl7kU1Sv2EqRm8kRn', 'Makaela Dominos'),
(8, 'sZ0ZdMBFQZNqN8SyD5J3mG1jwpIXKnPC', '0');

-- --------------------------------------------------------

--
-- Table structure for table `rejectedreshelfrequest`
--

CREATE TABLE `rejectedreshelfrequest` (
  `id` int(11) NOT NULL,
  `productid` int(11) NOT NULL,
  `message` text NOT NULL,
  `reason` varchar(100) NOT NULL,
  `sender` varchar(50) NOT NULL,
  `datesent` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `rejectedreshelfrequest`
--

INSERT INTO `rejectedreshelfrequest` (`id`, `productid`, `message`, `reason`, `sender`, `datesent`) VALUES
(1, 3, 'Took a few home with me, so we\'ll need new ones!', 'no stealing allowed, you know...', 'Mike', '2022-06-15 09:24:39');

-- --------------------------------------------------------

--
-- Table structure for table `requestupdateempolyee`
--

CREATE TABLE `requestupdateempolyee` (
  `id` int(11) NOT NULL,
  `employee_id` int(11) NOT NULL,
  `email` varchar(50) NOT NULL,
  `street` varchar(50) NOT NULL,
  `city` varchar(50) NOT NULL,
  `postalcode` varchar(50) NOT NULL,
  `housenumber` varchar(50) NOT NULL,
  `phone` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `requestupdateempolyee`
--

INSERT INTO `requestupdateempolyee` (`id`, `employee_id`, `email`, `street`, `city`, `postalcode`, `housenumber`, `phone`) VALUES
(32, 1, 'alex@mediabazaar.com', 'Rachelsmolen ', 'Maastricht', '4675FG', '10', 612345678);

-- --------------------------------------------------------

--
-- Table structure for table `reshelfrequest`
--

CREATE TABLE `reshelfrequest` (
  `id` int(11) NOT NULL,
  `productid` int(11) NOT NULL,
  `message` text DEFAULT NULL,
  `sender` varchar(50) NOT NULL,
  `datesent` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `roles`
--

CREATE TABLE `roles` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `roles`
--

INSERT INTO `roles` (`id`, `name`) VALUES
(0, 'Administrator'),
(1, 'Manager'),
(2, 'HR Manager'),
(3, 'Store Employee'),
(4, 'Depot Employee');

-- --------------------------------------------------------

--
-- Table structure for table `schedule`
--

CREATE TABLE `schedule` (
  `id` int(11) NOT NULL,
  `EmployeeName` varchar(50) NOT NULL,
  `shiftDate` text NOT NULL,
  `shiftType` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `schedule`
--

INSERT INTO `schedule` (`id`, `EmployeeName`, `shiftDate`, `shiftType`) VALUES
(1, '0', '16/3/2022', 'Afternoon'),
(2, 'John McClain', '17/3/2022', 'Evening'),
(3, 'John McClain', '17/3/2022', 'Morning'),
(5, 'Johnny Sins', '17/3/2022', 'Afternoon'),
(7, 'John McClain', '18/3/2022', 'Afternoon'),
(8, 'Johnny Sins', '24/3/2022', 'Morning'),
(9, 'Johnny Sins', '8/4/2022', 'Morning'),
(10, 'John McClain', '8/4/2022', 'Evening'),
(11, 'Johnny Sins', '20/3/2022', 'Evening'),
(13, 'John McClain', '17/3/2022', 'Afternoon'),
(14, 'Emily Ratajkowski', '10/3/2022', 'Afternoon'),
(15, 'Alex', '19/3/2022', 'Morning'),
(17, 'John ', '11/3/2022', 'Afternoon'),
(18, 'John ', '9/5/2022', 'Morning'),
(19, 'Metodi ', '9/5/2022', 'Morning'),
(20, 'Makaela ', '9/5/2022', 'Morning'),
(21, 'Michael ', '9/5/2022', 'Morning');

-- --------------------------------------------------------

--
-- Table structure for table `unapproved_employee`
--

CREATE TABLE `unapproved_employee` (
  `id` int(50) NOT NULL,
  `name` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `address` varchar(50) NOT NULL,
  `salary` double NOT NULL,
  `bsn` int(11) NOT NULL,
  `phone` int(11) NOT NULL,
  `role` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `absence_employee`
--
ALTER TABLE `absence_employee`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `acceptedreshelfrequest`
--
ALTER TABLE `acceptedreshelfrequest`
  ADD PRIMARY KEY (`id`),
  ADD KEY `productid` (`productid`);

--
-- Indexes for table `complaints`
--
ALTER TABLE `complaints`
  ADD PRIMARY KEY (`id`),
  ADD KEY `complainerID` (`complainerID`),
  ADD KEY `receiverID` (`receiverID`);

--
-- Indexes for table `contact_person`
--
ALTER TABLE `contact_person`
  ADD PRIMARY KEY (`id`),
  ADD KEY `employee_id` (`employee_id`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`id`),
  ADD KEY `role` (`role`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `register_keys`
--
ALTER TABLE `register_keys`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `rejectedreshelfrequest`
--
ALTER TABLE `rejectedreshelfrequest`
  ADD PRIMARY KEY (`id`),
  ADD KEY `productid` (`productid`);

--
-- Indexes for table `requestupdateempolyee`
--
ALTER TABLE `requestupdateempolyee`
  ADD PRIMARY KEY (`id`),
  ADD KEY `requestupdateempolyee_ibfk_1` (`employee_id`);

--
-- Indexes for table `reshelfrequest`
--
ALTER TABLE `reshelfrequest`
  ADD PRIMARY KEY (`id`),
  ADD KEY `productid` (`productid`);

--
-- Indexes for table `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `schedule`
--
ALTER TABLE `schedule`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `unapproved_employee`
--
ALTER TABLE `unapproved_employee`
  ADD PRIMARY KEY (`id`),
  ADD KEY `role` (`role`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `absence_employee`
--
ALTER TABLE `absence_employee`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `acceptedreshelfrequest`
--
ALTER TABLE `acceptedreshelfrequest`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `complaints`
--
ALTER TABLE `complaints`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `contact_person`
--
ALTER TABLE `contact_person`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `employee`
--
ALTER TABLE `employee`
  MODIFY `id` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `product`
--
ALTER TABLE `product`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `register_keys`
--
ALTER TABLE `register_keys`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `rejectedreshelfrequest`
--
ALTER TABLE `rejectedreshelfrequest`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `requestupdateempolyee`
--
ALTER TABLE `requestupdateempolyee`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT for table `reshelfrequest`
--
ALTER TABLE `reshelfrequest`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `roles`
--
ALTER TABLE `roles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `schedule`
--
ALTER TABLE `schedule`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT for table `unapproved_employee`
--
ALTER TABLE `unapproved_employee`
  MODIFY `id` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `acceptedreshelfrequest`
--
ALTER TABLE `acceptedreshelfrequest`
  ADD CONSTRAINT `acceptedreshelfrequest_ibfk_1` FOREIGN KEY (`productid`) REFERENCES `product` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `complaints`
--
ALTER TABLE `complaints`
  ADD CONSTRAINT `complaints_ibfk_1` FOREIGN KEY (`complainerID`) REFERENCES `employee` (`id`),
  ADD CONSTRAINT `complaints_ibfk_2` FOREIGN KEY (`receiverID`) REFERENCES `employee` (`id`);

--
-- Constraints for table `contact_person`
--
ALTER TABLE `contact_person`
  ADD CONSTRAINT `contact_person_ibfk_1` FOREIGN KEY (`employee_id`) REFERENCES `employee` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `employee`
--
ALTER TABLE `employee`
  ADD CONSTRAINT `employee_ibfk_1` FOREIGN KEY (`role`) REFERENCES `roles` (`id`);

--
-- Constraints for table `rejectedreshelfrequest`
--
ALTER TABLE `rejectedreshelfrequest`
  ADD CONSTRAINT `rejectedreshelfrequest_ibfk_1` FOREIGN KEY (`productid`) REFERENCES `product` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `reshelfrequest`
--
ALTER TABLE `reshelfrequest`
  ADD CONSTRAINT `reshelfrequest_ibfk_1` FOREIGN KEY (`productid`) REFERENCES `product` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
