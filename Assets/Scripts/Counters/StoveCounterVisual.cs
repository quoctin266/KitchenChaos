using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject stoveOnGameObject;

    [SerializeField] private GameObject particlesGameObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var stoveCounter = GetComponentInParent<StoveCounter>();

        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        if(e.state == StoveCounter.State.Idle || e.state == StoveCounter.State.Burned) {
            stoveOnGameObject.SetActive(false);
            particlesGameObject.SetActive(false);
        }
        else {
            stoveOnGameObject.SetActive(true);
            particlesGameObject.SetActive(true);
        }
    }
}
