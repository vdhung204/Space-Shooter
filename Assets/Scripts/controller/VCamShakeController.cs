using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class VCamShakeController : MonoBehaviour
{
    public static VCamShakeController Instance { get; private set; }
    private CinemachineVirtualCamera mCam;
    private float shakeIntensity = 1f;
    private float shakeTime = 0.2f;

    private float timer = 0;
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    private void Awake()
    {
        Instance = this;
        mCam = GetComponent<CinemachineVirtualCamera>();
    }
    private void Start()
    {
        StopShake();
    }
    public void ShakeCamere()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = mCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = shakeIntensity;

        timer = shakeTime;
    }
    private void StopShake()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = mCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = 0f;

        timer = 0;
    }
   
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                StopShake();
            }
        }
    }
}
