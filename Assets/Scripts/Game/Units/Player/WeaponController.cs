using SpaceInvaders.Game.Boosters;
using SpaceInvaders.Game.Bullets;
using System.Threading.Tasks;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace SpaceInvaders.Game.Units.Player
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private GameObject _defoltBullet;

        private bool _inRecharge;
        private GameObject _currentBullet;

        private void Start()
        {
            _currentBullet = _defoltBullet;
            _inRecharge = false;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1") && !_inRecharge)
            {
                _inRecharge = true;
                ShotBullet();
            }
        }

        private void ShotBullet()
        {
            var instantiateBullet = Instantiate(_currentBullet, transform.position, Quaternion.Euler(0,0,180));
            var bulletScript = instantiateBullet.GetComponent<Bullet>();
            bulletScript.senderScript = GetComponent<PlayerController>();
            bulletScript.directionMove = new Vector2(0, -1);
            bulletScript.IsDestroy += RechargeEnd;
        }

        private async UniTask WeaponBusterStart(DefaultBooster buster)
        {
            _currentBullet = buster.bullet;
            await Task.Delay(buster.actionTimeInMilliseconds);
            _currentBullet = _defoltBullet;
        }

        private async void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.GetComponent<DefaultBooster>())
            {
                var buster = collision.transform.GetComponent<DefaultBooster>();
                await WeaponBusterStart(buster);
                Destroy(collision.gameObject);
            }
        }

        private void RechargeEnd()
        {
            _inRecharge = false;
        }
    }
}

