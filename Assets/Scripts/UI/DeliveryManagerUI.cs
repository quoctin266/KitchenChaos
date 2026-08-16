using UnityEngine;

public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField] private GameObject recipeTemplate;

    [SerializeField] private Transform container;

    void Start() {
        DeliveryManager.Instance.OnRecipeSpawned += DeliveryManager_OnRecipeSpawned;
        DeliveryManager.Instance.OnRecipeCompleted += DeliveryManager_OnRecipeCompleted;
    }

    private void DeliveryManager_OnRecipeSpawned(object sender, DeliveryManager.OnRecipeSpawnedEventArgs e) {
        var gameObject = Instantiate(recipeTemplate, container);

        gameObject.SetActive(true);

        var deliveryManagerSingleUI = gameObject.GetComponent<DeliveryManagerSingleUI>();

        deliveryManagerSingleUI.SetRecipeSO(e.recipeSO);

        deliveryManagerSingleUI.SetRecipeTitle(e.recipeSO.recipeName);

        deliveryManagerSingleUI.SpawnIngredientIcons(e.recipeSO);
    }

    private void DeliveryManager_OnRecipeCompleted(object sender, DeliveryManager.OnRecipeCompletedEventArgs e) {
        foreach (Transform child in container) {
            // Skip initial inactive template
            if (child.gameObject.activeSelf) {
                var deliveryManagerSingleUI = child.GetComponent<DeliveryManagerSingleUI>();

                if (deliveryManagerSingleUI.GetRecipeSO() == e.recipeSO) {
                    Destroy(child.gameObject);

                    break;
                }
            } 
        }
    }
}
