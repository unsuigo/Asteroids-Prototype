using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MobileController : MonoBehaviour , IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image jostickBG;
    [SerializeField]
    private Image jostick;
    private Vector2 inputVector;

    private void Start()
    {
        jostickBG = GetComponent<Image>();
        jostick = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector2.zero;
        jostick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(jostickBG.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / jostickBG.rectTransform.sizeDelta.x);
            pos.y = (pos.y / jostickBG.rectTransform.sizeDelta.x);

            print(pos);
            inputVector = new Vector2(pos.x * 2, pos.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            jostick.rectTransform.anchoredPosition = 
                new Vector2(
                    inputVector.x * (jostickBG.rectTransform.sizeDelta.x / 2), 
                    inputVector.y * (jostickBG.rectTransform.sizeDelta.y / 2)
                );

        }
    }

    public float Horizontal()
    {
        print("Horizontal");
        if (inputVector.x != 0) return inputVector.x;
        else return Input.GetAxis("Horizontal");

    }

    public float Vertical()
    {

        print("Vertical");
        if (inputVector.y != 0) return inputVector.y;
        else return Input.GetAxis("Vertical");

    }
}
