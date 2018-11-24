using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour {

    public float speed = 10f;

    Transform _transform;
    Camera cam;

    float camBound;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        cam = Camera.main;
        camBound = cam.orthographicSize / 2f;
    }

    private void Update () {
        float x = Input.acceleration.x * speed * Time.deltaTime;
        _transform.Translate(new Vector3(x, 0, 0));

        BoundsChecker();
	}

    private void BoundsChecker()
    {
        if (_transform.position.x <= -camBound)
        {
            _transform.position = new Vector3(-camBound, _transform.position.y, _transform.position.z);
        }
        else if (_transform.position.x >= camBound)
        {
            _transform.position = new Vector3(camBound, _transform.position.y, _transform.position.z);
        }
    }

}
