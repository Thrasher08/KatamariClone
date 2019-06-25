using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCounter : MonoBehaviour
{
    public float objectCount;

    private void OnValidate()
    {
        objectCount = transform.childCount;
    }
}
