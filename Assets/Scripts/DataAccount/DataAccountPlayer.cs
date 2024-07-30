using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataAccountPlayer
{
    private static PlayerInfor _playerExp;
    private static PlayerInfor _playerCoin;

    public static PlayerInfor PlayerExpData
    {
        get
        {
            if (_playerExp != null)
                return _playerExp;

            var local = PlayerPrefs.GetString(DataAccountPlayerConstans.EXP_PLAYER_DATA);
            if (!string.IsNullOrEmpty(local))
            {
                _playerExp = JsonConvert.DeserializeObject<PlayerInfor>(local);
            }
            else
            {
                _playerExp = new PlayerInfor();
            }

            return _playerExp;
        }
    }
    public static PlayerInfor PlayerCoinData
    {
        get
        {
            if (_playerCoin != null)
                return _playerCoin;

            var local = PlayerPrefs.GetString(DataAccountPlayerConstans.COIN_PLAYER_DATA);
            if (!string.IsNullOrEmpty(local))
            {
                _playerCoin = JsonConvert.DeserializeObject<PlayerInfor>(local);
            }
            else
            {
                _playerCoin = new PlayerInfor();
            }

            return _playerCoin;
        }
    }

    public static void SaveDataExp()
    {
        PlayerPrefs.SetString(DataAccountPlayerConstans.EXP_PLAYER_DATA, JsonConvert.SerializeObject(_playerExp));
    }
    public static void SaveDataCoin()
    {
        PlayerPrefs.SetString(DataAccountPlayerConstans.COIN_PLAYER_DATA, JsonConvert.SerializeObject(_playerCoin));
    }
}
