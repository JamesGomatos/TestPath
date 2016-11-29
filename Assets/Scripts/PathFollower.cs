using UnityEngine;
using System.Collections;

public class PathFollower : MonoBehaviour {

	// hold our points which is a number of empty game objects
	public Transform[] path;
	public float speed = 5.0f;
	public float reachDistance = 1.0f;
	public int currentPoint = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// get the distance between
		float dist = Vector3.Distance(path [currentPoint].position, transform.position);

		transform.position = Vector3.MoveTowards (transform.position, path [currentPoint].position, Time.deltaTime * speed);
		if (dist <= reachDistance) {
			currentPoint++;
		}

		if (currentPoint >= path.Length) {
			currentPoint = 0;
		}

	}


	// disply all the objects in path
	void onDrawGizmos (){
		if (path.Length > 0)
			for (int i = 0; i < path.Length; i++) {
				if (path[i] != null) {
					Gizmos.DrawSphere(path[i].position,reachDistance);
				}
			}
	}
}
