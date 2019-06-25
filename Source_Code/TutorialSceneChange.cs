using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSceneChange : MonoBehaviour
{
    public int level;
    public ParticleSystem rolled;
    Quaternion rotation;
    bool tutComplete = false;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(rolled, other.transform.position, rotation);
        completeTutorial();
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(level);
    }

    private void Update()
    {
        /*PlayerPrefs.GetString("Tutorial", "0");
        if (PlayerPrefs.GetString("Tutorial") == "1")
        {
            SceneManager.LoadScene(level);
        }*/
    }

    public void completeTutorial()
    {
        PlayerPrefs.GetString("Tutorial", "0");
        PlayerPrefs.SetString("Tutorial", "1");
    }

}
