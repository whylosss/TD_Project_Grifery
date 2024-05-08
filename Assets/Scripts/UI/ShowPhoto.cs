using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowPhoto : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _photo;

    private void Start()
    {
        _photo.enabled = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _photo.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _photo.enabled = false;
    }
}
