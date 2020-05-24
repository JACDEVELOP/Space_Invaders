using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestarLevelScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            var textUIComp = GameObject.Find("Score").GetComponent<Text>();

            int score = int.Parse(textUIComp.text);

            score = 0;

            textUIComp.text = score.ToString();
            GameOverScript.isPlayerDead = false;
            Time.timeScale = 1;
            SceneManager.LoadScene("MainScene");
        }
    }
}
