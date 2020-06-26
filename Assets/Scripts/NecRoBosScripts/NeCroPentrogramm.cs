using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeCroPentrogramm : MonoBehaviour
{
    public SpriteRenderer img; // ваша картинка
    public AnimationCurve curve; // можете использовать это значение и менять плавность прозрачности, например чтобы прозрачность картинки сначала медленно, а под конец быстро происходила, вообщем сделайте значение public и поиграйте в едиторе с кривой
    float t; // ваше значение прозрачности.


    public void StartFade()
    {
        Invoke("StartCoroutineFade", 1f);
    }

    private void StartCoroutineFade()
    {
        StartCoroutine(FadeIn());

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
