using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class End : MonoBehaviour
{
    public int vie = 4;
    List<GameObject> Life = new List<GameObject>();
    List<GameObject> City = new List<GameObject>();

    [SerializeField] private TextMeshProUGUI Score;

    [SerializeField] private TextMeshProUGUI AffichageText;

    [SerializeField] private GameObject Canvas;
    
    //recuperer les image de la vie et les met dans un tableau
    //recuperer les zone des batiment et les met dans un tableau
    void Start()
    {
        Canvas.SetActive(false);
        Life.Add(GameObject.Find("Life5"));
        Life.Add(GameObject.Find("Life4"));
        Life.Add(GameObject.Find("Life3"));
        Life.Add(GameObject.Find("Life2"));
        Life.Add(GameObject.Find("Life1"));
        City.Add(GameObject.Find("Zone5"));
        City.Add(GameObject.Find("Zone4"));
        City.Add(GameObject.Find("Zone3"));
        City.Add(GameObject.Find("Zone2"));
        City.Add(GameObject.Find("Zone1"));
        
    }

    //Quand un enemy arrive dans la zone
    private void OnTriggerEnter(Collider other) {
        
        if(other.transform.tag=="lily")
        {   // si il ne nous reste plus de vie alors on désactive la dernier vie et la derniere zone 
            // On arrete le spawn des enemi
            // On Désactive le Canvas qui nous permet de jouer et On active le Canvas de fin et y on affiche le score
            if(vie==0)
            {
                Life[vie].SetActive(false);
                City[vie].SetActive(false);
                vie-=1;
                Destroy(other.gameObject);
                GameObject.Find("Pont").GetComponent<Spawner>().Stop();
                string text = Score.text;
                GameObject.Find("Play_Canvas").SetActive(false);
                Canvas.SetActive(true);
                AffichageText.text = text;
            }

            // Si nous avons encore des vie, nous enlevons une image du hud et une zone de la ville 
            // on réduit le nombre de vie de 1 et on détruit l'enemie
            if(vie>0)
            {
                Life[vie].SetActive(false);
                City[vie].SetActive(false);
                vie-=1;
                Destroy(other.gameObject);
            }
            
            //Detruit le reste des enemies qui reste
            if(vie<0)
            {
                Destroy(other.gameObject);
            }

            
        }
    }
}
