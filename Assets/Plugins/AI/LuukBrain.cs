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
    private bool FreeFire;

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

        if (!Start)
        {
            GetRandomTarget();
            FreeFire = true;
            Start = true;
        }
        
        if (Start)
        {
            lastData.LookAt(lastData.targets[RandomizedTargetID]);
            lastData.MoveTo(lastData.targets[RandomizedTargetID]);
            if (FreeFire)
            {
                lastData.Shoot(true);
            }
            else
            {
                lastData.Shoot(false);
            }
        }

        if (!lastData.targets[RandomizedTargetID].alive)
        {
            GetRandomTarget();
        }

        FreeFire = false;

        if (lastData.me.health < 50)
        {
            lastData.BackOff(lastData.targets[RandomizedTargetID]);
            FreeFire = false;
            GetRandomTarget();
            StartTiming = true;
            if (TimingCompleted)
            {
                FreeFire = true;
            }
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
            LogTimeToPass(2);
        }
        if (GameTime >= TimeToPass && TimeBool)
        {
            TimeBool = false;
            StartTiming = false;
            TimingCompleted = true;
        }
        void LogTimeToPass(float PassTime)
        {
            TimeToPass = GameTime + PassTime;
        }
    }
}
