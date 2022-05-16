using System;
using UnityEngine;
using System.Threading.Tasks;

public class PlayerController : IUnit
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        float directionHorizontal = Input.GetAxis("Horizontal");
        float directionVertical = Input.GetAxis("Vertical");

        var direction = new Vector2(directionHorizontal, directionVertical);
        transform.Translate(direction * _speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.GetComponent<EnemyController>())
        {
            IsDamage();
            Destroy(collision.gameObject);
        }
    }
}
