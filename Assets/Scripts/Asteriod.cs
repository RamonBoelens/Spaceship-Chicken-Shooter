using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriod : MonoBehaviour
{
    [Range(5, 15)]
    public float speed = 5;

    public void Start()
    {
        asteriodManager.instance.Enroll(this);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Edge")
        {
            asteriodManager.instance.Unroll(this);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Asteroids")
        {
            transform.rotation = Random.rotation;
        }
    }
}
