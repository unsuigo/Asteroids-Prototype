
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject topLeftPanel;
    public GameObject topRightPanel;
    public GameObject mainMenuPanel;
    public GameObject gameOverMenuPanel;
    public GameObject GameOverPanel;
    public GameObject LogoPanel;

    [Header("LogoTime")]
    public int logoTime;

    [Header("Debug")]
    public Text lives;
    public Text score;
    public Text scoreGameOverMenu;
    public Text highScoreMainMenu;
    public Text highScoreGameOverMenu;


    // Use this for initialization
    void Start()
    {
        CleanScreenUI();
        LogoPanelUI();
        Invoke("MainMenuUI", logoTime);

    }

    public void CleanScreenUI()
    {
        LogoPanel.SetActive(false);
        topLeftPanel.SetActive(false);
        topRightPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        gameOverMenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);

    }

    public void LogoPanelUI()
    {
        LogoPanel.SetActive(true);
        topLeftPanel.SetActive(false);
        topRightPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        gameOverMenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);

    }

    public void MainMenuUI()
    {
        LogoPanel.SetActive(false);
        topLeftPanel.SetActive(false);
        topRightPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        gameOverMenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    public void GamePlayingUI()
    {
        LogoPanel.SetActive(false);
        topLeftPanel.SetActive(true);
        topRightPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        gameOverMenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    public void GameOverUI()
    {
        LogoPanel.SetActive(false);
        topLeftPanel.SetActive(false);
        topRightPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        gameOverMenuPanel.SetActive(false);
        GameOverPanel.SetActive(true);

    }
    public void GameOverMenuUI()
    {
        LogoPanel.SetActive(false);
        topLeftPanel.SetActive(false);
        topRightPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        gameOverMenuPanel.SetActive(true);
        GameOverPanel.SetActive(false);
    }

    void OnUpdateHighScore(int highScoreFromManager)
    {
        highScoreMainMenu.text = highScoreFromManager.ToString();
        highScoreGameOverMenu.text = highScoreFromManager.ToString();
    }

    void OnUpdateScore(int scoreFromManager)
    {
        score.text = scoreFromManager.ToString();
        scoreGameOverMenu.text = scoreFromManager.ToString();

    }

    void OnUpdateLife(int livesFromManager)
    {
        lives.text = livesFromManager.ToString();
    }
}
