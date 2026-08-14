using UnityEngine;
using static Player;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject[] visualGameObjectArr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, OnSelectedCounterChangedEventArgs e) {
        var baseCounter = GetComponentInParent<BaseCounter>();

        // show/hide visual 
        if (baseCounter == e.selectedCounter) {
            foreach (var visualGameObject in visualGameObjectArr) {
                visualGameObject.SetActive(true);
            }
        }
        else {
            foreach (var visualGameObject in visualGameObjectArr) {
                visualGameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
