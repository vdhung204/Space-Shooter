using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataAccountPlayer
{
    private static PlayerExp _playerExp;

    public static PlayerExp PlayerExpData
    {
        get
        {
            if (_playerExp != null)
                return _playerExp;

            var local = PlayerPrefs.GetString(DataAccountPlayerConstans.EXP_PLAYER_DATA);
            if (!string.IsNullOrEmpty(local))
            {
                _playerExp = JsonConvert.DeserializeObject<PlayerExp>(local);
            }
            else
            {
                _playerExp = new PlayerExp();
            }

            return _playerExp;
        }
    }

    public static void SaveDataScore()
    {
        PlayerPrefs.SetString(DataAccountPlayerConstans.EXP_PLAYER_DATA, JsonConvert.SerializeObject(_playerExp));
    }
}
