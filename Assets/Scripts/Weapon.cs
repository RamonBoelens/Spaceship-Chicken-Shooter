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
}
