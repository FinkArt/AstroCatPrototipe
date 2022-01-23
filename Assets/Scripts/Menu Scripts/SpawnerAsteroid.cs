using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAsteroid : MonoBehaviour
{
    [SerializeField] private GameObject asteroidForMenu;
    Vector2 respawnAsteroid;
    float timeRespawmAsteroids;
    [SerializeField] private GameObject respawmPlaceAsteroid;

    // [SerializeField] private GameObject spawner;

    private void Awake()
    {
        if (respawmPlaceAsteroid.transform.position.x < 0)
            timeRespawmAsteroids = 5f;
        else
            timeRespawmAsteroids = 2.1f;
    }
    private void Start()
    {
        StartCoroutine(RespawnAsteroid());
        
    }
    private void Repeat()
    {
        StartCoroutine(RespawnAsteroid());   
    }

    private IEnumerator RespawnAsteroid()
    {
        yield return new WaitForSeconds(timeRespawmAsteroids);
        float randY = Random.Range(-6f, 15f);
        respawnAsteroid = new Vector2(transform.position.x, randY);
        Instantiate(asteroidForMenu, respawnAsteroid, Quaternion.identity);
        Repeat();
    }

}
