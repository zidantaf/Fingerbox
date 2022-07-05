using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetunjukBermain : MonoBehaviour
{
    public GameObject petunjuk;
    private float waits = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Petunjuk());
    }

    

    IEnumerator Petunjuk()
    {
        yield return new WaitForSeconds(waits);
        petunjuk.SetActive(true);
    }
}
