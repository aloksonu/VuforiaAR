using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float MoveSpeedDefault = 0.4f;
    //[SerializeField] private float MoveSpeedMerging = 5f;

    private Rigidbody _rb;
    private float _moveSpeedValue;
    private float _dirX, _dirY;
    //[SerializeField] private bool _steamCollisionCondition;
    //private Vector2 VelocityVector;
    //GameObject _collisionDrop, _collisionObstacal;
    //PlayerMoveType playerMoveType;
    //private bool _callNextHilighter;
    void Start()
    {
        //_steamCollisionCondition = true;
        //_callNextHilighter = true;
        _moveSpeedValue = MoveSpeedDefault * Time.deltaTime;
        //playerMoveType = PlayerMoveType.NormalSpeed;
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR
        //if (!UnityEditor.EditorApplication.isRemoteConnected)
        //{
        //    _dirX = Input.GetAxis("Horizontal");
        //   // _dirY = Input.GetAxis("Vertical");
        //}
        //else
        //{
        //    _dirX = Input.acceleration.x;
        //    //_dirY = Input.acceleration.y;
        //}
        _dirX = Input.GetAxis("Horizontal");
#else
            _dirX = Input.acceleration.x;
           // _dirY = Input.acceleration.y;
#endif

        //if (playerMoveType == PlayerMoveType.NormalSpeed)
        //{
        //    Vector2 velocityVector = new Vector2(_rb.velocity.x + _dirX * _moveSpeedValue,
        //                     _rb.velocity.y + _dirY * _moveSpeedValue);
        //    _rb.velocity = velocityVector;
        //}
        //else if (playerMoveType == PlayerMoveType.MergeSpeed)
        //{
        //    Vector2 velocityVector = new Vector2(_dirX * MoveSpeedMerging, _dirY * MoveSpeedMerging);
        //    _rb.velocity = velocityVector;
        //}
        //else if (playerMoveType == PlayerMoveType.NoSpeed)
        //{
        //    Vector2 velocityVector = new Vector2(_dirX * 0f, _dirY * 0f);
        //    _rb.velocity = velocityVector;
        //}

        Vector3 velocityVector = new Vector3(_rb.velocity.x + _dirX * _moveSpeedValue,
                             _rb.velocity.y , _rb.velocity.z);
        _rb.velocity = velocityVector;
    }
}
