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
 
 //Initialisation du bouton et calcule de la distance que peut parcourir le canon
public void Start()
{
    buttonPressed = false;
}

//Detection de l'appuie sur le bouton
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
    //Recupération de l'angle du canon
    Quaternion startRotation = Canon.transform.rotation;


    //Bouton presser alors mouvement activer, l'angle est donnée par x qui est lié au bouton
    //Bouton non presser alors mouvment immobile 
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
    //Si le canon est position entre les deux borne alors on peut lui appliquer l'angle
    if(Canon.transform.rotation.x >Down.transform.rotation.x  && Canon.transform.rotation.x < Up.transform.rotation.x )
    {
        Canon.transform.rotation = Quaternion.Slerp(Canon.transform.rotation, angle_movement,  Time.deltaTime * speed);
    }

    //Si le canon dépasse la borne alors il ne peut bouger que dans la direction qui le ramene vers l'intérieur des borne
    if(Canon.transform.rotation.x <Down.transform.rotation.x && angle==10)
    {
        Canon.transform.rotation = Quaternion.Slerp(Canon.transform.rotation, angle_movement,  Time.deltaTime * speed);
    }
    if(Canon.transform.rotation.x > Up.transform.rotation.x && angle==-10)
    {
        Canon.transform.rotation = Quaternion.Slerp(Canon.transform.rotation, angle_movement,  Time.deltaTime * speed);
    }
    
}
}