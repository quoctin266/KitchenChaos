using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryManagerSingleUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipeTitle;

    [SerializeField] private GameObject iconTemplate;

    [SerializeField] private Transform iconContainer;

    private RecipeSO recipeSO;

    public void SetRecipeTitle(string title) {
        recipeTitle.text = title;
    }

    public void SpawnIngredientIcons(RecipeSO recipeSO) {
        foreach (var ingredient in recipeSO.kitchenObjectSOList) {
            var icon = Instantiate(iconTemplate, iconContainer);

            icon.SetActive(true);

            icon.GetComponent<Image>().sprite = ingredient.sprite;
        }
    }

    public void SetRecipeSO(RecipeSO recipeSO) {
        this.recipeSO = recipeSO;
    }

    public RecipeSO GetRecipeSO() {
        return recipeSO;
    }
}
