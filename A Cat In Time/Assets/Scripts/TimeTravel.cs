using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeTravel : MonoBehaviour {
    private bool travelComplete = true;     //damit man nicht spammen kann
    private Vector3 newPos;
    private Camera mainCam;

    [SerializeField]
    private AudioClip[] audioClips;

    private AudioSource audioSource;

    [SerializeField]
    private Image passout;

    public static TimeTravel Instance;

    private bool initiatedTravel = false;
    private Color passoutColor;

    [SerializeField]
    private float blinkduration = 2f;

    [SerializeField]
    private Gradient blinkGradient;

    private float blinkGradientPosition;

    private void Awake()
    {
        Instance = this;
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void OnSceneLoad(Scene arg0, LoadSceneMode arg1)
    {
        mainCam = Camera.main;
        initiatedTravel = false;
        blinkGradientPosition = 0f;
    }

    private void Start() {

        audioSource = GetComponent<AudioSource>();
        passoutColor = new Color(0, 0, 0, 1);
    }


    private void Update() {

        if (!initiatedTravel) {
            blinkGradientPosition += 1/blinkduration * Time.deltaTime;
            passoutColor.a = 1f - blinkGradient.Evaluate(blinkGradientPosition).r;
        }
        
        if (initiatedTravel) {
            
            passoutColor.a += 1.4f * Time.deltaTime;
            mainCam.fieldOfView += 90 * Time.deltaTime;
        }
        passout.color = passoutColor;
    }
    
    public void DoIt() {
        SoundEffect();
        StartCoroutine(StartTravel());
    }

    void SoundEffect()
    {
        if(SceneManager.GetActiveScene().buildIndex % 2 == 0)
        {
            audioSource.Stop();
            audioSource.clip = audioClips[1];
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }
        
    }

    //thIs Is wHErE tHe mAGiC HapENs
    public IEnumerator StartTravel() {
        initiatedTravel = true;
        yield return new WaitForSeconds(1f);
        //EKELHAFT. HARDCODED. DIRTY. PAH!

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:             
                SceneManager.LoadScene(2);
                break;
            case 2:
                SceneManager.LoadScene(1);
                break;
            case 3:
                SceneManager.LoadScene(4);
                break;
            case 4:
                SceneManager.LoadScene(3);
                break;
            case 5:
                SceneManager.LoadScene(6);
                break;
            case 6:
                SceneManager.LoadScene(5);
                break;
            case 7:
                SceneManager.LoadScene(8);
                break;
            case 8:
                SceneManager.LoadScene(7);
                break;

        }

    }



}
