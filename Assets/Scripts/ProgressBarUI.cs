using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Image barImage;

    [SerializeField] private BaseCounter baseCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        baseCounter.OnProgressChanged += BaseCounter_OnProgressChanged;

        barImage.fillAmount = 0f;

        gameObject.SetActive(false);
    }

    private void BaseCounter_OnProgressChanged(object sender, BaseCounter.OnProgressChangedEventArgs e) {
        barImage.fillAmount = e.progressNormalized;

        if(barImage.fillAmount == 0f || barImage.fillAmount == 1f) {
            gameObject.SetActive(false);
        }
        else {
            gameObject.SetActive(true);
        }
    }
}
