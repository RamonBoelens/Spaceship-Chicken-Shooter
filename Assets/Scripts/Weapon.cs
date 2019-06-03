using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    public string WeaponName;
    public float FireRate;
    public int Damage;
    public float BulletSpread;

    public GameObject bulletPrefab;

    private bool allowFiring = true;

    public void Shoot(Vector3 pos)
    {
        Debug.Log("Check Shoot");

        if (allowFiring)
        {
            Debug.Log("Shoot");

            allowFiring = false;

            

            GameObject go = Instantiate(bulletPrefab);
            go.transform.position = pos;
        }
    }
}
