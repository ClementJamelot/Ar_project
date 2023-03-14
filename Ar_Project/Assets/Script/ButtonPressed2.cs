using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class ButtonPressed2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

[SerializeField]private GameObject Canon;
[SerializeField]private bool buttonPressed;
[SerializeField] private float speed = 0.6f;
private int angle;

[SerializeField] private GameObject Up;
[SerializeField] private GameObject Down;

[SerializeField]public Quaternion angle_movement;

[SerializeField]private int x;
 
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
    
    if(Canon.transform.rotation.x >Down.transform.rotation.x  && Canon.transform.rotation.x < Up.transform.rotation.x )
    {
        Canon.transform.rotation = Quaternion.Slerp(Canon.transform.rotation, angle_movement,  Time.deltaTime * speed);
    }

    if(Canon.transform.rotation.x <Down.transform.rotation.x && angle==-10)
    {
        Canon.transform.rotation = Quaternion.Slerp(Canon.transform.rotation, angle_movement,  Time.deltaTime * speed);
    }
    if(Canon.transform.rotation.x > Up.transform.rotation.x && angle==10)
    {
        Canon.transform.rotation = Quaternion.Slerp(Canon.transform.rotation, angle_movement,  Time.deltaTime * speed);
    }
    
}
}