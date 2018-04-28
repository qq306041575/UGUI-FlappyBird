﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnComponent : MonoBehaviour
{
    const float HorizontalMovement = 2048f + 256f;
    const float VerticalMovement = 256f;

    public float MoveSpeed;

    Vector2 _position;
    RectTransform _panel;

    void Awake()
    {
        _position = Vector2.up * Random.Range(-VerticalMovement, VerticalMovement);
        _panel = GetComponent<RectTransform>();
        _panel.anchoredPosition = _position;
    }

    void Update()
    {
        _position.x -= MoveSpeed;
        if (_position.x + HorizontalMovement < 0)
        {
            _position.x += HorizontalMovement;
            _position.y = Random.Range(-VerticalMovement, VerticalMovement);
        }
        _panel.anchoredPosition = _position;
    }
}
