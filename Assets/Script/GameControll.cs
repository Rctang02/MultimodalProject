using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControll : MonoBehaviour
{

    private Text scoreText;
    public Text finalScoreText;
    public int  scoreAmount = 0;
    private float timer = 0.0f;
    private int  scoreSum;
    private int finalScore;
    public GameObject gameoverUI;
    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        gameoverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int seconds = (int) (timer % 60);
        scoreSum = scoreAmount + seconds;
        scoreText.text = "Score: " + scoreSum;
    }

    public void Restart() {
        finalScore = scoreSum;
        finalScoreText.text = "Final Score: " + finalScore;
        scoreText.gameObject.SetActive(false);
        spawner.SetActive(false);
        gameoverUI.SetActive(true);
        
    }
}
