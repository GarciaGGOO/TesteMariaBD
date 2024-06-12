CREATE TABLE `dados2` (
	`id` INT(11) NOT NULL AUTO_INCREMENT,
	`id_area` INT(11) NOT NULL,
	`data_hora` DATETIME NOT NULL,
	`temp_maxima` DOUBLE NOT NULL,
	`temp_minima` DOUBLE NOT NULL,
	`temp_media` DOUBLE NOT NULL,
	`temp_externa` DOUBLE NOT NULL,
	`hora_final` DATETIME NOT NULL,
	PRIMARY KEY (`id`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB
AUTO_INCREMENT=136885304
;
