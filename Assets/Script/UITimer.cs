using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Color textColor = Color.white;
    [SerializeField] private float fontSize = 36f;
    private float elapsedTime = 0f;

    void Start()
    {
        timerText.color = textColor;
        timerText.fontSize = fontSize;
        timerText.fontStyle = FontStyles.Bold;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

