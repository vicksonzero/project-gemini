using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class BFadeInFadeOut : MonoBehaviour
{
    public Image fader;
    public float fadeInTime = 5;
    public float fadeStayTime = 5;
    public float fadeOutTime = 5;
    public string nextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(fader.DOFade(0, fadeInTime).SetEase(Ease.InQuad));
        mySequence.AppendInterval(fadeStayTime);
        mySequence.Append(fader.DOFade(1, fadeOutTime).SetEase(Ease.OutQuad));
        mySequence.AppendCallback(() =>
        {
            SceneManager.LoadScene(nextSceneName);
        });
    }

}
