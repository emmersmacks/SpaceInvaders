using SpaceInvaders.Game.Bullets;
using System.Threading.Tasks;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace SpaceInvaders.Game.Units.Enemy
{
    public class EnemyController : IUnit
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private GameObject _buster;
        [SerializeField] private Sprite _deadSprite;

        private AudioSource _audioSource;
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            IsDamage += OnDamage;
            IsHit += OnHit;
            _audioSource = GetComponent<AudioSource>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void OnHit()
        {

        }

        public void Fire()
        {
            var bulletInstance = Instantiate(_bullet, transform.position, Quaternion.identity);
            var bulletScript = bulletInstance.GetComponent<Bullet>();
            bulletScript.senderScript = this;
            bulletScript.directionMove = new Vector2(0, -1);
            bulletScript.IsDestroy += OnActionDestroy;
        }
        private async void OnDamage()
        {
            SpawnBuster();
            _spriteRenderer.sprite = _deadSprite;
            await PlayDeadSound();
            Destroy(gameObject);
        }

        private async UniTask PlayDeadSound()
        {
            _audioSource.Play();
            var audioTime = (int)(_audioSource.clip.length * 1000);
            await Task.Delay(audioTime);
        }

        public void SpawnBuster()
        {
            if (Random.Range(0, 2) == 1)
            {
                Instantiate(_buster, transform.position, Quaternion.identity);
            }
        }
        private void OnActionDestroy()
        {
        }
    }
}

