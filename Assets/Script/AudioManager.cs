using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource collect;
    public AudioSource jump;
    public AudioSource bgm;
    public static AudioManager Instance { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        bgm.Play();
    }

    public void playjump()
    {
        jump.Play();
    }
    public void playcollect()
    {
        collect.Play();
    }
}
