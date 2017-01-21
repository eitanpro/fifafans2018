using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardCreator : MonoBehaviour
{
	public float cubeSizeX = 7f;
	public float cubeSizeY = 4.5f;
	public float positionX = 0;
	public float positionY = 0;
	public float width = 10;
	public float height = 3;

	public GameObject fanObject;
	public GameObject stoneObject;

	public Runner camera;

	private ArrayList fans = new ArrayList();
	private ArrayList stones = new ArrayList();

	private bool isRunning;

	int interval = 3; 
	float nextTime = 0;

	Stadium nextStadium;
	public GameObject stadiumObject;

	Sky nextSky;
	public GameObject skyObject;

	float lastFanX;

	public float population = 0.1f;

	private int score = 0;

	private void DrawFanWithProbability (float widthX) // The old way
	{
		for (int x = 0; x < width; ++x) {
			for (int y = 0; y < height; ++y) {
				float xP = positionX + lastFanX + x * cubeSizeX;
				float yP = positionY + y * cubeSizeY + 1f;

				if (xP > positionX + lastFanX + widthX)
				{
					lastFanX += (int) ((widthX / cubeSizeX) + 1) * cubeSizeX;
					return;
				}

				// draw with probability
				if (Random.Range(0f, 1f) < population)
				{
					GameObject fan = Instantiate(fanObject, new Vector3(xP, yP, -1f), Quaternion.identity) as GameObject;
					fan.transform.parent = transform;

					var code = fan.GetComponent<FanControllerObj>();
					Debug.Log(code);
					code.SetBoardCreator(this);

					//fans.Add(fan);
				}
			}
		}
		lastFanX += (int) ((widthX / cubeSizeX) + 1) * cubeSizeX;
	}

	private void DrawFanWaveWay()
	{
		for (int x = 0; x < width; ++x) {
			for (int y = 0; y < height; ++y) {
				float xP = positionX + x * cubeSizeX;
				float yP = positionY + y * cubeSizeY + 1f;
				
				// draw with probability
				if (Random.Range(0f, 1f) < 0.1)
				{
					GameObject fan = Instantiate(fanObject, new Vector3(xP, yP, -1f - y), Quaternion.identity) as GameObject;
					fan.transform.parent = transform;

					var code = fan.GetComponent<FanControllerObj>();
					code.SetBoardCreator(this);

					fans.Add(fan);
				}
			}
		}
	}

	public bool IsRunning ()
	{
		return isRunning;
	}

	public void ResetGame ()
	{
		this.isRunning = false;

		// TODO save game

		// TODO reset scene
		//UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
	private void Draw ()
	{
		//fans.Clear ();
		//stones.Clear ();
		
//		for (int x = 0; x < width; ++x) {
//			for (int y = -2; y < height + 2; ++y) {
//				float xP = positionX + x * 10;
//				float yP = positionY + y * cubeSizeY;
//				
//				GameObject stone = Instantiate(stoneObject, new Vector3(xP, yP, 0f), Quaternion.identity) as GameObject;
//				stone.transform.parent = transform;
//				
//				stones.Add(stone);
//			}
//		}

		var s = Instantiate(stadiumObject, new Vector3(7.76f, -4.7f, 0), Quaternion.identity) as GameObject;
		nextStadium = s.GetComponent<Stadium> ();

		var s2 = Instantiate(skyObject, new Vector3(8.6f, 8.6f, 1f), Quaternion.identity) as GameObject;
		nextSky = s2.GetComponent<Sky> ();
	}

	private void Start ()
	{
		//if (Time.time >= nextTime) {
			Draw ();
		//	nextTime += interval; 
		//}
	}

	private void Update ()
	{
		if (nextStadium.wasVisible) {
			Vector3 stadiumSize = nextStadium.GetComponent<Collider>().bounds.size;
			Vector3 endPosition = nextStadium.transform.position + stadiumSize;
			var s = Instantiate(stadiumObject, new Vector3(endPosition.x, -4.7f, 0), Quaternion.identity) as GameObject;
			s.transform.parent = transform;
			nextStadium = s.GetComponent<Stadium> ();

			DrawFanWithProbability (stadiumSize.x);
		}
		if (nextSky.wasVisible) {
			Vector3 endPosition = nextSky.transform.position + nextSky.GetComponent<Collider>().bounds.size;
			var s = Instantiate(skyObject, new Vector3(endPosition.x, 8.6f, 1f), Quaternion.identity) as GameObject;
			s.transform.parent = transform;
			nextSky = s.GetComponent<Sky> ();
		}
	}
}