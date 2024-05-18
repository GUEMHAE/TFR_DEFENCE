using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioBGMPlayer;
    public AudioSource audioEffectPlayer;
    public AudioClip[] bgList;
    public AudioClip[] effectSoundList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        TitleBGM();
    }

    private void Start()
    {
        audioBGMPlayer = GetComponent<AudioSource>();
        audioEffectPlayer = gameObject.AddComponent<AudioSource>();
        audioEffectPlayer.volume = 0.6f;
        SceneManager.sceneLoaded += OnSceneLoaded; // 씬이 로드될 때 호출될 메서드 등록
    }

    private void OnSceneLoaded(Scene sceneName, LoadSceneMode mode) //씬에 따라 브금 재생을 위한 메소드
    {
        if (sceneName.name == "TitleScene")
        {
            TitleBGM();
        }
        else if(sceneName.name=="Tutorial"||sceneName.name=="Game")
        {
            MainBGM();
        }
        else
        {
            audioBGMPlayer.Stop();
        }
    }

    public void TitleBGM()
    {
        audioBGMPlayer.clip = bgList[0];
        audioBGMPlayer.loop = true;
        audioBGMPlayer.Play();
    }

    public void MainBGM()
    {
        audioBGMPlayer.clip = bgList[1];
        audioBGMPlayer.loop = true;
        audioBGMPlayer.Play();
    }

    public void SelectUISound()
    {
        audioEffectPlayer.PlayOneShot(effectSoundList[0]);
    }

    public void UnitEffectSound(int index)
    {
        audioEffectPlayer.PlayOneShot(effectSoundList[index]);
    }
}
