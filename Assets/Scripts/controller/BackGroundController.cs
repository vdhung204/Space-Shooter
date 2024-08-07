using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    public static BackGroundController instance;
    public float backGroundSpeed = 0.1f;
    private Material mat;
    private Vector2 offSet = Vector2.zero;

    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
        this.RegisterListener(EventID.WaveEnd, (sender, param) => SkipBg((int) param));
    }
    void Start()
    {
        offSet = mat.GetTextureOffset("_MainTex");
        
    }

    private void SkipBg(int delayTime)
    {
        backGroundSpeed = 1;
        StartCoroutine(BackSpeed(delayTime));
    }


    IEnumerator BackSpeed(int delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        backGroundSpeed = 0.1f;
    }
    private void Update()
    {
        MoveBackGround();
        mat.SetTextureOffset("_MainTex", offSet);
    }
    private void MoveBackGround()
    {
        offSet.y += backGroundSpeed * Time.deltaTime;
    }

}
