using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchScene(int goToScene)
    {
        SettingsHandler.Instance.onSpawnLocation = true;
        SceneManager.LoadScene(goToScene);
        
    }
}
