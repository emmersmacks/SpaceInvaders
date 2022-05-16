using UnityEngine;
using SpaceInvaders.Data.Controllers;
using SpaceInvaders.UI.Controllers;
using SpaceInvaders.Game.Units.Player;
using Cysharp.Threading.Tasks;

namespace SpaceInvaders.Game.Data.Controllers
{
    public class GameDataController : MonoBehaviour
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
            if (playerLives <= 0)
            {
                StartGameOverAction();
                CompareScoreValues();
            }
        }

        private async UniTask StartGameOverAction()
        {
            await _uiController.ShowGameOverWindow();
            _uiController.SetGameOverScore(currentScore.ToString());
        }

        private void CompareScoreValues()
        {
            var savedScore = DataLoader.GetScoreNumber();
            if (savedScore < currentScore)
                DataLoader.SetScoreNumber(currentScore);
        }
    }
}
