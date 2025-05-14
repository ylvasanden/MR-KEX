using UnityEngine;
using Vuforia;

public class ImageTargetEventHandler : MonoBehaviour
{
    private void Start()
    {
        var trackable = GetComponent<ObserverBehaviour>();
        if (trackable)
        {
            trackable.OnTargetStatusChanged += OnTargetFound;
        }
    }

    private void OnTargetFound(ObserverBehaviour observer, TargetStatus status)
    {
        if (status.Status == Status.TRACKED)
        {
            Debug.Log("QR Code detected!");
            PerformAction();
        }
    }

    private void PerformAction()
    {
        // Add your logic here (e.g., spawn an object, enable a UI, etc.)
        //GameObject.Find("Zombie1").SetActive(true);
        Debug.Log("Here an action can be performed!");
    }
}