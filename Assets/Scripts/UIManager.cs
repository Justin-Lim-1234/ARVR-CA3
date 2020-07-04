using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerController pc;

    public GameObject shieldfx;
    public Slider healthbar;
    public Slider energybar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = pc.health / 100;
        energybar.value = pc.energy / 100;

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
