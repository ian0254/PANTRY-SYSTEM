-- phpMyAdmin SQL Dump
-- version 4.2.7.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Sep 08, 2014 at 10:23 AM
-- Server version: 5.6.20
-- PHP Version: 5.5.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `db_pantry`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_acquireditems`
--

CREATE TABLE IF NOT EXISTS `tbl_acquireditems` (
  `employeename` text NOT NULL,
  `dateacquired` text NOT NULL,
  `duedate` text NOT NULL,
  `quantity` int(11) NOT NULL,
  `itemprice` int(11) NOT NULL,
  `totalprice` int(11) NOT NULL,
  `itemname` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_acquireditems`
--

INSERT INTO `tbl_acquireditems` (`employeename`, `dateacquired`, `duedate`, `quantity`, `itemprice`, `totalprice`, `itemname`) VALUES
('CONTRERAS, IAN JEROMEMARTIN', '9/8/2014', '9/11/2014', 1, 20, 20, 'xzxz'),
('CONTRERAS, IAN JEROMEMARTIN', '9/8/2014', '9/8/2014', 2, 6, 12, 'kopiko brown'),
('Contreras, ian jerome m.', '9/8/2014', '9/8/2014', 2, 1, 2, 'STICK O');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_employee`
--

CREATE TABLE IF NOT EXISTS `tbl_employee` (
`ID` int(11) NOT NULL,
  `Emp_lname` text NOT NULL,
  `Emp_fname` text NOT NULL,
  `Emp_mname` text NOT NULL,
  `Emp_number` text NOT NULL,
  `Emp_fullname` text NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=15 ;

--
-- Dumping data for table `tbl_employee`
--

INSERT INTO `tbl_employee` (`ID`, `Emp_lname`, `Emp_fname`, `Emp_mname`, `Emp_number`, `Emp_fullname`) VALUES
(14, 'Contreras', 'ian jerome', 'm.', '12345', 'Contreras, ian jerome m.');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_items`
--

CREATE TABLE IF NOT EXISTS `tbl_items` (
  `item_name` text NOT NULL,
  `item_price` int(255) NOT NULL,
  `item_cstock` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_items`
--

INSERT INTO `tbl_items` (`item_name`, `item_price`, `item_cstock`) VALUES
('xzxz', 20, ''),
('kopiko brown', 6, ''),
('GSHOCK', 22222, ''),
('STICK O', 1, '24');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_employee`
--
ALTER TABLE `tbl_employee`
 ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_employee`
--
ALTER TABLE `tbl_employee`
MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=15;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
