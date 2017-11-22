using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BallController : MonoBehaviour {

    public Rigidbody ball;
    private int score = 0;
    private float timer = 60;
    public Text scoreLabel;
    public Text timeLabel;
    public GameObject table;

	// Use this for initialization
	void Start () {
	    
    }

    void updateUIScore() {
        scoreLabel.text = "Score : " + score;
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        timeLabel.text = "Time : " + (int)timer;
        if (table.transform.position.y > ball.transform.position.y) {
            Application.LoadLevel("Gameover");
            
        }
        print(timer);
        if (timer < 0) {
            Application.LoadLevel("Gameover");
        }
	}

    void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 mov = new Vector3(h,0,v);
        //print(h + " " + v);
        ball.AddForce(mov);
        
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (other.tag.Equals("collect"))
        {
            
            score++;
            updateUIScore();
        }
        else if (other.tag.Equals("wrong")) {
            score = (score - 1) < 0 ? 0 : (score - 1);
            updateUIScore();
            ball.AddForce(new Vector3(2,5,0) * 50);
        }
    }
}
