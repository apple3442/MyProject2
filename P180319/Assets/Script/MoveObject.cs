using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour,IGameobject {

    [SerializeField]
    private float _startPositionx = 0.05f;
    [SerializeField]
    private float _endPositionx = -0.014f;
	
	public void GameUpdate () {
        Move();
	}
    private void Move()
    {
        Vector3 position = transform.position;
        position.x -= Manager.Instance.Speed;
        if (position.x < _endPositionx)
        {
            FinishEndPosition();
            
        }
        else
        {
            transform.position = position;
        }
        
    }

    virtual protected void FinishEndPosition()
    {
        transform.position = new Vector3(_startPositionx,transform.position.y,0);
    }
}
