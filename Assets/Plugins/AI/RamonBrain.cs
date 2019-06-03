﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ramon Brain AI", menuName = "Brains/Ramon Brain AI")]
public class RamonBrain : BrainBase
{
    private BrainData lastData;

    public override void UpdateData(BrainData data)
    {
        /*
         * Actions Avaliable:
         * 
           
            public Action<int> ThrustForward;
            public Action<bool, int> Rotate;
            public Action<Target> LookAt;
            public Action<Target> MoveTo;
            public Action<Target> LookAway;
            public Action<Target> BackOff;
         */
    }
}
