using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{

    public GameObject GameController;
    public Renderer rend;
    public float scrollSpeed;
    public float tileSizeZ;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;

        if (GameController.GetComponent<Game_Controller>().youWin == true)
        {
            scrollSpeed = -3;
        }
        if (GameController.GetComponent<Game_Controller>().gameOver == true)
        {
            scrollSpeed = 0.0f;
        }
    }
}
