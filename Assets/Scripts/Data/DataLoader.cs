using UnityEngine;

namespace SpaceInvaders.Data.Controllers
{
    public static class DataLoader
    {
        private const string scoreKey = "score";

        public static void SaveScoreNumber(int number)
        {
            PlayerPrefs.SetInt(scoreKey, number);
        }

        public static int GetScoreNumber()
        {
            Debug.Log(PlayerPrefs.HasKey(scoreKey));
            int score = 0;
            if (PlayerPrefs.HasKey(scoreKey))
                score = PlayerPrefs.GetInt(scoreKey);
            else
                PlayerPrefs.SetInt(scoreKey, 0);
            return score;
        }
    }
}

