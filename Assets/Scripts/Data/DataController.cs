using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceInvaders.Data.Controllers;

public class DataController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameUIController _uiController;

    public int currentScore = 0;
    public int playerLives;

    private void Start()
    {
        _playerController.IsHit += OnHit;
        _playerController.IsDamage += OnDamage;
        playerLives = _uiController.GetCurrentLives();
    }

    public void OnHit()
    {
        currentScore++;
        _uiController.UpdateScoreTextField(currentScore);
    }

    public void OnDamage()
    {
        _uiController.DestroyOneHeart();
        playerLives--;
        CheckCurrentHealth();
    }

    private void CheckCurrentHealth()
    {
        if(playerLives <= 0)
        {
            StartGameOverAction();
            CompareScoreValues();
        }
    }

    private void StartGameOverAction()
    {
        _uiController.ShowGameOverWindow();
        _uiController.SetGameOverScore(currentScore.ToString());
    }

    private void CompareScoreValues()
    {
        var savedScore = DataLoader.GetScoreNumber();
        if (savedScore < currentScore)
            DataLoader.SaveScoreNumber(currentScore);
    }
}
