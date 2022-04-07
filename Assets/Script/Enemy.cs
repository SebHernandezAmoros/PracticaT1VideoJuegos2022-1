using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Velocity = 10;

    private Rigidbody2D _rb;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Desplazarse();
    }

    private void Desplazarse()
    {
        _rb.velocity = new Vector2(Velocity * -1, _rb.velocity.y);
    }
}
