using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    public int preferedSpeed = 5;//speed of cube
    public GameObject tapToPlay;//tap to play panel 
    public GameObject winFireWork;
    public GameObject winPanel;
    public GameObject losePanel;
    public Image progressBar;
    public Text coinsText;
    public Text levelText;

    float splineLenght;
    float duration = 0;
    float time;
    bool startStopCube = false;
    bool startTimeCount = false;
    bool tapToPlayClicked = false;
    int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (preferedSpeed == 0)
        {
            duration = 0;
        }
        splineLenght = GetComponent<Spline>().Length;
        duration = splineLenght / preferedSpeed;
        if (!PlayerPrefs.HasKey("Coins"))
        {
            PlayerPrefs.SetInt("Coins", 50);
        }
        coins = PlayerPrefs.GetInt("Coins");
        setCoins();
        levelText.text = "Level " + (SceneManager.GetActiveScene().buildIndex).ToString();
        //coins to canvas
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void TapToPlayClicked()
    {
        tapToPlayClicked = true;
    }
    void setCoins()
    {
        PlayerPrefs.SetInt("Coins", coins);
        coinsText.text = "Coins " + coins.ToString();
    }

    public void WinFunc()
    {

        startTimeCount = false;
        tapToPlayClicked = false;
        progressBar.fillAmount = 1;
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
        {
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex + 1);
        }
        else {
            print("Game is passed");
            Application.Quit();
        }
        startStopCube = true;
        winFireWork.SetActive(true);
        duration = 4;
        preferedSpeed = 0;
        winPanel.SetActive(true);
    }
    public void LoseFunc()
    {
        losePanel.SetActive(true);
        tapToPlayClicked = false;
        duration = 0;
        GetComponent<ExampleFollowSpline>().DurationInSecond = duration;
    }
    public void ClaimButton()
    {
        //add coins
        coins += 75;
        setCoins();
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex+1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//0 scene is loader of scenes
        }
        else
        {
            print("Game is passed");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if((Input.touchCount>0 || Input.GetMouseButtonDown(0))&&tapToPlayClicked)
        {   
            tapToPlay.SetActive(false); 
            GetComponent<ExampleFollowSpline>().DurationInSecond = duration;
            startTimeCount = true;
        }
        else if(Input.touchCount == 0)// && Input.GetMouseButtonUp(0))
        {
            GetComponent<ExampleFollowSpline>().DurationInSecond = 0;
            startTimeCount = false;
        }
        if (startTimeCount) {
            time += Time.deltaTime;
            progressBar.fillAmount = (GetComponent<ExampleFollowSpline>().rate/2)/duration;
           
      
        }
        if(startStopCube)
        {
            duration += Time.deltaTime * 20;
            if (duration > 50)
            {
                duration = 0;
                preferedSpeed = 0;
                startStopCube = false;
                //call claim panel
            }

            GetComponent<ExampleFollowSpline>().DurationInSecond = duration;
        }
    }
}
