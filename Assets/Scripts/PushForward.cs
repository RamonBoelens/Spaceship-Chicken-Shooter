using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushForward : MonoBehaviour
{

    private Rigidbody rb;
    public float thrust = 20;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(GiveForce(5));
    }

    // Pushes the object forward for a certain amount of frames
    IEnumerator GiveForce(int frames)
    {
        int i = 0;
        while (i < frames)
        {
            rb.AddForce(transform.up * thrust);

            i++;
            yield return 0;
        }
    }
}
