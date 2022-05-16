using SpaceInvaders.Game.Units;
using UnityEngine;

namespace SpaceInvaders.Game.Bullets
{
    public class LongStrikeBullet : Bullet
    {
        private int _hitCount = 3;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);
            if (collision.transform.GetComponent<IUnit>().GetType().Name != senderScript.GetType().Name)
            {
                _hitCount--;
                if (_hitCount == 0)
                    DestroyBullet();
            }
        }
    }
}

