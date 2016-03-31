using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuSlider : MonoBehaviour
{
    public AnimationCurve animCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public Vector3 inPosition;
    public Vector3 outPosition;
    public float duration = 1.0f;

    public void MoveSlide()
    {
        StartCoroutine(Slide(10f));
    }

    private IEnumerator Slide(float time)
    {
        StartCoroutine(StartSlidePanel(true));
        yield return new WaitForSeconds(time);
        StartCoroutine(StartSlidePanel(false));
    }

    private IEnumerator StartSlidePanel(bool isSlideIn)
    {
        float startTime = Time.time;
        Vector3 startPos = transform.localPosition;
        Vector3 moveDistance;

        if (isSlideIn)
            moveDistance = (inPosition - startPos);
        else 
            moveDistance = (outPosition - startPos);

        while ((Time.time - startTime) < duration)
            {
                transform.localPosition = startPos + moveDistance * animCurve.Evaluate((Time.time - startTime) / duration);
                yield return 0;
            }
        transform.localPosition = startPos + moveDistance;
    }
}
