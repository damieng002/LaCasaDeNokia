using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{
    static readonly int HEIGHT = 48;
    static readonly int WIDTH = 84;
    static readonly int TARGET_FPS = 10;
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
        GameManager.Instance.SetDisplayRef(this);
        GameManager.Instance.LoadMenu();
    }

    public void SetScreens(List<Screen> screens)
    {
        this.screens = screens;
        this.screenToShow = 0;
    }

    public void SetScreenToShow(int screenToShow)
    {
        this.screenToShow = screenToShow;
    }

    public int ScreenToShow => screenToShow;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0)){GameManager.Instance.KeyPressed('0');}
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)){GameManager.Instance.KeyPressed('1');}
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)){GameManager.Instance.KeyPressed('2');}
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)){GameManager.Instance.KeyPressed('3');}
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)){GameManager.Instance.KeyPressed('4');}
        if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5)){GameManager.Instance.KeyPressed('5');}
        if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6)){GameManager.Instance.KeyPressed('6');}
        if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7)){GameManager.Instance.KeyPressed('7');}
        if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8)){GameManager.Instance.KeyPressed('8');}
        if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9)){GameManager.Instance.KeyPressed('9');}
        if (Input.GetKeyDown(KeyCode.Asterisk) || Input.GetKeyDown(KeyCode.KeypadMultiply)){GameManager.Instance.KeyPressed('*');}
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
