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

private float distance;

[SerializeField]private bool buttonPressed;
[SerializeField]private float speed = 0.6f;
[SerializeField]private Vector3 movement;


[SerializeField]private float x;
 
public void Start()
{
    //Initialisation du bouton et calcule de la distance que peut parcourir le canon
    buttonPressed = false;
    distance = Origin.transform.position.x - Right.transform.position.x;
    
    
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
    //Bouton presser alors mouvement activer, la direction est donnée par x qui est lié au bouton
    //Bouton non presser alors mouvment immobile 
    if(buttonPressed == true)
    {
        movement = Canon.transform.right * x;    
    }
    else
    {
        movement = new Vector3(0,0,0);
    }
    //Si le canon est position entre les deux borne alors on peut lui appliquer le mouvment
    if(Canon.transform.position.x<Origin.transform.position.x+distance && Canon.transform.position.x>Origin.transform.position.x-distance)
    {  
        Canon.transform.Translate(movement * speed * Time.deltaTime);
    }

    //Si le canon dépasse la borne alors il ne peut bouger que dans la direction qui le ramene vers l'intérieur des borne
    if(Canon.transform.position.x>Origin.transform.position.x+distance && x==-0.5f)
    {
        Canon.transform.Translate(movement * speed * Time.deltaTime);
    }
    if(Canon.transform.position.x<Origin.transform.position.x-distance && x==0.5f)
    {
        Canon.transform.Translate(movement * speed * Time.deltaTime);
    }
    
    
}
}