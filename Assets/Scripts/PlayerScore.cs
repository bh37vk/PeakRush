using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore instance;

    public GameObject player;
    public TMP_Text scoreText;
    public TMP_Text scoreText2;
    public TMP_Text highscoreText;
    private int playerScore;

    int highscore;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        playerScore = player.GetComponent<RagdollDeath>().playerScore;
        scoreText.text = playerScore.ToString();
        scoreText2.text = playerScore.ToString();
        highscoreText.text = highscore.ToString();
        if (highscore < playerScore)
        {
            PlayerPrefs.SetInt("highscore", playerScore);
        }
    }
}
