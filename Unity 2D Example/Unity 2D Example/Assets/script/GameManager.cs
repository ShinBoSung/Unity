using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalPoint;
    public int stagePoint;
    public int stageIndex;
    public int health;
    public GameObject[] stages;
    public PlayerMove player;
    public void NextStage()
    {
        if(stageIndex < stages.Length-1)
        {
            stages[stageIndex].SetActive(false);
            stageIndex++;

            stages[stageIndex].SetActive(true);
            PlayerReposition();
        }
        else
        {
            Time.timeScale = 0;
            Debug.Log("게임 클리어!");
        }

        totalPoint += stagePoint;
        stagePoint = 0;
    }

    public void healthDown()
    {
        if(health > 0)
        {
            health--;
        }
        else
        {
            //Playr Die Effect
            player.OnDie();

            //Result UI
            Debug.Log("죽었습니다!");

            //Retry Button UI
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
}
