CREATE SCHEMA 'mps';

CREATE TABLE `mps`.`phrase` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `text` VARCHAR(150) NULL,
  `difficulty` INT NULL,
  `type` INT NULL,
  PRIMARY KEY (`id`));

CREATE TABLE `mps`.`users` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL,
  `password` VARCHAR(45) NULL,
  `score` INT NULL DEFAULT 0,
  PRIMARY KEY (`id`));
