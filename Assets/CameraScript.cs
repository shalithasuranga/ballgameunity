using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    public GameObject ball;
    public Vector3 diff;

	// Use this for initialization
	void Start () {
        diff = this.transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = ball.transform.position + diff;
	}
}
