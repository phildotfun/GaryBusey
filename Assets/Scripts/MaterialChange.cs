using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MaterialChange : MonoBehaviour
{
    [SerializeField] Material mat;

    private Material childMat;
    private int childCount;
    private Transform childObject;

    // Start is called before the first frame update
    public void Start()
    {
        //check how many children there are in dog
        childCount = gameObject.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMaterial();
    }

    void ChangeMaterial()
    {
        //change materials
        for (int i = 0; i < childCount; i++)
        {
            childObject = gameObject.transform.GetChild(i);
            childObject.GetComponent<Renderer>().material = mat;
            Debug.Log("material:" + childObject.GetComponent<Renderer>().material);
        }
    }
}
