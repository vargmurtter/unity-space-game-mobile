using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour {
    
    [Header("Main Settings")]
    public int hp = 5;
    public int coins = 0;
    public int score = 0;
    public float speed = 10f;

    [Header("UI Settings")]
    public Text healthText;
    public Image healthImage;
    public Text coinText;
    public Image coinImage;

    [Header("Death Screen Settings")]
    public GameObject deathScreen;

    Transform _transform;
    Camera cam;

    float move;
    float camBound;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        cam = Camera.main;
        camBound = cam.orthographicSize / 2;
    }

    private void Update()
    {
        HealthChecker();
        BoundsChecker();
        KeyboardMovement();
        //TouchMovement();
        AccelerationMovement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckAsteroidCollision(collision);
        CheckCoinCollision(collision);
    }


    float duration = 0f;
    private void HealthChecker()
    {
        if (hp <= 0)
        {
            if (!deathScreen.activeSelf)
                deathScreen.SetActive(true);

            if (duration >= 3f)
            {
                SceneManager.LoadScene("Menu");
            }

            duration += Time.deltaTime;
        }
    }

    private void CheckAsteroidCollision(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject);
            hp--;
            healthText.text = hp.ToString();
            Debug.Log("THIS IS ASTEROID");
        }
    }

    private void CheckCoinCollision(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins++;
            coinText.text = coins.ToString();
            Debug.Log("THIS IS COIN");
        }
    }

    private void TouchMovement()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;

            float halfScreen = Screen.width / 2.0f;

            Vector2 direction = Vector2.zero;

            if (touchPosition.x < halfScreen) direction = Vector2.left;
            else if (touchPosition.x > halfScreen) direction = Vector2.right;

            _transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    private void AccelerationMovement()
    {
        float accel = Input.acceleration.x * speed * Time.deltaTime;
        _transform.Translate(new Vector3(accel, 0, 0));
    }

    private void KeyboardMovement()
    {
        move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        _transform.Translate(new Vector2(move, 0));
    }

    private void BoundsChecker()
    {
        if (_transform.position.x <= -camBound)
        {
            _transform.position = new Vector3(-camBound, _transform.position.y, _transform.position.z);
        }else if (_transform.position.x >= camBound)
        {
            _transform.position = new Vector3(camBound, _transform.position.y, _transform.position.z);
        }
    }

}
