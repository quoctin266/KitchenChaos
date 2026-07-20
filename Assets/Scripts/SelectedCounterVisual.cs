using UnityEngine;
using static Player;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject visualGameObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, OnSelectedCounterChangedEventArgs e) {
        var clearCounter = GetComponentInParent<ClearCounter>();

        if (clearCounter == e.selectedCounter) {
            visualGameObject.SetActive(true);
        }
        else {
            visualGameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
