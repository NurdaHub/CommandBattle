using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button playButton;
    public TextMeshProUGUI timerText;

    private string battleText = "Battle time: ";

    public void OnGameOver(string battleTime)
    {
        playButton.gameObject.SetActive(true);
        timerText.text = battleText + battleTime + " sec";
        timerText.gameObject.SetActive(true);
    }
}
