using System.Collections;
using UnityEngine;

public class BloodManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameObject bloodSplatter;
    [SerializeField] private GameObject bloodOverlay;
    [SerializeField] private float alphaPerFrame = 0.05f;


    private Coroutine currentCoroutine;

    private bool isRunning;
    public void ApplyBlood()
    {
        bloodSplatter.transform.rotation *= Quaternion.Euler(0, 0, Random.Range(0, 360));
        if(isRunning){ StopCoroutine(currentCoroutine); }
        currentCoroutine = StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        isRunning = true;
        canvasGroup.alpha = 1f;
        while (true)
        {
            canvasGroup.alpha -= alphaPerFrame;
            if (canvasGroup.alpha <= 0)
            {
                isRunning = false;
                yield break;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
