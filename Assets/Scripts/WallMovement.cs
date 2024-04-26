using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public Cooldown TimerTillEnd;

    public int rollCredits = 0;

    private Rigidbody2D _rigidbody2d;
    private Animator _animator;
    
    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();

        TimerTillEnd = new Cooldown();
    }
    private void FixedUpdate()
    {
        if (_rigidbody2d == null)
            return;

        _rigidbody2d.velocity = new Vector2(2,0);
    }

    private void Update()
    {
        if (TimerTillEnd == null)
            return;

        //Debug.Log(TimerTillEnd.CurrentProgress);
        if (TimerTillEnd.CurrentProgress == Cooldown.Progress.Finished)
        {
            GameObject doorSound = GameObject.FindWithTag("DoorSound");
            doorSound.GetComponent<AudioSource>().Play();

            rollCredits = 1;

            TimerTillEnd.CurrentProgress = Cooldown.Progress.Ready;
            Destroy(gameObject.GetComponent<SpriteRenderer>());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GiantBoundary"))
        {
            Destroy(_rigidbody2d);
            Destroy(_animator);

            if (gameObject.tag == "EndScenePlayer")
            {
                TimerTillEnd.Duration = 3f;
                TimerTillEnd.StartCooldown();
            }
        }
    }
}
