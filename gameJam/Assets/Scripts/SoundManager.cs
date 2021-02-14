using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public static AudioSource audioSource;
    public bool sound = true;



    [SerializeField]
    public static AudioClip almak, click, kapiGicirti, kilic1, kilic2, kilic3, kilic4, kilic5, adim, sword, sword1, sword2;
    public static AudioClip[] kiliclar;
    public static AudioClip[] swords;

    private void Start()
    {
        almak = Resources.Load<AudioClip>("Almak");
        click = Resources.Load<AudioClip>("Click");
        kapiGicirti = Resources.Load<AudioClip>("Kapı gıcırtı");

        kiliclar[0] = Resources.Load<AudioClip>("Kısa Kılıç1");
        kiliclar[1] = Resources.Load<AudioClip>("Kısa Kılıç2");
        kiliclar[2] = Resources.Load<AudioClip>("Kısa Kılıç3");
        kiliclar[3] = Resources.Load<AudioClip>("Kısa Kılıç4");
        kiliclar[4] = Resources.Load<AudioClip>("Kısa Kılıç5");



        adim = Resources.Load<AudioClip>("Step1");

        swords[0] = Resources.Load<AudioClip>("Sword1");
        swords[1] = Resources.Load<AudioClip>("Sword2");
        swords[2] = Resources.Load<AudioClip>("Sword3");

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "almak":
                audioSource.PlayOneShot(almak);
                break;

            case "click":
                audioSource.PlayOneShot(click);
                break;

            case "kapiGicirti":
                audioSource.PlayOneShot(kapiGicirti);
                break;

            case "kilic":

                audioSource.PlayOneShot(kiliclar[Random.Range(0, 5)]);
                break;


            case "adim":
                audioSource.PlayOneShot(adim);
                break;


            case "sword":
                audioSource.PlayOneShot(swords[Random.Range(0, 3)]);
                break;
        }
    }

}
