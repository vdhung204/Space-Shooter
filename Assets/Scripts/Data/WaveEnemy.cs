using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WaveEnemy : ScriptableObject
{
    public WaveInfor[] waveEnemy;

    public WaveInfor GetWaveInfor(int wave)
    {

        foreach (WaveInfor lvl in waveEnemy)
        {
            if (lvl.wave == wave)
                return lvl;
        }

        return waveEnemy[0];
    }
}
[Serializable]
public struct WaveInfor
{
    public int wave;
    public int delay_time;
    public int spawn_enemy;
}
