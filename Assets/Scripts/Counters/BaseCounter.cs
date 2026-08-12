using System;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;

    public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;

    public class OnProgressChangedEventArgs : EventArgs {
        public float progressNormalized;
    }

    public virtual void Interact(Player player) {
        Debug.LogError("BaseCounter.Interact() is not implemented");
    }

    public virtual void InteractAlternate(Player player) {
        Debug.Log("BaseCounter.InteractAlternate() is not implemented");
    }

    protected void RaiseProgressChanged(float progress) {
        OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs {
            progressNormalized = progress
        });
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
