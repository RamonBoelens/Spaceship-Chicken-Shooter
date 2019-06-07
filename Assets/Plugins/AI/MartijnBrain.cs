using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Martijn Brain AI", menuName = "Brains/Martijn Brain AI")]
public class MartijnBrain : BrainBase
{
    private BrainData lastData;
    private Target[] CurrentTargets;
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
        // Converts The all Target array into a new array to not edit the array for everyone
        // After this using Linq order method to sort on health
        CurrentTargets = lastData.targets;
        CurrentTargets = CurrentTargets.OrderBy(x => x.health).ToArray();
        // Go forwards
        lastData.ThrustForward(1);


        // using location of itself and the position of the first in the new array to see if they are realy close to itself to prevent targeting itself
        // after this looking towards this enemy
        if (Vector3.Distance(data.me.position, CurrentTargets[0].position) < 2.0f)
        {

            lastData.LookAt (CurrentTargets[1]);
        }

        else if  (Vector3.Distance(data.me.position, CurrentTargets[0].position) > 2.0f)
        {
            lastData.LookAt(CurrentTargets[0]);
        }
            
        // Same way of checking again and if low health backing off if its close 
         if (lastData.me.health < 25 && Vector3.Distance(data.me.position, CurrentTargets[0].position) < 2.0f && Vector3.Distance(data.me.position, CurrentTargets[1].position) < 10.0f)
        {
            Debug.Log("useles");
            lastData.BackOff(CurrentTargets[1]);
        }
        if (lastData.me.health < 25 && Vector3.Distance(data.me.position, CurrentTargets[0].position) > 2.0f && Vector3.Distance(data.me.position, CurrentTargets[0].position) < 10.0f)
        {
            lastData.BackOff(CurrentTargets[0]);
        }
            // only shooting if its close
        if ( Vector3.Distance(data.me.position, CurrentTargets[1].position) < 10.0f)
            {
                
                lastData.Shoot(true);
                
            }
        if (CurrentTargets[0].position != lastData.me.position && Vector3.Distance(data.me.position, CurrentTargets[0].position) < 10.0f)
        {
            
                lastData.Shoot(true);
            
        }

    }


}