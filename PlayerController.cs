using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]GameManager _gameManager;

    Rigidbody2D _rb;
    Camera _maincamera;

    float _moveVertical;
    float _moveHorizontal;
    float _moveSpeed = 5f;
    float _speedLimited = 0.7f;
    Vector2 _moveVelocity;

    Vector2 offset;

    bool _isTurnLeft = false;
    bool _isTurnRight = false;
    bool _isRunning = false;
    bool _isJumping = false;

    Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _maincamera = Camera.main;
    }

    void Update()
    {
        _moveHorizontal = Input.GetAxisRaw("Horizontal");  
        _moveVertical = Input.GetAxisRaw("Vertical");

        //di chuyen cua nhan vat
        if (_moveHorizontal != 0)
        {
            if (_moveHorizontal > 0)
            {
                _anim.SetBool("_isTurnRight", true);
                _anim.SetBool("_isTurnLeft", false);
                _anim.SetBool("_isRunning", true);
                _moveVelocity = new Vector2(_moveHorizontal, 0f) * _moveSpeed;
                _rb.velocity = _moveVelocity;
            }
            else
            {
                _anim.SetBool("_isTurnLeft", true);
                _anim.SetBool("_isTurnRight", false);
                _anim.SetBool("_isRunning", true);
                _moveVelocity = new Vector2(_moveHorizontal, 0f) * _moveSpeed;
                _rb.velocity = _moveVelocity;
            }
        }
        else
        {
            //_anim.SetBool("_isTurnLeft", false);
            //_anim.SetBool("_isTurnRight", false);
            _anim.SetBool("_isRunning", false);
            _anim.SetBool("_isJumping", false);
            _moveVelocity = new Vector2(0f, 0f);
            _rb.velocity = _moveVelocity;
        }
        //_moveVelocity = new Vector2(_moveHorizontal, _moveVertical)* _moveSpeed * Time.deltaTime;
    }

    //void FixedUpdate()
    //{
    //    MovePlayer();
    //}

    //di chuyen cua nhan vat
    void MovePlayer()
    {
        if (_moveHorizontal != 0 && _moveVertical == 0)
        {
            if (_moveHorizontal > 0)
            {
                _anim.SetBool("_isTurnRight", true);
                _anim.SetBool("_isTurnLeft", false);
                _anim.SetBool("_isRunning", true);
                _moveVelocity = new Vector2(_moveHorizontal, 0f) * _moveSpeed;
                _rb.velocity = _moveVelocity;
            }
            else
            {
                _anim.SetBool("_isTurnLeft", true);
                _anim.SetBool("_isTurnRight", false);
                _anim.SetBool("_isRunning", true);
                _moveVelocity = new Vector2(_moveHorizontal, 0f) * _moveSpeed;
                _rb.velocity = _moveVelocity;
            }
        }
        else
        {
            _moveVelocity = new Vector2(0f, 0f);
            _rb.velocity = _moveVelocity;
            _anim.SetBool("_isTurnLeft", false);
            _anim.SetBool("_isTurnRight", false);
            _anim.SetBool("_isRunning", false);
            _anim.SetBool("_isJumping", false);
        }
    }
}
