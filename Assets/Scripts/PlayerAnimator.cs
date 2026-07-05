using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
    [SerializeField] private Player player;

    private const string IS_WALKING = "IsWalking";

    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start() {
        
    }

    // Update is called once per frame
    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
