using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Image barImage;

    [SerializeField] private CuttingCounter cuttingCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        cuttingCounter.OnProgressChanged += CuttingCounter_OnProgressChanged;

        barImage.fillAmount = 0f;

        gameObject.SetActive(false);
    }

    private void CuttingCounter_OnProgressChanged(object sender, CuttingCounter.OnProgressChangedEventArgs e) {
        barImage.fillAmount = e.progressNormalized;

        if(barImage.fillAmount == 0f || barImage.fillAmount == 1f) {
            gameObject.SetActive(false);
        }
        else {
            gameObject.SetActive(true);
        }
    }
}
