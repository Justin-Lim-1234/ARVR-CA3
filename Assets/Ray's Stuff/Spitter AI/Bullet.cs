using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed= 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0, 0, Speed);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("Spit hit player");
            PlayerController pc = col.gameObject.GetComponent<PlayerController>();
            if (!pc.shieldUp)
            {
                pc.TakeDamage(10);
            }

        }

        if (col.gameObject.layer == 12)
        {
            Destroy(gameObject);

        }
    }
}
