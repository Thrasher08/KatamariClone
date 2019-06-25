using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowKatamari : MonoBehaviour
{

    public GameObject katamari;
    Vector3 viewOffset;

    // Start is called before the first frame update
    void Start()
    {
        viewOffset = new Vector3(0, 1.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Look at Katamari
        transform.LookAt(katamari.transform.position + viewOffset);
    }
}
