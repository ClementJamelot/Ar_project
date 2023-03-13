using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class ButtonPressed2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

public GameObject Canon;
public bool buttonPressed;
public float speed = 0.6f;
private int angle;

public Quaternion angle_movement;

public int x;
 
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
    Quaternion startRotation = Canon.transform.rotation;
    if(buttonPressed == true)
    {
        
        angle = x; 
        angle_movement = startRotation* Quaternion.Euler(angle, 0, 0);
       
    }
    else
    {
        angle = 0;
        angle_movement = startRotation* Quaternion.Euler(angle, 0, 0);
    }
    
    if(Canon.transform.rotation.eulerAngles.x >50.7 && Canon.transform.rotation.eulerAngles.x < 86.7)
    {
        
        Canon.transform.rotation = Quaternion.Slerp(Canon.transform.rotation, angle_movement,  Time.deltaTime * speed);
    }
       
        
    
    
    if(Canon.transform.rotation.eulerAngles.x <50.7 && angle==-10)
    {
        Canon.transform.rotation = Quaternion.Slerp(Canon.transform.rotation, angle_movement,  Time.deltaTime * speed);
    }
    if(Canon.transform.rotation.eulerAngles.x > 86.7 && angle==10)
    {
        Canon.transform.rotation = Quaternion.Slerp(Canon.transform.rotation, angle_movement,  Time.deltaTime * speed);
    }
    
}
}