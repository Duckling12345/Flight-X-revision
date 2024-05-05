using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExtinguisherScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool Pressed;

    [SerializeField] private float extinguishRate = 1.0f; //amount of fire extinguished per second

    [SerializeField] private Transform raycastOrigin = null;

    [Space, Header("Steam")]
    [SerializeField] private GameObject steamObject = null;

    public GameObject extinguisherEffect;


    private bool IsRaycastingSomething(out RaycastHit hit) => Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, 100f);

    private bool IsRaycastingFire(out FireScript fire)
    {
        fire = null;

        return IsRaycastingSomething(out RaycastHit hit) && hit.collider.TryGetComponent(out fire);
    }

    private void Start()
    {
        if (!steamObject)
            Debug.LogError("Please place a steam particle system on the Extinguisher's steamObject field or rewrite the Extinguisher script.", this);
    }

    private void Update()
    {
        if (IsRaycastingFire(out FireScript fire))
        {
            ExtinguishFire(fire);
        }
        else
        {
            extinguisherEffect.SetActive(false);
        }
    }

    private void ExtinguishFire(FireScript fire)
    {
        fire.TryExtinguish(extinguishRate * Time.deltaTime);

        steamObject.transform.position = fire.transform.position;
        steamObject.SetActive(fire.GetIntensity() > 0.0f);
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }
}
