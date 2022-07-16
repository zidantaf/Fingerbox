using System.Collections;
using UnityEngine;

public class VictoryStageCam : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 EndPos;
    public Vector3 EndPos2;
    private float elapsedTime;
    [SerializeField] private float duration = 15f;
    [SerializeField] private float duration2 = 15f;
    public AnimationCurve curve;
    public AnimationCurve curve2;
    public GameObject FinishCin;
    public GameObject VictoryUI;
    private bool isAgain = false;

    public void Start()
    {
        StartCoroutine(ClosedUI());
        StartCoroutine(OpenedUI());
        StartCoroutine(Again());
        transform.position = startPos;
    }
    public void Update()
    {
        

            

        if (isAgain == true)
        {
            transform.position = EndPos;

            elapsedTime += Time.deltaTime;
            float percentageComplete2 = elapsedTime / duration2;

            EndPos = Vector3.Lerp(EndPos, EndPos2, curve2.Evaluate(percentageComplete2));
        }
        else
        {
            transform.position = startPos;

            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / duration;
            startPos = Vector3.Lerp(startPos, EndPos, curve.Evaluate(percentageComplete));
        }
    }

    float angka = 4.5f;
    IEnumerator Again()
    {
        yield return new WaitForSeconds(angka);
        isAgain = true;
    }

    IEnumerator ClosedUI()
    {
        yield return new WaitForSeconds(1);
        FinishCin.GetComponent<Animator>().Play("UICinematicClosed");
    }

    IEnumerator OpenedUI()
    {
        yield return new WaitForSeconds(1);
        VictoryUI.SetActive(true);
    }
}
