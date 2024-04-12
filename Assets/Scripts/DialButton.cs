using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialButton : MonoBehaviour
{
    private Button m_button;

    private TextMeshProUGUI m_text;

    private int m_timesPressed;

    public int TimesPressed {
        get {
            return m_timesPressed;
        } set {
            m_timesPressed = value;
            if (m_text != null) m_text.SetText(m_timesPressed.ToString());
        }
    }

    void Awake() {
        m_button = base.GetComponentInChildren<Button>();
        m_text = base.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start() {
        m_button.onClick.AddListener(() => {
            Events.Dial.OnButton();
        });
        OnReset();
    }

    void OnEnable() {
        Events.Dial._Button += OnButton;
        Events.Dial._Reset += OnReset;
    }

    void OnDisable() {
        Events.Dial._Button -= OnButton;
        Events.Dial._Reset -= OnReset;

    }

    void OnReset() {
        TimesPressed = 0;
    }

    void OnButton() {
        TimesPressed++;
        m_text.SetText(m_timesPressed.ToString());

    }
}
