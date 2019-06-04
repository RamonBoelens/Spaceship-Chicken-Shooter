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

    public void Shoot(Transform pos, GameObject BulletSpawnPoint)
    {
        GameObject go = Instantiate(bulletPrefab, BulletSpawnPoint.transform.position, Quaternion.Euler(new Vector3(0, pos.transform.rotation.y * 135, 90)));

        SfxManager.instance.PlaySound(SfxManager.instance.ShotPistol);
    }
}
