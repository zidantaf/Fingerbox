using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform playercoor;
    public Vector3 jarak;
    public Vector3 jarakFinish;
    private float elapsedTime;
    [SerializeField] private float durationFinishCam = 5f;
    public PlayerCollision playerCollision;
    public AnimationCurve curve;
    public GameObject FinishCin;

    public void Update()
    {
        transform.position = playercoor.position + jarak;

        if (jarak != jarakFinish)
        {
            if (GameObject.Find("ThePlayer").GetComponent<PlayerCollision>().isFinish)
            {
                StartCoroutine(CamMenjauhWaits());
                StartCoroutine(FinishCinematicWaits());
            }
        }
        else if(jarak == jarakFinish)
        {
            StopCoroutine(CamMenjauhWaits());
        }

    }

    private void CamMenjauh()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / durationFinishCam;
        jarak = Vector3.Lerp(jarak, jarakFinish, curve.Evaluate(percentageComplete));

    }
    IEnumerator CamMenjauhWaits()
    {
        yield return new WaitForSeconds(1);
        CamMenjauh();
    }

    IEnumerator FinishCinematicWaits()
    {
        yield return new WaitForSeconds(2);
        FinishCin.SetActive(true);
    }
}
