using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamageBox : MonoBehaviour
{
    public int SwordDps = 20;
    public GameObject bloodObj;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 8)
        {
            Debug.Log("Hit");
            Health healthenemy =  col.gameObject.GetComponent<Health>();
            ParticleSystem blood = bloodObj.GetComponent<ParticleSystem>();
            blood.Play();
            healthenemy.currenthealth -=  SwordDps;

        }

    }
}
