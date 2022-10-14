using System.Collections;
using UnityEngine;

public class ScoreEffect : MonoBehaviour
{
    [SerializeField] private float _destroyTime;
    private Color currentColor;

    public void Init(Color col)
    {
        currentColor = col;

        StartCoroutine(Effect());
    }

    private IEnumerator Effect()
    {

        float timeElapsed = 0f;
        float speed = 1 / _destroyTime;
        Vector3 startScale = Vector3.one * 0.64f;
        Vector3 endScale = Vector3.one * 1.32f;
        Vector3 scaleOffset = endScale - startScale;
        Vector3 currentScale = startScale;

        Color startColor = currentColor;
        startColor.a = 0.8f;
        Color endColor = currentColor;
        endColor.a = 0.2f;
        Color colorOffset = endColor - startColor;
        Color c = startColor;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = c;

        while(timeElapsed < 1f)
        {
            timeElapsed += speed * Time.deltaTime;

            currentScale = startScale + timeElapsed * scaleOffset;
            transform.localScale = currentScale;

            c = startColor + timeElapsed * colorOffset;
            sr.color = c;

            yield return null;
        }

        Destroy(gameObject);
    }
}
