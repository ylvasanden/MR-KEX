using UnityEngine;

public class FireDebug2 : MonoBehaviour
{
    void Update()
    {
        Debug.Log("Fire position: " + transform.position);
    }
    void Start()
    {
        Debug.LogWarning("Snälla funka " + this.gameObject);
    }
}
