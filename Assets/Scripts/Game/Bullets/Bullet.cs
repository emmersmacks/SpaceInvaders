using System.Threading.Tasks;
using UnityEngine;
using System;
using SpaceInvaders.Game.Units;
using Cysharp.Threading.Tasks;

namespace SpaceInvaders.Game.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] protected float _speed;

        public Vector2 directionMove;
        public IUnit senderScript;
        public Action IsDestroy = default;

        protected const int _timeToDestroyInMillisecond = 1200;

        protected async void Start()
        {
            await StartDestroyTimer();
        }

        private void FixedUpdate()
        {
            if (transform != null)
                transform.Translate(directionMove * _speed * Time.fixedDeltaTime);
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.GetComponent<IUnit>().GetType().Name != senderScript.GetType().Name)
            {
                collision.transform.GetComponent<IUnit>().IsDamage();
                senderScript.IsHit();
            }
        }

        protected async UniTask StartDestroyTimer()
        {
            await Task.Delay(_timeToDestroyInMillisecond);
            DestroyBullet();
        }

        protected void DestroyBullet()
        {
            if (gameObject != null)
            {
                IsDestroy();
                Destroy(gameObject);
            }
        }
    }
}

