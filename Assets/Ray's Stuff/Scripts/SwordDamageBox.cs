using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamageBox : MonoBehaviour
{
    public int SwordDps = 30;


    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
          Health healthenemy =  collider.gameObject.GetComponent<Health>();
            healthenemy.currenthealth -=  SwordDps;

        }

    }
}
