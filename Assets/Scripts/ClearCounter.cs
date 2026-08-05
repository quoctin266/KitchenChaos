using UnityEngine;

public class ClearCounter : BaseCounter
{
    public override void Interact(Player player) {
        // Player drop object on counter
        if (player.GetKitchenObject() != null && GetKitchenObject() == null) {
            player.GetKitchenObject().SetKitchenObjectParent(this);
        }
        // Player pick up object from counter
        else if (player.GetKitchenObject() == null && GetKitchenObject() != null) {
            GetKitchenObject().SetKitchenObjectParent(player);
        }
    }
}
