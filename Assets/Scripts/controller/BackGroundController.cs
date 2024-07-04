using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    public float backGroundSpeed;
    private Material mat;
    private Vector2 offSet = Vector2.zero;

    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }
    void Start()
    {
        offSet = mat.GetTextureOffset("_MainTex");
        
    }
    private void Update()
    {
        offSet.y += backGroundSpeed * Time.deltaTime;
        mat.SetTextureOffset("_MainTex", offSet);
    }


}
