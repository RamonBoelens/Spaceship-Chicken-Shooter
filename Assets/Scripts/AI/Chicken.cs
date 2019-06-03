using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    private Rigidbody rb;

    #region Rando's Code

    /*
     * Code used from the example used in class by Rando
     * 
     */

    public BrainBase brain;
    private BrainData data;

    public bool IsAlive { get; private set; }

    private void Start()
    {
        IsAlive = true;

        rb = GetComponent<Rigidbody>();
        data.ThrustForward = ThrustForward;
        data.Rotate = Rotate;
        data.LookAt = LookAt;
        data.MoveTo = MoveTo;
    }

    public void Update()
    {
        GatherData();
        GatherTargets();
        UpdateBrain();
    }

    private void GatherData()
    {
        data.me = MakeTarget(this);
    }

    //Gives us a list of robots we can actually see
    private void GatherTargets()
    {
        data.targets = FindObjectsOfType<Chicken>().Where(CanSee).Select(MakeTarget).ToArray();
    }

    private bool CanSee(Chicken chicken)
    {
        // Ray casts etc.
        if (chicken == this) return false;
        return true;
    }

    private Target MakeTarget(Chicken chicken)
    {
        return new Target
        {
            position = chicken.transform.position,
            rotation = chicken.transform.rotation,
            alive = chicken.IsAlive
        };
    }

    private void UpdateBrain()
    {
        brain.UpdateData(data);
    }

    #endregion

    private int thrust = 15;
    private float rotationSpeed = 2.0f;

    private void ThrustForward(int timeInFrames)
    {
        int i = 0;
        while (i < timeInFrames)
        {
            rb.AddForce(transform.forward * thrust);
            i++;
        }
    }

    private void Rotate(bool rotateClockwise, int degrees)
    {
        if (rotateClockwise)
        {
            transform.Rotate(new Vector3 (0, degrees, 0));
            //Debug.Log($"Rotating clockwise with {degrees} degrees.");
        }
        else
        {
            transform.Rotate(new Vector3(0, -degrees, 0));
            //Debug.Log($"Rotating counter clockwise with {degrees} degrees.");
        }
    }

    private void LookAt(Target target)
    {
        Vector3 targetDir = target.position - transform.position;

        float step = rotationSpeed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        Debug.DrawRay(transform.position, newDir, Color.red);

        transform.rotation = Quaternion.LookRotation(newDir);
    }

    private void MoveTo(Target target)
    {
        LookAt(target);

        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            //Debug.Log("At Position");
            return;
        }

        rb.AddForce(transform.forward * thrust);
    }
}
