using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalPoint;
    public int stagePoint;
    public int stageIndex;
    public int health;
    public GameObject[] stages;
    public PlayerMove player;

    public Image[] UIhealth;
    public Text UIPoint;
    public Text UIStage;
    public GameObject RestartBtn;

    void Update()
    {
        UIPoint.text = (totalPoint + stagePoint).ToString();
    }

    public void NextStage()
    {
        if(stageIndex < stages.Length-1)
        {
            stages[stageIndex].SetActive(false);
            stageIndex++;

            stages[stageIndex].SetActive(true);
            PlayerReposition();

            UIStage.text = "STAGE " + (stageIndex + 1);
        }
        else
        {
            Time.timeScale = 0;
           
            RestartBtn.SetActive(true);
            Text btnText = RestartBtn.GetComponentInChildren<Text>();
            btnText.text = "Game Clear!";
            ViewBtn();
        }

        totalPoint += stagePoint;
        stagePoint = 0;
    }

    public void healthDown()
    {
        if(health > 0)
        {
            health--;
            UIhealth[health].color = new Color(1, 0, 0, 0.4f);
        }
        else
        {
            //Playr Die Effect
            player.OnDie();

            //Result UI
            Debug.Log("ав╬З╫ю╢о╢ы!");

            //Retry Button UI
            RestartBtn.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Player Reposition
            if(health > 1)
            {
                PlayerReposition();
            }

            //Health Down
            healthDown();
        }
    }

    void PlayerReposition()
    {
        player.transform.position = new Vector3(0, 0, -1);
        player.VelocityZero();
    }

    void ViewBtn()
    {
        RestartBtn.SetActive(true);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
