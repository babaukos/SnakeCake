using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PointerClickEvent : MonoBehaviour, IPointerClickHandler
{
	public UnityEvent Event;

	public void OnPointerClick(PointerEventData eventData)
	{
		Event.Invoke();
	}
}
