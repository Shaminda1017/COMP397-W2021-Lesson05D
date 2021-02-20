using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControlPanelController : MonoBehaviour
{
    public RectTransform rectTransform;

    public Vector2 offscreenPossition;
    public Vector2 onscreenPossition;
    [Range(0.1f, 3.0f)]
    public float speed = 1.0f;
    public float timer = 0.0f;
    public bool isOnScreen = false;

    public CameraController playerCamera;

    public Pauseable pauseable;


    // Start is called before the first frame update
    void Start()
    {
        pauseable = FindObjectOfType<Pauseable>();
        playerCamera = FindObjectOfType<CameraController>();
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = offscreenPossition;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {  
            isOnScreen = !isOnScreen;
            timer = 0.0f;
        }
        if (isOnScreen)
        {
            Cursor.lockState = CursorLockMode.None;
            playerCamera.enabled = false;
        }
        else
        {
            playerCamera.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (isOnScreen)
        {
            MoveControlPanelDown();
        }
        else
        {
            MoveControlPanelUp();
        }
    }
    private void MoveControlPanelDown()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(offscreenPossition, onscreenPossition, timer);
        if(timer < 1.0f)
        {
            timer += Time.deltaTime * speed;
        }
    }

    private void MoveControlPanelUp()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(onscreenPossition, offscreenPossition, timer);
        if (timer < 1.0f)
        {
            timer += Time.deltaTime * speed;
        }

        if (pauseable.isGamePaused)
        {
            pauseable.TogglePause();
        }
    }
}
