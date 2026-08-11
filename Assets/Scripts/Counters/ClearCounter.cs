using UnityEngine;

public class ClearCounter : BaseCounter
{
    public override void Interact(Player player) {
        if (player.GetKitchenObject() != null) {
            // Player drop object on counter
            if (GetKitchenObject() == null) {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            // Player carry a plate and place an ingredient on it
            else if (player.GetKitchenObject() is PlateKitchenObject plateKitchenObjectOnPlayer) {
                if (plateKitchenObjectOnPlayer.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())) {
                    GetKitchenObject().DestroySelf();
                }
            }
            // Counter has a plate and player place an ingredient on it
            else if (GetKitchenObject() is PlateKitchenObject plateKitchenObjectOnCounter) {
                if (plateKitchenObjectOnCounter.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())) {
                    player.GetKitchenObject().DestroySelf();
                }
            }
        }
        // Player pick up object from counter
        else if (player.GetKitchenObject() == null && GetKitchenObject() != null) {
            GetKitchenObject().SetKitchenObjectParent(player);
        }
    }
}
