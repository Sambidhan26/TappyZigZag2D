using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class BallController : MonoBehaviour
{
    public static BallController instance;

    AudioSource player;
    Rigidbody playerRB;
    Transform playerTransform;
    
    public Material playerMaterials;
    //public GameObject particle;
    public int totalCoins;
    public Text diamondScore;
    public Text diamondHighScore;
    public Text totalCoinsText;

    //public Transform groundCheck;
    //public LayerMask groundLayer;
    //public Text highDiamondsScore;

    public GameObject particles;

    
    public float speed;


    public int diamond;
    //public int highDiamond;

    public int diamondIncreaseSpeed = 2;

    public int speedUp = 5;

    //public GameObject[] diamondPrefabs;

    bool started;
    bool gameOver;
    public bool isOnGrounded = true;
    private void Awake()
    {

        //highDiamond = diamond;

        
        playerRB = GetComponent<Rigidbody>();
        player = GetComponent<AudioSource>();
        playerTransform = GetComponent<Transform>();

        //diamondHighScore.text = "DIAMONDS:  " + PlayerPrefs.GetInt("HighDiamond").ToString();
        totalCoinsText.text = "TOTAL DIAMONDS: " + PlayerPrefs.GetInt("TotalDiamond").ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        totalCoins = 0;
        //PlayerPrefs.SetInt("TotalDiamond",diamond);
        diamond = 0;
        PlayerPrefs.SetInt("Diamond", diamond);
        //highDiamond = diamond;
        //diamond = 0;
        //  diamond = diamondIncreaseSpeed;
       
        //diamondScore.text = PlayerPrefs.GetInt("Diamond").ToString();
        started = false;
        gameOver = false;

        //DiamondCheck();

        DiamondIncreaseSpeed();
        //JumpTouch();
        //TotalCoinCollected();

        //PlayerPrefs.SetInt("Diamond", diamond);
        //diamond = 0;
        //playerRB.velocity = new Vector3(speed, 0, 0);
    }


    private void FixedUpdate()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, 3.0f, groundLayer);
        //isGrounded = Physics.OverlapSphere(groundCheck.position, 2.0f,groundLayer);
        
    }
    // Update is called once per frame
    void Update()
    {
        //totalCoinsText.text = "TOTAL DIAMONDS: " + PlayerPrefs.GetInt("TotalDiamond").ToString();
        diamondScore.text = PlayerPrefs.GetInt("Diamond").ToString();
        //diamondScore.text = diamond.ToString();
        //highDiamond = diamond;
        //GameSartedOnTouch();

        if (playerTransform.position.y < -1.0f)
        {
            UIManager.instance.NormalScore();
            ScoreManager.instance.StopScore();
            UIManager.instance.GameOver();
            //UIManager.instance.GameStart();
        }

        DiamondIncreaseSpeed();
        DiamondCheck();
        //ChangeBallColor();
        //JumpTouch();
        //TotalCoinCollected();
        //TotalCoinCollected();
        //diamondScore.text = PlayerPrefs.GetInt("Diamond").ToString();

        //Debug.DrawRay(transform.position, Vector3.down, Color.green);

        if (!Physics.Raycast(transform.position, Vector3.down, 20.0f))
        {
            gameOver = true;

            playerRB.velocity = new Vector3(0, -25f, 0);

            Camera.main.GetComponent<CameraFollow>().gameOver = true;

            GameManager.instance.GameOver();

            //Debug.DrawRay(transform.position, Vector3.down, Color.green);
        }
        //if (Input.GetMouseButtonDown(0) && !gameOver)
        //{
        //    SwitchDirection();
        //}
    }

    //void GameSartedOnTouch()
    //{
    //    if (!started)
    //    {
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            playerRB.velocity = new Vector3(speed, 0, 0);

    //            started = true;

    //            GameManager.instance.StartGame();
    //        }
    //    }
    //}

    void SwitchDirection()
    {
        if (playerRB.velocity.z > 0)
        {
            playerRB.velocity = new Vector3(speed, 0, 0);
        }

        else if (playerRB.velocity.x > 0)
        {
            playerRB.velocity = new Vector3(0, 0, speed);
        }
    }


    //ButtonTouch for tap button game starts when touched
    public void ButtonTouch()
    {
        if (!started)
        {
            //if (Input.GetMouseButtonDown(0))
            //{
                playerRB.velocity = new Vector3(speed, 0, 0);

                started = true;

                GameManager.instance.StartGame();
            //}
        }
        if (!gameOver)
        {
            SwitchDirection();
        }

    }


    public void JumpTouch()
    {
        if (started)
        {
            if (isOnGrounded)
            {
                playerRB.AddForce(Vector3.up * 250);
                isOnGrounded = false;
            }
            
            //playerRB.velocity = Vector3.up * 10;
        }

        //if (!started)
        //{
        //    //if (Input.GetMouseButtonDown(0))
        //    //{
        //    playerRB.velocity = new Vector3(speed, 0, 0);
            

        //    started = true;

        //    GameManager.instance.StartGame();
        //    //}
        //}
        //if (!gameOver)
        //{
        //    SwitchDirection();
        //}


        //if (!gameOver)
        //{
        //    Debug.Log("HelloWorld");
        //    //playerRB.AddForce(Vector3.up * 100 * Time.deltaTime);
        //    playerRB.velocity = new Vector3(0, 5, 0);
        //    gameOver = false;
        //}
        //else
        //{
        //    ButtonTouch();
        //    gameOver = true;
        //}
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coins")
        {

            player.Play();
            Instantiate(particles,transform.position,Quaternion.identity);
            //Destroy(particles, 2.0f);
         
            //if(diamond == 5)
            //{
            //    speed += 5;
            //}

            diamond += 1;
            PlayerPrefs.SetInt("Diamond", diamond);

            TotalCoinCollected();
            //PlayerPrefs.SetInt("Diamond", diamond);
            //Debug.Log("Outside");
            //DiamondIncrementScore();
            //if ((int)(diamond % diamondIncreaseSpeed) == 0 && diamond > 0)
            //{
            //    Debug.Log("Hello");
            //    diamondIncreaseSpeed += 5;
            //    speed += speedUp;
            //}
            //GameObject particleIns = Instantiate(particle, other.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(other.gameObject);
            //Destroy(particleIns, 1.0f);

            //Instantiate(particle, other.gameObject.transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Platforms")
        {
            isOnGrounded = true;
        }
        if(collision.gameObject.tag == "VaccumePlatform")
        {
            //Destroy(collision.gameObject);
            Destroy(this.gameObject);
            UIManager.instance.GameOver();
            //UIManager.instance.GameStart();
        }
    }

    //public void DiamondIncrementScore()
    //{
    //    //diamond += 1;
    //    //PlayerPrefs.SetInt("Diamond", diamond);
    //}

    private void DiamondIncreaseSpeed()
    {

        //Debug.Log("Outside");
        if ((diamond % diamondIncreaseSpeed) == 0 && diamond > 0)
        {
            //Debug.Log("Hello");
            diamondIncreaseSpeed += speedUp;
            speed += speedUp;
        }
    }

    private void DiamondCheck()
    {

        //PlayerPrefs.SetInt("HighDiamond", diamond);

        if(diamond > PlayerPrefs.GetInt("HighDiamond"))
        {
            PlayerPrefs.SetInt("HighDiamond", diamond);
        }

        //TotalCoinCollected();
        //CancelInvoke("diamondIncrementScore");
        
        //PlayerPrefs.SetInt("HighDiamond", diamond);

        //if (PlayerPrefs.HasKey("HighDiamond"))
        //{
        //    if (diamond > PlayerPrefs.GetInt("HighDiamond"))
        //    {
        //        PlayerPrefs.SetInt("Diamond", diamond);
        //    }
        //    else
        //    {
        //        PlayerPrefs.SetInt("Diamond", diamond);
        //    }
        //}

        //int compareDiamond = PlayerPrefs.GetInt("HighDiamond",highDiamond);

        //if(diamond > compareDiamond)
        //{
        //    PlayerPrefs.SetInt("HighDiamond", diamond);
        //}
    }

    public void TotalCoinCollected()
    {
        //Debug.Log("HelloWorld");
        totalCoins = PlayerPrefs.GetInt("TotalDiamond", 0);
        totalCoins += 1;
        PlayerPrefs.SetInt("TotalDiamond", totalCoins);
        PlayerPrefs.Save();
    }

    //public void ChangeBallColor()
    //{
    //    //switch(diamond)
    //    //{
    //    //    case 6:
    //    //        playerMaterials.color = Color.green;
    //    //        break;

    //    //    case 10:
    //    //        playerMaterials.color = Color.red;
    //    //        break;

    //    //    case 15:

    //    //        playerMaterials.color = Color.yellow;

    //    //        break;
    //    //    default:

    //    //        playerMaterials.color = Color.black;
    //    //        break;
    //    //}

    //    if(diamond == 6)
    //    {
    //        playerMaterials.color = Color.green;
    //    }
    //    if (diamond == 10)
    //    {
    //        playerMaterials.color = Color.red;
    //    }

    //    if (diamond == 15)
    //    {
    //        playerMaterials.color = Color.yellow;
    //    }
    //}
}
