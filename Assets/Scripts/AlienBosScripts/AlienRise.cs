using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AlienRise : MonoBehaviour
{

    private GameObject _player;
    private Vector3 _pos;
    private bool _isAttract;
    private Rigidbody2D rigidbodyRise;
    private int HelthOfRise = 10;
    private Coroutine _riseCoroutine;
    public Text textClick;

    void Start()
    {
        _player = GameObject.Find("carPlayer");
        _pos = transform.position;
        rigidbodyRise = GetComponent<Rigidbody2D>();
        _riseCoroutine = StartCoroutine(StartLightRiseSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAttract)
        {
            _player.transform.position = Vector3.MoveTowards(_player.transform.position, _pos, Time.deltaTime * 2f);

            if (Input.GetMouseButtonDown(0))
            {
                HelthOfRise--;
                if(HelthOfRise == 0)
                {
                    Destroy(gameObject);
                }

                if(_riseCoroutine != null)
                {
                    StopCoroutine(_riseCoroutine);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D bulletConfront)
    {


        if (bulletConfront.gameObject.tag == "PlayerCar")
        {
            _isAttract = true;
            textClick.enabled = true;

        }

    }

    private IEnumerator StartLightRiseSpawn()
    {

        while (true)
        {

            var turn = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, _player.transform.position - transform.position), 1000f);
            rigidbodyRise.MoveRotation(turn.eulerAngles.z);


            yield return new WaitForSeconds(1f);

        }
    }
}

