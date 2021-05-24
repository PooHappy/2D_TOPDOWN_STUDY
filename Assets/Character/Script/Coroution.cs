using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroution : MonoBehaviour
{
    Coroutine myCoroutine1;
    Coroutine myCoroutine2;

    private void Start()
    {
        myCoroutine1 = StartCoroutine(LoopA());
        myCoroutine2 = StartCoroutine(LoopB());
        StartCoroutine(Stooooop());
    }
    #region Loop
    IEnumerator LoopA()
    {
        for (int i = 0; i < 100; i++)
        {
            print("x값 = " + i);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator LoopB()
    {
        for (int j = 0; j < 100; j++) 
        { 
            print("y값 = " + j);
            yield return new WaitForSeconds(1f);
        }
    }
    #endregion Loop
    IEnumerator Stooooop()
    {
        yield return new WaitForSeconds(2f);
        StopCoroutine(myCoroutine1);

        yield return new WaitForSeconds(2f);
        StopCoroutine(myCoroutine2);
    }
}
