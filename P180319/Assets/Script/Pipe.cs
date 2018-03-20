using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MoveObject{

	// Use this for initialization
	void Start () {
		
	}

    public void GameUpdate () {

        base.GameUpdate();
		
	}

    protected override void FinishEndPosition()
    {
        Destroy(gameObject);
    }
}
