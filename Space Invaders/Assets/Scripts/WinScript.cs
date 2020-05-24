using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    private Text win;
    // Start is called before the first frame update
    void Start()
    {
        win = GetComponent<Text>();
        win.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        var textUIComp = GameObject.Find("Score").GetComponent<Text>();

        int score = int.Parse(textUIComp.text);
        if (score == 200)
        {
            Time.timeScale = 0;
            win.enabled = true;
        }
    }
}
