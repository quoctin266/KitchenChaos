using UnityEngine;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField] private GameObject iconTemplate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var plateKitchenObject = GetComponentInParent<PlateKitchenObject>();

        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
    }

    public void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e) {
        var gameObject = Instantiate(iconTemplate, transform);

        gameObject.SetActive(true);

        var plateIconSingleUI = gameObject.GetComponent<PlateIconSingleUI>();

        plateIconSingleUI.SetPlateIcon(e.kitchenObjectSO);
    }
}
