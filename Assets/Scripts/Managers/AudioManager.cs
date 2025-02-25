using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip teleTypeFX;
    [SerializeField] private AudioSource audioSource;

    public void PlayTeleTypeFX()
    {
        audioSource.clip = teleTypeFX;
        audioSource.Play();
    }

    public void StopSoundFX()
    {
        audioSource.Stop();
    }
}
