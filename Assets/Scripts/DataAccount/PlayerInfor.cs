using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfor
{
    public int expPlayer;
    public int coinPlayer;

    public int shipPlayerUse = 1;
    public List<int> listShips = new List<int>() {1};
    public List<int> listLevelPlayer = new List<int>() {1};


    public void ChangeShipPlayer(int ship)
    {
        shipPlayerUse = ship; 
        DataAccountPlayer.SaveDataPlayerInfor();
    }
    public void BoughtShip(int id)
    {
        listShips.Add(id);
        DataAccountPlayer.SaveDataPlayerInfor();
    }
    public void ChangeLevelPlayer(int level)
    { 
        listLevelPlayer.Add(level);
        DataAccountPlayer.SaveDataPlayerInfor();
    }
    
}
