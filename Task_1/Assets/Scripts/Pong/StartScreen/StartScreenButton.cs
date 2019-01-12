using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PongV2;

public class StartScreenButton : MonoBehaviour {

    public string DoWithBeenClick;
    public int NamberOfPlayers;

    public void ClickAction()
    {
        if (DoWithBeenClick == "pong")
        {
            Side.PlayersCount = NamberOfPlayers;
            Application.LoadLevel(DoWithBeenClick);
        }
        if(DoWithBeenClick == "exit")
        {
            Application.Quit();
        }
    }


}
