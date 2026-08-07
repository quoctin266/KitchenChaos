using System;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    private const string CUT = "Cut";

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var cuttingCounter = GetComponentInParent<CuttingCounter>();

        cuttingCounter.OnCut += CuttingCounter_OnCut;
    }

    private void CuttingCounter_OnCut(object sender, EventArgs e) {
        animator.SetTrigger(CUT);
    }
}
