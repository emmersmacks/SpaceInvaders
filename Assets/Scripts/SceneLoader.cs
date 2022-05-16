using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceInvaders.Scene.Controllers
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private int sceneIndex;

        public void LoadScene()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(sceneIndex);
        }
    }
}

