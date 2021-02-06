using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable] public class AudioClipDictionary : SerializableDictionary<string, AudioClip> { }
public class Display : MonoBehaviour
{
    public static readonly int HEIGHT = 48;
    public static readonly int WIDTH = 84;
    public static readonly int TARGET_FPS = 2;
    public static readonly Color32 LIGHT_COLOR = new Color32(199, 240, 216, 255);
    public static readonly Color32 DARK_COLOR = new Color32(67, 82, 61, 255);
    
    [SerializeField]
    private GameObject pixelPrefab;
    [SerializeField]
    private AudioClipDictionary audioClips;
    private AudioSource _audioSource;
    private SpriteRenderer[,] _pixels;

    private List<Screen> _screens = new List<Screen>();
    private int _screenToShow;

    
    private float _crtTime = 0f;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _pixels = new SpriteRenderer[WIDTH, HEIGHT];
        for (int x = 0; x < WIDTH; x++)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                GameObject tmp = Instantiate(pixelPrefab);
                tmp.transform.position = new Vector3(x-WIDTH/2+0.5f,y-HEIGHT/2+0.5f,-1);
                _pixels[x, HEIGHT-y-1] = tmp.GetComponent<SpriteRenderer>();
            }
        }
        GameManager.Instance.SetDisplayRef(this);
        GameManager.Instance.LoadMenu();
    }

    public void SetScreens(List<Screen> screens)
    {
        this._screens = screens;
        this._screenToShow = 0;
    }

    public void SetScreenToShow(int screenToShow)
    {
        this._screenToShow = screenToShow;
    }

    public int ScreenToShow => _screenToShow;

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
        _crtTime += Time.fixedDeltaTime;
        if (_crtTime >= 1f / TARGET_FPS)
        {
            _crtTime = 0f;
            GameManager.Instance.NextFrame();
            BuildAndShowFrames();
        }
    }

    private void BuildAndShowFrames()
    {
        for (int i = 0; i < _screens.Count; i++)
        {
            bool[,] frame = _screens[i].BuildFrame();
            if (i == _screenToShow)
            {
                UpdateDisplay(frame);
            }
        }
    }

    private void UpdateDisplay(bool[,] frame)
    {
        if (frame.GetLength(0) != WIDTH || frame.GetLength(1) != HEIGHT)
        {
            return;
        }

        for (int x = 0; x < WIDTH; x++)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                _pixels[x, y].color = frame[x, y] ? DARK_COLOR : LIGHT_COLOR;
            }
        }
    }

    public void PlaySound(string name)
    {
        _audioSource.clip = audioClips[name];
        _audioSource.Play();
    }
}
