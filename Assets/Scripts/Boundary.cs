using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2 (Screen.width, Screen.height));
    }

    void Update()
    {
        Vector2 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1, screenBounds.x);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1, screenBounds.y);
        transform.position = viewPos;
    }
}
