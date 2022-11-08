using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuHandler : ISceneSwap
{
    public static IWeapon playerOneWeapon;
    public static IWeapon playerTwoWeapon;

    [SerializeField] private int playerOneIndex = 0;
    [SerializeField] private int playerTwoIndex = 0;

    [SerializeField] private TextMeshProUGUI playerOneName;
    [SerializeField] private TextMeshProUGUI playerTwoName;

    [SerializeField] private Image playerOneDisplay;
    [SerializeField] private Image playerTwoDisplay;

    [SerializeField] private Image playerOneBackground;
    [SerializeField] private Image playerTwoBackground;

    [SerializeField] private IWeapon[] weapons;
    [SerializeField] private Color red;
    [SerializeField] private Color white;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //player 1 select weapons
        if(playerOneName.gameObject.activeInHierarchy)//if panel is active
        {
            if(playerOneWeapon == null)//if no weapon selected
            {
                if(Input.GetKeyDown(KeyCode.A))//if left is pressed
                {
                    ChangeWeapon(false, ref playerOneIndex);
                }
                if(Input.GetKeyDown(KeyCode.D))//if right is pressed
                {
                    ChangeWeapon(true, ref playerOneIndex);
                }
            }
            
            if(Input.GetKeyDown(KeyCode.Space))//if space is pressed
            {
                if(playerOneWeapon == null)//if no weapon is selected
                {
                    SelectWeapon(0);
                    playerOneBackground.color = red;
                }
                else
                {
                    playerOneWeapon = null;
                    playerOneBackground.color = white;
                }
            }
        }

        //player 2 select weapons
        if(playerTwoName.gameObject.activeInHierarchy)//if panel is active
        {
            if(playerTwoWeapon == null)//if no weapon selected
            {
                if(Input.GetKeyDown(KeyCode.J))//if left is pressed
                {
                    ChangeWeapon(false, ref playerTwoIndex);
                }
                if(Input.GetKeyDown(KeyCode.L))//if right is pressed
                {
                    ChangeWeapon(true, ref playerTwoIndex);
                }
            }
            
            if(Input.GetKeyDown(KeyCode.RightControl))//if space is pressed
            {
                if(playerTwoWeapon == null)//if no weapon is selected
                {
                    SelectWeapon(1);
                    playerTwoBackground.color = red;
                }
                else
                {
                    playerTwoWeapon = null;
                    playerTwoBackground.color = white;
                }
            }
        }
    }

    public void SetupMenu()
    {
        playerOneIndex = 0;
        playerTwoIndex = 1;

        playerOneWeapon = null;
        playerTwoWeapon = null;

        playerOneBackground.color = white;
        playerTwoBackground.color = white;

        ChangeMenu();
    }

    public void ChangeMenu()
    {
        playerOneName.text = weapons[playerOneIndex].weaponName;
        playerTwoName.text = weapons[playerTwoIndex].weaponName;

        playerOneDisplay.sprite = weapons[playerOneIndex].sprite;
        playerTwoDisplay.sprite = weapons[playerTwoIndex].sprite;
    }

    public void SelectWeapon(int player)//used to set weapon into static so it can be accessed by game scene
    {
        if(player == 0)//if first player
        {
            playerOneWeapon = weapons[playerOneIndex];
        }
        else//if second player
        {
            playerTwoWeapon = weapons[playerTwoIndex];
        }

        if(playerTwoName.gameObject.activeInHierarchy)//if second player is active
        {
            if(playerOneWeapon != null && playerTwoWeapon != null) //if both players have selected a weapon
            {
                SwapScene(1);//start game
            }
        }
        else
        {
            SwapScene(1);//1 is game
        }
    }

    //call this function to change the weapon index by 1, also includes index reseting
    public void ChangeWeapon(bool plus, ref int index)
    {
        if(plus)//if changing in positive direction
        {
            index++;
            if(index >= weapons.Length)
            {
                index = 0;
            }
        }
        else//if changing in negative direction
        {
            index--;
            if(index < 0)
            {
                index = weapons.Length - 1;
            }
        }
        ChangeMenu();
    }
}
