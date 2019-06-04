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

        lastData = data;

        int rand = Random.Range(0, 600);

        if (rand == 16)
        {
            lastData.Rotate(true, 105);
        }

        else
        {
            if (Vector3.Distance(data.me.position, data.targets[0].position) > 15.0f)
            {
                lastData.LookAt(data.targets[0]);
                lastData.MoveTo(data.targets[0]);

                lastData.Shoot(true);
            }
            else
            {
                lastData.BackOff(data.targets[0]);
            }
        }
    }
}
