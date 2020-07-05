﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerController pc;
    public GameManager gm;

    public GameObject shieldfx;
    public Image healthbar;
    public Image energybar;
    public Text numOfAliensTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = pc.health / 100;
        energybar.fillAmount = pc.energy / 50;
        numOfAliensTxt.text = "Aliens Left: " + gm.numOfAliens;

        if (pc.shieldUp)
        {
            shieldfx.SetActive(pc.shieldUp);
        }

        else
        {
            shieldfx.SetActive(pc.shieldUp);
        }
    }
}
