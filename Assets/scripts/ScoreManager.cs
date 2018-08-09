using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;
    public static int score, highscore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    

	// Use this for initialization
	public void NewGame () {
        score = 0;
        PlayerPrefs.SetInt("score", score);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SaveScore()
    {
        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("highscore"))
        {
            if (score > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    public int GetHighscore()
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            return PlayerPrefs.GetInt("highscore");
        }
        return score;
        
    }

    public int GetGamesPlayed()
    {
        if (PlayerPrefs.HasKey("gamesplayed"))
        {
            return PlayerPrefs.GetInt("gamesplayed");
        }
        return 0;
    }
}
