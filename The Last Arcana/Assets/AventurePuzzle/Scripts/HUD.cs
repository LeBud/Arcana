using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD Instance { get; private set; }

    [Header("Pause Panel")]
    public GameObject pausePanel;
    public GameObject inGamePanel;
    public GameObject pauseBtt;

    [Header("Grab")]
    public GameObject grabObj;
    public GameObject grabRotateObj;

    [Header("Astral Pocket")]
    public Slider astralSlider;
    public GameObject astralInputs;

    [Header("White Fade")]
    public GameObject whiteFade;
    public Animator whiteFadeAnim;

    [Header("Tutorial")]
    [SerializeField] GameObject tutorialHolder;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    private void Start()
    {
        astralSlider.minValue = 0;
        astralSlider.maxValue = AstralPocket.Instance.timeToReset;
    }

    public IEnumerator Tutorial()
    {
        tutorialHolder.SetActive(true);
        yield return new WaitForSeconds(6);
        tutorialHolder.SetActive(false);
    }

    #region PauseMenu
    public void SelectBtt(GameObject button)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button);
    }

    public void Pause()
    {
        SelectBtt(pauseBtt);
        pausePanel.SetActive(true);
        inGamePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        GameManager.Instance.gameIsPause = false;
        pausePanel.SetActive(false);
        inGamePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}
