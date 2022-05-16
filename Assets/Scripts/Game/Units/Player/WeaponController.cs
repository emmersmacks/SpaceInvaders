using System.Threading.Tasks;
using UnityEngine;

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
            var instantiateBullet = Instantiate(_currentBullet, transform.position, Quaternion.identity);
            var bulletScript = instantiateBullet.GetComponent<Bullet>();
            bulletScript.senderScript = GetComponent<PlayerController>();
            bulletScript._directionMove = new Vector2(0, 1);
            bulletScript.IsDestroy += RechargeEnd;
        }
    }

    private void RechargeEnd()
    {
        _inRecharge = false;
    }

    private async void WeaponBusterStart(DefoltBuster buster)
    {
        _currentBullet = buster.bullet;
        await Task.Delay(buster.actionTimeInMilliseconds);
        _currentBullet = _defoltBullet;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<DefoltBuster>())
        {
            var buster = collision.transform.GetComponent<DefoltBuster>();
            WeaponBusterStart(buster);
            Destroy(collision.gameObject);
        }
    }
}
