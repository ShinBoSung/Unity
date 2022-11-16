using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform Playertransform;
    Vector3 Offset;
    void Start()
    {
        Playertransform = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - Playertransform.position;
    }

    void LateUpdate()
    {
        transform.position = Playertransform.position + Offset;
    }
}
