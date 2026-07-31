using UnityEngine;

public interface IKitchenObjectParent
{
    public Transform GetKitchenObjectLocation();

    public void SetKitchenObject(KitchenObject kitchenObject);

    public KitchenObject GetKitchenObject();
}
