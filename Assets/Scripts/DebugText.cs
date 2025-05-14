using UnityEngine;

public class DebugText : MonoBehaviour
{
    void Start()
    {
        Debug.LogWarning("I come in peace!", this.gameObject);
    }
}