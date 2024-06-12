
# Projeto de Popular Tabelas

Este projeto foi criado com o objetivo de popular a tabela `dados2` em um banco de dados. Planeja-se implementar modificações para torná-lo adaptável a diferentes tabelas.

## Objetivo

O principal objetivo deste projeto é fornecer uma base para a inserção de dados em uma tabela específica, `dados2`, e permitir modificações futuras para adaptar o script a outras tabelas.

## Estrutura da Tabela

A tabela `dados2` é definida com os seguintes campos:

- `id`: Identificador único, auto incrementado.
- `id_area`: Identificador da área.
- `data_hora`: Data e hora do registro.
- `temp_maxima`: Temperatura máxima registrada.
- `temp_minima`: Temperatura mínima registrada.
- `temp_media`: Temperatura média registrada.
- `temp_externa`: Temperatura externa registrada.
- `hora_final`: Hora final do registro.

A estrutura SQL para a criação da tabela é a seguinte:

```sql
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
AUTO_INCREMENT=136885304;

