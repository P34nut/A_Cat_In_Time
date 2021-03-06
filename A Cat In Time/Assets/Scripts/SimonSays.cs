﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimonSays : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform panel;
    public Sprite[] sprites;
    public Mesh[] Meshes;
    MeshFilter meshFilter;

    private int bleepCount;
    [SerializeField]
    private int roundCount;

    List<int> bleeps;
    List<int> playerBleeps;
    List<GameObject> playerButtons;

    System.Random randomGenerator;

    bool inputEnabled = false;
    bool gameOver = false;
    bool startedGame = false;

    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip[] audioClips;

    //public Animator animator;

    private void OnMouseDown()
    {
        StartGame();
    }

    public void StartGame()
    {
        
        meshFilter = GetComponent<MeshFilter>();
        //if (!SettingsHandler.Instance.didRiddle[1] && !startedGame)
        //{
            startedGame = true;
            bleepCount = 3;
            playerButtons = new List<GameObject>();

            panel.gameObject.SetActive(true);

            CreatePlayerButtons("1", 0);
            CreatePlayerButtons("2", 1);
            CreatePlayerButtons("3", 2);
            CreatePlayerButtons("4", 3);

            StartCoroutine(IESimonSays());
        //}
    }

    //Instantiate Button
    void CreatePlayerButtons(string name, int index)
    {

        GameObject playerButton = Instantiate<GameObject>(buttonPrefab, panel);
        playerButton.name = name;
        playerButton.GetComponent<Image>().sprite = sprites[index];

        playerButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            OnButtonClicked(index);
        });

        playerButtons.Add(playerButton);
    }

    void Win()
    {
        StopAllCoroutines();
        //animator.Play("Idle"); ///////////////////////////////////////////////////////
        meshFilter.mesh = Meshes[0];
        audioSource.clip = audioClips[1]; 
        audioSource.Play();
        
        SettingsHandler.Instance.didRiddle[1] = true;
        showTokenUI.Instance.setTokenUI(1);
        Invoke(nameof(to2020), 3f);
    }

    void to2020()
    {
        TimeTravel.Instance.DoIt();
    }

    void GameOver()
    {
        Debug.Log("GAME OVER");
        roundCount = 0;
        gameOver = true;
        inputEnabled = false;

        for (int i = 0; i < playerButtons.Count; i++)
        {
            Destroy(playerButtons[i]);
        }
        playerButtons.Clear();
        panel.gameObject.SetActive(false);
        //animator.Play("Idle"); ////////////////////////////////////////////////
        meshFilter.mesh = Meshes[0];
        audioSource.clip = audioClips[0];
        audioSource.Play();
        gameOver = false;
        startedGame = false;
    }

    void OnButtonClicked(int index)
    {
        if (!inputEnabled)
        {
            return;
        }

        ShowPose(index);

        StartCoroutine(Delay(.5f));

        playerBleeps.Add(index);

        if (bleeps[playerBleeps.Count -1] != index)
        {
            GameOver();
            return;
        }

        if (bleeps.Count == playerBleeps.Count)
        {

            roundCount++;

            if (roundCount == 4)
            {
                Win();
            }
            else
            {
                StartCoroutine(IESimonSays());
            }
        }

    }

    IEnumerator IESimonSays()
    {
        yield return new WaitForSeconds(.5f);
        inputEnabled = false;

        //Random nach Seed, dadurch aber jeder Durchlauf gleich. Falls jedes mal anders --> in Start eine RandomZahl erzeugen die als Seed nehmen
        randomGenerator = new System.Random("StadtmuseumHFUSimonSays".GetHashCode()); 

        SetBleeps();

        yield return new WaitForSeconds(1f);
        Debug.Log("______________________________________________");
        for (int i = 0; i < bleeps.Count; i++)
        {
            ShowPose(bleeps[i]); 
            //AnimatorClipInfo[] clipInfos = animator.GetCurrentAnimatorClipInfo(0); /////////////////////////////////////////
            //yield return new WaitForSeconds(clipInfos[0].clip.length);
            yield return new WaitForSeconds(.5f);
            meshFilter.mesh = Meshes[0];
            yield return new WaitForSeconds(.5f);
        }
        Debug.Log("--------------------------------------------------");
        meshFilter.mesh = Meshes[0];
        inputEnabled = true;

        yield return null;

    }

    void ShowPose(int index) ///////////////////////////
    {
        switch (index)
        {
            //load 3d models instead of Mesh
            case 0:
                //animator.Play("Hit");
                meshFilter.mesh = Meshes[1];
                Debug.Log("SimonSays: 1");
                break;
            case 1:
                //animator.Play("Hit2");
                meshFilter.mesh = Meshes[2];
                Debug.Log("SimonSays: 2");
                break;
            case 2:
                //animator.Play("Spell");
                meshFilter.mesh = Meshes[3];
                Debug.Log("SimonSays: 3");
                break;
            case 3:
                //animator.Play("Death");
                meshFilter.mesh = Meshes[4];
                Debug.Log("SimonSays: 4");
                break;
            case 4:
                meshFilter.mesh = Meshes[0];
                break;
        }

        //PlayAudio();
        
    }

    void PlayAudio()
    {
        Debug.Log("Audio Playing");  //Hier fehlt dann noch Audio?
    }

    void SetBleeps()
    {
        bleeps = new List<int>();
        playerBleeps = new List<int>();

        for (int i = 0; i < bleepCount; i++)
        {
            bleeps.Add(randomGenerator.Next(0, 4));
        }

        bleepCount++;
    }

    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);

        meshFilter.mesh = Meshes[0];

    }


}
