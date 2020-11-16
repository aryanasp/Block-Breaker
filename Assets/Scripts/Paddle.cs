using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    
    [SerializeField]
    private float minX = 1f;
    [SerializeField]
    private float maxX = 15f;
    [SerializeField]
    float screenWidthInUnits = 16f;
    Vector2 paddlePos;

    // Start is called before the first frame update
    void Start()
    {
   
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float mousePosXInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        paddlePos = new Vector2(mousePosXInUnits, transform.position.y);
        paddlePos.x = Mathf.Clamp(paddlePos.x, minX, maxX);
        transform.position = paddlePos;
    }   
}
