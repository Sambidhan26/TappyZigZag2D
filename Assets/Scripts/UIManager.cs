using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    AudioSource audioUI;
    public GameObject zigZagPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public GameObject scorePanel;
    //public GameObject diamondScore;
    //public GameObject diamondPanel;
    //public GameObject scoreObject;

    public Text score;
    public Text normalScore;
    public Text highScore;
    //public Text diamondScore;
    //public Text highScore2;
    // Start is called before the first frame update

    private void Awake()
    {
        highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
    void Start()
    {

        audioUI = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
        }


        //audioUI = GetComponent<AudioSource>();

        NormalScore();
        //normalScore.text = "NORMAL SCORE: " + PlayerPrefs.GetInt("Score").ToString();
        //highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore").ToString();

        //ScoreManager.instance.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //score.text = ScoreManager.instance.score.ToString();
    }

    public void GameStart()
    {
        //highScore.text = PlayerPrefs.GetInt("Score").ToString();
        normalScore.text = PlayerPrefs.GetInt("Score").ToString();
        //ScoreManager.instance.score.ToString();
        zigZagPanel.SetActive(false);
        tapText.SetActive(false);
        scorePanel.SetActive(true);
        audioUI.Play();
        //diamondPanel.SetActive(false);
        //diamondPanel.SetActive(true);
        //zigZagPanel.GetComponent<Animator>().Play("PanelAnim");

    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("Score").ToString();
        //highScore.text = PlayerPrefs.GetInt("Diamond").ToString();
        normalScore.text = PlayerPrefs.GetInt("Score").ToString();
        //diamondScore.text = PlayerPrefs.GetInt("Diamond").ToString();
        
        gameOverPanel.SetActive(true);
        scorePanel.SetActive(false);
        audioUI.Stop();
        //diamondPanel.SetActive(true);


        
    }

    public void NormalScore()
    {
        normalScore.text = "NORMAL SCORE: " + PlayerPrefs.GetInt("Score").ToString();
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }


}