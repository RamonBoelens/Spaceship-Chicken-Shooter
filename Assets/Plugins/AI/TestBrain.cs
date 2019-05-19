using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TestBrain : BrainBase
{
    private BrainData lastData;

    public override void UpdateData(BrainData data)
    {
        lastData = data;
    }
}
