using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;

    public static SoundManager Instance { get; private set; }

    void Awake() {
        Instance = this;
    }

    void Start() {
        DeliveryManager.Instance.OnDeliverSuccess += DeliveryManager_OnDeliverSuccess;
        DeliveryManager.Instance.OnDeliverFailed += DeliveryManager_OnDeliverFailed;

        CuttingCounter.OnAnyCut += CuttingCounter_OnAnyCut;
        TrashCounter.OnAnyObjectTrashed += TrashCounter_OnAnyObjectTrashed;

        Player.Instance.OnPickedSomething += Player_OnPickedSomething;
        BaseCounter.OnAnyObjectPlaced += BaseCounter_OnAnyObjectPlaced;
    }

    private void Player_OnPickedSomething(object sender, System.EventArgs e) {
        PlaySoundFromList(audioClipRefsSO.objectPickup, Player.Instance.transform.position);
    }

    private void BaseCounter_OnAnyObjectPlaced(object sender, System.EventArgs e) {
        var baseCounter = sender as BaseCounter;

        PlaySoundFromList(audioClipRefsSO.objectDrop, baseCounter.transform.position);
    }

    private void CuttingCounter_OnAnyCut(object sender, System.EventArgs e) {
        var cuttingCounter = sender as CuttingCounter;

        PlaySoundFromList(audioClipRefsSO.chop, cuttingCounter.transform.position);
    }

    private void TrashCounter_OnAnyObjectTrashed(object sender, System.EventArgs e) {
        var trashCounter = sender as TrashCounter;

        PlaySoundFromList(audioClipRefsSO.trash, trashCounter.transform.position);
    }

    private void DeliveryManager_OnDeliverFailed(object sender, System.EventArgs e) {
        PlaySoundFromList(audioClipRefsSO.deliveryFail, DeliveryCounter.Instance.transform.position);
    }

    private void DeliveryManager_OnDeliverSuccess(object sender, System.EventArgs e) {
        PlaySoundFromList(audioClipRefsSO.deliverySuccess, DeliveryCounter.Instance.transform.position);
    }

    private void PlaySoundFromList(List<AudioClip> clips, Vector3 position, float volume = 1f) {
        if (clips != null && clips.Count > 0) {
            var clip = clips[Random.Range(0, clips.Count)];

            AudioSource.PlayClipAtPoint(clip, position, volume);
        }
    }

    public void PlaySoundFootsteps(Vector3 position, float volume = 1f) {
        PlaySoundFromList(audioClipRefsSO.footstep, position, volume);
    }
}
