using UnityEngine;
using System.Collections;

# Test Change #2!

public class AudioBounce : MonoBehaviour
{
    AudioSource aSource;
    Animator aController;

    public GameObject cylinder;
    public GameObject otherBall;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
        aController = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("entered " + other.name);
        other.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.blue);
        cylinder.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.blue);
    }

    private void OnTriggerExit(Collider other)
    {
        print("exited");
        other.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.green);
        cylinder.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.green);
    }

    // Only run WHEN the 'thing'/'event' happens 
    // So this case - run this code when a collsion happens
    void OnCollisionEnter(Collision collision)
    {
        PlaySound();
        if (otherBall)
            otherBall.gameObject.GetComponent<Rigidbody>().useGravity = true;
        else
            print("You forgot to fill the box in dummy!");
    }

    void OnMouseDown() {
        GetComponent<Rigidbody>().useGravity = true;
    }

    void Update() {
        if (Input.GetKeyDown("f") || Input.GetButtonDown("Jump"))
            GetComponent<Rigidbody>().useGravity = true;
        if (Input.GetKeyDown("a")) {
            aController.SetBool("isStretching", true);
            // bool currentValue = aController.GetBool("isStretching");
        }
    }

    public void PlaySound() {
        aSource.Play();
        print("sound just played!");
    }
}
