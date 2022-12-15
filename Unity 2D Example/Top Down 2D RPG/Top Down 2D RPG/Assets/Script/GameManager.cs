using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

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
            ObjData objData = GetComponent<ObjData>();
            Talk(objData.id, objData.isNpc);
        }
        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isnpc)
    {
        talkManager.GetTalk(id, talkIndex);
    }
}
