using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class BrainBase : ScriptableObject
{
    #region Rando's Code

    /*
     * Code used from the example used in class by Rando
     * 
     */

    public abstract void UpdateData(BrainData data);

    #endregion
}

public struct BrainData
{
    public Action<int> ThrustForward;
    public Action<bool, int> Rotate;
    public Action<Target> LookAt;
    public Action<Target> MoveTo;
    public Action<Target> LookAway;
    public Action<Target> BackOff;
    public Action<bool> Shoot;

    // Information about the chickens
    public Target me;
    public Target[] targets;
}

public struct Target
{
    public Vector3 position;
    public Quaternion rotation;
    public bool alive;
    public int health;
}
