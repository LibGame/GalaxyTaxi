using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{

    private Transform player;
    private Rigidbody2D rb;
    private float x, y;
    private void Start()
    {
        player = GameObject.Find("carPlayer").GetComponent<Transform>();
        x = player.position.x;
        y = player.position.y;
        rb = GameObject.Find("carPlayer").GetComponent<Rigidbody2D>();
    }

}
