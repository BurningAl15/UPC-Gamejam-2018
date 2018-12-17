using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour {

    public string[] messages;
    public int numMessages;
    [SerializeField]
    Text texto;
    [SerializeField]
    float time;
    int i = 0;

    public string nextScene;

    void Start()
    {
        numMessages = messages.Length;
        time = 3f;
        StartCoroutine(SceneControl(1f));
    }

    void Update(){ }

    IEnumerator SceneControl(float duration)
    {

        for (int i = 0; i < messages.Length; i++)
        {
            //Seteando texto
            texto.text = messages[i];

            //Fade in del texto
            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                var color = texto.color;
                color.a = Mathf.Lerp(0f, 1f, t / duration);
                texto.color = color;
                yield return null;
            }

            //Esperando input
            while (!Input.anyKey)
            {
                yield return null;
            }

            //Fade out del texto
            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                var color = texto.color;
                color.a = Mathf.Lerp(1f, 0f, t / duration);
                texto.color = color;
                yield return null;
            }

        }
        SceneManager.LoadScene(nextScene);

    }
}
