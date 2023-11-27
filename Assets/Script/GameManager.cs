using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum viewportState
    {
        Top,
        Left,
        Right,
        Bottom,
    }
    [SerializeField]
    private GameObject enemyPrefab;

    public viewportState currentViewport;
    private void Awake()
    {
        InvokeRepeating("spawnEnemy", 0, 0.5f);
    }
    public void spawnEnemy()
    {
        float valueRandom = Random.value;

        currentViewport = (viewportState)Random.Range(0, 3);
        switch (currentViewport)
        {
            case viewportState.Top:
                {
                    Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(valueRandom, 1, 0));
                    Instantiate(enemyPrefab, new Vector3(spawnPosition.x, spawnPosition.y, 0), Quaternion.identity);
                    break;
                }
            case viewportState.Left:
                {
                    Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, valueRandom, 0));
                    Instantiate(enemyPrefab, new Vector3(spawnPosition.x, spawnPosition.y, 0), Quaternion.identity);
                    break;
                }
            case viewportState.Right:
                {

                    Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(1, valueRandom, 0));
                    Instantiate(enemyPrefab, new Vector3(spawnPosition.x, spawnPosition.y, 0), Quaternion.identity);
                    break;
                }
            case viewportState.Bottom:
                {

                    Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(valueRandom, 0, 0));
                    Instantiate(enemyPrefab, new Vector3(spawnPosition.x, spawnPosition.y, 0), Quaternion.identity);
                    break;
                }
        }

    }
}
