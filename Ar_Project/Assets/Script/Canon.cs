using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI AffichageText;

    public void Mise_score()
    {
        int numb_score =int.Parse(AffichageText.text) +10;
        AffichageText.text=numb_score.ToString();
    }
}
