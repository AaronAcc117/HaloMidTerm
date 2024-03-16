using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 5;
    public AudioSource audioSource;
    public AudioClip CoinSound;
    public AudioClip Hazard1Sound;
    public GameManagerv2 gameManager;


    void Start()
    {



    }


    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");

        transform.Translate(speed * Time.deltaTime * xMove, 0, 0);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hazard1")
        {
            //Debug.Log("collided");
            audioSource.PlayOneShot(Hazard1Sound);
            Destroy(gameObject);

        }


        if (collision.tag == "Coin")
        {


            audioSource.PlayOneShot(CoinSound);
            Destroy(collision.gameObject/*,(AUDIO NAME HERE).clip.length*/);
            gameManager.IncreaseScore();
        }

        if (collision.tag == "ThemeBox")
        {
            //Debug.Log("collided");
            Debug.Log("Transition");
        }
    }
}
