using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject cam;

    float horizontalInput;
    float verticalInput;

    public float moveSpeed = 5f;
    public float health = 100f;
    public bool isDead = false;

    public float energy = 100f;
    public float energyChargeCD = 1.5f;
    public float energyUse = 20f;
    public bool shieldUp = false;

    public CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("LeftTrackpadHorizontal");
        verticalInput = Input.GetAxis("LeftTrackpadVertical");

        HealthManager();
        ShieldEnergy();
    }

    void FixedUpdate()
    {
        Quaternion rot = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0);
        Vector3 move = rot * new Vector3(horizontalInput, 0, verticalInput);
        cc.Move(move * moveSpeed * Time.deltaTime);
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

        if (!shieldUp && energyChargeCD <= 0)
        {
            energy += energyUse * Time.deltaTime;
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
