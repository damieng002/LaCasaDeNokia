using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{
    private const int HEIGHT = 48;
    private const int WIDTH = 84;
    private const int TARGET_FPS = 10;
    static readonly Color32 LIGHT_COLOR = new Color32(199, 240, 246, 255);
    static readonly Color32 DARK_COLOR = new Color32(67, 82, 61, 255);
    
    [SerializeField]
    private GameObject pixelPrefab;
    private SpriteRenderer[,] pixels;

    private List<Screen> screens = new List<Screen>();
    private int screenToShow;

    
    private float crtTime = 0f;
    void Start()
    {
        pixels = new SpriteRenderer[WIDTH, HEIGHT];
        for (int x = 0; x < WIDTH; x++)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                GameObject tmp = Instantiate(pixelPrefab);
                tmp.transform.position = new Vector3(x-WIDTH/2+0.5f,y-HEIGHT/2+0.5f,-1);
                pixels[x, HEIGHT-y-1] = tmp.GetComponent<SpriteRenderer>();
            }
        }
        screens.Add(new SampleScreen());
        screenToShow = 0;
    }

    private void FixedUpdate()
    {
        crtTime += Time.fixedDeltaTime;
        if (crtTime >= 1f / TARGET_FPS)
        {
            crtTime = 0f;
            BuildAndShowFrames();
        }
    }

    private void BuildAndShowFrames()
    {
        for (int i = 0; i < screens.Count; i++)
        {
            bool[,] frame = screens[i].BuildFrame();
            if (i == screenToShow)
            {
                UpdateDisplay(frame);
            }
        }
    }

    private void UpdateDisplay(bool[,] frame)
    {
        if (frame.GetLength(0) != WIDTH || frame.GetLength(1) != HEIGHT)
        {
            // show error and exit
            Debug.Log("Error: Size of frame to show is not 84x48");
        }

        for (int x = 0; x < WIDTH; x++)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                pixels[x, y].color = frame[x, y] ? DARK_COLOR : LIGHT_COLOR;
            }
        }
    }
}
