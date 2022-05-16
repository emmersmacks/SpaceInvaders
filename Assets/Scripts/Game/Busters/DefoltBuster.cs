using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefoltBuster : MonoBehaviour, IWeaponBuster
{
    [SerializeField] public GameObject bullet;
    [SerializeField] public int actionTimeInMilliseconds;
    [SerializeField] private int _fallSpeed;

    private void FixedUpdate()
    {
        if (transform != null)
            transform.Translate(new Vector2(0, -1) * _fallSpeed * Time.fixedDeltaTime);
    }
}
