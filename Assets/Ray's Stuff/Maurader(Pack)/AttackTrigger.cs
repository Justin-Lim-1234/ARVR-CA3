using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    private int count = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        //if (count > 0)
        //{
        if (collision.gameObject.tag == "Player")
        {
            print("Player has taken damage");
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();

            if (!pc.shieldUp)
            {
                pc.TakeDamage(15);
            }

            //count = 0;

        }
        else
        {
            print("Unable to find object");

        }


        //}

    }
}
