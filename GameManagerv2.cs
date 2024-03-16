using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerv2 : MonoBehaviour
{
    // Screen Edges
    public Transform northPoint;
    public Transform southPoint;
    public Transform westPoint;
    public Transform eastPoint;

    float itemSpawnDelay = 2;

    float timeElapsed = 0;
    [Range(1, 40)] public int itemCount = 40;
    int currentItemCount = 0;

    public GameObject coinPrefab;
    public GameObject hazard1Prefab;
    public GameObject ThemeBoxPrefab;
    public AudioClip coinSound;
    public AudioClip hazardSound;
    public AudioClip ThemeBoxSound;
    public AudioSource audioSource;

    //score
    public int score;
    public TextMeshPro scoreText;

    //randomize coin or hazard
    public GameObject[] items;
    public GameObject themeBox;

    private void Start()
    {
        //SpawnItem();
        //health = 100

    }

    public void Update()
    {
        // Time tracking
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= itemSpawnDelay)
        {
            SpawnItem();
            timeElapsed = 0;
        }

        //if (currentItemCount > itemCount / 2)
        //{
        //itemSpawnDelay -= 1;
        //}

        //score
        scoreText.text = "SCORE: " + score.ToString();
    }

    void GameOver()
    {
       
    }

    void SpawnItem()
    {
        if (currentItemCount < itemCount)
        {
            int randomIndex = Random.Range(0, items.Length);
            Instantiate(items[randomIndex], SpawnPos(), Quaternion.identity);
            currentItemCount++;
        }
    }

    private Vector2 SpawnPos()
    {
        int xValue = Random.Range((int)westPoint.position.x, (int)eastPoint.position.x);
        int yValue = (int)northPoint.position.y;
        return new Vector2(xValue, yValue);
    }

    public void IncreaseScore()
    {
        score += 10;
    }

    public void DestroyPlayer(GameObject playerObject)
    {
        Destroy(playerObject);
    }
}
