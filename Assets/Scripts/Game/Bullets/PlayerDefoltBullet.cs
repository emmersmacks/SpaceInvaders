using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefoltBullet : Bullet
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
