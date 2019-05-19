using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public BrainBaseRando brain;

    private BrainDataRando data;

    public bool IsAlive { get; private set; }

    public void Start()
    {
        IsAlive = true;
        data.logMessage = LogMessage;
        data.goTo = GoTo;
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
        data.targets = FindObjectsOfType<Robot>().Where(CanSee).Select(MakeTarget).ToArray();
    }

    private bool CanSee(Robot robot)
    {
        // Ray casts etc.
        if (robot == this) return false;
        return true;
    }

    private TargetRando MakeTarget(Robot robot)
    {
        return new TargetRando
        {
            position = robot.transform.position,
            rotation = robot.transform.rotation,
            alive = robot.IsAlive
        };
    }

    private void UpdateBrain()
    {
        brain.UpdateData(data);
    }

    private void LogMessage(string text)
    {
        Debug.Log($"{name}: {text}");
    }

    private void GoTo(Vector3 pos)
    {
        data.me.position = pos;
    }
}