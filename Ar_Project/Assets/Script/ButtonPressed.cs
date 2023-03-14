using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

public GameObject Canon;
[SerializeField] private GameObject Origin;
[SerializeField] private GameObject Left;
[SerializeField] private GameObject Right;

private float distance_left;
private float distance_right;
[SerializeField]private bool buttonPressed;
[SerializeField]private float speed = 0.6f;
[SerializeField]private Vector3 movement;


[SerializeField]private float x;
 
public void Start()
{
    buttonPressed = false;
    distance_right = Origin.transform.position.x - Right.transform.position.x;
    distance_left = Left.transform.position.x - Origin.transform.position.x;
}
public void OnPointerDown(PointerEventData eventData)
{
    buttonPressed = true;
}
public void OnPointerUp(PointerEventData eventData)
{
    buttonPressed = false;
}
 
void Update()
{
    if(buttonPressed == true)
    {
        
        movement = new Vector3(x,0,0);  
       
    }
    else
    {
        movement = new Vector3(0,0,0);
    }
    if(Canon.transform.position.x<distance_left && Canon.transform.position.x>-distance_right)
    {
        Canon.transform.Translate(movement * speed * Time.deltaTime);
    }
    if(Canon.transform.position.x>distance_left && x==-0.5f)
    {
        Canon.transform.Translate(movement * speed * Time.deltaTime);
    }
    if(Canon.transform.position.x<distance_right && x==0.5f)
    {
        Canon.transform.Translate(movement * speed * Time.deltaTime);
    }
    
}
}