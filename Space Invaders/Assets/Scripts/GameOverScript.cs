using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public static bool isPlayerDead;
    private Text gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = GetComponent<Text>();
        gameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDead)
        {
            //El time scale lo que hara es congelar la pantalla
            //esto es para que los aliens no se muevan
            Time.timeScale = 0;
            gameOver.enabled = true;
        }
        
    }
}
