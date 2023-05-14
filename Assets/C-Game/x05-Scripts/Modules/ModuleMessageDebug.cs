using System;
using UnityEngine;
using System.Collections;

public class ModuleMessageDebug : MonoBehaviour
{
    [SerializeField] private bool _useDebug;
    private static bool _useDebugStatic;

    public static event Action<string, string> onDebugLog;
    public static event Action<string, string> onDebugWarning;
    public static event Action<string, string> onDebugError;

    private void OnEnable()
    {
        _useDebugStatic = _useDebug;
        onDebugLog += HandleDebugLog;
        onDebugWarning += HandleDebugWarning;
        onDebugError += HandleDebugError;
    }

    private void OnDisable()
    {
        onDebugLog -= HandleDebugLog;
        onDebugWarning -= HandleDebugWarning;
        onDebugError -= HandleDebugError;
    }

    public static void HandleDebugLog(string title, string information)
    {
        if (_useDebugStatic) { Debug.Log($"[+] {title} : {information}"); }
    }

    public static void HandleDebugWarning(string title, string information)
    {
        if (_useDebugStatic) { Debug.LogWarning($"[-] {title} : {information}"); }
    }

    public static void HandleDebugError(string title, string information)
    {
        if (_useDebugStatic) { Debug.LogError($"[!] {title} : {information}"); }
    }

    public static void InvokeDebugLog(string title, string information)
    {
        onDebugLog?.Invoke(title, information);
    }

    public static void InvokeDebugWarning(string title, string information)
    {
        onDebugWarning?.Invoke(title, information);
    }

    public static void InvokeDebugError(string title, string information)
    {
        onDebugError?.Invoke(title, information);
    }
}