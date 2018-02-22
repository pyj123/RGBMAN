﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private AudioSource bgmSource;
    private Dictionary<string, AudioClip> soundEffectPool;
    private Dictionary<string, AudioClip> bgmPool;
    private ObjectPool<EachSound> soundPool;
    [SerializeField]
    private EachSound eachSoundPrefab;

    public float BgmVolume
    {
        get
        {
            return PlayerPrefs.GetFloat(PlayerPrefKeys.BgmVolumeKey, 0.7f);
        }
    }

    public float EffectVolume
    {
        get
        {
            return PlayerPrefs.GetFloat(PlayerPrefKeys.EffectVolumeKey, 1f);


        }
    }

    public bool IsBgmMute
    {
        get
        {
            if (PlayerPrefs.GetInt(PlayerPrefKeys.BgmMuteKey, 1) == 0)
                return true;
            else
                return false;
        }
    }
    public void SetBgmMute()
    {
        if (bgmSource == null) return;
        bgmSource.mute = IsBgmMute;
    }
    public bool IsEffectMute
    {
        get
        {
            if (PlayerPrefs.GetInt(PlayerPrefKeys.EffectMuteKey, 1) == 0)
                return true;
            else
                return false;
        }
    }

    private void SetBgmDefaultOption()
    {
        if (bgmSource == null) return;

        SetBgmMute();

        bgmSource.volume = BgmVolume;
    }


    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            soundEffectPool = new Dictionary<string, AudioClip>();
            bgmPool = new Dictionary<string, AudioClip>();
            MakeSoundPool();
            bgmSource = GetComponent<AudioSource>();
            bgmSource.volume = BgmVolume;
            bgmSource.loop = true;
            LoadSounds();
            SetBgmDefaultOption();
       

            DontDestroyOnLoad(Instance.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void SetBgmVolume()
    {
        if (bgmSource == null) return;
        bgmSource.volume = BgmVolume;
    }
    private void MakeSoundPool()
    {
        soundPool = new ObjectPool<EachSound>(eachSoundPrefab, 10, this.transform);
    }
    private void LoadSounds()
    {
        LoadBGM();
        LoadSoundEffect();
    }

    private void LoadBGM()
    {
        AudioClip[] clips = Resources.LoadAll<AudioClip>("Sounds/Bgm");

        for (int i = 0; i < clips.Length; i++)
        {
            bgmPool.Add(clips[i].name, clips[i]);
        }
    }

    public AudioClip GetClip(string name)
    {
        if (soundEffectPool == null) return null;
        if (soundEffectPool.Count == 0) return null;
        if (soundEffectPool.ContainsKey(name) == false) return null;

        return soundEffectPool[name];
    }


    private void LoadSoundEffect()
    {
        AudioClip[] clips = Resources.LoadAll<AudioClip>("Sounds/Effect");

        for (int i = 0; i < clips.Length; i++)
        {
            soundEffectPool.Add(clips[i].name, clips[i]);
        }
    }

    public void PlayBgm(string soundName,bool InstantPlay = false)
    {
        //if (IsBgmMute==true) return;
        if (bgmSource == null || bgmPool == null) return;
        if (bgmPool.ContainsKey(soundName) == false) return;

        bgmSource.clip = bgmPool[soundName];
        bgmSource.Play();
        if (InstantPlay == false)
        {
            StopCoroutine("SlowStartBgm");
            StartCoroutine(SlowStartBgm());
        }
  
    }

    public void SetBGMPitch(float value)
    {
        if (bgmSource == null) return;
        bgmSource.pitch = value;
    }

    public void EndBgm()
    {
        SlowEndBgm();
    }

    public void ChangeBgm(string name)
    {
        StartCoroutine(BgmChangeRoutine(name));
    }

    IEnumerator BgmChangeRoutine(string name)
    {
        yield return StartCoroutine(SlowEndBgm());
        PlayBgm(name);
    }

    IEnumerator SlowEndBgm()
    {
        float countVolume = 0f;
        float count = 0f;

        if (bgmSource != null)
            bgmSource.volume = 0f;

        while (true)
        {
            count += Time.deltaTime;
            countVolume = Mathf.Lerp(BgmVolume, 0f, count);

            if (bgmSource != null)
                bgmSource.volume = countVolume;

            if (count >= 1f)
            {
                countVolume = BgmVolume;
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator SlowStartBgm()
    {
        float countVolume = 0f;
        float count = 0f;

        if (bgmSource != null)
            bgmSource.volume = 0f;

        while (true)
        {
            count += Time.deltaTime;
            countVolume = Mathf.Lerp(0f, BgmVolume, count);

            if (bgmSource != null)
                bgmSource.volume = countVolume;

            if (count >= 1f)
            {
                countVolume = BgmVolume;
                yield break;
            }
            yield return null;
        }

    }

    public void PlaySoundEffect(string soundName)
    {                                                               //0 = false
        if (IsEffectMute == true) return;
        PlayerOneShot(soundName);
    }

    private void PlayerOneShot(string soundName)
    {
        if (soundEffectPool == null) return;
        if (soundEffectPool.ContainsKey(soundName) == false) return;
        if (soundPool == null) return;
        EachSound eachSound = soundPool.GetItem();
        if (eachSound != null)
        {
            eachSound.Initialize(soundEffectPool[soundName], EffectVolume);
            eachSound.transform.position = Camera.main.transform.position;
        }
    }


}
