using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSway : MonoBehaviour
{
    public float scaler = 1;

    float randomAmp;
    float randomFreq;

    float xRot = -10;
    float yRot = -40;

    Vector3 _startPosition;
    Vector3 _currentEulerAngles;
    Quaternion _currentRotation;

    float currentX;
    float currentY;

    [HideInInspector]
    public float x, y, z;

    // Start is called before the first frame update
    public void Start()
    {
        currentX = transform.rotation.x;
        currentY = transform.rotation.y;

        //create random starting amplitude and frequencey
        randomAmp = Random.Range(1,15);
        randomFreq = Random.Range(1, 3);

    }

    // Update is called once per frame
    void Update()
    {
        PositionAninmation();
    }

    void PositionAninmation()
    {
        //rotate angle along sin wave
        float yAnimation = Mathf.Sin(Time.time * randomFreq) * randomAmp;
        float xAnimation = Mathf.Cos(Time.time * randomFreq) * randomAmp;
        transform.position = new Vector3(transform.position.x, yAnimation / scaler, transform.position.z);

        //transform rotation
        _currentEulerAngles = new Vector3(randomAmp, randomAmp, z + xAnimation);
        _currentRotation.eulerAngles = _currentEulerAngles;
        transform.rotation = _currentRotation;


    }
}
