using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPuzzleHadler : MonoBehaviour
{
    [SerializeField]
    PositionPuzzle[] scripts;
    public static PositionPuzzleHadler Instance;
    public bool[] isCorrect;
    bool b = true;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        isCorrect = new bool[4];
        StartPuzzle();
    }

    private void Update()
    {
        if (isCorrect[0] && isCorrect[1] && isCorrect[2] && isCorrect[3] && b)
        {
            b = false;
            WonGame();
        }
    }

    public void StartPuzzle()
    {
        //if (!SettingsHandler.Instance.didRiddle[2])
        //{
            for (int i = 0; i < scripts.Length; i++)
            {
                scripts[i].StartGame();
            }
        //}
    }

    void WonGame()
    {
        SettingsHandler.Instance.didRiddle[2] = true;
        showTokenUI.Instance.setTokenUI(2);
        Invoke(nameof(to2020), 3f);
    }

    void to2020()
    {
        TimeTravel.Instance.DoIt();
    }


}
