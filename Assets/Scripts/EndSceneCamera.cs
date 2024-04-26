using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndSceneCamera : MonoBehaviour
{
    public Sprite PlayerSprite;
    public Camera Camera;
    public CameraMovement CameraMovement;
    public RuntimeAnimatorController _animatorController;

    private Rigidbody2D _rigidbody2d;
    private SpriteRenderer _spriteRenderer;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(Camera.GetComponent<CameraMovement>());
            Camera.AddComponent<CameraMovementEnd>();

            Camera.orthographicSize = 5f;

            Destroy(collision.gameObject);

            GameObject go = new GameObject("EndScenePlayer");
            go.tag = "EndScenePlayer";
            go.transform.position = new Vector3(12f, -4.5f, 0f);

            go.AddComponent<Rigidbody2D>();
            go.AddComponent<BoxCollider2D>();
            go.AddComponent<WallMovement>();
            go.AddComponent<SpriteRenderer>().sprite = PlayerSprite;
            go.AddComponent<Animator>().runtimeAnimatorController = _animatorController;

            _spriteRenderer = go.GetComponent<SpriteRenderer>();
            _spriteRenderer.sortingLayerName = "Front";

            _rigidbody2d = go.GetComponent<Rigidbody2D>();
            _rigidbody2d.gravityScale = 0f;


            Destroy(gameObject);
        }
    }
}
