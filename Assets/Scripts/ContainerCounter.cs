using System;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public event EventHandler OnPlayerGrabbedObject;

    public override void Interact(Player player) {
        // spawn kitchen object and give to player
        if(player.GetKitchenObject() == null) {
            var kitchenObjectSpawn = Instantiate(kitchenObjectSO.prefab);
            kitchenObjectSpawn.GetComponent<KitchenObject>().SetKitchenObjectParent(player);

            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}
