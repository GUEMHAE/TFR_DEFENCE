using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollider : MonoBehaviour //파티클 요소 개별로 collider를 주기 위한 스크립트
{
    public ParticleSystem particleSystem;
    public GameObject particlePrefab; // Collider가 있는 파티클 대표 GameObject

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

        // 파티클 수에 변화가 있을 경우 불필요한 GameObject를 제거
        for (int i = particleCount; i < particleObjects.Length; i++)
        {
            if (particleObjects[i] != null)
                Destroy(particleObjects[i]);
        }
    }
}
