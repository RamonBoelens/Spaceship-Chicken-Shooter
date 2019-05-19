using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BrainLuuk : BrainBaseRando
{
    private BrainDataRando lastData;
    public override void UpdateData(BrainDataRando data)
    {
        lastData = data;
        data.logMessage($"Updating at {data.me.position}. I can see {data.targets.Length}");
        data.goTo(new Vector3(3, 0, 0));
    }
}