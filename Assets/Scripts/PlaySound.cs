using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    public AudioSource audioSource;
    MeshDeformerInput input;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        HitSound();
    }

    void HitSound()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(inputRay, out hit))
        {
            float randPitch = Random.Range(-.25f, .25f);
            if (Input.GetMouseButton(0))
            {
                audioSource.pitch = randPitch;
                audioSource.Play();
            }
        }
    }
}
