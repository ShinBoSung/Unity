using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBall : MonoBehaviour
{
    public float jumpPowre;
    bool isJump;
    public int ItemCount;
    public GameManagerLogic manager;
    Rigidbody rigid;
    AudioSource audio;

    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPowre, 0), ForceMode.Impulse);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            ItemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(ItemCount);
        }
        else if (other.tag == "Finish")
        {
           if (ItemCount == manager.TotalItemCount)
            {
                if (manager.Stage == 2)
                {
                    SceneManager.LoadScene(0);
                }
                else
                {
                    SceneManager.LoadScene(manager.Stage + 1);
                }
            }
            else
            {
                SceneManager.LoadScene(manager.Stage);
            }
        }
    }   
}
