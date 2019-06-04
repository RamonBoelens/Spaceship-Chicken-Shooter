using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Martijn Brain AI", menuName = "Brains/Martijn Brain AI")]
public class MartijnBrain : BrainBase
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
        lastData.ThrustForward(1);
        lastData.targets.OrderBy(t => t.health);

        if (lastData.targets[0].position == lastData.me.position)
        {
            lastData.LookAt(lastData.targets[1]);
        }

        else if  (lastData.targets[0].position != lastData.me.position)
        {
            lastData.LookAt(lastData.targets[0]);
        }
            

         if (lastData.me.health < 25)
        {
            lastData.BackOff(lastData.targets[0]);
        }

        if (lastData.targets[0].position == lastData.me.position)
            {
            if (Vector3.Distance(data.me.position, data.targets[1].position) < 10.0f)
                {
                lastData.Shoot(true);
                }
            }
        if (lastData.targets[0].position != lastData.me.position)
        {
            if (Vector3.Distance(data.me.position, data.targets[0].position) < 10.0f)
            {
                lastData.Shoot(true);
            }
        }

    }


}