using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Ramon Brain AI", menuName = "Brains/Ramon Brain AI")]
public class RamonBrain : BrainBase
{
    private BrainData lastData;

    public float targetRange = 15.0f;
    public float shootingRange = 10.0f;

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
            public Action<Vector3> MoveToLocation;
         */

        lastData = data;

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

        // Check if my own health is 50 or higher
        if (lastData.me.health >= 50)
        {
            // Get a target
            GetTarget();

            // Check if the target is outside a certain range
            if (CalcDistance(currentTarget) > shootingRange)
                // If so, move towards that target
                lastData.MoveTo(currentTarget);
            // If the target is inside that range then look at it and shoot
            else
            {
                lastData.LookAt(currentTarget);
                lastData.Shoot(true);
            }
        }
        // If it's 50 or lower then check the closest target is closer than a certain range
        else if (CalcDistance(targetsBasedOnDist[0]) < shootingRange)
            // Back away from that target
            lastData.BackOff(targetsBasedOnDist[0]);
        // Else shoot at the closest target
        else
        {
            lastData.LookAt(targetsBasedOnDist[0]);
            lastData.Shoot(true);
        }

        // Clear the lists for the next update
        foreach (Target target in lastData.targets)
        {
            targetsBasedOnDist.Remove(target);
        }

        foreach (Target target in lastData.targets)
        {
            targetsBasedOnHealth.Remove(target);
        }
    }

    private void GetTarget()
    {
        // Check if any of the players have their health at 50 or below
        if (targetsBasedOnHealth[0].health <= 50)
        {
            // If, so check if the player with the lowest health is in a certain range
            if (CalcDistance(targetsBasedOnHealth[0]) < targetRange)
                // Then make that the target
                currentTarget = targetsBasedOnHealth[0];
            // Else check if the second player has their health at 50 or below
            else if (targetsBasedOnHealth[1].health <= 50)
                // If, so check if the player with the lowest health is in a certain range
                if (CalcDistance(targetsBasedOnHealth[1]) < targetRange)
                    // Then make that the target
                    currentTarget = targetsBasedOnHealth[1];
                // Else check if the third player has their health at 50 or below
                else if (targetsBasedOnHealth[2].health <= 50)
                    // If, so check if the player with the lowest health is in a certain range
                    if (CalcDistance(targetsBasedOnHealth[2]) < targetRange)
                        // Then make that the target
                        currentTarget = targetsBasedOnHealth[2];
        }
        // If none of the players with their health at or below 50 are in a certain range, then target the closet player
        else
        {
            currentTarget = targetsBasedOnDist[0];
        }
    }

    private float CalcDistance(Target target)
    {
        return Vector3.Distance(lastData.me.position, target.position);
    }
}
