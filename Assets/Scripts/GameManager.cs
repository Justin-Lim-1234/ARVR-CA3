using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController pc;
    public bool pause = false;
    public bool gameOver = false;
    public float numOfAliens;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            if (Input.GetButtonDown("LeftGripPress"))
            {
                pause = !pause;
                pc.shieldUp = pause;

            }

            numOfAliens = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (numOfAliens <= 0 || pc.isDead)
            {
                gameOver = true;
            }
        }
    }
}
