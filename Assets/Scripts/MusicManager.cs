using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource level1Bgm;
    public AudioSource level2Bgm;
    public static MusicManager instance;
    private GameManager GameManager;

    private void Awake()
    {
        GameManager = GetComponent<GameManager>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (GameManager.Instance.CurrentLevel == 1)
        {
            if (level1Bgm.isPlaying == false)
            {
                level1Bgm.Play();
                //Debug.Log("Playing BGM1");
            }
        }
        else if (GameManager.Instance.CurrentLevel == 2)
        {
            if (level2Bgm.isPlaying == false)
            {
                level1Bgm.Stop();
                level2Bgm.Play();
                //Debug.Log("Playing BGM2");
            }
        }
        else
        {
            level1Bgm.Stop();
            level2Bgm.Stop();
        }
    }
}


