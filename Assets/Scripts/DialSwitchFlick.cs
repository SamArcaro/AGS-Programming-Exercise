using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialSwitchFlick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 m_mousePos;

    private DialSwitch m_dialSwitch;

    void Awake() {
        m_dialSwitch = GetComponentInParent<DialSwitch>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        m_mousePos = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vector3 curMousePos = Input.mousePosition;

        // Do nothing if mouse did not 'flick' up
        if (curMousePos.y < m_mousePos.y) return;

        // Do nothing if switch routine is currently active
        if (!m_dialSwitch.IsSwitchRoutineNull()) return;

        // Call switch event
        Events.Dial.OnSwitch();
    }
}
