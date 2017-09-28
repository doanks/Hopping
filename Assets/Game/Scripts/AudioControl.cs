using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioControl : MonoBehaviour
{
    Image image;
    public Sprite[] sprites;

    // Use this for initialization
    void Awake()
    {
        image = GetComponent<Image>();
        RefreshAudio();
    }

    void RefreshAudio()
    {
        int sound = PlayerPrefs.GetInt("sound", 1);
        AudioListener.pause = sound == 1 ? false : true;
        image.sprite = sprites[sound];
    }

    public void ChangeAudio()
    {
        AudioListener.pause = !AudioListener.pause;
        PlayerPrefs.SetInt("sound", AudioListener.pause == true ? 0 : 1);
        RefreshAudio();
    }
}