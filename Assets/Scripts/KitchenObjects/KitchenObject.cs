using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private IKitchenObjectParent kitchenObjectParent;

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent) {
        // remove kitchen object from previous parent
        this.kitchenObjectParent?.SetKitchenObject(null);

        // assign kitchen object to next parent
        this.kitchenObjectParent = kitchenObjectParent;
        kitchenObjectParent.SetKitchenObject(this);

        // move kitchen object to the next parent visually
        transform.parent = kitchenObjectParent.GetKitchenObjectLocation();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent GetKitchenObjectParent() {
        return kitchenObjectParent;
    }

    public KitchenObjectSO GetKitchenObjectSO() {
        return kitchenObjectSO;
    }

    public void DestroySelf() {
        kitchenObjectParent.SetKitchenObject(null);
        Destroy(gameObject);
    }

    public static KitchenObject SpawnKitchenObject(KitchenObjectSO kitchenObjectSO, IKitchenObjectParent kitchenObjectParent) {
        var kitchenObjectSpawn = Instantiate(kitchenObjectSO.prefab);
        var kitchenObject = kitchenObjectSpawn.GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectParent(kitchenObjectParent);

        return kitchenObject;
    }
}
