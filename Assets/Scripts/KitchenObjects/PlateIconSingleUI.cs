using UnityEngine;
using UnityEngine.UI;

public class PlateIconSingleUI : MonoBehaviour
{
    [SerializeField] private Image icon;

    public void SetPlateIcon(KitchenObjectSO kitchenObjectSO) {
        icon.sprite = kitchenObjectSO.sprite;
    }
}
