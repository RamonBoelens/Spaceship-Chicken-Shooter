using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

[CreateAssetMenu(fileName = "Luuk Brain AI", menuName = "Brains/Luuk Brain AI")]
public class LuukBrain : BrainBase
{
    private BrainData lastData;


    private int TargetAmount;
    private int RandomizedTargetID;

    private float GameTime;
    private float PassTime;
    private float TimeToPass;
    private bool TimeBool;
    private bool StartTiming;
    private bool TimingCompleted;

    private bool Start;

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

        for (TargetAmount = 1; TargetAmount < lastData.targets.Length; TargetAmount++)
        {
            TargetAmount++;
        }
        //Debug.Log("Targets " + TargetAmount);


        if (!Start)
        {
            GetRandomTarget();
            Start = true;
        }
        
        if (Start)
        {
            lastData.LookAt(lastData.targets[RandomizedTargetID]);
            lastData.MoveTo(lastData.targets[RandomizedTargetID]);
            lastData.Shoot(true);
        }

        if (!lastData.targets[RandomizedTargetID].alive)
        {
            GetRandomTarget();
        }

        void GetRandomTarget()
        {
            RandomizedTargetID = UnityEngine.Random.Range(0, TargetAmount);
        }


        GameTime = Time.time;
        if (StartTiming && !TimeBool)
        {
            TimingCompleted = false;
            TimeBool = true;
            LogTimeToPass(1);
        }
        if (GameTime >= TimeToPass && TimeBool)
        {
            //Debug.Log("Second has passed");
            TimeBool = false;
            StartTiming = false;
            TimingCompleted = true;
        }
        void LogTimeToPass(float PassTime)
        {
            //Debug.Log("Start passing");
            TimeToPass = GameTime + PassTime;
        }
        // Figure out Music BPM & Time.time
    }
}
