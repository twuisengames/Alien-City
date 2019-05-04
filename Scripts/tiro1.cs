using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiro1 : MonoBehaviour {

	private Rigidbody2D rb;
	public float veltiro1 =1000;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		rb.AddForce (new Vector2 (veltiro1, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
