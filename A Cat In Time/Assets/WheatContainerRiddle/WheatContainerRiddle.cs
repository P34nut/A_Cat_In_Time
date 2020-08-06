using UnityEngine;
using UnityEngine.SceneManagement;

public class WheatContainerRiddle : MonoBehaviour
{
    [SerializeField]
    WheatContainer[] Containers;

    [SerializeField]
    GameObject Scoop;

    [SerializeField]
    int scoopSize; //in Fractions
    public int scoopFillstate;

    float animationSpeed = 2;

    //Take scoop of wheat from a container - only possible when scoop is empty
    public void TakeScoopFromContainer(int ct)
    {
        if (scoopFillstate != 0)
            return;
        
        if (Containers[ct].GetFillstate() >= scoopSize)
            scoopFillstate = scoopSize;
    
        else
            scoopFillstate = Containers[ct].GetFillstate();
        
        Containers[ct].SetFillstate(Containers[ct].GetFillstate() - scoopFillstate);
    }

    //Add wheat from the scoop to a container - if the container has not enough empty space, only transfer the possible ammount
    public void AddScoopToContainer(int ct)
    {
        int totransfer = Mathf.Clamp(scoopFillstate, 0, Containers[ct].GetEmptySpace());
        Containers[ct].SetFillstate(Containers[ct].GetFillstate() + totransfer);
        scoopFillstate -= totransfer;
        if (Solved()) 
            Invoke(nameof(Win), 1.5f);
    }

    //Returns true if all fillstates are equal - currently only works with 3 containers
    bool Solved()
    {
        return (Containers[0].GetFillstate() == Containers[1].GetFillstate() &
         Containers[0].GetFillstate() == Containers[2].GetFillstate());
    }

    void Win() {
        GetComponent<AudioSource>().Play();
        Debug.Log("Kornmarkträtsel gewonnen!");
        Invoke(nameof(to2020), 3f);
        SettingsHandler.Instance.didRiddle[0] = true;
        showTokenUI.Instance.setTokenUI(0);
    }

    void to2020() {
        StartCoroutine(GameObject.Find("passout").GetComponent<TimeTravel>().StartTravel());
    }

    void Update()
    {
        Vector3 newScale = new Vector3(1, (float)scoopFillstate / scoopSize, 1);
        Scoop.transform.localScale = Vector3.Lerp(Scoop.transform.localScale, newScale, animationSpeed * Time.deltaTime);
    }
}
