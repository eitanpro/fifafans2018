using UnityEngine;
using System.Collections;

public class Stadium : MonoBehaviour {

	public bool wasVisible;

	// Use this for initialization
	void Start () {
		wasVisible = false;
	}

	void OnBecameVisible () {
		wasVisible = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
