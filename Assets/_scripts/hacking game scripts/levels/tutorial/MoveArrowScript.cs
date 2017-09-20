using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrowScript : MonoBehaviour {



	private float centerPoint;
	public bool movingRight = true;
	//amount you want the arrow to move by
	public float offset = 10.0f;
	public float MOVE_SPEED = 10;



	// Use this for initialization
	void Start () {
		
		centerPoint = this.gameObject.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {


		if (movingRight) {
			
			this.gameObject.transform.position += new Vector3 (Time.deltaTime * MOVE_SPEED, 0, 0);
			if (this.gameObject.transform.position.x > centerPoint + offset ) {
				movingRight = !movingRight;

			}
		} else {

			this.gameObject.transform.position -= new Vector3 (Time.deltaTime*MOVE_SPEED,0,0);

			if(this.gameObject.transform.position.x < centerPoint - offset ){


				movingRight = !movingRight;


			}
		}

	

	}
}
