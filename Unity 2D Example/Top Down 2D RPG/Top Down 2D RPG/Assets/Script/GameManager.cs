using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;


    public void Action(GameObject sanObj)
    {
        if(isAction)
        {
            isAction = false;            
        }
        else
        {
            isAction = true;            
            scanObject = sanObj;
            talkText.text = "�̰��� �̸���" + scanObject.name + "�̶�� �Ѵ�.";
        }
        talkPanel.SetActive(isAction);
    }
}
