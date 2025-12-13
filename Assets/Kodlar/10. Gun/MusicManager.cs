using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public enum currentMusic
// {
//     TranceMusic =0,
//     ChillMusic =1,
//     DanceMusic =2
// }

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public List<AudioClip> musicClips;
    public AudioSource musicSource;

    public float musicMaxVolume = 1;

    public float musicVolumeChangeTimer = 2;
    public float musicChangeTimer = 8;

    private bool isMusicChanging;
    private float changeTimer;
    // private string currentMusic;
    // private bool music = true;

    // private currentMusic musicPlayed;
    private int currentIndex = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicMaxVolume = 1;
        SetNewMusic();
        // musicPlayed = currentMusic.TranceMusic;
    }

    void Update()
    {
        if (!isMusicChanging)
        {
            changeTimer += Time.deltaTime;
        }
        else
        {
            return;
        }

        if (changeTimer >= musicChangeTimer)
        {
            ChangeMusic();
        }
    }

    public void ChangeMusic()
    {
        isMusicChanging = true;
        changeTimer = 0;
        StartCoroutine(ChangeMusicRoutine());
    }

    IEnumerator ChangeMusicRoutine()
    {
        yield return StartCoroutine(DecreaseVolume());
        SetNewMusic();
        yield return StartCoroutine(IncreaseVolume());
    }

    private void SetNewMusic()
    {
        musicSource.Stop();
        // musicSource.clip = musicClips[UnityEngine.Random.Range(0, musicClips.Count)];

        // if (string.IsNullOrEmpty(currentMusic))
        // {
        //     musicSource.clip = musicClips[0];
        //     currentMusic = "music1";
        // }
        // else if (currentMusic == "music1")
        // {
        //     musicSource.clip = musicClips[1];
        //     currentMusic = "music2";
        // }
        // else
        // {
        //     musicSource.clip = musicClips[0];
        //     currentMusic = "music1";
        // }

        // if (music)
        // {
        //     musicSource.clip = musicClips[0];
        // }
        // else
        // {
        //     musicSource.clip = musicClips[1];
        // }
        // music = !music;

        // int index = UnityEngine.Random.Range(0, 2);
        // while (currentIndex == index)
        // {
        //     index = UnityEngine.Random.Range(0, 2);
        // }
        int index;
        do
        {
            index = UnityEngine.Random.Range(0, 3);
        } while (index == currentIndex);
        currentIndex = index;

        musicSource.clip = musicClips[index];

        // switch (musicPlayed)
        // {
        //     case currentMusic.TranceMusic:
        //         musicSource.clip = musicClips[0];
        //         musicPlayed = currentMusic.ChillMusic;
        //         break;
        //     case currentMusic.ChillMusic:
        //         musicSource.clip = musicClips[1];
        //         musicPlayed = currentMusic.DanceMusic;
        //         break;
        //     case currentMusic.DanceMusic:
        //         musicSource.clip = musicClips[2];
        //         musicPlayed = currentMusic.TranceMusic;
        //         break;
        //     default:
        //         break;
        // }



        musicSource.Play();
    }

    IEnumerator IncreaseVolume()
    {
        while (musicSource.volume < musicMaxVolume)
        {
            musicSource.volume += (musicMaxVolume / musicVolumeChangeTimer) * Time.deltaTime;
            yield return null;
        }

        if (musicSource.volume >= musicMaxVolume)
        {
            isMusicChanging = false;
        }
    }

    IEnumerator DecreaseVolume()
    {
        while (musicSource.volume != 0)
        {
            musicSource.volume -= (musicMaxVolume / musicVolumeChangeTimer) * Time.deltaTime;
            yield return null;
        }
    }
}
