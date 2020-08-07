using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public AudioMixerGroup audioMixer;
    public AudioClip[] audioClips;


    AudioSource audioSourceA;
    AudioSource audioSourceB;
    

    float musicVolume = 1.0f;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += LevelLoad;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSourceA = gameObject.AddComponent<AudioSource>();
        audioSourceB = gameObject.AddComponent<AudioSource>();

        audioSourceA.volume = musicVolume;
        audioSourceB.volume = 0.0f;

        audioSourceA.outputAudioMixerGroup = audioMixer;
        audioSourceB.outputAudioMixerGroup = audioMixer;

        if (audioClips.Length > 0)
        {
            audioSourceA.clip = audioClips[0];
            audioSourceB.loop = true;
            audioSourceA.loop = true;
            audioSourceA.Play();
        }

    }

    IEnumerator CrossFade(AudioSource audioA, AudioSource audioB, float seconds)
    {
        float step_interval = seconds / 20.0f;
        float vol_interval = musicVolume / 20.0f;

        audioB.time = audioA.time;
        audioB.Play();

        for (int i = 0; i < 20; i++)
        {
            audioA.volume -= vol_interval;
            audioB.volume += vol_interval;

            yield return new WaitForSeconds(step_interval);
        }

        audioA.Stop();

    }
    
    public IEnumerator SwitchTrack(int trackIndex)
    {
        bool play_a = true;

        if (audioSourceB.volume == 0.0f)
        {
            play_a = false;
        }

        if (play_a)
        {
            audioSourceA.clip = audioClips[trackIndex];
            if (audioSourceA.clip != audioSourceB.clip)
            {
                yield return StartCoroutine(CrossFade(audioSourceB, audioSourceA, 2.0f));
            }
        }
        else
        {
            audioSourceB.clip = audioClips[trackIndex];
            if (audioSourceA.clip != audioSourceB.clip)
            {
                yield return StartCoroutine(CrossFade(audioSourceA, audioSourceB, 2.0f));
            }
        }

    }

    void LevelLoad(Scene scene, LoadSceneMode mode)
    {
        int level = scene.buildIndex;

        if (level!= 0)
        {
            StartCoroutine(SwitchTrack(level));
        }
    }

    void PauseMusic()
    {
        audioSourceA.Pause();
        audioSourceB.Pause();
    }

    void UnPauseMusic()
    {
        audioSourceA.UnPause();
        audioSourceB.UnPause();
    }

    private void Update()
    {
    }

}
