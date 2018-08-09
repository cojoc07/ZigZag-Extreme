using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UiManager : MonoBehaviour {

    public static UiManager instance;
    public bool started = false;


    public GameObject titleText;

    public GameObject gameoverPanel;

    public GameObject tapText;

    public Text score;
    public Text highscoreTitle, highscoreGameover;
    public Text gamesPlayed;


    //facem uimanager singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        //afisam scorul in title
        highscoreTitle.text = "Highscore: " + ScoreManager.instance.GetHighscore().ToString();

        UiManager.instance.gamesPlayed.text = "Games played: " + ScoreManager.instance.GetGamesPlayed().ToString();

    }


   
    void Start () {
        
    }
	
	void Update () {
		
	}

    public void GameStart()
    {
        started = true;

        //Ascundem interfata
        tapText.GetComponent<Animator>().Play("tap_down");
        titleText.GetComponent<Animator>().Play("title_up");
        highscoreTitle.GetComponent<Animator>().Play("highscore_up");

        if (PlayerPrefs.HasKey("gamesplayed"))
        {
            PlayerPrefs.SetInt("gamesplayed", PlayerPrefs.GetInt("gamesplayed") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("gamesplayed", 1);
        }
       
        
    }

    public void GameOver()
    {
        //afisam panoul de gameover
        gameoverPanel.SetActive(true);
        started = false;

        //Salvam scorul, afisam highscore si scorul curent
        ScoreManager.instance.SaveScore();
        highscoreGameover.text = ScoreManager.instance.GetHighscore().ToString();
        score.text = ScoreManager.score.ToString();
    } 

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    /////////////////////////////////
    // BUTOANE WORLD CANVAS /////////
    /////////////////////////////////

    public void ChangeDifficulty()
    {
        print("Ai schimbat dificultatea");
    }

    

}
