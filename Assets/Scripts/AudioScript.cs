using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// borrowed from https://forum.unity.com/threads/best-way-to-play-intermittent-random-sounds.856216/#post-5644465

public class SoundEffectPlayer : MonoBehaviour
{
	private AudioSource audioSource;
	public List<AudioClip> audioClips;
	public AudioClip currentClip;
	public float minWaitBetweenPlays = 1f;
    public float maxWaitBetweenPlays = 5f;
    public float waitTimeCountdown = -1f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying) {
            if (waitTimeCountdown < 0f)
            {
                currentClip = audioClips[Random.Range(0, audioClips.Count)];
                audioSource.clip = currentClip;
                audioSource.Play();
                waitTimeCountdown = Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
            }
            else
            {
                waitTimeCountdown -= Time.deltaTime;
            }
        }
    }
}