using UnityEngine;

public static class DebugOutput
{
    public static void Log(string title, string information)
    {
        ModuleMessageDebug.InvokeDebugLog(title, information);
    }

    public static void Warning(string title, string information)
    {
        ModuleMessageDebug.InvokeDebugWarning(title, information);
    }

    public static void Error(string title, string information)
    {
        ModuleMessageDebug.InvokeDebugError(title, information);
    }
}