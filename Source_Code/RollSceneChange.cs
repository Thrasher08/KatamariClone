using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RollSceneChange : MonoBehaviour
{
    public int level;
    public ParticleSystem rolled;
    Quaternion rotation;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(rolled, other.transform.position, rotation);
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(level);
    }

    private void Update()
    {
        //PlayerPrefs.DeleteAll();
    }
}
