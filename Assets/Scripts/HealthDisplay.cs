using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Sprite heart;
    public Health PlayerHealth;
    public Image Heart1;
    public Image Heart2;
    public Image Heart3;

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth == null)
            return;

        if (PlayerHealth.CurrentHealth == 3)
        {
            if (Heart1.GetComponent<Image>() == null)
            {
                Heart1.AddComponent<Image>().sprite = heart;
            }

            if (Heart2.GetComponent<Image>() == null)
            {
                Heart2.AddComponent<Image>().sprite = heart;
            }

            if (Heart3.GetComponent<Image>() == null)
            {
                Heart3.AddComponent<Image>().sprite = heart;
            }
        }

        if (PlayerHealth.CurrentHealth == 2)
        {
            Destroy(Heart3.GetComponent<Image>());
        }

        if (PlayerHealth.CurrentHealth == 1)
        {
            Destroy(Heart2.GetComponent<Image>());
        }
    }
}
