using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cementerySound : MonoBehaviour
{
    public Light lightCementry;
    public bool isThunder;
    public AudioSource thunder;
    public bool increase;

    void Start()
    {
        Invoke("startCroutine", 8f);

    }

    private void Update()
    {
        if (isThunder)
        {

            if (increase)
            {
                if (lightCementry.intensity < 5.3) 
                {
                    lightCementry.intensity = Mathf.MoveTowards(lightCementry.intensity, 5.3f, Time.deltaTime * 8f);
                }
                else
                    increase = false;
            }
            else
            {
                if (lightCementry.intensity > 1.4f)
                {
                    lightCementry.intensity = Mathf.MoveTowards(lightCementry.intensity, 1.4f, Time.deltaTime * 8f);

                    if(lightCementry.intensity == 1.4f)
                    {
                        StopThunder();
                    }
                }
                else
                    increase = true;
            }
        }
    }
    private void StopThunder()
    {
        isThunder = false;

    }
    private void startCroutine()
    {
        StartThunder();
        StartCoroutine(SpawnThunder());

    }

    private void StartThunder()
    {
        thunder.Play(0);
        isThunder = true;
    }

    IEnumerator SpawnThunder()
    {

        while (true)
        {
            StartThunder();

            yield return new WaitForSeconds(Random.Range(30, 40));

        }
    }

}
