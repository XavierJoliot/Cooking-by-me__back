# Dictionnaire de routes

## RECETTES
| URL | Méthode HTTP | Controller | METHODE |
|--|--|--|--|
| /api/recette | `GET` | RecipeController | GetAllRecipesAsync | 
| /api/recette/`{id}` | `GET` | RecipeController | GetRecipeByIdAsync`(id)` | 
| /api/recette/`{id}` | `PUT` `PATCH` | RecipeController| UpdateRecipe`(id)` | 
| /api/recette | `POST` | RecipeController | CreateRecipe | 
| /api/recette/`{id}` | `DELETE` | RecipeController | DeleteRecipe`(id)` |


## INGREDIENTS
| URL | Méthode HTTP | Controller | METHODE |
|--|--|--|--|
| /api/ingredient/`{id}` | `GET` | IngredientController | GetIngredientByIdAsync`(id)` | 
| /api/ingredient/`{id}` | `PUT` `PATCH` | IngredientController| UpdateIngredient`(id)` | 
| /api/ingredient | `POST` | IngredientController | addAsync | 
| /api/ingredient/`{id}` | `DELETE` | IngredientController | DeleteIngredient`(id)` |


## ETAPES
| URL | Méthode HTTP | Controller | METHODE |
|--|--|--|--|
| /api/etape/`{id}` | `GET` | StepController | getByIdAsync`(id)` | 
| /api/etape/`{id}` | `PUT` `PATCH` | StepController| updateAsync`(id)` | 
| /api/etape | `POST` | StepController | UpdtateStep | 
| /api/etape/`{id}` | `DELETE` | StepController | DeleteStep`(id)` |


## GROUPES
| URL | Méthode HTTP | Controller | METHODE |
|--|--|--|--|
| /api/groupe | `GET` | GroupController | GetAllGroupsAsync | 
| /api/groupe/`{id}` | `GET` | GroupController | GetGroupByIdAsync`(id)` | 
| /api/groupe/`{id}` | `PUT` `PATCH` | GroupController| UpdateGroup`(id)` | 
| /api/groupe | `POST` | GroupController | CreateGroup | 
| /api/groupe/`{id}` | `DELETE` | GroupController | DeleteGroup`(id)` |