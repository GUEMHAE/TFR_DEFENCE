using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEscUI : MonoBehaviour
{
    public Slider BGMSlider;
    public Slider EffectSlider;

    // Start is called before the first frame update
    void Start()
    {
        BGMSlider.onValueChanged.AddListener(BG);
        EffectSlider.onValueChanged.AddListener(Effect);
    }

    void BG(float volume)
    {
        SoundManager SM = SoundManager.instance;

        if (SM != null)
        {
            SM.audioBGMPlayer.volume = volume;
        }
    }

    void Effect(float volume)
    {
        // SoundManager의 인스턴스를 가져옴
        SoundManager SM = SoundManager.instance;

        // SoundManager의 인스턴스가 존재하는 경우
        if (SM != null)
        {
            // 배경 음악의 볼륨을 슬라이더의 값으로 설정
            SM.audioEffectPlayer.volume = volume;
        }
    }
}
