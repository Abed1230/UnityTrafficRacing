using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField]
    private float scoreIncrementInterval;
    [SerializeField]
    private GameObject uiController;
    [SerializeField]
    private GameObject trackObj;
    [SerializeField]
    private GameObject spawnerObj;

    private TrackScrollController trackScrollController;
    private Spawner spawner;

    // good start values 
    // trackScrollSpeed = 0.5f
    // carSpeed = 2.3f;
    // coinSpeed = 5f;
    private float trackScrollSpeed = 0.5f;
    private float carSpeed = 2.3f;
    private float coinSPeed = 5f;

    private float score = 0;
    private float coins = 0;

    private float CarSpawnDelay = 1.7f;
    private float nextCarSpawn;

    private int minCoinSpawnDelay = 5;
    private int maxCoinSpawnDelay = 9;
    private float nextCoinSpawn = 1f;

    private int minCoinSpawnAmmount = 5;
    private int maxCoinSpawnAmmount = 20;

    private int randCoinSpawnAmmount;
    private int randCoinSpawnPos;

    // Use this for initialization
    void Start()
    {
        trackScrollController = trackObj.GetComponent<TrackScrollController>();
        spawner = spawnerObj.GetComponent<Spawner>();
        
        trackScrollController.SetSpeed(trackScrollSpeed);

        nextCarSpawn = CarSpawnDelay;

        InvokeRepeating("IncreaseScore", 0f, scoreIncrementInterval);
    }
	
	// Update is called once per frame
	void Update ()
    {
        nextCarSpawn -= Time.deltaTime;
        if(nextCarSpawn <= 0)
        {
            spawner.SpawnCar(carSpeed);
            nextCarSpawn = CarSpawnDelay;
        }

        nextCoinSpawn -= Time.deltaTime;
        if (nextCoinSpawn <= 0) 
        {
            SpawnCoins();
            nextCoinSpawn = Random.Range(minCoinSpawnDelay, maxCoinSpawnDelay + 1); 
        }
        
    }

    private void SpawnCoins()
    {
        randCoinSpawnAmmount = Random.Range(minCoinSpawnAmmount, maxCoinSpawnAmmount + 1);
        randCoinSpawnPos = Random.Range(0, spawner.GetSpawnPositionsCount());
        InvokeRepeating("SpawnCoin", 0f, 0.1f);
    }

    private void SpawnCoin()
    {
        spawner.SpawnCoin(coinSPeed, randCoinSpawnPos);
        if (--randCoinSpawnAmmount == 0)
            CancelInvoke("SpawnCoin");
    }
    
    private void IncreaseScore()
    {
        score++;
        uiController.GetComponent<UIController>().SetScoreText(score.ToString());
    }

    public void IncreaseCoins()
    {
        coins++;
        uiController.GetComponent<UIController>().SetCoinsText(coins.ToString());
    }

    public void GameOver()
    {
        CancelInvoke();
        uiController.GetComponent<UIController>().GameOver(score);
    }

}
