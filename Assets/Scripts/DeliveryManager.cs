using System;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    [SerializeField] private RecipeListSO recipeListSO;

    private List<RecipeSO> waitingRecipes;

    private float spawnRecipeTimer;

    private float spawnRecipeTimerMax = 4f;

    private int waitingRecipesMax = 4;

    public static DeliveryManager Instance { get; private set; }

    public event EventHandler<OnRecipeSpawnedEventArgs> OnRecipeSpawned;

    public event EventHandler<OnRecipeCompletedEventArgs> OnRecipeCompleted;

    public class OnRecipeSpawnedEventArgs : EventArgs {
        public RecipeSO recipeSO;
    }

    public class OnRecipeCompletedEventArgs : EventArgs {
        public RecipeSO recipeSO;
    }

    private void Awake() {
        if (Instance != null) {
            Debug.LogError("There is more than one delivery manager instance");
        }
        Instance = this;

        waitingRecipes = new List<RecipeSO>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitingRecipes.Count < waitingRecipesMax) {
            spawnRecipeTimer += Time.deltaTime;

            if (spawnRecipeTimer >= spawnRecipeTimerMax) {
                spawnRecipeTimer = 0f;

                var recipes = recipeListSO.recipes;
                var randomRecipe = recipes[UnityEngine.Random.Range(0, recipes.Count)];
                waitingRecipes.Add(randomRecipe);

                OnRecipeSpawned?.Invoke(this, new OnRecipeSpawnedEventArgs { recipeSO = randomRecipe });
            }
        }
    }

    public bool DeliverRecipe(PlateKitchenObject plateKitchenObject) {
        var deliverIngredients = plateKitchenObject.GetKitchenObjectSOList();

        foreach (var recipe in waitingRecipes) {
            var recipeIngredients = recipe.kitchenObjectSOList;

            // check same number of ingredients
            if (recipeIngredients.Count == deliverIngredients.Count) {
                // check if all ingredients are the same
                if (recipeIngredients.TrueForAll(x => deliverIngredients.Contains(x))) {
                    waitingRecipes.Remove(recipe);

                    OnRecipeCompleted?.Invoke(this, new OnRecipeCompletedEventArgs { recipeSO = recipe });

                    return true;
                }
            }
        }

        return false;
    }

    public List<RecipeSO> GetWaitingRecipes() {
        return waitingRecipes;
    }
}
