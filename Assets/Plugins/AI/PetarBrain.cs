using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Petar Brain AI", menuName = "Brains/Petar Brain AI")]
public class PetarBrain : BrainBase
{
    private BrainData lastData;

	


	public override void UpdateData(BrainData data)
    {
		lastData = data;

		int enemy = 0;
		int currentTime = 0;
		int randomTime = Random.Range(15,40);

		int timeToSwitch = 20 + currentTime;


		void StartLookingForEnemy()
		{	
			
			lastData.LookAt(lastData.targets[enemy]);
		}


		


		if (Vector3.Distance(data.me.position, data.targets[enemy].position) > 4f)
		{
			lastData.MoveTo(lastData.targets[enemy]);
			lastData.Shoot(true);
		} else if (Vector3.Distance(data.me.position, data.targets[enemy].position) < 4f)
		{
			lastData.Shoot(false);
			lastData.LookAway(lastData.targets[enemy]);
			lastData.ThrustForward(3);
		}

		
		

		if (Time.time >= timeToSwitch)
		{
			enemy = enemy + 1;
			currentTime = (int) Time.time;
			lastData.LookAt(lastData.targets[enemy]);
			
		}

		//Debug.Log(enemy);
		//Debug.Log(timeToSwitch);
		//Debug.Log(currentTime);


		//Debug.Log(timeToSwitch);










		//if (Vector3.Distance(data.me.position, data.targets[enemy].position) > 8f)
		//{
		//	if (enemy < 1)
		//	{
		//		enemy = enemy + 1;
		//		ChooseTarget();
		//	} else if (enemy == 2)
		//	{
		//		enemy = 1;
		//		ChooseTarget();
		//	}


		//}









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
	}
}