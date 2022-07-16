using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishStatsOpen : MonoBehaviour
{

    public GameObject finishUI;
    public float duration = 3f;

    void Start()
    {
        StartCoroutine(Shows());
    }

    IEnumerator Shows()
    {
        yield return new WaitForSeconds(duration);
        finishUI.SetActive(true);
    }
}
