using UnityEngine.UI;
using UnityEngine;

public class GameUIController : UIController
{
    [SerializeField] private GameObject _gameOverWindow;
    [SerializeField] private Text _gameOverScoreText;
    [SerializeField] private GameObject _livesPanel;

    public void ShowGameOverWindow()
    {
        _gameOverWindow.SetActive(true);
        Time.timeScale = 0;
    }

    public void DestroyOneHeart()
    {
        Destroy(_livesPanel.transform.GetChild(0).gameObject);
    }

    public void SetGameOverScore(string score)
    {
        _gameOverScoreText.text = scoreFieldTextForm + score;
    }

    public int GetCurrentLives()
    {
        return _livesPanel.transform.childCount;
    }
}
