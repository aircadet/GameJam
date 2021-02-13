using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public Slider progressBar;
    public Text text;
    private void Awake()
    {
        
    }
    public void NextLevel(int level)
    {
        progressBar.gameObject.SetActive(true);
        StartCoroutine(startLoading(level));
    }

    IEnumerator startLoading(int level)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(level);
        while (!async.isDone)
        {
            Debug.Log("Yüzde ---> " + async.progress);
            progressBar.value = async.progress / 0.9f;

            text.text = "%" + (async.progress / 0.9f) * 100;

            yield return null;

        }
    }
}
