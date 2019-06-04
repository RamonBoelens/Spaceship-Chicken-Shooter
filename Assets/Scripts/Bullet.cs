using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float bulletSpeed = 17.5f;

    private void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Edge")
        {
            Destroy(gameObject);
        }

        if (other.tag == "ChickenM")
        {
            Debug.Log("Bullet hit Martijn!");
        }
        if (other.tag == "ChickenP")
        {
            Debug.Log("Bullet hit Petar!");
        }
        if (other.tag == "ChickenL")
        {
            Debug.Log("Bullet hit Luuk!");
        }
        if (other.tag == "ChickenR")
        {
            Debug.Log("Bullet hit Ramon");
        }

        Destroy(gameObject);
    }
}
