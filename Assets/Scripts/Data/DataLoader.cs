using UnityEngine;

namespace SpaceInvaders.Data.Controllers
{
    public static class DataLoader
    {
        private const string _scoreKey = "score";

        public static void SetScoreNumber(int number)
        {
            PlayerPrefs.SetInt(_scoreKey, number);
        }

        public static int GetScoreNumber()
        {
            CheckAvailability();
            var score = PlayerPrefs.GetInt(_scoreKey);
            return score;
        }

        private static void CheckAvailability()
        {
            if (!PlayerPrefs.HasKey(_scoreKey))
                PlayerPrefs.SetInt(_scoreKey, 0);
        }
    }
}

