using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfor
{
    public int expPlayer;
    public int coinPlayer;

    public int shipPlayerUse = 1;


    public void ChangeShipPlayer(int ship)
    {
        shipPlayerUse = ship;
        DataAccountPlayer.SaveDataPlayerInfor();
    }
}
