using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float health = 100f;
    public bool isDead = false;

    public float energy = 100f;
    public float energyChargeCD = 1.5f;
    public float energyUse = 25f;
    public bool shieldUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            isDead = true;
        }

        HealthManager();
        ShieldEnergy();
    }

    private void ShieldEnergy()
    {
        float triggerLeft = Input.GetAxis("RightTrigger");

        if (triggerLeft >= 0.9f && energy > 0)
        {
            shieldUp = true;
            energy -= energyUse * Time.deltaTime;
            energyChargeCD = 1.5f;
            Debug.Log("Shield up");
        }

        else
        {
            shieldUp = false;
        }

        if (!shieldUp && energyChargeCD <= 0 && triggerLeft < 0.9f)
        {
            energy += energyUse * Time.deltaTime;

            if (energy >= 50)
            {
                energy = 50;
            }
        }

        else
        {
            energyChargeCD -= Time.deltaTime;
        }
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
    }

    public void HealthManager()
    {
        if (health <= 0)
        {
            isDead = true;
        }
    }
}
