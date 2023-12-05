using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public static MusicManager i;

    // Start is called before the first frame update
    void Start()
    {
        if (i == null)
        {
            DontDestroyOnLoad(gameObject);
            i = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
