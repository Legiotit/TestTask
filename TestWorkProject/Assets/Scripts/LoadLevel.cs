using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Класс отвечающий за переход между уровнями
/// </summary>
public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    private Image fadeImage;

    private void Start()
    {
        StartCoroutine(Fade(1, 0));
    }

    public void LoadScene(int numberScene)
    { 
        SceneManager.LoadScene(numberScene);
        StartCoroutine(Fade(0, 1));
    }

    private IEnumerator Fade(float startValue, float endValue)
    {
        float delta = (endValue - startValue) / 10f;
        float ft = startValue;
        while (!ft.Equals(endValue))
        {
            ft += delta;
            fadeImage.color = new Color(0, 0, 0, ft);
            yield return new WaitForSeconds(.01f);
        }
    }
}
