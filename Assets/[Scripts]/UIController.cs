using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{

    public TMP_Text scoreText;
    public TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + GameManager.Instance.score;
        int min = (int)GameManager.Instance.timer / 60;
        int sec = (int)GameManager.Instance.timer % 60;

        timerText.text = min + "." + sec;
    }
}
