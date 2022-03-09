using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public UIManager uiManager;
    public Timer timer;
    public TeamManager[] teamManagers;
    private bool isGameOver;

    private void Awake()
    {
        Instance = this;
        uiManager.playButton.onClick.AddListener(OnPlayButtonPresseed);
    }

    private void OnPlayButtonPresseed()
    {
        if (isGameOver)
            SceneManager.LoadScene(0);
        
        timer.StartTimer();
        
        foreach (var teamManager in teamManagers)
        {
            teamManager.SetTargetToUnits();
        }
    }

    public void CheckUnits()
    {
        foreach (var teamManager in teamManagers)
        {
            var teamHasUnit = teamManager.HasActiveUnit();
            
            if (!teamHasUnit)
                GameOver();
        }
    }

    private void GameOver()
    {
        var gameTime = timer.GetTime();
        isGameOver = true;
        uiManager.OnGameOver(gameTime.ToString());
    }
}
