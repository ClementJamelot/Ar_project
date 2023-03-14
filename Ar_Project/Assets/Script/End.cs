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
    
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        
        if(other.transform.tag=="lily")
        {
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
            if(vie>0)
            {
                Life[vie].SetActive(false);
                City[vie].SetActive(false);
                vie-=1;
                Destroy(other.gameObject);
            }
            
            if(vie<0)
            {
                Destroy(other.gameObject);
            }
            if(vie==2)
            {  
                transform.position= new Vector3(0,0.048f,-0.341f);
            }
            if(vie==0)
            {  
                transform.position= new Vector3(0,0.048f,-0.226f);
            }
            
        }
    }
}
