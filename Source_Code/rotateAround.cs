using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAround : TempScripting
{

    public Transform pivot;
    public Collision other;
    public float speed = 10;
    public bool attached;

    void awake()
    {
        attached = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivot.position, pivot.up, speed * Time.deltaTime);

        /*if (pivot.parent == pivot.parent.gameObject.CompareTag("Player"))
        {
            Destroy(pivot);
        }*/
    }

    public void setAttached(bool attached)
    {
        attached = this.attached;
    }

    public bool getAttached()
    {
        return attached;
    }
}
