using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] private Transform counterTopPoint;

    [SerializeField] private GameObject plateVisualPrefab;

    private List<GameObject> plateVisuals;

    private float plateVisualOffsetY = 0.1f;

    private void Awake() {
        plateVisuals = new List<GameObject>();
    }

    void Start() {
        var platesCounter = GetComponentInParent<PlatesCounter>();

        platesCounter.OnPlateSpawned += PlatesCounter_OnPlateSpawned;
        platesCounter.OnPlateTaken += PlatesCounter_OnPlateTaken;
    }

    private void PlatesCounter_OnPlateSpawned(object sender, System.EventArgs e) {
        var plateVisual = Instantiate(plateVisualPrefab, counterTopPoint);

        plateVisual.transform.localPosition = new Vector3(0f, plateVisualOffsetY * plateVisuals.Count, 0f);

        plateVisuals.Add(plateVisual);
    }

    private void PlatesCounter_OnPlateTaken(object sender, System.EventArgs e) {
        if (plateVisuals.Count > 0) {
            var plateVisual = plateVisuals.Last();

            plateVisuals.Remove(plateVisual);

            Destroy(plateVisual);
        }
    }
}
