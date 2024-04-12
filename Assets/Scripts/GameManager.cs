using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int CurrentLevel = 0;
    private static GameManager m_Instance = null;
    public static GameManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = (GameManager)FindObjectOfType(typeof(GameManager));
                if (m_Instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    m_Instance = go.AddComponent<GameManager>();
                }
                DontDestroyOnLoad(m_Instance.gameObject);
            }
            return m_Instance;
        }
    }

    public void ToNextLevel()
    {
        if (Instance.CurrentLevel == 2)
        {
            Instance.CurrentLevel = 0;
            SceneManager.LoadScene(Instance.CurrentLevel);
            return;
        }
        Instance.CurrentLevel++;
        SceneManager.LoadScene(Instance.CurrentLevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
