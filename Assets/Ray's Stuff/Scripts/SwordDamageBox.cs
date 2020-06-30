using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamageBox : MonoBehaviour
{
    public int SwordDps = 30;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 8)
        {
            Debug.Log("Hit");
            Health healthenemy =  col.gameObject.GetComponent<Health>();
            healthenemy.currenthealth -=  SwordDps;

        }

    }
}
