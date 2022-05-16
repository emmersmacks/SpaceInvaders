using UnityEngine;
using UnityEngine.UI;
using SpaceInvaders.Data.Controllers;

namespace SpaceInvaders.UI.Controllers
{
    public class MenuUIConroller : UIController
    {
        protected void Start()
        {
            UpdateScoreTextField(DataLoader.GetScoreNumber());
        }
    }
}

