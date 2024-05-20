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
        // SoundManager�� �ν��Ͻ��� ������
        SoundManager SM = SoundManager.instance;

        // SoundManager�� �ν��Ͻ��� �����ϴ� ���
        if (SM != null)
        {
            // ��� ������ ������ �����̴��� ������ ����
            SM.audioEffectPlayer.volume = volume;
        }
    }
}
