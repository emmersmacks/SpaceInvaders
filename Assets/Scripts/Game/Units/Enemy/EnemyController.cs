using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : IUnit
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject buster;

    private void Start()
    {
        IsDamage += OnDamage;
        IsHit += OnHit;
    }

    private void OnHit()
    {

    }

    public void Fire()
    {
        var bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletInstance.GetComponent<Bullet>().senderScript = this;
        bulletInstance.GetComponent<Bullet>()._directionMove = new Vector2(0, -1);
    }

    public void SpawnBuster()
    {
        if (Random.Range(0, 2) == 1)
        {
            Instantiate(buster, transform.position, Quaternion.identity);
        }
    }

    private void OnDamage()
    {
        Destroy(gameObject);
    }
}
