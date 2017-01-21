using UnityEngine;
using System.Collections;

public class FanControllerObj : MonoBehaviour {

	private BoardCreator board;

	private bool isCheering = false;

	void OnMouseDown()
	{
		//if (boardCreator.IsRunning ()) {
			Cheer();
		//}
	}

	public void Cheer()
	{
		isCheering = true;
		this.GetComponent<Animator> ().SetBool ("isCheering", true);
	}

	void OnBecameInvisible ()
	{
		if (!isCheering) {
			Debug.Log ("Missing cheering!");
			board.ResetGame();
		}
	}

	// Use this for initialization
	void Start () {

	}

	public void SetBoardCreator (BoardCreator board)
	{
//		Debug.Log("SetBoardCreator");
		this.board = board;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
