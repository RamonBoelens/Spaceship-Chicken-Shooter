using System.Collections;
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

        if (Vector3.Distance(data.me.position, data.targets[0].position) > 10.0f)
        {
            lastData.LookAt(data.targets[0]);
            //lastData.MoveTo(data.targets[0]);

            lastData.Shoot(true);
        }
        else
        {
            lastData.BackOff(data.targets[0]);
        }
    }
}
