using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetiorGenerator : MonoBehaviour {

    public GameObject[] asteroids;

    float duration = 0f;
    float offset;

    Transform _transform;
    Camera cam;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        cam = Camera.main;
        offset = cam.orthographicSize / 2f;
    }

    void Update () {
        Generate();
	}

    void Generate()
    {
        duration += Time.deltaTime;

        if (duration > 1f)
        {
            Instantiate(
                asteroids[Random.Range(0, asteroids.Length)],
                new Vector3(Random.Range(-offset, offset), _transform.position.y, -2),
                Quaternion.identity
            );

            duration = 0f;
        }
    }
}
