using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //creates variables that are able to be changed in the engine for game balancing
    public float maxTime = 1;
    private float timer = 0;
    public GameObject GameOverCanvas;
    public GameObject WinCanvas1;
    public GameObject WinCanvas2;
    public GameObject WinCanvas3;
    public GameObject fastBulletSpawner;
    public GameObject slowBulletSpawner;
    public PlayerMovement playerMove;
    public Text scoreText;
    public float score;
    private float score2;
    public float timeScore;
    public float winCondition1;
    public float winCondition2;
    public float winCondition3;
    public AudioSource loseSound;

    //Allows time to move and displays the score
    public void Start()
    {
        Time.timeScale = 1;
        scoreText.text = ("SCORE: " + score.ToString());
        
    }

    //When the player loses, displays some text and plays a sound
    public void GameOver()
    {
        GameOverCanvas.SetActive(true);
        loseSound.Play();
    }

    //Reloads the scene when the player chooses to do so
    public void Replay()
    {
        SceneManager.LoadScene(1);
    }

    //Update runs once per frame
    void Update()
    { 
        //quits the game when escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //increments the score based on time
        if (timer > maxTime)
        {
            timeScore+= 1;
            score+= 1;
            score2+= 1;
            timer = 0;
        }

        //sciplays the score when it changes
        timer += Time.deltaTime;
        scoreText.text = ("SCORE: " + score.ToString());

        //adds new challenges to the game when the player survives for a certain amount of time
        if (timeScore >= winCondition1) 
        {
            Level1Clear();
        }

        if (timeScore >= winCondition2)
        {
            Level2Clear();
        }

        if (timeScore >= winCondition3)
        {
            Level3Clear();
        }

        /*if (score2 >= oneUpScore)
        {
            playerMove.OneUp();
            score2 = 0;
        }*/
    }

    //enables fast bullets
    public void Level1Clear()
    {
        WinCanvas1.SetActive(true);
        fastBulletSpawner.gameObject.SetActive(true);
    }

    //enables slow, big bullets
    public void Level2Clear()
    {
        WinCanvas2.SetActive(true);
        slowBulletSpawner.gameObject.SetActive(true);
    }

    //the player wins and the score is abel to be stored in a leaderboard
    public void Level3Clear()
    {
        PlayerPrefs.SetFloat("FinalScore", score);
        SceneManager.LoadScene(6);
        //Time.timeScale = 0;
    }

    //adds score to the player
    public void CoinCollected()
    {
        score += 300;
        score2 += 300;
    }

    //returns the player to the main menu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }


}
