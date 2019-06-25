using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompleteCheck : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField]
    //string level1 = PlayerPrefs.GetString(1 + "Complete");
    //[SerializeField]
    //string level2 = PlayerPrefs.GetString(2 + "Complete");

    public int levelNo1;
    public int levelNo2;
    public int levelNo3;

    public ParticleSystem hi;
    public GameObject kat;
    public Quaternion rotation;
    public bool oneShot = false;
    public GameObject winText;
    ParticleSystem test;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Hi");
        //PlayerPrefs.DeleteAll();
        //Debug.Log("Deleted");
        checkCompletion();
    }

    bool checkCompletion()
    {
        if(PlayerPrefs.GetString(levelNo1.ToString() + "Complete") == "1" && PlayerPrefs.GetString(levelNo2.ToString() + "Complete") == "1" && PlayerPrefs.GetString(levelNo3.ToString() + "Complete") == "1")
        {
            Debug.Log("You Beat the Game");
            if (oneShot == false)
            {
                test = Instantiate(hi, kat.transform.position, rotation);
                winText.SetActive(true);
                oneShot = true;
            }

            return true;
        }
        else
        {
            Debug.Log("Huh");
            return false;
        }

    }
}
