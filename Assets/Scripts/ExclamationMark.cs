using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ExclamationMark : MonoBehaviour
{
    public Sprite Exclamation;
    public EnemyVision _enemyVision;
    public EnemyMovement _enemyMovement;
    private void Update()
    {
        if (Exclamation == null || _enemyVision == null || _enemyMovement == null)
            return;

        if (_enemyVision._playerFound == true)
        {
            if (_enemyMovement.IsMovingRight == true && _enemyMovement.Target.position.x > transform.position.x || _enemyMovement.IsMovingRight == false && _enemyMovement.Target.position.x < transform.position.x)
            {
                if (gameObject.GetComponent<SpriteRenderer>() == null)
                {
                    Debug.Log("Adding sprite");
                    //Instantiate(this.gameObject, new Vector3(0, 2, 0), transform.rotation);
                    gameObject.AddComponent<SpriteRenderer>().sprite = Exclamation;
                }

            }
        }
        if (_enemyVision._playerFound == false)
        {
            if (gameObject.GetComponent<SpriteRenderer>() != null)
            {
                Destroy(gameObject.GetComponent<SpriteRenderer>());
            }
        }
    }
}
