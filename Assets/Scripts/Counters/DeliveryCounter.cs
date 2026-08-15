using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(Player player) {
        if (player.GetKitchenObject() != null) {
            // Player drop plate on counter
            if (player.GetKitchenObject() is PlateKitchenObject plateKitchenObject) {
                var deliverSuccess = DeliveryManager.Instance.DeliverRecipe(plateKitchenObject);

                if(deliverSuccess) {
                    player.GetKitchenObject().DestroySelf();
                }
            }

            // Player carry a plate and place an ingredient on it
            //else if (player.GetKitchenObject() is PlateKitchenObject plateKitchenObjectOnPlayer) {
            //    if (plateKitchenObjectOnPlayer.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())) {
            //        GetKitchenObject().DestroySelf();
            //    }
            //}
            // Counter has a plate and player place an ingredient on it
            //else if (GetKitchenObject() is PlateKitchenObject plateKitchenObjectOnCounter) {
            //    if (plateKitchenObjectOnCounter.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())) {
            //        player.GetKitchenObject().DestroySelf();
            //    }
            //}
        }
    }
}
