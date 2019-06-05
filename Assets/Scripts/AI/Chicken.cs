using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    private Rigidbody rb;

    #region Rando's Code

    /*
     * Code used from the example used in class by Rando
     * 
     */

    public BrainBase brain;
    private BrainData data;

    public bool IsAlive { get; private set; }
    public int health { get; private set; }

    public List<Weapon> availableWeapons;
    public Weapon currentWeapon { get; private set; }
    public GameObject BulletSpawnPoint;

    private float cooldown = 1.0f;
    private Vector3 spawnLocation;


    private void Start()
    {
        IsAlive = true;
        health = 100;

        rb = GetComponent<Rigidbody>();
        currentWeapon = availableWeapons[0];

        // Actions
        data.ThrustForward = ThrustForward;
        data.Rotate = Rotate;
        data.LookAt = LookAt;
        data.LookAway = LookAway;
        data.MoveTo = MoveTo;
        data.BackOff = BackOff;
        data.Shoot = Shoot;

        GameManager.instance.AssignChickens(this);

        SetSpawnLocation();
    }

    public void Update()
    {
        GatherData();
        GatherTargets();
        UpdateBrain();

        cooldown -= Time.deltaTime;
    }

    private void GatherData()
    {
        data.me = MakeTarget(this);
    }

    //Gives us a list of robots we can actually see
    private void GatherTargets()
    {
        data.targets = FindObjectsOfType<Chicken>().Where(CanSee).Select(MakeTarget).ToArray();
    }

    private bool CanSee(Chicken chicken)
    {
        // Ray casts etc.
        if (chicken == this) return false;
        return true;
    }

    private Target MakeTarget(Chicken chicken)
    {
        return new Target
        {
            position = chicken.transform.position,
            rotation = chicken.transform.rotation,
            alive = chicken.IsAlive,
            health = chicken.health
        };
    }

    private void UpdateBrain()
    {
        brain.UpdateData(data);

        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        //transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.y, 0));
    }

    #endregion

    private int thrust = 20;
    private float rotationSpeed = 2.0f;

    private void ThrustForward(int timeInFrames)
    {
        int i = 0;
        while (i < timeInFrames)
        {
            rb.AddForce(transform.forward * thrust);
            i++;
        }
    }

    private void Rotate(bool rotateClockwise, int degrees)
    {
        if (rotateClockwise)
        {
            transform.Rotate(new Vector3 (0, degrees, 0));
        }
        else
        {
            transform.Rotate(new Vector3(0, -degrees, 0));
        }
    }

    private void LookAt(Target target)
    {
        Vector3 targetDir = target.position - transform.position;

        float step = rotationSpeed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        newDir.y = 0.0f;
        Debug.DrawRay(transform.position, newDir, Color.red);

        transform.rotation = Quaternion.LookRotation(newDir);
    }
    
    private void LookAway(Target target)
    {
        Vector3 targetDir = target.position - transform.position;

        float step = rotationSpeed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, -targetDir, step, 0.0f);
        newDir.y = 0.0f;
        Debug.DrawRay(transform.position, newDir, Color.red);

        transform.rotation = Quaternion.LookRotation(newDir);
    }

    private void MoveTo(Target target)
    {
        LookAt(target);

        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            return;
        }

        rb.AddForce(transform.forward * thrust);
    }

    private void BackOff(Target target)
    {
        LookAway(target);
        ThrustForward(1);
    }

    private void Shoot(bool usePrimary)
    {
        if (cooldown < 0)
        {
            currentWeapon.Shoot(transform, BulletSpawnPoint);
            cooldown = currentWeapon.FireRate;
        }
    }

    public void DamageChicken(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            transform.position = spawnLocation;
            health = 100;
            SfxManager.instance.PlaySound(SfxManager.instance.Death);

            if (brain.name == "Martijn Brain AI")
                ScoreManager.instance.MartijnScoring();

            else if (brain.name == "Petar Brain AI")
                ScoreManager.instance.PetarScoring();

            else if (brain.name == "Luuk Brain AI")
                ScoreManager.instance.LuukScoring();

            else if (brain.name == "Ramon Brain AI")
                ScoreManager.instance.RamonScoring();
        }
        else
        {
            int rand = Random.Range(0, 1);

            if (rand == 0)
                SfxManager.instance.PlaySound(SfxManager.instance.Hit);
            else
                SfxManager.instance.PlaySound(SfxManager.instance.Hit2);
        }
    }

    private void SetSpawnLocation()
    {
        spawnLocation = transform.position;
    }
}
