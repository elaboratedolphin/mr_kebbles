using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonpress : MonoBehaviour
{
    public AudioSource ButtonPress;
    // Start is called before the first frame update
    void ButtonSound()
    {
        ButtonPress.Play();
    }
}
