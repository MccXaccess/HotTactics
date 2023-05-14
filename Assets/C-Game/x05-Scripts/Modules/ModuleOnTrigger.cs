using UnityEngine;
using UnityEngine.Events;

public class ModuleOnTrigger : MonoBehaviour
{
    [SerializeField] string _targetTag;
    public UnityEvent OnTriggerEnterEvent;
    public UnityEvent OnTriggerExitEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_targetTag))
        {
            OnTriggerEnterEvent?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_targetTag))
        {
            OnTriggerExitEvent?.Invoke();
        }
    }
}