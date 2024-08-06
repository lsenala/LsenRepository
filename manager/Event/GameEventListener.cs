
using UnityEngine;
using UnityEngine.Events;
public class GameEventListener : MonoBehaviour
{
    public GameEvent Event;

    public UnityEvent �����¼�;
    private void OnEnable()
    {
        Event.RegisterListener(this);
    }
    private void OnDisable()
    {
        Event.UnRegisterListener(this);
    }
    public void OnEventRaised()
    {
        �����¼�.Invoke();
    }
}
