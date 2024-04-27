using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArtifactData", menuName = "Artifact/ArtifactData", order = int.MaxValue)]
public class Artifact : ScriptableObject
{
    [SerializeField] private string artifactName;
    public string ArtifactName { get { return artifactName; } }

    [SerializeField] private Sprite artifactSprite;
    public Sprite ArtifactSprite { get { return artifactSprite; } }
}

