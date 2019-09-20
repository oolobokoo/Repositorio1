using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionPanel : MonoBehaviour {

    Image image;
    public float transitionSpeed = 1;

    static public TransitionPanel instance;

    void Awake () {
        if (instance == null) {
            DontDestroyOnLoad (transform.parent.gameObject);
            instance = this;
        } else {
            DestroyImmediate (transform.parent.gameObject);
        }
    }

    public void Initialize () {
        image = GetComponent<Image> ();
    }

    public IEnumerator FadeAlpha (float targetValue) {
        Color temp;
        while (image.color.a != targetValue) {
            temp = image.color;
            temp.a = Mathf.MoveTowards (temp.a, targetValue, transitionSpeed * Time.deltaTime);
            image.color = temp;
            yield return null;
        }
    }
}
