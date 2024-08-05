using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TooltipHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text tooltipText; // Arraste o Text do tooltip aqui no Inspector
    public string message; // Defina a mensagem do tooltip no Inspector
    private RectTransform canvasRectTransform;

    private SlotItem slotItem;
    private bool focusingThisSlotItem;

    void Start()
    {
        tooltipText.gameObject.SetActive(false); // Certifique-se de que o tooltip esteja invisível inicialmente
        canvasRectTransform = tooltipText.canvas.GetComponent<RectTransform>();
        slotItem = GetComponent<SlotItem>();
    }

    void Update()
    {
        if (tooltipText.gameObject.activeSelf)
        {
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Input.mousePosition, null, out localPoint);
            tooltipText.rectTransform.localPosition = localPoint;

            if (focusingThisSlotItem && slotItem.itemData)
            {
                tooltipText.text = slotItem.itemData.description; // Define a mensagem do tooltip
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        focusingThisSlotItem = true;
        tooltipText.gameObject.SetActive(true); // Torna o tooltip visível
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        focusingThisSlotItem = false;
        tooltipText.gameObject.SetActive(false); // Torna o tooltip invisível
    }
}