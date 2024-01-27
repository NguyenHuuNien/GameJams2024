
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody2D _rocketRB;
    float _speed = 50f;
    float _currentSpeed = 0f;


    float _timeSlow = 0.8f;
    float _time = 1f;
    float _timer = 0f;
    [NonSerialized] public Vector2 playerDirection;
    private void Start()
    {
        _rocketRB = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        _currentSpeed = Mathf.Lerp(0f, _speed, _timer / _timeSlow);
        _rocketRB.velocity = playerDirection * _currentSpeed;
        float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;

        // Tạo một quaternion xoay từ góc tính toán
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = targetRotation;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_timer >= _time)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}