using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioManager : MonoBehaviour
{
    public AudioSource audioSource; // ������ ����� �ҽ�
    public Slider audioSlider; // ������ ������ �����̴�

    void Start()
    {
        // �����̴��� ���� ����� ������ OnVolumeChanged �Լ��� ȣ��
        audioSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    // �����̴� ���� ����� �� ȣ��Ǵ� �Լ�
    void OnVolumeChanged(float volume)
    {
        // ����� �ҽ��� ������ �����̴��� ������ ����
        audioSource.volume = volume;
    }
}
