using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit_Trigger : MonoBehaviour
{
    public float attackDmg = 0;



    // Update is called once per frame
    void Update()
    {
      
    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            pc.TakeDamage(attackDmg);
            print("Player has taken damage from spit");
            Destroy(this.gameObject);

        }
        else
        {
            print("Unable to find object");

        }
        if (collision.gameObject.tag != "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

}