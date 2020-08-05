using UnityEngine;

public class WheatContainerRiddle : MonoBehaviour
{
    [SerializeField]
    WheatContainer[] Containers;

    [SerializeField]
    GameObject Scoop;

    [SerializeField]
    int scoopSize; //in Fractions
    int scoopFillstate;

    float animationSpeed = 2;


    #region Testlauf - Remove me lat0r biatch

    void Start()
    {
        Invoke(nameof(teststep1), 2f);
        Invoke(nameof(teststep2), 4f);
        Invoke(nameof(teststep3), 6f);
        Invoke(nameof(teststep4), 8f);
        Invoke(nameof(teststep5), 10f);
        Invoke(nameof(teststep6), 12f);
    }

    void teststep1() { takeScoopFromContainer(1); }
    void teststep2() { addScoopToContainer(0); }
    void teststep3() { takeScoopFromContainer(1); }
    void teststep4() { addScoopToContainer(0); }
    void teststep5() { takeScoopFromContainer(0); }
    void teststep6() { addScoopToContainer(1); }

    #endregion


    //Take scoop of wheat from a container - only possible when scoop is empty
    void takeScoopFromContainer(int ct)
    {
        if (scoopFillstate != 0)
        {
            return;
        }
        if (Containers[ct].GetFillstate() >= scoopSize)
        {
            scoopFillstate = scoopSize;
        }
        else
        {
            scoopFillstate = Containers[ct].GetFillstate();
        }
        Containers[ct].SetFillstate(Containers[ct].GetFillstate() - scoopFillstate);
    }

    //Add wheat from the scoop to a container - if the container has not enough empty space, only transfer the possible ammount
    void addScoopToContainer(int ct)
    {
        int totransfer = Mathf.Clamp(scoopFillstate, 0, Containers[ct].GetEmptySpace());
        Containers[ct].SetFillstate(Containers[ct].GetFillstate() + totransfer);
        scoopFillstate -= totransfer;
    }

    //Returns true if all fillstates are equal - currently only works with 3 containers
    bool Solved()
    {
        return (Containers[0].GetFillstate() == Containers[1].GetFillstate() &
         Containers[0].GetFillstate() == Containers[2].GetFillstate());
    }

    void Update()
    {
        Vector3 newScale = new Vector3(1, (float)scoopFillstate / scoopSize, 1);
        Scoop.transform.localScale = Vector3.Lerp(Scoop.transform.localScale, newScale, animationSpeed * Time.deltaTime);
    }
}
