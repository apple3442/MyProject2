using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour, IGameobject
{
    [SerializeField]
    private Rigidbody2D _rigidBody = null;

    [SerializeField]
    private float _jumValue = 1.0f;

    private void Start()
    {
        _rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    public void GameUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _rigidBody.AddForce(new Vector2(0, _jumValue));
        }
    }

    public void FreezePositionY(bool value)
    {
        _rigidBody.constraints = value ? RigidbodyConstraints2D.FreezePositionY : RigidbodyConstraints2D.None;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Enemy":
                Manager.Instance.isPlay = false;
                break;
        }
    }
}
