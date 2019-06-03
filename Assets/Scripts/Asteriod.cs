using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriod : MonoBehaviour
{


    public void start()
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
        else if (other.tag == "Asteriods")
        {
            this.transform.rotation = Random.rotation;
        }


	}
}
