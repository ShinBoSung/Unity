using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Start()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    
    void GenerateData()
    {
        talkData.Add(1000, new string[] {"안녕?", "이곳에 처음 왔구나?"});

        talkData.Add(100, new string[] { "평범한 나무 상자다." });

        talkData.Add(200, new string[] { "누군가 사용한 흔적이 있다." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }
}
