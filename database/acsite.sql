-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 12, 2019 at 10:33 PM
-- Server version: 10.4.6-MariaDB
-- PHP Version: 7.3.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `acsite`
--

-- --------------------------------------------------------

--
-- Table structure for table `assigned_quizzes`
--

CREATE TABLE `assigned_quizzes` (
  `id` int(11) NOT NULL,
  `quiz_id` int(11) NOT NULL,
  `assignee_id` int(11) NOT NULL,
  `submitted` int(1) NOT NULL DEFAULT 0,
  `assigned_on` timestamp NOT NULL DEFAULT current_timestamp(),
  `submitted_on` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `assigned_quizzes`
--

INSERT INTO `assigned_quizzes` (`id`, `quiz_id`, `assignee_id`, `submitted`, `assigned_on`, `submitted_on`) VALUES
(1, 14, 11, 1, '2019-11-19 19:16:50', '2019-11-19 19:18:53'),
(2, 32, 8, 0, '2019-12-01 05:00:00', '0000-00-00 00:00:00'),
(3, 32, 5, 0, '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(4, 32, 10, 0, '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(5, 32, 3, 0, '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(6, 33, 10, 0, '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(7, 33, 2, 0, '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(8, 32, 8, 0, '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(9, 1, 8, 0, '0000-00-00 00:00:00', '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `id` int(11) NOT NULL,
  `name` varchar(100) COLLATE utf8mb4_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`id`, `name`) VALUES
(1, 'Code of conduct'),
(2, 'Policy and Procedures'),
(3, 'Confidential reporting (whistle blowing)'),
(4, 'Internal investigation'),
(5, 'Internal controls'),
(6, 'Leadership and governance'),
(7, 'M&A, Joint venture & business associate due diligence'),
(8, 'Program testing and benchmarking'),
(9, 'Risk assessments'),
(10, 'Structuring an ethics, anti-corruption and compliance program'),
(11, 'Third party due diligence'),
(12, 'Conflict of interest'),
(13, 'Ethics and compliance red flags'),
(14, 'Preventing ethics, anti-corruption and other compliance failures'),
(15, 'Doing the right thing when facing ethical challenges'),
(16, 'Improving the organizational culture'),
(17, 'Business case for ethics & compliance'),
(18, 'Legal case for ethics and compliance');

-- --------------------------------------------------------

--
-- Table structure for table `censoredwords`
--

CREATE TABLE `censoredwords` (
  `id` int(11) NOT NULL,
  `word` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `censoredwords`
--

INSERT INTO `censoredwords` (`id`, `word`) VALUES
(1, 'fuck'),
(2, 'bitch');

-- --------------------------------------------------------

--
-- Table structure for table `industries`
--

CREATE TABLE `industries` (
  `id` int(11) NOT NULL,
  `name` varchar(100) COLLATE utf8mb4_bin NOT NULL,
  `active` int(1) NOT NULL DEFAULT 0,
  `submitted_by` int(11) NOT NULL,
  `submitted_on` timestamp NOT NULL DEFAULT current_timestamp(),
  `approved_by` int(11) NOT NULL,
  `approved_on` timestamp NULL DEFAULT NULL ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `industries`
--

INSERT INTO `industries` (`id`, `name`, `active`, `submitted_by`, `submitted_on`, `approved_by`, `approved_on`) VALUES
(1, 'Agriculture', 1, 11, '2019-11-25 06:08:05', 11, '2019-11-25 06:26:50'),
(2, 'Arms, defense & military', 1, 11, '2019-11-25 06:08:05', 11, '2019-11-25 06:27:20'),
(3, 'Banking & finance', 1, 11, '2019-11-25 06:08:05', 11, '2019-11-25 06:27:22'),
(4, 'Civilian aerospace', 1, 11, '2019-11-25 06:08:05', 11, '2019-11-25 06:27:28'),
(5, 'Consumer services', 1, 11, '2019-11-25 06:08:05', 11, '2019-11-25 06:27:30'),
(6, 'Fisheries', 1, 11, '2019-11-25 06:08:05', 11, '2019-11-25 06:27:32'),
(7, 'Forestry', 1, 11, '2019-11-25 06:08:05', 11, '2019-11-25 06:27:33'),
(8, 'Heavy manufacturing', 1, 11, '2019-11-25 06:08:05', 11, '2019-11-25 06:27:34'),
(9, 'Information technology', 1, 11, '2019-11-25 06:08:05', 11, '2019-11-25 06:27:36'),
(10, 'Light manufacturing', 1, 11, '2019-11-25 06:08:05', 11, '2019-11-25 06:27:19'),
(11, 'Oil and gas', 1, 11, '2019-11-25 06:08:05', 11, '2019-11-25 06:27:18'),
(12, 'Pharmaceutical & health care', 1, 11, '2019-11-25 06:08:05', 11, '2019-11-25 06:26:56'),
(13, 'Power generation & transmission', 1, 11, '2019-11-25 06:08:05', 11, '2019-11-25 06:27:08'),
(14, 'Public works & Construction', 1, 11, '2019-11-25 06:08:05', 11, '2019-11-25 06:27:09'),
(15, 'Real estate, property, legal and business services', 1, 11, '2019-11-25 06:08:05', 11, '2019-11-25 06:27:11'),
(16, 'Telecommunications', 1, 11, '2019-11-25 06:08:05', 11, '2019-11-25 06:27:12'),
(17, 'Transportation & storage', 1, 11, '2019-11-25 06:08:05', 11, '2019-11-25 06:27:14'),
(18, 'Utilities', 1, 11, '2019-11-25 06:08:05', 11, '2019-11-25 06:27:15'),
(19, 'Public services', 1, 11, '2019-11-25 06:08:05', 11, '2019-11-25 06:27:16'),
(20, 'Other', 1, 11, '2019-11-25 06:08:05', 11, '2019-11-25 06:27:37');

-- --------------------------------------------------------

--
-- Table structure for table `questions`
--

CREATE TABLE `questions` (
  `id` int(16) NOT NULL,
  `userid` int(16) UNSIGNED NOT NULL,
  `question` varchar(500) NOT NULL,
  `answer_1` varchar(500) NOT NULL,
  `answer_2` varchar(500) NOT NULL,
  `answer_3` varchar(500) DEFAULT NULL,
  `answer_4` varchar(500) DEFAULT NULL,
  `answer` int(11) NOT NULL,
  `type` int(11) NOT NULL,
  `date_created` date NOT NULL,
  `link` varchar(500) DEFAULT NULL,
  `ticketid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `questions`
--

INSERT INTO `questions` (`id`, `userid`, `question`, `answer_1`, `answer_2`, `answer_3`, `answer_4`, `answer`, `type`, `date_created`, `link`, `ticketid`) VALUES
(14, 7, 'agile is ', 'fun', 'useful', 'very fun', 'not fun', 3, 1, '2019-04-15', NULL, 2),
(16, 7, 'What is APIPA?', 'option 1', 'option 2', 'option 3', 'option 4', 2, 1, '2019-10-30', NULL, 2),
(17, 7, 'What is AWS?', 'Google\'s web services?', 'Amazon\'s web services?', 'Microsoft\'s web services?', 'idk', 2, 1, '2019-11-04', NULL, 2),
(18, 12, 'If you see corruption you should..', 'Get out of there', 'Speak up', 'Pretend you saw nothing', 'None of the above', 2, 1, '2019-12-03', NULL, 2),
(19, 12, 'Would you pay a small amount to a driving instructor to pass a test?', 'If you had to', 'Without hesitation', 'Never', 'Maybe', 3, 1, '2019-12-03', NULL, 2),
(20, 12, 'Bribing people is ok', 'True', 'False', NULL, NULL, 2, 2, '2019-12-03', NULL, 2),
(21, 12, 'Paying a police officer a small amount to escape a larger fine is acceptable', 'True', 'False', NULL, NULL, 2, 2, '2019-12-03', NULL, 2),
(22, 12, 'In business, it\'s \"you scratch my back, and I\'ll scratch yours.\"', 'True', 'False', NULL, NULL, 2, 2, '2019-12-03', NULL, 2),
(23, 12, 'You should avoid giving a job to a relative if they were under-qualified for the position.', 'True', 'False', NULL, NULL, 1, 2, '2019-12-03', NULL, 2);

-- --------------------------------------------------------

--
-- Table structure for table `quizzes`
--

CREATE TABLE `quizzes` (
  `id` int(16) UNSIGNED NOT NULL,
  `title` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `userid` int(16) UNSIGNED NOT NULL,
  `description` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `industry_id` int(11) NOT NULL,
  `tag_one` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT 'NULL',
  `tag_two` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT 'NULL',
  `tag_three` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT 'NULL',
  `created` timestamp NOT NULL DEFAULT current_timestamp(),
  `edited_on` timestamp NULL DEFAULT NULL ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `quizzes`
--

INSERT INTO `quizzes` (`id`, `title`, `userid`, `description`, `industry_id`, `tag_one`, `tag_two`, `tag_three`, `created`, `edited_on`) VALUES
(1, 'test', 8, 'test', 1, NULL, NULL, NULL, '2019-04-15 04:00:00', '2019-11-24 19:38:43'),
(2, 'wef', 7, 'sdfsdf', 2, NULL, NULL, NULL, '2019-04-15 04:00:00', '2019-11-24 19:38:46'),
(3, 'leanne', 7, 'test quiz', 3, NULL, NULL, NULL, '2019-04-15 04:00:00', '2019-11-24 19:38:49'),
(4, 'This is Ilya\'s quiz', 7, 'test', 4, NULL, NULL, NULL, '2019-11-02 04:00:00', '2019-11-24 19:38:52'),
(5, 'This is Ilya\'s quiz', 7, 'test', 5, NULL, NULL, NULL, '2019-11-02 04:00:00', '2019-11-24 19:38:54'),
(6, 'This is Ilya\'s quiz', 7, 'zcxz', 6, NULL, NULL, NULL, '2019-11-02 04:00:00', '2019-11-24 19:38:56'),
(7, 'werwsrw', 7, 'wer', 2, NULL, NULL, NULL, '2019-11-02 04:00:00', '2019-11-24 19:38:59'),
(8, 'dfgd', 7, 'dgfg', 3, NULL, NULL, NULL, '2019-11-02 04:00:00', '2019-11-24 19:39:02'),
(9, 'sfdff', 7, 'sdf', 8, NULL, NULL, NULL, '2019-11-02 04:00:00', '2019-11-24 19:39:04'),
(10, 'sfdff', 7, 'sdf', 1, NULL, NULL, NULL, '2019-11-02 04:00:00', '2019-11-24 19:39:07'),
(11, 'wqeq', 7, 'qwe', 2, NULL, NULL, NULL, '2019-11-02 04:00:00', '2019-11-24 19:39:10'),
(12, 'zxc', 7, 'zxc', 3, NULL, NULL, NULL, '2019-11-02 04:00:00', '2019-11-24 19:39:14'),
(13, '1234', 7, 'zxc', 4, NULL, NULL, NULL, '2019-11-02 04:00:00', '2019-11-24 19:39:17'),
(32, 'this is new quiz', 11, '123', 5, 'NULL', 'NULL', 'NULL', '2019-11-23 17:08:31', '2019-11-24 19:39:20'),
(33, 'q', 11, 'qwe', 0, 'NULL', 'NULL', 'NULL', '2019-11-24 23:04:31', '0000-00-00 00:00:00'),
(34, 'asdasd', 11, 'asd', 0, 'NULL', 'NULL', 'NULL', '2019-11-24 23:14:33', '0000-00-00 00:00:00'),
(35, 'rtre', 11, 'gretg', 0, 'NULL', 'NULL', 'NULL', '2019-11-24 23:16:12', '0000-00-00 00:00:00'),
(36, 'this is 24324', 11, '234234', 0, 'NULL', 'NULL', 'NULL', '2019-11-24 23:21:24', '0000-00-00 00:00:00'),
(37, 'asd', 11, 'asd', 0, 'NULL', 'NULL', 'NULL', '2019-11-24 23:22:47', '0000-00-00 00:00:00'),
(38, 'asdasd', 11, 'asd', 0, 'NULL', 'NULL', 'NULL', '2019-11-24 23:28:24', '0000-00-00 00:00:00'),
(39, 'zzzz', 11, 'zzzz', 14, 'NULL', 'NULL', 'NULL', '2019-11-24 23:33:50', '0000-00-00 00:00:00'),
(40, '1111', 11, '123123', 20, 'NULL', 'NULL', 'NULL', '2019-11-24 23:36:36', '0000-00-00 00:00:00'),
(41, 'wer', 11, '', 2, 'NULL', 'NULL', 'NULL', '2019-11-25 00:22:51', '0000-00-00 00:00:00'),
(42, 'saa', 11, NULL, 2, 'NULL', 'NULL', 'NULL', '2019-11-25 00:27:42', '0000-00-00 00:00:00'),
(43, 'qqq', 11, 'qq', 1, 'NULL', 'NULL', 'NULL', '2019-11-25 04:20:22', '0000-00-00 00:00:00'),
(44, 'asdasd', 11, 'qqq', 16, 'NULL', 'NULL', 'NULL', '2019-11-25 04:20:51', '0000-00-00 00:00:00'),
(45, 'rer', 11, NULL, 0, 'NULL', 'NULL', 'NULL', '2019-11-25 04:57:07', '0000-00-00 00:00:00'),
(46, 'sasdad', 11, NULL, 1, 'NULL', 'NULL', 'NULL', '2019-11-25 04:58:50', '0000-00-00 00:00:00'),
(47, 'This is test', 11, 'thsgsdf', 12, 'NULL', 'NULL', 'NULL', '2019-11-25 14:40:54', '0000-00-00 00:00:00'),
(48, 'Anti-money Laundering and Real Estate as a High Risk Sector', 12, NULL, 15, 'NULL', 'NULL', 'NULL', '2019-11-25 19:31:04', '0000-00-00 00:00:00'),
(49, 'Anti-corruption Checklist in National and International Business Transactions', 12, NULL, 3, 'NULL', 'NULL', 'NULL', '2019-11-25 19:31:47', '0000-00-00 00:00:00'),
(50, 'Preventing Bribery and Corruption Through Strong Controls, Policies and Procedures', 12, NULL, 20, 'NULL', 'NULL', 'NULL', '2019-11-25 19:32:10', '0000-00-00 00:00:00'),
(51, 'Internal Structures: How to Identify and Deal with Red Flags', 12, NULL, 20, 'NULL', 'NULL', 'NULL', '2019-11-25 19:33:01', '0000-00-00 00:00:00'),
(52, 'Accountability, Leadership and Responsibilities – What it Means and How to Own it', 12, NULL, 20, 'NULL', 'NULL', 'NULL', '2019-11-25 19:33:31', '0000-00-00 00:00:00'),
(53, 'zxc', 11, 'zxc', 6, 'NULL', 'NULL', 'NULL', '2019-12-02 14:02:44', '0000-00-00 00:00:00'),
(54, '123123', 11, NULL, 14, 'NULL', 'NULL', 'NULL', '2019-12-02 15:09:34', '0000-00-00 00:00:00'),
(56, 'testttt', 12, 'testttt', 1, 'NULL', 'NULL', 'NULL', '2019-12-03 13:40:08', '0000-00-00 00:00:00'),
(57, 'dfs', 12, NULL, 1, 'NULL', 'NULL', 'NULL', '2019-12-03 15:16:20', '0000-00-00 00:00:00'),
(58, 'This is test', 12, NULL, 3, 'NULL', 'NULL', 'NULL', '2019-12-03 15:38:49', '0000-00-00 00:00:00'),
(59, 'new', 12, NULL, 19, 'NULL', 'NULL', 'NULL', '2019-12-03 15:58:23', '0000-00-00 00:00:00'),
(60, 'xvxc', 12, NULL, 19, 'NULL', 'NULL', 'NULL', '2019-12-03 16:19:04', '0000-00-00 00:00:00'),
(61, 'IGdfgfd', 12, NULL, 13, 'NULL', 'NULL', 'NULL', '2019-12-03 16:22:57', '0000-00-00 00:00:00'),
(62, 'zxczc', 12, NULL, 14, 'NULL', 'NULL', 'NULL', '2019-12-03 16:44:17', '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `quizzes_questions`
--

CREATE TABLE `quizzes_questions` (
  `quizid` int(16) UNSIGNED NOT NULL,
  `questionid` int(16) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `quizzes_questions`
--

INSERT INTO `quizzes_questions` (`quizid`, `questionid`) VALUES
(3, 16),
(3, 17),
(48, 18),
(48, 19),
(48, 21),
(48, 23);

-- --------------------------------------------------------

--
-- Table structure for table `roles`
--

CREATE TABLE `roles` (
  `id` int(16) NOT NULL,
  `name` varchar(15) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `roles`
--

INSERT INTO `roles` (`id`, `name`) VALUES
(1, 'General'),
(2, 'Admin');

-- --------------------------------------------------------

--
-- Table structure for table `submitted_answers`
--

CREATE TABLE `submitted_answers` (
  `id` int(11) NOT NULL,
  `quiz_id` int(11) NOT NULL,
  `question_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `answer` varchar(500) CHARACTER SET utf8 NOT NULL,
  `submitted_on` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `submitted_answers`
--

INSERT INTO `submitted_answers` (`id`, `quiz_id`, `question_id`, `user_id`, `answer`, `submitted_on`) VALUES
(9, 3, 15, 7, 'False', '2019-11-04 15:22:37'),
(10, 3, 16, 7, 'option 4', '2019-11-04 15:22:38'),
(11, 3, 17, 7, 'idk', '2019-11-04 15:22:32'),
(12, 16, 1, 11, 'False', '2019-11-19 15:54:22'),
(13, 14, 1, 11, 'False', '2019-11-20 05:29:24'),
(14, 14, 3, 11, 'True', '2019-11-20 05:29:23'),
(15, 14, 2, 11, 'sdf', '2019-11-20 05:29:25'),
(16, 22, 1, 11, 'True', '2019-11-20 05:29:41'),
(17, 30, 17, 11, 'Google\'s web services?', '2019-11-23 00:00:58'),
(18, 32, 1, 11, 'True', '2019-12-02 15:13:26'),
(19, 32, 2, 11, 'sdf', '2019-12-02 15:13:28'),
(20, 48, 18, 12, 'Pretend you saw nothing', '2019-12-03 16:58:44'),
(21, 48, 19, 12, 'Without hesitation', '2019-12-03 16:24:28'),
(22, 48, 21, 12, 'True', '2019-12-03 16:24:29'),
(23, 48, 23, 12, 'True', '2019-12-03 16:24:30');

-- --------------------------------------------------------

--
-- Table structure for table `tickets`
--

CREATE TABLE `tickets` (
  `id` int(11) NOT NULL,
  `Name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `tickets`
--

INSERT INTO `tickets` (`id`, `Name`) VALUES
(1, 'Safe'),
(2, 'Censorship Issue'),
(3, 'No Ticket'),
(4, 'Admin Request');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(16) UNSIGNED NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `salt` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL,
  `roleid` int(11) NOT NULL,
  `ticketid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `name`, `email`, `password`, `salt`, `roleid`, `ticketid`) VALUES
(2, 'kishan', 'k@k.com', '123123123', '', 1, 3),
(3, 'admin', 'admin@admin.com', '123123123', '', 2, 3),
(5, 'ilya admin', 'ilyaAdmin@yahoo.ca', '123', '', 2, 3),
(6, '123', '123@yahoo.ca', '123', '', 2, 3),
(7, 'Gedan', 'ilyak@yahoo.ca', 'zxc', '', 1, 4),
(8, 'zx', 'zxc@yahoo.ca', 'zxc', '', 1, 3),
(9, 'amd', 'amd@yahoo.ca', 'zxc', '', 1, 3),
(10, 'ilya', 'ilya@yahoo.ca', 'zxc', '', 1, 3),
(11, 'zxc', 'zxc@gmail.com', 'zxc', '', 1, 3),
(12, 'Kishan', 'kishan@gmail.com', 'zxc', '', 1, 3);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `assigned_quizzes`
--
ALTER TABLE `assigned_quizzes`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `censoredwords`
--
ALTER TABLE `censoredwords`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `industries`
--
ALTER TABLE `industries`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `questions`
--
ALTER TABLE `questions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `userid` (`userid`),
  ADD KEY `ticketid` (`ticketid`);

--
-- Indexes for table `quizzes`
--
ALTER TABLE `quizzes`
  ADD PRIMARY KEY (`id`),
  ADD KEY `userid` (`userid`);

--
-- Indexes for table `quizzes_questions`
--
ALTER TABLE `quizzes_questions`
  ADD KEY `quizid` (`quizid`),
  ADD KEY `questionid` (`questionid`);

--
-- Indexes for table `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `submitted_answers`
--
ALTER TABLE `submitted_answers`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tickets`
--
ALTER TABLE `tickets`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD KEY `roleid` (`roleid`),
  ADD KEY `ticketid` (`ticketid`) USING BTREE;

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `assigned_quizzes`
--
ALTER TABLE `assigned_quizzes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `censoredwords`
--
ALTER TABLE `censoredwords`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `industries`
--
ALTER TABLE `industries`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `questions`
--
ALTER TABLE `questions`
  MODIFY `id` int(16) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT for table `quizzes`
--
ALTER TABLE `quizzes`
  MODIFY `id` int(16) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=63;

--
-- AUTO_INCREMENT for table `roles`
--
ALTER TABLE `roles`
  MODIFY `id` int(16) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `submitted_answers`
--
ALTER TABLE `submitted_answers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT for table `tickets`
--
ALTER TABLE `tickets`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(16) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `questions`
--
ALTER TABLE `questions`
  ADD CONSTRAINT `ticketid` FOREIGN KEY (`ticketid`) REFERENCES `tickets` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `quizzes`
--
ALTER TABLE `quizzes`
  ADD CONSTRAINT `quizzes_ibfk_1` FOREIGN KEY (`userid`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `quizzes_questions`
--
ALTER TABLE `quizzes_questions`
  ADD CONSTRAINT `quizzes_questions_ibfk_1` FOREIGN KEY (`questionid`) REFERENCES `questions` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `quizzes_questions_ibfk_2` FOREIGN KEY (`quizid`) REFERENCES `quizzes` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `roleid` FOREIGN KEY (`roleid`) REFERENCES `roles` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`ticketid`) REFERENCES `tickets` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
