using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushForward : MonoBehaviour
{

    private Rigidbody rb;
    public float thrust = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(GiveForce(200));
    }

    // Pushes the object forward for a certain amount of frames
    IEnumerator GiveForce(int frames)
    {
        int i = 0;
        while (i < frames)
        {
            rb.AddForce(transform.forward * thrust);

            Debug.Log($"Waiting for i: {i}");
            i++;
            yield return 0;
        }
    }
}
