using UnityEngine;

public class StoveCounterSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    void Start() {
        var stoveCounter = GetComponentInParent<StoveCounter>();

        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e) {
        if (e.state == StoveCounter.State.Idle || e.state == StoveCounter.State.Burned) {
            audioSource.Pause();
        }
        else {
            audioSource.Play();
        }
    }
}
