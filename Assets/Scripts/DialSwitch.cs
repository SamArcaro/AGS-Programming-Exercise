using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialSwitch : MonoBehaviour {

    [SerializeField]
    private Button[] m_buttons;

    [SerializeField]
    private RectTransform m_switchPivot;

    private const float SWITCH_OFF_ROT = 45f;

    private const float SWITCH_ON_ROT = 135f;

    private TextMeshProUGUI m_text;

    private int m_timesSwitched;

    public int TimesSwitched {
        get {
            return m_timesSwitched;
        } set {
            m_timesSwitched = value;
            if (m_text != null) m_text.SetText(m_timesSwitched.ToString());
        }
    }

    void Awake() {
        m_buttons = base.GetComponentsInChildren<Button>();
        m_text = base.GetComponentInChildren<TextMeshProUGUI>();

    }

    void Start() {
        OnReset();
    }

    void OnEnable() {
        Events.Dial._Switch += OnSwitch;
        Events.Dial._Reset += OnReset;
    }

    void OnDisable() {
        Events.Dial._Switch -= OnSwitch;
        Events.Dial._Reset -= OnReset;
    }

    void OnReset() {
        StopAllCoroutines();
        TimesSwitched = 0;
        if (m_switchPivot != null) {
            m_switchPivot.localEulerAngles = new Vector3(0f, 0f, SWITCH_OFF_ROT);
        }
    }

    void OnSwitch() {
        DoSwitchRoutine();
    }

    void DoSwitchRoutine() {
        switchRoutine = StartCoroutine(SwitchRoutine());
    }

    private Coroutine switchRoutine;

    IEnumerator SwitchRoutine() {
        TimesSwitched++;

        // set pivot to flicked rotation
        if (m_switchPivot != null) {
            m_switchPivot.localEulerAngles = new Vector3(0f, 0f, SWITCH_ON_ROT);
        }

        yield return new WaitForSeconds(1.5f);

        // reset pivot to off rotation
        if (m_switchPivot != null) {
            m_switchPivot.localEulerAngles = new Vector3(0f, 0f, SWITCH_OFF_ROT);
        }
        
        switchRoutine = null;
        StopAllCoroutines();
    }

    public bool IsSwitchRoutineNull() {
        return switchRoutine == null;
    }
}
