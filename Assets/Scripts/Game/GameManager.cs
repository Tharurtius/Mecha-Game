using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerOne;
    [SerializeField] private GameObject _playerTwo;
    public Quaternion rotation;

    public GameObject PlayerOne
    {
        get { return _playerOne; }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(MainMenuHandler.playerTwoWeapon != null)
        {
            _playerTwo = Instantiate(_playerTwo, Vector3.back, Quaternion.identity);
            _playerTwo.GetComponent<PlayerHandler>().Weapon = MainMenuHandler.playerTwoWeapon;
        }

        _playerOne = Instantiate(_playerOne, Vector3.forward, Quaternion.identity);
        _playerOne.GetComponent<PlayerHandler>().Weapon = MainMenuHandler.playerOneWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        rotation = _playerOne.transform.rotation;
    }
}
