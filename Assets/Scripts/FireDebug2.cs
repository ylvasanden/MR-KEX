using UnityEngine;

public class FireDebug2 : MonoBehaviour
{
    void Update()
    {
        Debug.Log("Fire position: " + transform.position);
    }
    void Start()
    {
        Debug.LogWarning("Sn�lla funka " + this.gameObject);
    }
}
