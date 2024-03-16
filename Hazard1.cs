using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hazard1 : MonoBehaviour


{
    public float minSpeed = -5f;
    public float maxSpeed = -10f;
    private float fallingSpeed;

    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fallingSpeed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        rb.velocity = new Vector2(0, fallingSpeed);
    }
}