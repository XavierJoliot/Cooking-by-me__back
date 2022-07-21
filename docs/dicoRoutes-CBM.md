# Dictionnaire de routes

## RECETTES
| URL | Méthode HTTP | Controller | METHODE |
|--|--|--|--|
| /api/recette | `GET` | RecipeController | getAllAsync | 
| /api/recette/`{id}` | `GET` | RecipeController | getByIdAsync`(id)` | 
| /api/recette/`{id}` | `PUT` `PATCH` | RecipeController| updateAsync`(id)` | 
| /api/recette | `POST` | RecipeController | addAsync | 
| /api/recette/`{id}` | `DELETE` | RecipeController | deleteAsync`(id)` |
| /api/recette/groupe/`{id}` | `GET` | RecipeController | getAllByGroupIdAsync`(id)` |


## INGREDIENTS
| URL | Méthode HTTP | Controller | METHODE |
|--|--|--|--|
| /api/recette/`{recipeId}`/ingredient | `GET` | IngredientController | getAllByRecipeIdAsync`(recipeId)` | 
| /api/ingredient/`{id}` | `GET` | IngredientController | getByIdAsync`(id)` | 
| /api/ingredient/`{id}` | `PUT` `PATCH` | IngredientController| updateAsync`(id)` | 
| /api/recette/`{recipeId}`/ingredient | `POST` | IngredientController | addAsync`(recipeId)` | 
| /api/recette/ingredient/`{id}` | `DELETE` | IngredientController | deleteAsync`(id)` |


## ETAPES
| URL | Méthode HTTP | Controller | METHODE |
|--|--|--|--|
| /api/recette/`{recipeId}`/etape | `GET` | StepController | getAllByRecipeIdAsync(`recipeId`) | 
| /api/recette/etape/`{id}` | `GET` | StepController | getByIdAsync`(id)` | 
| /api/recette/etape/`{id}` | `PUT` `PATCH` | StepController| updateAsync`(id)` | 
| /api/recette/`{recipeId}`/etape | `POST` | StepController | addAsync`(recipeId)` | 
| /api/recette/etape/`{id}` | `DELETE` | StepController | deleteAsync`(id)` |


## GROUPES
| URL | Méthode HTTP | Controller | METHODE |
|--|--|--|--|
| /api/groupe | `GET` | GroupController | getAllAsync | 
| /api/groupe/`{id}` | `GET` | GroupController | getByIdAsync`(id)` | 
| /api/groupe/`{id}` | `PUT` `PATCH` | GroupController| updateAsync`(id)` | 
| /api/groupe | `POST` | GroupController | addAsync | 
| /api/groupe/`{id}` | `DELETE` | GroupController | deleteAsync`(id)` |