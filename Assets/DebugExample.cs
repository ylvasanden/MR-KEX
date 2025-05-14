using UnityEngine;

public class DebugExample : MonoBehaviour
{
    void Start()
    {
        Debug.LogWarning("I come in peace!", this.gameObject);
    }
}