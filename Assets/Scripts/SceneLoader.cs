using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceInvaders.Scene.Controllers
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private int _sceneIndex;

        public void LoadScene()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(_sceneIndex);
        }
    }
}

