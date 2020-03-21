using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetHighScoreText : MonoBehaviour
{
    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        if (scoreText != null)
            scoreText.text = PlayerPrefs.GetInt("highScore", 0).ToString();
        else
            Debug.Log("No High score text found");
    }
}
