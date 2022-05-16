using System.Threading.Tasks;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float _speed;

    public Vector2 _directionMove;
    public IUnit senderScript;
    public Action IsDestroy = default;

    protected const int _timeToDestroyInMillisecond = 1500;
    
    protected void Start()
    {
        StartDestroyTimer();
        IsDestroy += OnActionDestroy;
    }

    private void FixedUpdate()
    {
        if(transform != null)
            transform.Translate(_directionMove * _speed * Time.fixedDeltaTime);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<IUnit>().GetType().Name != senderScript.GetType().Name)
        {
            collision.transform.GetComponent<IUnit>().IsDamage();
            senderScript.IsHit();
        }
    }

    protected async void StartDestroyTimer()
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

    private void OnActionDestroy()
    {

    }
}
