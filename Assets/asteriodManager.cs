using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteriodManager : MonoBehaviour {
    public List<Asteriod> AliveAsteriods;

    public static asteriodManager instance = null;
    public GameObject astroidPF;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        //while (AliveAsteriods.Count <10)
      //  {
            spawnAsteriod();
        spawnAsteriod();
        spawnAsteriod();
        spawnAsteriod();
        spawnAsteriod();
        spawnAsteriod();
        spawnAsteriod();
        spawnAsteriod();

        // }
    }
    public void Enroll(Asteriod  asteriod)
    {
        AliveAsteriods.Add(asteriod);
    }
  

    public void Unroll(Asteriod asteriod)
    {
        AliveAsteriods.Remove(asteriod);

        CheckAsteriods();

    }
    
    public void CheckAsteriods()
    {
        if (AliveAsteriods.Count < 10)
        {
            spawnAsteriod();

        }
    }
    
    public void spawnAsteriod()
    {
        
        int xpos = Random.Range(-30, 30);
        int zpos = Random.Range(-20, 20);

        GameObject go = Instantiate(astroidPF, new Vector3(xpos, 0, zpos), Quaternion.identity);
        go.transform.rotation = Random.rotation;
    }

}
