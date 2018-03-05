-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema wedding_planner
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema wedding_planner
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `wedding_planner` DEFAULT CHARACTER SET utf8 ;
USE `wedding_planner` ;

-- -----------------------------------------------------
-- Table `wedding_planner`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `wedding_planner`.`users` (
  `user_id` INT NOT NULL AUTO_INCREMENT,
  `first_name` VARCHAR(45) NULL,
  `last_name` VARCHAR(45) NULL,
  `email` VARCHAR(45) NULL,
  `password` VARCHAR(255) NULL,
  PRIMARY KEY (`user_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `wedding_planner`.`weddings`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `wedding_planner`.`weddings` (
  `wedding_id` INT NOT NULL AUTO_INCREMENT,
  `bride_name` VARCHAR(45) NULL,
  `groom_name` VARCHAR(45) NULL,
  `date` DATETIME NULL,
  `address` VARCHAR(100) NULL,
  `user_id` INT NOT NULL,
  PRIMARY KEY (`wedding_id`, `user_id`),
  INDEX `fk_weddings_users_idx` (`user_id` ASC),
  CONSTRAINT `fk_weddings_users`
    FOREIGN KEY (`user_id`)
    REFERENCES `wedding_planner`.`users` (`user_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `wedding_planner`.`rsvps`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `wedding_planner`.`rsvps` (
  `rsvp_id` INT NOT NULL AUTO_INCREMENT,
  `users_user_id` INT NOT NULL,
  `wedding_id` INT NOT NULL,
  `user_id` INT NOT NULL,
  PRIMARY KEY (`rsvp_id`, `users_user_id`, `wedding_id`, `user_id`),
  INDEX `fk_rsvps_users1_idx` (`users_user_id` ASC),
  INDEX `fk_rsvps_weddings1_idx` (`wedding_id` ASC, `user_id` ASC),
  CONSTRAINT `fk_rsvps_users1`
    FOREIGN KEY (`users_user_id`)
    REFERENCES `wedding_planner`.`users` (`user_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_rsvps_weddings1`
    FOREIGN KEY (`wedding_id` , `user_id`)
    REFERENCES `wedding_planner`.`weddings` (`wedding_id` , `user_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;