using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MySingleton<MusicManager>
{
    public AudioSource audioSource;
    public AudioClip theme;
    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;
    public AudioClip spin;
    public AudioClip die;
    public AudioClip hitEffect;
    public AudioClip click;
    public AudioMixer mixer;
    public AudioClip pick_up;
    public AudioClip gold;
    public string parameterName = "MasterVolume";
    public bool hit_effect_is_playing;
    public float timer;
    public AudioClip spawn_sound;
    public void PlaySpawnSound()
    {
        audioSource.PlayOneShot(spawn_sound);
    }
    public void PlayPickUpSound()
    {
        audioSource.PlayOneShot(pick_up);
    }
    public void PlayGoldSound()
    {
        audioSource.PlayOneShot(gold);
    }
    public void PlayHitEffect()
    {
        if (!hit_effect_is_playing)
        {
            audioSource.PlayOneShot(hitEffect);
            hit_effect_is_playing = true;
            timer = 0;
        }

    }

    private void FixedUpdate()
    {
        if (hit_effect_is_playing == true)
        {
            timer += Time.fixedDeltaTime;
        }
        if(timer>=0.5f)
        {
            hit_effect_is_playing=false;
        }
        
    }


    private void Start()
    {
        timer = 0;
        hit_effect_is_playing = false;
    }


    protected float Volume
    {
        get
        {
            float parameter;
            mixer.GetFloat(parameterName, out parameter);
            return parameter;
        }
        set
        {
            mixer.SetFloat(parameterName, value);
        }
    }
    public void SetVolume(float volume)
    {
        Volume = volume;
    }


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Volume = 0;
    }
    public void PlayMusic(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

}


