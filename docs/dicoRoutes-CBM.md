# Dictionnaire de routes

## RECETTES
| URL | Méthode HTTP | Controller | METHODE |
|--|--|--|--|
| /api/recette | `GET` | RecipeController | getAll | 
| /api/recette/`{id}` | `GET` | RecipeController | get`(id)` | 
| /api/recette/`{id}` | `PUT` `PATCH` | RecipeController| update`(id)` | 
| /api/recette | `POST` | RecipeController | add | 
| /api/recette/`{id}` | `DELETE` | RecipeController | delete`(id)` |
| /api/recette/groupe/`{id}` | `GET` | RecipeController | getAllByGroup`(id)` |


## INGREDIENTS
| URL | Méthode HTTP | Controller | METHODE |
|--|--|--|--|
| /api/recette/`{recipeId}`/ingredient | `GET` | IngredientController | getAllByRecipe`(recipeId)` | 
| /api/ingredient/`{id}` | `GET` | IngredientController | get`(id)` | 
| /api/ingredient/`{id}` | `PUT` `PATCH` | IngredientController| update`(id)` | 
| /api/recette/`{recipeId}`/ingredient | `POST` | IngredientController | add`(recipeId)` | 
| /api/recette/ingredient/`{id}` | `DELETE` | IngredientController | delete`(id)` |


## ETAPES
| URL | Méthode HTTP | Controller | METHODE |
|--|--|--|--|
| /api/recette/`{recipeId}`/etape | `GET` | StepController | getAllByRecipe(`recipeId`) | 
| /api/recette/etape/`{id}` | `GET` | StepController | get`(id)` | 
| /api/recette/etape/`{id}` | `PUT` `PATCH` | StepController| update`(id)` | 
| /api/recette/`{recipeId}`/etape | `POST` | StepController | add`(recipeId)` | 
| /api/recette/etape/`{id}` | `DELETE` | StepController | delete`(id)` |


## GROUPES
| URL | Méthode HTTP | Controller | METHODE |
|--|--|--|--|
| /api/groupe | `GET` | GroupController | getAll | 
| /api/groupe/`{id}` | `GET` | GroupController | get`(id)` | 
| /api/groupe/`{id}` | `PUT` `PATCH` | GroupController| update`(id)` | 
| /api/groupe | `POST` | GroupController | add | 
| /api/groupe/`{id}` | `DELETE` | GroupController | delete`(id)` |