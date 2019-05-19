using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BrainBaseRando : ScriptableObject
{
    public abstract void UpdateData(BrainDataRando data);
}


//Behave differently in memory:
//Class; changing the class, everything changes.
//Struct; creates a copy of the data. as soon as you change it, the other data will be outdated.
public struct BrainDataRando
{
    public Action<string> logMessage;
    public Action<Vector3> goTo;
    public Action<Vector3> rotateTowards;
    public Action<float> turn;


    public TargetRando me;
    public TargetRando[] targets;
}

public struct TargetRando
{
    public Vector3 position;
    public Quaternion rotation;
    public bool alive;
}
