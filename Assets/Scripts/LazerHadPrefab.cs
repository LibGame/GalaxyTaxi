using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerHadPrefab : MonoBehaviour
{
    GameObject Player; // игрок
    public Transform Turell; // лазер
    public Transform LazerPosDisgarge; // точка спавна лазера
    Rigidbody2D rigidbodyTurell;
    public GameObject LazerPref; // префаб лазера

    public bool isInduced = true; // время до наведения

    void Start()
    {
        rigidbodyTurell = GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("PlayerCar");
        Invoke("isWasInduced", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInduced)
        {
            var turn = Quaternion.Lerp(Turell.rotation, Quaternion.LookRotation(Vector3.forward, Player.transform.position - Turell.position), Time.deltaTime * GameProperties.RotationTureSpeed1);
            rigidbodyTurell.MoveRotation(turn.eulerAngles.z);
        }
    }
    
    void isWasInduced()
    {
        isInduced = false;
        Invoke("isShoot", 0f);

    }

    void isShoot()
    {
        var turn = Quaternion.Lerp(Turell.rotation, Quaternion.LookRotation(Vector3.forward, Player.transform.position - Turell.position), Time.deltaTime * GameProperties.RotationTureSpeed1);

        var lazer = Instantiate(LazerPref, LazerPosDisgarge.position, LazerPosDisgarge.rotation);
        lazer.transform.SetParent(transform);
        Invoke("DestroyLazer", 2f);

    }

    void DestroyLazer()
    {
        Destroy(gameObject);
    }
}
