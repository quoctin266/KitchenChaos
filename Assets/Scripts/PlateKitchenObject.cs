using UnityEngine;
using System.Collections.Generic;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSO;

    private List<KitchenObjectSO> kitchenObjectSOList;

    private void Awake() {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO) {
        // Check if the ingredient is valid and not already on the plate
        if (validKitchenObjectSO.Contains(kitchenObjectSO) && !kitchenObjectSOList.Contains(kitchenObjectSO)) {
            kitchenObjectSOList.Add(kitchenObjectSO);
            return true;
        }
        return false;
    }
}
