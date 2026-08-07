using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CuttingCounter : BaseCounter 
{
    [SerializeField] private List<CuttingRecipeSO> cuttingRecipes;

    public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;

    public event EventHandler OnCut;

    public class OnProgressChangedEventArgs : EventArgs {
        public float progressNormalized;
    }

    private int cuttingProgress;

    public override void Interact(Player player) {
        // Player drop object on counter
        if (player.GetKitchenObject() != null && GetKitchenObject() == null) {
            var kitchenObject = player.GetKitchenObject();
            var recipe = cuttingRecipes.FirstOrDefault(x => x.input == kitchenObject.GetKitchenObjectSO());

            // If the object can be cut, place it on the counter
            if (recipe != null) {
                kitchenObject.SetKitchenObjectParent(this);

                cuttingProgress = 0;

                OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs { progressNormalized = 0f });
            }
        }
        // Player pick up object from counter
        else if (player.GetKitchenObject() == null && GetKitchenObject() != null) {
            GetKitchenObject().SetKitchenObjectParent(player);
        }
    }

    public override void InteractAlternate(Player player) {
        var kitchenObject = GetKitchenObject();
        if (kitchenObject != null) {
            var recipe = cuttingRecipes.FirstOrDefault(x => x.input == kitchenObject.GetKitchenObjectSO());

            if (recipe != null) {
                cuttingProgress++;

                OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs { progressNormalized = (float)cuttingProgress / recipe.cuttingProgressMax });

                OnCut?.Invoke(this, EventArgs.Empty);

                if (cuttingProgress >= recipe.cuttingProgressMax) {
                    kitchenObject.DestroySelf();

                    KitchenObject.SpawnKitchenObject(recipe.output, this);
                }
            }
        }
    }
}
