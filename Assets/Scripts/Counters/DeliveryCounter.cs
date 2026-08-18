using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public static DeliveryCounter Instance { get; private set; }

    private void Awake() {
        if (Instance != null) {
            Debug.LogError("There is more than one delivery counter instance");
        }

        Instance = this;
    }

    public override void Interact(Player player) {
        if (player.GetKitchenObject() != null) {
            // Player drop plate on counter
            if (player.GetKitchenObject() is PlateKitchenObject plateKitchenObject) {
                var deliverSuccess = DeliveryManager.Instance.DeliverRecipe(plateKitchenObject);

                if(deliverSuccess) {
                    player.GetKitchenObject().DestroySelf();
                }
            }
        }
    }
}
