using UnityEngine;
using System;
using System.Collections;

public static class CoroutineUtils
{
    public static IEnumerator WaitAndDo(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action();
    }

    public static IEnumerator WaitAndDoSync(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action();
    }
}