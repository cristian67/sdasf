using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool gameOver;
    public bool gameWin;


    public AnimCanvas animCanvas;
    public GameObject GameOverCutscene;
    public GameObject GameCutscene;
    public GameObject GameWinCutscene;

    public PlayerController player { get; private set; }
    public float scrollSpeed = -1.5f;

    private int score;
    public Text scoreText;


    //Singleton
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("Instancia es null");
            }

            return instance;
        }
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        instance = this;
    }

    void Update()
    {

        if (gameOver) {
            animCanvas.CanvasAnimDead();
            GameOverCutscene.SetActive(true);
            GameCutscene.SetActive(false);
            if (gameOver && Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (gameWin)
        {
            GameWinCutscene.SetActive(true);
            GameCutscene.SetActive(false);
        }
       
    }

    public void PlayerScore()
    {
        if (gameOver) { return; }
        score++;
        scoreText.text = "Score: " + score;
        //SoundSystem.instance.PlayCoin();
    }

    public void PlayerDie()
    {
        gameOver = true;
    }

    public void PlayerWin()
    {
        gameWin = true;
    }

    private void OnDestroy()
    {
        if (GameManager.instance == this)
        {
            GameManager.instance = null;
        }
    }

}
