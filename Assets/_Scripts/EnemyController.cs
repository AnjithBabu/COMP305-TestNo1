using UnityEngine;
using System.Collections;

[System.Serializable]
public class Speed {
	public float minSpeed, maxSpeed;
}

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}


public class EnemyController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public Speed speed;
	public Boundary boundary;
    public GameController gameController;

	// PRIVATE INSTANCE VARIABLES
	private float _CurrentSpeed;
	private float _CurrentDrift;

	// Use this for initialization
	void Start () {
        this.speed.minSpeed = 5f;
        this.speed.maxSpeed = 7f;
        this.boundary.xMin = -289f;
        this.boundary.xMax = 282f;
        this.boundary.yMin = -200f;
        this.boundary.yMax = 288f;
		this._Reset ();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 currentPosition = gameObject.GetComponent<Transform>().position;
        currentPosition.y -= this._CurrentSpeed;
        gameObject.GetComponent<Transform> ().position = currentPosition;
		
        //// Check bottom boundary
        if (currentPosition.y <= boundary.yMin)
        {

            this._Reset();
        }
	}

	// resets the gameObject
	private void _Reset() {
		this._CurrentSpeed = Random.Range (speed.minSpeed, speed.maxSpeed);
        Vector2 resetPosition = new Vector2(Random.Range(boundary.xMin, boundary.xMax), boundary.yMax);
		gameObject.GetComponent<Transform> ().position = resetPosition;
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameController.LivesValue -= 1;
            this._Reset();
        }

    }
}
