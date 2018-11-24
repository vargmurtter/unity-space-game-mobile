using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetiorMovement : MonoBehaviour {

    public float speed = 10f;
    public float rotateSpeed = 5f;

    private Transform _transform;

	void Start () {
        _transform = GetComponent<Transform>();
        Destroy(gameObject, 5f);
	}
	
	void Update () {
        Move();
        //Rotate();
	}

    void Move()
    {
        _transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void Rotate()
    {
        _transform.Rotate(new Vector3(0, 0, rotateSpeed), Space.World);
    }
}
