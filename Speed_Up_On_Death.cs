using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Up_On_Death : MonoBehaviour
{

    public GameObject GameController;
    private ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var velocityOverLifetime = ps.velocityOverLifetime;
        if (GameController.GetComponent<Game_Controller>().gameOver == true)
        {
            velocityOverLifetime.speedModifierMultiplier = 0;
        }
        else if (GameController.GetComponent<Game_Controller>().youWin == true)
        {
            velocityOverLifetime.speedModifierMultiplier = 9;
        }
    }
}
