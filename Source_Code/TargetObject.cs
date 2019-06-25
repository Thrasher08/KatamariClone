using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    public GameObject target;
    public katamari kat;

    // Update is called once per frame
    void Update()
    {
        rolledTarget();
    }
    public bool rolledTarget()
    {
        if(target.transform.parent == kat.gameObject.transform)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
