using System.Collections;
using UnityEngine;
using System;

public static class ExtensionSetCoroutine 
{
    public static event Action onCoroutineActions;

    public static IEnumerator SetCoroutineWait(this float duration)
    {
        yield return new WaitForSeconds(duration);
        onCoroutineActions?.Invoke();
    }

    #region DEVELOPMENT
    public static IEnumerator SetCoroutineBurst(this float duration)
    {
        float startTime = Time.time;
        float endTime = startTime + duration;
        float currentTime = 0.0f;

        while (currentTime < endTime)
        {
            currentTime+=Time.fixedDeltaTime;
        }

        yield return null;
    }
    #endregion


    #region Setup Events
    public static void SubscribeToCoroutineActions(Action action)
    {
        onCoroutineActions += action;
    }

    public static void UnsubscribeFromCoroutineActions(Action action)
    {
        onCoroutineActions -= action;
    }
    #endregion
}