using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public AudioClip audioInicio;
    AudioSource fuenteDeAudio;

    void Start()
    {
        fuenteDeAudio = GetComponent<AudioSource>();
        fuenteDeAudio.clip = audioInicio;
        fuenteDeAudio.Play();
    }    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
