# Dictionnaire de données


## RECETTES (`recipe`)

| Champ | Type | Spécificités | Description | 
| - | - | - | - | 
| id | INT | PRIMARY KEY, NOT NULL, UNSIGNED, AUTO_INCREMENT | L'identifiant de la recette | 
| user_id | VARCHAR(255) | NOT NULL | L'identifiant de l'utilisateur | 
| title | VARCHAR(255) | NOT NULL | Le titre de la recette | 
| duration | INT | NULL | La durée de préparation de la recette, peut être nul | 
| quantity | INT | NOT NULL | Le nombre de personnes pour les doses indiquées de la recette | 
| image_path | VARCHAR(255) | NULL | L'url de l'image de la recette, peut être nul | 
| note | LONGTEXT | NULL | Une note de l'utilisateur concernant la recette, peut être nul | 
| created_at | DATETIME | NOT NULL, DEFAULT CURRENT_DATETIME | La date de création de la recette | 
| updated_at | DATETIME | NULL | La date de la dernière mise à jour de la recette, peut être nul | 


## INGREDIENTS (`ingredient`)

| Champ | Type | Spécificités | Description | 
| - | - | - | - | 
| id | INT | PRIMARY KEY, NOT NULL, UNSIGNED, AUTO_INCREMENT | L'identifiant de l'ingredient | 
| recipe_id | INT, FOREIGN KEY | NOT NULL | L'identifiant de la recette contenant l'ingredient | 
| name | VARCHAR(255) | NOT NULL | Le nom de l'ingredient |
| quantity | INT | NOT NULL | La quantité de l'ingredient | 
| unit | VARCHAR(255) | NOT NULL | L'unité de la quantité de l'ingredient |
| created_at | DATETIME | NOT NULL, DEFAULT CURRENT_DATETIME | La date de création de l'ingredient | 
| updated_at | DATETIME | NULL | La date de la dernière mise à jour de l'ingredient, peut être nul | 


## ETAPES (`step`)

| Champ | Type | Spécificités | Description | 
| - | - | - | - | 
| id | INT | PRIMARY KEY, NOT NULL, UNSIGNED, AUTO_INCREMENT | L'identifiant de l'étape | 
| recipe_id | INT, FOREIGN KEY | NOT NULL | L'identifiant de la recette contenant l'étape | 
| order | INT | NOT NULL | L'ordre de l'étape |
| description | LONGTEXT | NOT NULL | La description de l'étape |
| created_at | DATETIME | NOT NULL, DEFAULT CURRENT_DATETIME | La date de création de l'étape | 
| updated_at | DATETIME | NULL | La date de la dernière mise à jour de l'étape, peut être nul | 


## GROUPES (`group`)

| Champ | Type | Spécificités | Description | 
| - | - | - | - | 
| id | INT | PRIMARY KEY, NOT NULL, UNSIGNED, AUTO_INCREMENT | L'identifiant du groupe | 
| user_id | VARCHAR(255) | NOT NULL | L'identifiant de l'utilisateur | 
| title | VARCHAR(255) | NOT NULL | Le titre du groupe |
| image_path | VARCHAR(255) | NULL | L'url de l'image du groupe, peut être nul | 
| description | LONGTEXT | NULL | Une description de l'utilisateur concernant le groupe, peut être nul | 
| created_at | DATETIME | NOT NULL, DEFAULT CURRENT_DATETIME | La date de création du groupe | 
| updated_at | DATETIME | NULL | La date de la dernière mise à jour du groupe, peut être nul |


## GROUPES_RECETTE (`group_recipe`)

| Champ | Type | Spécificités | Description | 
| - | - | - | - | 
| id | INT | PRIMARY KEY, NOT NULL, UNSIGNED, AUTO_INCREMENT | L'identifiant du groupe | 
| recipe_id | INT, FOREIGN KEY | NOT NULL | L'identifiant de la recette contenue dans le groupe |
| group_id | INT, FOREIGN KEY | NOT NULL | L'identifiant du groupe contenant la recette |
