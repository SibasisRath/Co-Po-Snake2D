using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/SoundInfo")]
public class SoundInfo : ScriptableObject
{
    [SerializeField] [Range(0, 1)] private float backGroundSound;
    [SerializeField] [Range(0, 1)] private float soundEffect;

    public float BackGroundSound { get => backGroundSound; set => backGroundSound = value; }
    public float SoundEffect { get => soundEffect; set => soundEffect = value; }
}
