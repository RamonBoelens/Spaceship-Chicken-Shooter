using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{


    public int MartijnScore;
    public int RamonScore;
    public int LuukScore;
    public int PetarScore;

    public Text MScoreText;
    public Text RScoreText;
    public Text LScoreText;
    public Text PScoreText;

    public static ScoreManager instance = null;

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
        MScoreText.text = MartijnScore.ToString();
        RScoreText.text = RamonScore.ToString();
        LScoreText.text = LuukScore.ToString();
        PScoreText.text = PetarScore.ToString();
    }
    
    public void MartijnScoring()
    {
        MartijnScore -= 1;
        MScoreText.text = MartijnScore.ToString();
}
    public void LuukScoring()
    {
        LuukScore -= 1;
        LScoreText.text = LuukScore.ToString();
    }
    public void RamonScoring()
    {
        RamonScore -= 1;
        RScoreText.text = RamonScore.ToString();
    }
    public void PetarScoring()
    {
        PetarScore -= 1;
        PScoreText.text = PetarScore.ToString();
    }



}



