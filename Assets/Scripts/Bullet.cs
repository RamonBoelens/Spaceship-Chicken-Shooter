using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 17.5f;
    private int bulletDamage = 25;

    private void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ChickenM")
        {
            GameManager.instance.CallDamageChicken(0, bulletDamage);
        }
        if (other.tag == "ChickenP")
        {
            GameManager.instance.CallDamageChicken(2, bulletDamage);
        }
        if (other.tag == "ChickenL")
        {
            GameManager.instance.CallDamageChicken(1, bulletDamage);
        }
        if (other.tag == "ChickenR")
        {
            GameManager.instance.CallDamageChicken(3, bulletDamage);
        }

        Destroy(gameObject);
    }
}
