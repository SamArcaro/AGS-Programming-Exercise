using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetPopUp : MonoBehaviour
{
    [SerializeField]
    private new GameObject gameObject;

    [SerializeField]
    private Button yesButton, noButton;

    [SerializeField]
    private GameObject greyScreenObject;

    void Awake() {

    }

    void Start() {
        yesButton.onClick.AddListener(() => {
            Events.Dial.OnReset();
        });

        noButton.onClick.AddListener(() => {
            greyScreenObject.SetActive(true);
#if !UNITY_EDITOR
            Application.Quit();
#endif
        });

        OnReset();
    }

    void OnEnable() {
        Events.Dial._Reset += OnReset;
        Events.Dial._GameFinish += OnGameFinish;
    }

    void OnDisable() {
        Events.Dial._Reset -= OnReset;
        Events.Dial._GameFinish -= OnGameFinish;
    }

    void OnReset() {
        gameObject.SetActive(false);
        greyScreenObject.SetActive(false);
    }

    void OnGameFinish() {
        gameObject.SetActive(true);
        greyScreenObject.SetActive(false);
    }
}
