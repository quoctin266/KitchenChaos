using System;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    private const string OPEN_CLOSE = "OpenClose";

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var containerCounter = GetComponentInParent<ContainerCounter>();

        containerCounter.OnPlayerGrabbedObject += ContainerCounter_OnPlayerGrabbedObject;
    }

    private void ContainerCounter_OnPlayerGrabbedObject(object sender, EventArgs e) {
        animator.SetTrigger(OPEN_CLOSE);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
