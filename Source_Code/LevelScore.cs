using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = PlayerPrefs.GetFloat(level.ToString() + "Score", 0).ToString();
    }
}
