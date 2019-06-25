using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class displayBGM : MonoBehaviour
{
    public BGMPlayer currentBGM;
    public TextMeshProUGUI bgmText;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        bgmText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        bgmText.text = "" + currentBGM.name;
    }
}
