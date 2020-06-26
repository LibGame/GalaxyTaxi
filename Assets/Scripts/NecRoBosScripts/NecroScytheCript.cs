using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroScytheCript : MonoBehaviour
{
    private Animator Anim;
    public SpriteRenderer img; // ваша картинка
    public AnimationCurve curve;
    public float t; // ваше значение прозрачности.

    void Start()
    {
        Anim = GetComponent<Animator>();

    }

    public void StartSckythe()
    {
        transform.gameObject.SetActive(true);
        Invoke("startCoroutine", Random.Range(5, 10));
    }

    public void startCoroutine()
    {
        StartCoroutine(CircleSckythe());
    }

    public void StopAnimation()
    {
        Anim.SetBool("isCircling", false);
    }

    public void StartFade()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator CircleSckythe()
    {

        while (true)
        {
            Anim.SetBool("isCircling", true);

            yield return new WaitForSeconds(Random.Range(10, 15));

        }
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
