using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CuttingCounter : BaseCounter 
{
    [SerializeField] private List<CuttingRecipeSO> cuttingRecipes;

    public override void Interact(Player player) {
        // Player drop object on counter
        if (player.GetKitchenObject() != null && GetKitchenObject() == null) {
            var kitchenObject = player.GetKitchenObject();
            var recipe = cuttingRecipes.FirstOrDefault(x => x.input == kitchenObject.GetKitchenObjectSO());

            // If the object can be cut, place it on the counter
            if (recipe != null) {
                kitchenObject.SetKitchenObjectParent(this);
            }
        }
        // Player pick up object from counter
        else if (player.GetKitchenObject() == null && GetKitchenObject() != null) {
            GetKitchenObject().SetKitchenObjectParent(player);
        }
    }

    public override void InteractAlternate(Player player) {
        if(GetKitchenObject() != null) {
            var kitchenObject = GetKitchenObject();
            var recipe = cuttingRecipes.FirstOrDefault(x => x.input == kitchenObject.GetKitchenObjectSO());

            if (recipe != null) {
                kitchenObject.DestroySelf();

                KitchenObject.SpawnKitchenObject(recipe.output, this);
            }
        }
    }
}
