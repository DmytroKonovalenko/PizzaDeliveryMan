using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystik : MonoBehaviour,IPointerDownHandler,IDragHandler,IPointerUpHandler
{
    Image joystick;
    Image stick;
    Vector2 inputVector;
    private void Start()
    {
        joystick = GetComponent<Image>();
        stick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(joystick.rectTransform,eventData.position,eventData.pressEventCamera,out pos))
        {
            pos.x = (pos.x / joystick.rectTransform.sizeDelta.x);
            pos.y = (pos.y / joystick.rectTransform.sizeDelta.y);
        }
        inputVector = new Vector2(pos.x ,pos.y);
        inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

        stick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystick.rectTransform.sizeDelta.x / 2), inputVector.y * (joystick.rectTransform.sizeDelta.y / 2));
    }

    

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        stick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float Horizontal()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxisRaw("Horizontal");
    }public float Vertical()
    {
        if (inputVector.y != 0)
            return inputVector.y;
        else
            return Input.GetAxisRaw("Vertical");
    }
   
}






