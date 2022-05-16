using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongStrikeBullet : Bullet
{
    private int hitCount = 3;

    private void Start()
    {
        base.Start();
        _directionMove = new Vector2(0, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.transform.GetComponent<IUnit>().GetType().Name != senderScript.GetType().Name)
        {
            hitCount--;
            if (hitCount == 0)
                DestroyBullet();
        }
    }
}
