using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    void Start()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    
    void GenerateData()
    {
        talkData.Add(1000, new string[] {"안녕?", "이곳에 처음 왔구나?"});

        talkData.Add(2000, new string[] { "안녕?", "이곳에 처음 왔구나?" });

        talkData.Add(100, new string[] { "평범한 나무 상자다." });

        talkData.Add(200, new string[] { "누군가 사용한 흔적이 있다." });

        portraitData.Add(1000 + 0,);
        portraitData.Add(1000 + 1,);
        portraitData.Add(1000 + 2,);
        portraitData.Add(1000 + 3,);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if(talkIndex == talkData[id].Length)
        {            
            return null;
        }
        else
        {
            return talkData[id][talkIndex];
        }        
    }
}
