using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerOne;
    [SerializeField] private GameObject _playerTwo;
    [SerializeField] private Camera mainCam;
    public static float edgeX;
    public static float edgeZ;
    [SerializeField] private float spawnEdge;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float spawnCooldown = 10;//how long until next spawn
    [SerializeField] private float spawnCountdown = 0;//actual counter
    [SerializeField] private int spawnNumber = 3;//how many spawns
    public static List<GameObject> living;

    // Start is called before the first frame update
    void Awake()
    {
        living = new List<GameObject>();
        if(MainMenuHandler.playerTwoWeapon != null)
        {
            _playerTwo = Instantiate(_playerTwo, Vector3.back, Quaternion.identity);
            _playerTwo.GetComponent<PlayerHandler>().Weapon = MainMenuHandler.playerTwoWeapon;
            living.Add(_playerTwo);
        }

        _playerOne = Instantiate(_playerOne, Vector3.forward, Quaternion.identity);
        _playerOne.GetComponent<PlayerHandler>().Weapon = MainMenuHandler.playerOneWeapon;
        living.Add(_playerOne);
        
        mainCam = Camera.main;

        Vector3 edge = mainCam.ViewportToWorldPoint(new Vector3(0.95f, 0.9f, 30f));
        edgeX = edge.x;
        edgeZ = edge.z;
        spawnEdge = edgeZ + 10;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCountdown -= Time.deltaTime;
        if (spawnCountdown <= 0)
        {
            spawnCooldown *= 0.9f;
            spawnCountdown += spawnCooldown;
            SpawnEnemies(spawnNumber);
            spawnNumber += Math.Clamp(Random.Range(-8, 1), 0, 1);//10% chance to add more to spawn number
        }
    }

    void SpawnEnemies(int number)
    {
        for (int i = 0; i < number; i++)
        {
            int random = Random.Range(0, enemies.Length);
            GameObject enemy = Instantiate(enemies[random],//choose random enemy
                new Vector3(Random.Range(-edgeX, edgeX), 0, spawnEdge),//spawn anywhere on the edge
                Quaternion.Euler(0, 180, 0));//rotate towards other end of field
        }
    }
}
