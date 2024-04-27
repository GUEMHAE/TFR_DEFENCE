using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollider : MonoBehaviour //��ƼŬ ��� ������ collider�� �ֱ� ���� ��ũ��Ʈ
{
    public ParticleSystem particleSystem;
    public GameObject particlePrefab; // Collider�� �ִ� ��ƼŬ ��ǥ GameObject

    private ParticleSystem.Particle[] particles;
    private GameObject[] particleObjects;

    void Start()
    {
        particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
        particleObjects = new GameObject[particleSystem.main.maxParticles];
    }

    void Update()
    {
        int particleCount = particleSystem.GetParticles(particles);

        for (int i = 0; i < particleCount; i++)
        {
            if (particleObjects[i] == null)
            {
                particleObjects[i] = Instantiate(particlePrefab, particles[i].position, Quaternion.identity);
            }
            else
            {
                particleObjects[i].transform.position = particles[i].position;
            }
        }

        // ��ƼŬ ���� ��ȭ�� ���� ��� ���ʿ��� GameObject�� ����
        for (int i = particleCount; i < particleObjects.Length; i++)
        {
            if (particleObjects[i] != null)
                Destroy(particleObjects[i]);
        }
    }
}
