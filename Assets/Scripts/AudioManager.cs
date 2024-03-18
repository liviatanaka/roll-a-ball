using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------- Audio Sources --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip -----------")]

    public AudioClip background;
    public AudioClip coin;
    public AudioClip damage;
    public AudioClip special;
    public AudioClip victory;
    public AudioClip death;


    private void Start(){
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic(){
        musicSource.Stop();
    }

    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }

}
