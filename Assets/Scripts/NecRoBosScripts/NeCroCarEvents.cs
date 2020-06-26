
using UnityEngine;
using UnityEngine.UI;

public class NeCroCarEvents : MonoBehaviour
{

    public Text _text;

    public void SetDamage(int damage)
    {
        _text.CrossFadeAlpha(1, 0.1f, false);
        _text.text = damage.ToString();
        _text.CrossFadeAlpha(0, 1f, false);

    }
}
