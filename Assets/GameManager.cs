﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private List<Chicken> chickens = new List<Chicken>();

    public List<Text> healthTexts = new List<Text>();

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

    public void UpdateHealthText()
    {
        for (int i = 0; i < healthTexts.Count; i++)
        {
            healthTexts[i].text = "Health: " + chickens[i].health;
        }
    }
}
