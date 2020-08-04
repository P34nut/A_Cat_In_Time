using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimonSays : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform panel;
    //public Sprite[] sprites;          //Sprites zur besseren Darstellung der Tanzschritte hinzufügen

    private int bleepCount = 3;

    List<int> bleeps;
    List<int> playerBleeps;

    System.Random randomGenerator;

    bool inputEnabled = false;
    bool gameOver = false;

    public Animator animator;

    public void StartGame()
    {
        panel.gameObject.SetActive(true);

        CreatePlayerButtons("1", 0);
        CreatePlayerButtons("2", 1);
        CreatePlayerButtons("3", 2);
        CreatePlayerButtons("4", 3);

        StartCoroutine(IESimonSays());
    }

    //Instantiate Button
    void CreatePlayerButtons(string name, int index)
    {

        GameObject playerButton = Instantiate<GameObject>(buttonPrefab, panel);
        playerButton.name = name;
        playerButton.GetComponentInChildren<TMP_Text>().text = name;
        //playerButton.GetComponent<Image>().sprite = sprites[index];               //Füge Sprite dem Button hinzu

        playerButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            OnButtonClicked(index);
        });
    }

    void GameOver()
    {
        gameOver = true;
        inputEnabled = false;
        Debug.Log("GAME OVER"); //Do Something when Game Over
    }

    void OnButtonClicked(int index)
    {
        if (!inputEnabled)
        {
            return;
        }

        ShowAnim(index);

        playerBleeps.Add(index);

        if (bleeps[playerBleeps.Count -1] != index)
        {
            GameOver();
            return;
        }

        if (bleeps.Count == playerBleeps.Count)
        {
            StartCoroutine(IESimonSays());
        }

    }

    IEnumerator IESimonSays()
    {
        inputEnabled = false;

        randomGenerator = new System.Random("SimonSays".GetHashCode());

        SetBleeps();

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < bleeps.Count; i++)
        {
            ShowAnim(bleeps[i]);
            AnimatorClipInfo[] clipInfos = animator.GetCurrentAnimatorClipInfo(0);
            yield return new WaitForSeconds(clipInfos[0].clip.length);         
        }

        inputEnabled = true;

        yield return null;

    }

    void ShowAnim(int index)
    {
        switch (index)
        {
            case 0:
                animator.Play("Hit");
                Debug.Log("SimonSays: 1");
                break;
            case 1:
                animator.Play("Hit2");
                Debug.Log("SimonSays: 2");
                break;
            case 2:
                animator.Play("Spell");
                Debug.Log("SimonSays: 3");
                break;
            case 3:
                animator.Play("Death");
                Debug.Log("SimonSays: 4");
                break;
        }

        PlayAudio();
        
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
            bleeps.Add(randomGenerator.Next(0, 3));
        }

        bleepCount++;
    }


}
