using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Color normalColour;
    [SerializeField] private Color hoverColour;
    [SerializeField] private TMPro.TextMeshProUGUI textMesh;
    [SerializeField] private MenuAudio menuAudio;

    void Start()
    {
        textMesh = transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textMesh.color = hoverColour;
        menuAudio.PlayHoverSound();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textMesh.color = normalColour;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        menuAudio.PlayClickSound();
    }
}
