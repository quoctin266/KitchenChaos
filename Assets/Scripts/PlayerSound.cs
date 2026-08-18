using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private float footstepTimer;

    private float footstepTimerMax = 0.1f;

    void Update() {
        footstepTimer += Time.deltaTime;

        if(footstepTimer >= footstepTimerMax) {
            footstepTimer = 0f;

            if(Player.Instance.IsWalking()) {
                SoundManager.Instance.PlaySoundFootsteps(Player.Instance.transform.position);
            }
        }
    }
}
