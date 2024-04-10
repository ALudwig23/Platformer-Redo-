using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineHost : MonoBehaviour
{
    private static CoroutineHost m_Instance = null;
    public static CoroutineHost Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = (CoroutineHost)FindObjectOfType(typeof(CoroutineHost));
                if (m_Instance == null)
                {
                    GameObject gameObject = new GameObject("CoroutineHost");
                    m_Instance = gameObject.AddComponent<CoroutineHost>();
                }
                DontDestroyOnLoad(m_Instance.gameObject);
            }
            return m_Instance;  
        }
    }
}
