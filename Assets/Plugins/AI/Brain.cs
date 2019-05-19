﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Brain : BrainBase
{
    private BrainData lastData;

    private bool moveForward = false;
    private bool rotate = true;

    public override void UpdateData(BrainData data)
    {
        lastData = data;

        /*
        if (moveForward == true)
        {
            lastData.ThrustForward(1);
            moveForward = false;
            rotate = true;
        }
        
        else if (rotate == true)
        {
            lastData.Rotate(true, 1);
            moveForward = true;
            rotate = false;
        }

        lastData.LookAt(data.targets[0]);
        lastData.MoveTo(data.targets[0]);
        */
    }
}
