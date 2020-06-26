using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove1 : MonoBehaviour
{
    public enum ProjectMode { moveX = 1, moveY = 0 };
    public ProjectMode projectMode = ProjectMode.moveX;
    public float speed;
    public MeshRenderer firstBG;
    public float firstBGSpeed = 0.01f;

    public MeshRenderer secondBG;
    public float secondBGSpeed = 0.05f;

    public MeshRenderer thirdBG;
    public static float speedBG = 1.5f;
    private Vector2 savedFirst;
    private Vector2 savedSecond;
    private Vector2 savedThird;

    void Start()
    {
        if (firstBG) savedFirst = firstBG.sharedMaterial.GetTextureOffset("_MainTex");
        if (secondBG) savedSecond = secondBG.sharedMaterial.GetTextureOffset("_MainTex");
        if (thirdBG) savedThird = thirdBG.sharedMaterial.GetTextureOffset("_MainTex");
    }

    public void Move(MeshRenderer mesh, Vector2 savedOffset, float speed)
    {
        Vector2 offset = Vector2.zero;
        float tmp = Mathf.Repeat(Time.time * speedBG, 1);
        if (projectMode == ProjectMode.moveY) offset = new Vector2(savedOffset.x, tmp);
        else offset = new Vector2(tmp, savedOffset.y);
        mesh.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void Update()
    {

        speedBG = speed;

        if (firstBG) Move(firstBG, savedFirst, firstBGSpeed);
        if (secondBG) Move(secondBG, savedSecond, secondBGSpeed);
        if (thirdBG) Move(thirdBG, savedThird, GameProperties.thirdBGSpeed);
        
    }

    void OnDisable()
    {
        if (firstBG) firstBG.sharedMaterial.SetTextureOffset("_MainTex", savedFirst);
        if (secondBG) secondBG.sharedMaterial.SetTextureOffset("_MainTex", savedSecond);
        if (thirdBG) thirdBG.sharedMaterial.SetTextureOffset("_MainTex", savedThird);
    }
}
