using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<Chicken> chickens = new List<Chicken>();

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        SfxManager.instance.PlaySound(SfxManager.instance.StartRound);
    }

    public void AssignChickens(Chicken chicken)
    {
        chickens.Add(chicken);
    }

    public void CallDamageChicken(int ID, int damage)
    {
        chickens[ID].DamageChicken(damage);
    }
}
