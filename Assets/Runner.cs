using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

	public float Speed = 5.0f;
	public float Acceleration = 1.0f;

	public Vector3 myCamPos = Vector3.zero;

	// Use this for initialization
	void Start () {
		myCamPos = this.transform.position;
	}

	void MoveBackwards () {
		Speed = -10f;
		Acceleration = 0;
	}

	void ResetGame () {
		Speed = 5.0f;
		Acceleration = 1.0f;

		this.transform.position = myCamPos;
	}
	
	// Update is called once per frame
	void Update () {
		float time = Time.time;
		float x = Speed * time + (Acceleration / 2) * (time * time);
		float deltaX = x - this.transform.position.x;

		//Debug.Log (deltaX);

		this.transform.Translate(deltaX, 0f, 0f);
	}
}
