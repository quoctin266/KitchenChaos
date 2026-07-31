using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;

    public void Interact(Player player) {
        if(kitchenObject == null) {
            // spawn kitchen object on a counter or move from one counter to another
            var kitchenObjectSpawn = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectSpawn.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else {
            // give kitchen object to player
            if(player.GetKitchenObject() == null) {
                kitchenObject.SetKitchenObjectParent(player);
            }
        }
    }
    
    public Transform GetKitchenObjectLocation() {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject) {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject() { 
        return kitchenObject; 
    }
}
