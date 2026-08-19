using TMPro;
using UnityEngine;
using System;

public class GameStartCountdownUI : MonoBehaviour
{
    private TextMeshProUGUI startCountdownText;

    void Start()
    {
        startCountdownText = GetComponentInChildren<TextMeshProUGUI>();

        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        startCountdownText.text = Mathf.Ceil(GameManager.Instance.GetCountdownToStartTimer()).ToString();
    }

    private void GameManager_OnStateChanged(object sender, EventArgs e) {
        if (GameManager.Instance.IsCountdownToStart()) {
            gameObject.SetActive(true);
        }
        else {
            gameObject.SetActive(false);
        }
    }
}
