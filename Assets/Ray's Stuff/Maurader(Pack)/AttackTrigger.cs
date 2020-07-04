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
                PlayerController pc = GetComponent<PlayerController>();
                pc.TakeDamage(20);
                count = 0;

            }
            else
            {
                print("Unable to find object");

            }
            

        //}
       
    }
}
