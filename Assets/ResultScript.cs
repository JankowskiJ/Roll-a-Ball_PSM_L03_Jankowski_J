using TMPro;
using UnityEngine;

public class ResultScript : MonoBehaviour
{
    [SerializeField]
    GameObject data;
    [SerializeField]
    GameObject resultText;
    private int deaths=0, points=0,result;
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("DataManager");
        if (data != null)
        {
            deaths = data.GetComponent<DataScript>().totalDeaths ;
            points = data.GetComponent<DataScript>().totalPoints ;
        }
        result = (1000*points)-(150*deaths);
        resultText.GetComponent<TMP_Text>().text = "Wynik: "+ result+"(1000*"+points+") - (150*"+deaths+")";
    }
}
