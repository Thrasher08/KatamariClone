using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class katamari : MonoBehaviour
{

    [HideInInspector]
    public float facingAngle = 0;
    float x = 0;
    float z = 0;
    Vector2 unitV2; //Unit Vector for determening direction

    public GameObject cameraRef;
    float cameraDist = 5;

    public GameObject categoryMan;
    [HideInInspector]
    public Category[] cats;

    float size = 1;

    public GameObject sizeUI;

    public AudioClip pickUpSFX;

    // Start is called before the first frame update
    void Start()
    {
        cats = categoryMan.GetComponent<categoryManager>().cats;
    }

    // Update is called once per frame
    void Update()
    {
        //Controls
        x = Input.GetAxis("Horizontal") * Time.deltaTime * -100;    //Default -100
        z = Input.GetAxis("Vertical") * Time.deltaTime * 500;       //Default 500

        //Facing Angle
        facingAngle += x;
        unitV2 = new Vector2(Mathf.Cos(facingAngle * Mathf.Deg2Rad), Mathf.Sin(facingAngle * Mathf.Deg2Rad));

    }

    private void FixedUpdate()
    {
        //Apply force behind katamari
        this.transform.GetComponent<Rigidbody>().AddForce(new Vector3(unitV2.x, 0, unitV2.y) * z * 3);

        //Camera Position Based on Rotation
        cameraRef.transform.position = new Vector3(-unitV2.x * cameraDist, cameraDist, -unitV2.y * cameraDist) + this.transform.position;

        unlockPickupCategories();

    }

    void unlockPickupCategories()
    {
        for (int i = 0; i < cats.Length; i++)
        {
            if (cats[i].unlocked == false)
            {
                if (size >= cats[i].sizeRequired) {
                    cats[i].unlocked = true;
                    //Debug.Log("hi" + cats[i].categoryName.transform.childCount);

                    for (int j = 0; j < cats[i].categoryName.transform.childCount; j++) {
                        cats[i].categoryName.transform.GetChild(j).GetComponent<Collider>().isTrigger = true;
                    }
                }
            }
        }
    }

    //Pick Up Pickable Objects
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Sticky"))
        {
            //Grow Katamari
            for(int i = 0; i < cats.Length; i++)
            {
                if (other.transform.parent == cats[i].categoryName.transform)
                {
                    //Disable any attached scripts
                    TempScripting disableScript = other.gameObject.GetComponent<TempScripting>();
                    if (disableScript)
                    {
                        disableScript.enabled = false;
                    }
                    
                    transform.localScale += new Vector3(cats[i].massIncrement, cats[i].massIncrement, cats[i].massIncrement);
                    size += cats[i].massIncrement;
                }
            }

            cameraDist += 0.08f;
            other.enabled = false;  //Prevents child from picking up also

            other.transform.SetParent(this.transform);  //Sticks to katamari by setting katamari as parent

            sizeUI.GetComponent<Text>().text = "Mass: " + Math.Round(size, 2).ToString();

            this.GetComponent<AudioSource>().PlayOneShot(pickUpSFX);

        }
    }

    public float getSize()
    {
        return size;
    }

}


