using System.Collections;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _text;

    private void Awake ()
    {
        StartCoroutine(nameof(FpsUpdate));
    }

    private IEnumerator FpsUpdate ()
    {
        while (true)
        {
            float fps = 1 / Time.unscaledDeltaTime;
            _text.text = "" + fps;
            yield return new WaitForSeconds(1f);
        }
    }
}
