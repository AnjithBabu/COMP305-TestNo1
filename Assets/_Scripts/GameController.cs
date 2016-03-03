using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public int tankCount;
	public GameObject tank;
    public Text LivesLabel;
    public Text ScoreLabel;

    // PRIVATE INSTANCE VARIABLES
    private int _scoreValue;
    private int _livesValue;


    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
        }

        set
        {
            this._scoreValue = value;
            this.ScoreLabel.text = "Score: " + this._scoreValue;
        }
    }

    public int LivesValue
    {
        get
        {
            return this._livesValue;
        }

        set
        {
            this._livesValue = value;
            if (this._livesValue <= 0)
            {
               // this._endGame();
            }
            else
            {
                this.LivesLabel.text = "lives: " + this._livesValue;
            }
        }
    }

	// Use this for initialization
	void Start () {
        this.LivesValue = 5;
        this.ScoreValue = 0;
        this.tankCount = 4;
		this._GenerateTanks ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// generate Clouds
	private void _GenerateTanks() {
		for (int count=0; count < this.tankCount; count++) {
			Instantiate(tank);
		}
	}
}
