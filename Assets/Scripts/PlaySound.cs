using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource buttonSound;

    public void PlayButtonSound()
    {
        buttonSound.Play();
    }
}
