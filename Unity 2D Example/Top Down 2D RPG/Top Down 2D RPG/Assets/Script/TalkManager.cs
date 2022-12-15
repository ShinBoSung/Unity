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
        talkData.Add(1000, new string[] {"�ȳ�?", "�̰��� ó�� �Ա���?"});

        talkData.Add(100, new string[] { "����� ���� ���ڴ�." });

        talkData.Add(200, new string[] { "������ ����� ������ �ִ�." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }
}
