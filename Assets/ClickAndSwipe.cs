using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndSwipe : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(mousePos.origin, mousePos.direction, Mathf.Infinity);

			if (hit)
			{
				if (hit.collider.gameObject.tag == "Fan")
				{
					hit.collider.gameObject.GetComponent<FanControllerObj>().Cheer();
				}
			}
		}
		
	}
}
