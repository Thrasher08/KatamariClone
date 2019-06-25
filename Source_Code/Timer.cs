using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Image timer;
    public float timelimit;
    [SerializeField]
    float time;
    float imageFill;
    [SerializeField]
    float timeRemaining;
    public AudioClip endSFX;
    public AudioSource audio;
    [SerializeField]
    bool ended;
    public katamari kat;
    int level;
    public float targetSize;
    public TargetObject targetObject;
    //public GameObject goalObject;


    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        level = SceneManager.GetActiveScene().buildIndex;
    }

    private void Awake()
    {
        PlayerPrefs.GetInt(level.ToString() + "Complete", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerPrefs.DeleteAll();
        //Debug.Log(kat.getSize());
        if (time < timelimit)
        {
            time += Time.deltaTime;
            time = Mathf.Round(time * 100) / 100;
        }

        timeRemaining = timelimit - time;
        imageFill = ((timelimit - time) / timelimit);
        Mathf.Clamp(imageFill, 0, 1);
        timer.fillAmount = imageFill;

        if (timeRemaining <= 0 && !ended || targetObject.rolledTarget() == true)
        {
            ended = true;
            time = timelimit;
            TimerEnded();

        }

        /*if (goalObject.transform.parent == kat.gameObject.transform)
        {
            Debug.Log("You Win");
        }*/

        //Debug.Log("Hello" + PlayerPrefs.GetFloat(level.ToString() + "Score", 0));
        Debug.Log(PlayerPrefs.GetString(level.ToString() + "Complete"));
    }

    void TimerEnded()
    {

        audio.PlayOneShot(endSFX);
        Invoke("DisplayResults", endSFX.length);

    }

    void DisplayResults()
    {
        float finalSize = kat.getSize();
        if (finalSize > PlayerPrefs.GetFloat(level.ToString() + "Score", 0) && finalSize > targetSize)
        {
            PlayerPrefs.SetFloat(level.ToString() + "Score", finalSize);
            PlayerPrefs.Save();
            
        }

        if (finalSize > targetSize)
        {
            Debug.Log("Level Complete");
            //layerPrefs.GetInt(level.ToString() + "Complete", 0);
            PlayerPrefs.GetString(level.ToString() + "Complete", "0");

            Debug.Log("HERE?");
            PlayerPrefs.SetString(level.ToString() + "Complete", "1");
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetString(level.ToString() + "Complete"));
            Debug.Log("COMPLETE?");

            SceneManager.LoadScene(1);
        } else
        {
            PlayerPrefs.GetString(level.ToString() + "Complete", "0");
            Debug.Log(PlayerPrefs.GetString(level.ToString() + "Complete"));
            Debug.Log("Try Again");
        }

        //Debug.Log("Hello" + PlayerPrefs.GetFloat(level.ToString() + "Score", 0));
        //SceneManager.LoadScene(0);
    }

}
