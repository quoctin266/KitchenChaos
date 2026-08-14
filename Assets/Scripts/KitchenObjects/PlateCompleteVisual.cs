using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [SerializeField] private List<KitchenObjectSO_GameObject> kitchenObjectSOGameObjects;

    [Serializable]
    private struct KitchenObjectSO_GameObject {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }

    void Start() {
        var plateKitchenObject = GetComponentInParent<PlateKitchenObject>();

        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e) {
        var visualObject = kitchenObjectSOGameObjects.Find(x => x.kitchenObjectSO == e.kitchenObjectSO).gameObject;

        if(visualObject != null) {
            visualObject.SetActive(true);
        }
    }
}
