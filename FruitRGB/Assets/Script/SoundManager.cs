using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioClip sound_Cut;
    public AudioClip sound_Nock;
    public AudioSource sound_bg;
    AudioSource myAudio;

    public static SoundManager instance;

    void Awake()
    {
        if (SoundManager.instance == null)
            SoundManager.instance = this;
    }

    // Use this for initialization
    void Start () {
        myAudio = GetComponent<AudioSource>();
    }

    public void PlaySound(int a)
    {
        switch (a)
        {
            case 1:
                myAudio.PlayOneShot(sound_Cut);
                break;
            case 2:
                myAudio.PlayOneShot(sound_Nock);
                break;
        }
    }

	// Update is called once per frame
	void Update () {
        // 배경음악 점점 크게 작게
        if (sound_bg.volume > 0.7f)
            sound_bg.volume = 0.7f;

        if (sound_bg.volume != 0.7f)
        {
            sound_bg.volume += 0.2f * Time.deltaTime;
        }
    }
}
