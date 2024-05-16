using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioManager : MonoBehaviour
{
    public AudioSource audioSource; // 조절할 오디오 소스
    public Slider audioSlider; // 음량을 조절할 슬라이더

    void Start()
    {
        // 슬라이더의 값이 변경될 때마다 OnVolumeChanged 함수를 호출
        audioSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    // 슬라이더 값이 변경될 때 호출되는 함수
    void OnVolumeChanged(float volume)
    {
        // 오디오 소스의 볼륨을 슬라이더의 값으로 설정
        audioSource.volume = volume;
    }
}
