using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders.Game.Boosters
{
    public class DefaultBooster : MonoBehaviour, IWeaponBooster
    {
        [SerializeField] public GameObject bullet;
        [SerializeField] public int actionTimeInMilliseconds;
        [SerializeField] private int _fallSpeed;

        private void Start()
        {
            StartDestroyTimer();
        }

        private void FixedUpdate()
        {
            if (transform != null)
                transform.Translate(new Vector2(0, -1) * _fallSpeed * Time.fixedDeltaTime);
        }

        protected async UniTask StartDestroyTimer()
        {
            await UniTask.Delay(2000);
            Destroy();
        }

        protected void Destroy()
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}

