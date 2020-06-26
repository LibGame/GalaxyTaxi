using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeCroBook : MonoBehaviour
{
    public SpriteRenderer img; // ваша картинка
    public AnimationCurve curve; public 
    float t; // ваше значение прозрачности.
    public GameObject Pentogram;
    public Transform positionSpawn;
    private GameObject PointToSpawn;

    private void Start()
    {
        Invoke("SpawnPentogram", 1.8f);
        PointToSpawn = GameObject.Find("PointToSpawn");
    }

    private void SpawnPentogram()
    {
        var Pentrogramm = Instantiate(Pentogram, new Vector2(PointToSpawn.transform.position.x, PointToSpawn.transform.position.y-0.1f), Quaternion.identity);
        Pentrogramm.transform.SetParent(gameObject.transform);
    }

    public void StartFade()
    {
        Invoke("StartCoroutineFade", 1f);
        NeCroBos._isAnimated = false;
    }

    private void StartCoroutineFade()
    {
        StartCoroutine(FadeIn());
        Invoke("DestroyBook", 4f);

    }


    private void DestroyBook()
    {
        Destroy(gameObject);
    }

    IEnumerator FadeIn()
    {
        float t = 1f; // сначала она 100% не прозрачна, поэтому t = 1

        while (t > 0f)
        {
            t -= Time.deltaTime * 0.5f; // отнимаем от t с каждым циклом время после посл. фрейма пока t не станет 0 или меньше. Тут я еще умнажаю на 1.5, тут уже смотрите как вам точнее нужно
            float a = curve.Evaluate(t); // теперь с помощью кривой оцениваем значение "a"
            img.color = new Color(img.color.r, img.color.g, img.color.b, a); // и обновляем прозрачность картинки с помощью "a"
            yield return 0;
        }
    }
}
