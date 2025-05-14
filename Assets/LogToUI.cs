using UnityEngine;
using UnityEngine.UI;

public class LogToUI : MonoBehaviour
{
    public Text logText;
    private string logMessages = "";

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        logMessages += logString + "\n";
        logText.text = logMessages;
    }
}