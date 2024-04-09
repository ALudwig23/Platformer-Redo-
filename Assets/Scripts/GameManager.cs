using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    protected int CurrentLevel = 0;
    private static GameManager m_Instance = null;
    void Awake()
    {
        if (m_Instance == null)
        {

            m_Instance = (GameManager)FindObjectOfType(typeof(GameManager));
            if (m_Instance == null)
            {
                GameObject gameObject = new GameObject();
                m_Instance = gameObject.AddComponent<GameManager>();
            }
            DontDestroyOnLoad(m_Instance.gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad (m_Instance.gameObject);
    }

    public void ToNextLevel()
    {
        if (CurrentLevel == 2)
        {
            CurrentLevel = 0;
            SceneManager.LoadScene(CurrentLevel);
            return;
        }
        CurrentLevel++;
        SceneManager.LoadScene(CurrentLevel);
    }

}
