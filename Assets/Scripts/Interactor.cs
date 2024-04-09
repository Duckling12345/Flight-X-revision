using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

interface IInteractable
{
    public void Interact();
}
public class Interactor : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    public Transform InteractorSource;
    public float InteractRange;
    bool buttonPressed;

    
       //will study how to implement to button already have an idea but will continue to experiment and research to confirm. NGM. Thanks
    void Start()
    {
        
    }

    void Update()
    {
        if (buttonPressed)
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
                if(Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }


    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }

}
