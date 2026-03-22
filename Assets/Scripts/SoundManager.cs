using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Clips")]
    public AudioClip shootSound;
    public AudioClip hitSound;
    public AudioClip destroySound;
    public AudioClip spawnSound;
    public AudioClip backgroundMusic;

    [Header("Volume Control")]
    [Range(0f, 1f)] public float shootVolume = 0.4f;
    [Range(0f, 1f)] public float hitVolume = 0.25f;
    [Range(0f, 1f)] public float destroyVolume = 0.7f;
    [Range(0f, 1f)] public float spawnVolume = 0.2f;
    [Range(0f, 1f)] public float musicVolume = 0.4f;

    [Header("Cooldown (anti-spam)")]
    public float hitCooldown = 0.2f;

    private AudioSource audioSource;

    private Dictionary<AudioClip, float> lastPlayedTime = new Dictionary<AudioClip, float>();

    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        // play background music (loop)
        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.volume = musicVolume;
            audioSource.Play();
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip == null) return;

        float volume = 1f;
        float cooldown = 0f;

        
        if (clip == shootSound) volume = shootVolume;
        else if (clip == hitSound)
        {
            volume = hitVolume;
            cooldown = hitCooldown; 
        }
        else if (clip == destroySound) volume = destroyVolume;
        else if (clip == spawnSound) volume = spawnVolume;

        
        if (!lastPlayedTime.ContainsKey(clip))
            lastPlayedTime[clip] = -999f;

        if (Time.time - lastPlayedTime[clip] < cooldown)
            return;

        lastPlayedTime[clip] = Time.time;

        
        audioSource.pitch = 1f + Random.Range(-0.1f, 0.1f);

        audioSource.PlayOneShot(clip, volume);
    }
}