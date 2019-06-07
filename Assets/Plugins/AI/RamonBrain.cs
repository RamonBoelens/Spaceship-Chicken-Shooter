using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Ramon Brain AI", menuName = "Brains/Ramon Brain AI")]
public class RamonBrain : BrainBase
{
    private BrainData lastData;

    private float targetRange = 15.0f;

    private List<Target> targetsBasedOnDist = new List<Target>();
    private List<Target> targetsBasedOnHealth = new List<Target>();

    private Target currentTarget;

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
            public Action<bool> Shoot;
         */

        lastData = data;

        // Keep moving forawrd
        lastData.ThrustForward(1);

        // Order the targets list based on distance and store them in a different list
        lastData.targets = lastData.targets.OrderBy(x => CalcDistance(x)).ToArray();

        foreach (Target target in lastData.targets)
        {
            targetsBasedOnDist.Add(target);
        }

        // Order the targets list based on health and store them in a different list
        lastData.targets = lastData.targets.OrderBy(x => x.health).ToArray();

        foreach (Target target in lastData.targets)
        {
            targetsBasedOnHealth.Add(target);
        }

        // Check if any of the players have their health at 50 or below
        if (targetsBasedOnHealth[0].health > 50)
            return;
        else
        {
            // If so, check if the player with the lowest health is in a certain range
            if (CalcDistance(targetsBasedOnHealth[0]) < targetRange)
            {
                // Then make that the target
                currentTarget = targetsBasedOnHealth[0];
            }

        }


        lastData.LookAt(lastData.targets[0]); 
        lastData.Shoot(true);

        /*

        int rand = Random.Range(0, 600);

        if (rand == 16)
        {
            lastData.Rotate(true, 105);
        }

        else
        {
            if (CalcDistance(target) > 8.0f)
            {
                lastData.LookAt(data.targets[target]);
                lastData.MoveTo(data.targets[target]);

                lastData.Shoot(true);
            }
            else
            {
                lastData.BackOff(data.targets[target]);
            }
        }
        */
    }

    private float CalcDistance(Target target)
    {
        return Vector3.Distance(lastData.me.position, target.position);
    }
}
