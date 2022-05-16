using UnityEngine;
using UnityEngine.UI;
using SpaceInvaders.Data.Controllers;


public class MenuUIConroller : UIController
{
    protected void Start()
    {
        UpdateScoreTextField(DataLoader.GetScoreNumber());
    }
}
