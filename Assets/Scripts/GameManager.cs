using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public Text scoretext;
    public GameObject playButton;
    public Text gameover;
    public Player player;
    public Spawning spawning;
    public Sprite OffSprite;
    public Sprite OnSprite;
    public Button but;
    public Text highscore;
    public Text highest;
    public int record;

    public void Awake() {
        Application.targetFrameRate = 144;
        gameover.text = "Flappy Ryuk";
        player = FindObjectOfType<Player>();
        spawning = FindObjectOfType<Spawning>();

        Pause();
    }

    public void Play()
    {
        if (but.image.sprite == OnSprite)
            but.image.sprite = OffSprite;
        else
        {
            but.image.sprite = OnSprite;
        }


        score = 0;
        scoretext.text = score.ToString();

        playButton.SetActive(false);
        gameover.text = "";
        highscore.text = "";
        highest.text = "";

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void GameOver()
    {
        playButton.SetActive(true);
        gameover.text = "GAME OVER";
        highest.text = "highest score";
        highscore.text = record.ToString();
        Pause();
    }

    public void IncreaseScore(int scores)
    {
        score += scores;
        scoretext.text = score.ToString();
        if (score > record)
        {
            record = score;
        }
    }

}