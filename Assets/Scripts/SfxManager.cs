using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    //Select pitch and volume
    public float lowPitchRange = 0.75f;
    public float highPitchRange = 1.25f;
    public float volumeValue;

    //Player SFX
    public AudioSource Chicken1;
    public AudioSource Chicken2;

    public AudioSource Hit;
    public AudioSource Hit2;

    public AudioSource Death;
    public AudioSource StartRound;

    public AudioSource ShotRocket;
    public AudioSource SoaringRocket;
    public AudioSource Explosion;
    public AudioSource ShotGun;
    public AudioSource ShotLaser;
    public AudioSource ShotPistol;

    public static SfxManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }


    //Play sound function. Only has one sound!
    public void PlaySound(AudioSource sound)
    {
        sound.pitch = Random.Range(lowPitchRange, highPitchRange);
        sound.Play(0);
    }
}
