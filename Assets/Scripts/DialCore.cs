using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialCore : MonoBehaviour
{

    private RectTransform m_rect;

    [SerializeField]
    private float m_turnSpeed;

    private const float BASE_TURN_SPEED = 100f;

    private bool m_isButtonActive = false;

    private bool m_isSwitchActive = false;

    private int m_actionsTaken = 0;

    void Start() {
        m_rect = base.GetComponent<RectTransform>();
        OnReset();
    }

    void OnEnable() {
        Events.Dial._Button += OnButton;
        Events.Dial._Switch += OnSwitch;
        Events.Dial._Reset += OnReset;
    }

    void OnDisable() {
        Events.Dial._Button -= OnButton;
        Events.Dial._Switch -= OnSwitch;
        Events.Dial._Reset -= OnReset;
    }

    void Update() {
        HandleDialTurn();
    }

    void HandleDialTurn() {
        if (!m_isButtonActive) return;

        m_rect.eulerAngles = new Vector3(
            0f, 
            0f, 
            m_rect.eulerAngles.z + m_turnSpeed * Time.deltaTime
        );
    }

    void OnReset() {
        m_rect.eulerAngles = Vector3.zero;
        m_isButtonActive = m_isSwitchActive = false;
        m_turnSpeed = -BASE_TURN_SPEED;
        m_actionsTaken = 0;
    }

    void OnButton() {
        m_isButtonActive = !m_isButtonActive;
        OnActionTaken();
    }

    void OnSwitch() {
        m_isSwitchActive = !m_isSwitchActive;
        m_turnSpeed = BASE_TURN_SPEED * (m_isSwitchActive ? 1f : -1f);
        OnActionTaken();
    }

    void OnActionTaken() {
        m_actionsTaken++;
        if (m_actionsTaken < 10) return;
        Events.Dial.OnGameFinish();

    }
}
