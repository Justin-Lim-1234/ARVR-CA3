using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public PlayerController pc;
    public GameObject winBox, loseBox, mainBox;
    public GameObject city;
    public GameObject aliens;
    public bool pause = false;
    public bool gameOver = false;
    public bool win = false, lose = false;
    public float numOfAliens;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        aliens.SetActive(!gameOver);

        numOfAliens = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                numOfAliens = 0;
            }

            if (Input.GetButtonDown("LeftGripPress"))
            {
                pause = !pause;
                pc.shieldUp = pause;

            }

            if (numOfAliens <= 0)
            {
                win = true;
                gameOver = true;
                winBox.transform.position = player.transform.position;
                winBox.SetActive(win);
            }

            if (pc.isDead)
            {
                lose = true;
                gameOver = true;
                loseBox.transform.position = player.transform.position;
                loseBox.SetActive(lose);

            }

            if (gameOver)
            {
                city.SetActive(false);
            }

        }
    }

    public void Play()
    {
        mainBox.SetActive(false);
        city.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Reset()
    {
        winBox.SetActive(false);
        loseBox.SetActive(false);
        city.SetActive(false);
        win = lose = gameOver = false;
    }
}
