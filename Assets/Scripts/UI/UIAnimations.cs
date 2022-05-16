using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace SpaceInvaders.UI.Controllers
{
    public static class UIAnimations
    {
        private static int windowShowSpeed = 5;

        public static async UniTask WindowShowAnimation(GameObject window)
        {
            window.transform.localScale = Vector3.zero;
            while(window.transform.localScale.x < 1)
            {
                window.transform.localScale += new Vector3(0.1f,0.1f,0);
                await UniTask.Delay(5);
            }
        }
    }
}

