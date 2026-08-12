using UnityEngine;
using System.Collections.Generic;
using System;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSO;

    private List<KitchenObjectSO> kitchenObjectSOList;

    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;

    public class OnIngredientAddedEventArgs : EventArgs {
        public KitchenObjectSO kitchenObjectSO;
    }

    private void Awake() {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO) {
        // Check if the ingredient is valid and not already on the plate
        if (validKitchenObjectSO.Contains(kitchenObjectSO) && !kitchenObjectSOList.Contains(kitchenObjectSO)) {
            kitchenObjectSOList.Add(kitchenObjectSO);

            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs { kitchenObjectSO = kitchenObjectSO });

            return true;
        }
        return false;
    }
}
