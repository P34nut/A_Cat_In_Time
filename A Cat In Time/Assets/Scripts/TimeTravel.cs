using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeTravel : MonoBehaviour {
    private bool travelComplete = true;     //damit man nicht spammen kann
    //private Vector3 newPos;
    //private Quaternion newRot;
    private Camera mainCam;
    //private Transform player;

    [SerializeField]
    private GameObject Licht;
    [SerializeField]
    private GameObject Kerze;

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
        //newPos = new Vector3(-13f, 1.55f, -6.6f);
        //newRot = new Quaternion(0, 0, 0,0);
        
    }

    private void OnSceneLoad(Scene arg0, LoadSceneMode arg1)
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //player.position = newPos;
        //player.rotation = newRot;
        mainCam = Camera.main;
        initiatedTravel = false;
        blinkGradientPosition = 0f;
        //mainCam.fieldOfView = 60f;

        if (SceneManager.GetActiveScene().buildIndex != 7 && SceneManager.GetActiveScene().buildIndex != 1)
        {
            Licht.SetActive(false);
            Kerze.SetActive(false);
        }
        else if(SceneManager.GetActiveScene().buildIndex == 7)
        {
            Licht.SetActive(true);
            Kerze.SetActive(true);
        }

    }

    private void Start() {

        audioSource = GetComponent<AudioSource>();
        passoutColor = new Color(0, 0, 0, 1);
        Licht = GameObject.FindGameObjectWithTag("Licht");
        Kerze = GameObject.FindGameObjectWithTag("Kerze");
        Licht.SetActive(false);
        Kerze.SetActive(false);

    }


    private void Update() {

        if (!initiatedTravel) {
            blinkGradientPosition += 1/blinkduration * Time.deltaTime;
            passoutColor.a = 1f - blinkGradient.Evaluate(blinkGradientPosition).r;

            if (mainCam.fieldOfView > 60f)
            {
                mainCam.fieldOfView -= 90 * Time.deltaTime;
            }

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
        SettingsHandler.Instance.onSpawnLocation = false;
        //newPos = player.position;
        //newRot = player.rotation;
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
