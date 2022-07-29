# Dictionnaire de routes

## RECETTES
| URL | Méthode HTTP | Controller | METHODE |
|--|--|--|--|
| /api/recette | `GET` | RecipeController | getAllAsync | 
| /api/recette/`{id}` | `GET` | RecipeController | getByIdAsync`(id)` | 
| /api/recette/`{id}` | `PUT` `PATCH` | RecipeController| updateAsync`(id)` | 
| /api/recette | `POST` | RecipeController | addAsync | 
| /api/recette/`{id}` | `DELETE` | RecipeController | deleteAsync`(id)` |
| /api/recette/`{recipeId}`/ingredient | `GET` | RecipeController | getAllByRecipeIdAsync`(recipeId)` | 
| /api/recette/`{recipeId}`/etape | `GET` | RecipeController | getAllByRecipeIdAsync(`recipeId`) | 
| /api/recette/groupe/`{id}` | `GET` | RecipeController | getAllByGroupIdAsync`(id)` |


## INGREDIENTS
| URL | Méthode HTTP | Controller | METHODE |
|--|--|--|--|
| /api/ingredient/`{id}` | `GET` | IngredientController | getByIdAsync`(id)` | 
| /api/ingredient/`{id}` | `PUT` `PATCH` | IngredientController| updateAsync`(id)` | 
| /api/ingredient | `POST` | IngredientController | addAsync | 
| /api/ingredient/`{id}` | `DELETE` | IngredientController | deleteAsync`(id)` |


## ETAPES
| URL | Méthode HTTP | Controller | METHODE |
|--|--|--|--|
| /api/etape/`{id}` | `GET` | StepController | getByIdAsync`(id)` | 
| /api/etape/`{id}` | `PUT` `PATCH` | StepController| updateAsync`(id)` | 
| /api/etape | `POST` | StepController | addAsync | 
| /api/etape/`{id}` | `DELETE` | StepController | deleteAsync`(id)` |


## GROUPES
| URL | Méthode HTTP | Controller | METHODE |
|--|--|--|--|
| /api/groupe | `GET` | GroupController | getAllAsync | 
| /api/groupe/`{id}` | `GET` | GroupController | getByIdAsync`(id)` | 
| /api/groupe/`{id}` | `PUT` `PATCH` | GroupController| updateAsync`(id)` | 
| /api/groupe | `POST` | GroupController | addAsync | 
| /api/groupe/`{id}` | `DELETE` | GroupController | deleteAsync`(id)` |