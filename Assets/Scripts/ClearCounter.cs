using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    [SerializeField] private Transform counterTopPoint;

    public void Interact() {
        Debug.Log("Interact");
        var kitchenObjectSpawn = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
        kitchenObjectSpawn.transform.localPosition = Vector3.zero;

        Debug.Log(kitchenObjectSO.objectName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
