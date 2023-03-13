using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

public GameObject Canon;
public bool buttonPressed;
public float speed = 0.6f;
public Vector3 movement;

public float x;
 
public void Start()
{
    buttonPressed = false;
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
    if(Canon.transform.position.x<0.25 && Canon.transform.position.x>-0.25)
    {
        Canon.transform.Translate(movement * speed * Time.deltaTime);
    }
    if(Canon.transform.position.x>0.25 && x==-0.5f)
    {
        Canon.transform.Translate(movement * speed * Time.deltaTime);
    }
    if(Canon.transform.position.x<-0.25 && x==0.5f)
    {
        Canon.transform.Translate(movement * speed * Time.deltaTime);
    }
    
}
}