using UnityEngine;

public class PlayerAudio : MonoBehaviour

{
    private AudioSource audioSource;
    public AudioClip coinSound;
    public AudioClip jumpSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySFX(AudioClip sfx)
    {
        audioSource.PlayOneShot(sfx);
    }
}
