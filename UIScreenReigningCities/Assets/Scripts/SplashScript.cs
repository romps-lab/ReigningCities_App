using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScript : MonoBehaviour
{
    private bool finished = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoFade());
    }

    IEnumerator DoFade()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while(canvasGroup.alpha<1)
        {
            canvasGroup.alpha += Time.deltaTime;
            yield return null;

        }
        yield return new WaitForSeconds(6);
        //To fade Out
        /*while(canvasGroup.alpha>0)
        {
            canvasGroup.alpha -= Time.deltaTime;
            yield return null;
        }*/

        yield return finished = true;
    }
    // Update is called once per frame
    private void LateUpdate()
    {
        if(finished)
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
    }
}
