using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _onCatClickPlus;
    [SerializeField] private AudioSource _onCatClickMinus;

    public void ClickOnCatPlus()
    {
        _onCatClickPlus.Play();
    }

    public void ClicOnCatMinus()
    {
        _onCatClickMinus.Play();
    }
}
