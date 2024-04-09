using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    protected int CurrentLevel;
    public static GameManager Instance
    {
        get
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
            return m_Instance;
        }
    }

    private static GameManager m_Instance = null;

    public void StartGame()
    {
        CurrentLevel = 1;
        SceneManager.LoadScene(1);
    }

    public void ToNextLevel()
    {
        if (CurrentLevel == 2)
        {
            CurrentLevel = 1;
            SceneManager.LoadScene(0);
            return;
        }
        CurrentLevel = 2;
        SceneManager.LoadScene(2);
    }

}
