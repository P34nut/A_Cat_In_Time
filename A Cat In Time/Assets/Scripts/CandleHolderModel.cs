using UnityEngine;

public class CandleHolderModel : MonoBehaviour
{

    void Update()
    {
        transform.rotation = Quaternion.Euler (0.0f,transform.eulerAngles.y, transform.rotation.z * -1.0f);
    }
}
