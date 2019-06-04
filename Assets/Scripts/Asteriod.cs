using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriod : MonoBehaviour
{


    public void Start()
    {
        asteriodManager.instance.Enroll(this);
    }

	public void OnTriggerEnter(Collider other)
	{
        if (other.tag == "Edge")
        {
            asteriodManager.instance.Unroll(this);
            Destroy(gameObject);
        }
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroids")
        {
            transform.rotation = Random.rotation;
        }
    }
}
