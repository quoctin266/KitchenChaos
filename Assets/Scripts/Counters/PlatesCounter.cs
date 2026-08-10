using UnityEngine;
using System;

public class PlatesCounter : BaseCounter 
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private int spawnedPlateAmount;

    private int spawnedPlateMax = 4;

    private float spawnPlateTimer;

    private float spawnPlateTimeMax = 4f;

    public event EventHandler OnPlateSpawned;

    public event EventHandler OnPlateTaken;

    void Update() {
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer >= spawnPlateTimeMax) {
            spawnPlateTimer = 0f;

            if (spawnedPlateAmount < spawnedPlateMax) {
                spawnedPlateAmount++;

                // spawn dummy plate visual object
                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player) {
        // spawn actual plate kitchen object and give to player
        if (player.GetKitchenObject() == null && spawnedPlateAmount > 0) {
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);

            spawnedPlateAmount--;

            OnPlateTaken?.Invoke(this, EventArgs.Empty);
        }
    }
}
