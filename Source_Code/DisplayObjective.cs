using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayObjective : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;
    public string objective;
    public 
    // Start is called before the first frame update
    void Start()
    {
        objectiveText.text = objective;
        StartCoroutine(timeUntilRemoval());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator timeUntilRemoval()
    {
        yield return new WaitForSeconds(5);
        objectiveText.gameObject.SetActive(false);
    }
}
