using UnityEngine;

[RequireComponent(typeof(Collider))]
public class WheatContainer : MonoBehaviour
{
    [SerializeField]
    int fillstate = 1;
    public int Fractions = 6;

    [SerializeField]
    float animationSpeed = 2;

    [SerializeField]
    int ContainerID;

    [SerializeField]
    WheatContainerRiddle wheatContainerRiddle;

    void Awake()
    {
        transform.localScale = new Vector3(1, (float)fillstate / Fractions, 1);
    }

    public int GetFillstate() => this.fillstate;
    

    public void SetFillstate(int value)
    {
        fillstate = value;
    }

    public int GetEmptySpace() {
        return Mathf.Clamp(Fractions - fillstate, 0, Fractions);
    }

    void Update() {
        Vector3 newScale = new Vector3(1, (float)fillstate / Fractions, 1);
        transform.localScale = Vector3.Lerp (transform.localScale, newScale, animationSpeed * Time.deltaTime);
    }

    
    void OnMouseDown() {

        //if (wheatContainerRiddle.startRiddle)
        //{
            if (wheatContainerRiddle.scoopFillstate == 0)
            {
                wheatContainerRiddle.TakeScoopFromContainer(ContainerID);
            }
            else
            {
                wheatContainerRiddle.AddScoopToContainer(ContainerID);
            }
        //}
    }
}
