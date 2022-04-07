using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyPlayer : MonoBehaviour
{
    public float JumpForce = 10;
    public float Velocity = 10;

    private Rigidbody2D _rb;
    private Animator _animator;


    private static readonly string ANIMATOR_STATE = "State";
    private static readonly int ANIMATION_RUN = 0;
    private static readonly int ANIMATION_SLIDE = 1;
    private static readonly int ANIMATION_JUMP = 2;
    private static readonly int ANIMATION_IDLE = 5;

    private static bool SlideFlg = false;
    private static int enemyCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(message: SlideFlg);
        Desplazarse();

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Deslizarse();

        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            VelocityPowerUp();
            _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            ChangeAnimation(ANIMATION_JUMP);

        }

        Win();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var tag = other.gameObject.tag;

        if (tag == "Superado")
        {
            enemyCount = enemyCount + 1;
            Debug.Log(message: "--> contador: "+ enemyCount);
        }
    }

    private void Deslizarse()
    {
        ChangeAnimation(ANIMATION_SLIDE);
        SlideFlg = true;
    }

    private void Desplazarse()
    {
        SlideFlg = false;
        _rb.velocity = new Vector2(Velocity, _rb.velocity.y);
        ChangeAnimation(ANIMATION_RUN);
    }

    private void ChangeAnimation(int animation)
    {
        _animator.SetInteger(ANIMATOR_STATE, animation);
    }

    private void VelocityPowerUp()
    {
        Velocity = Velocity + (float)(Velocity * 0.05);
    }

    private void Win()
    {
        if (enemyCount == 10)
        {
            Debug.Log(message: "--GANASTE-- Enemigos superados: " + enemyCount);
            ChangeAnimation(ANIMATION_IDLE);
            Velocity = 0;
        }
    }
}
