using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CuttingCounter : BaseCounter 
{
    [SerializeField] private List<CuttingRecipeSO> cuttingRecipes;

    public event EventHandler OnCut;

    private int cuttingProgress;

    public override void Interact(Player player) {
        if (player.GetKitchenObject() != null) {
            // Player drop object on counter
            if (GetKitchenObject() == null) {
                var kitchenObject = player.GetKitchenObject();
                var recipe = cuttingRecipes.FirstOrDefault(x => x.input == kitchenObject.GetKitchenObjectSO());

                // If the object can be cut, place it on the counter
                if (recipe != null) {
                    kitchenObject.SetKitchenObjectParent(this);

                    cuttingProgress = 0;
                }
            }
            // Player carry a plate and place an ingredient on it
            else if (player.GetKitchenObject() is PlateKitchenObject plateKitchenObject) {
                if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())) {
                    GetKitchenObject().DestroySelf();
                }
            }
        }
        // Player pick up object from counter
        else if (player.GetKitchenObject() == null && GetKitchenObject() != null) {
            GetKitchenObject().SetKitchenObjectParent(player);
        }

        RaiseProgressChanged(0f);
    }

    public override void InteractAlternate(Player player) {
        var kitchenObject = GetKitchenObject();
        if (kitchenObject != null) {
            var recipe = cuttingRecipes.FirstOrDefault(x => x.input == kitchenObject.GetKitchenObjectSO());

            if (recipe != null) {
                cuttingProgress++;

                RaiseProgressChanged((float)cuttingProgress / recipe.cuttingProgressMax);

                OnCut?.Invoke(this, EventArgs.Empty);

                if (cuttingProgress >= recipe.cuttingProgressMax) {
                    kitchenObject.DestroySelf();

                    KitchenObject.SpawnKitchenObject(recipe.output, this);
                }
            }
        }
    }
}
