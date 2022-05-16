using SpaceInvaders.Game.Units;
using UnityEngine;

namespace SpaceInvaders.Game.Bullets
{
    public class DefoltBullet : Bullet
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);
            if (collision.transform.GetComponent<IUnit>().GetType().Name != senderScript.GetType().Name)
            {
                DestroyBullet();
            }
        }
    }
}

