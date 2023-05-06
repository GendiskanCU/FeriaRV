using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FeriaVirtual;

public class WatchUICanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI informationText;
    [SerializeField] private float timeBetweenLines = 4.0f;

    [SerializeField] private int mainInformationIterations = 5;

    private List<UIStrings> uIStrings = new List<UIStrings>();
    private List<string> mainStrings = new List<string>();
    private FeriaVirtualJSONDataProvider jSONDataProvider = new FeriaVirtualJSONDataProvider();

    private IEnumerator showInformation;

    // Start is called before the first frame update
    void Start()
    {
        uIStrings = jSONDataProvider.GetUIStrings();

        foreach(UIStrings str in uIStrings)
        {
            if(str.Id == "Main")
                mainStrings.Add(str.Line);
        }

        if(mainStrings.Count > 0)
        {
            showInformation = SetInfoText(mainStrings, mainInformationIterations);
            StartCoroutine(showInformation);
        }
    }

    public void ShowScores()
    {
        StopCoroutine(showInformation);

        List<string> scoreText = new List<string>();

        string line = string.Format("Tu puntuación total es: {0}",GlobalData.SharedInstance.TotalScore);
        scoreText.Add(line);
        line = string.Format("La máxima puntuación alcanzada es: {0}", PlayerPrefs.GetInt("MaxScore"));
        scoreText.Add(line);
        line= "";
        scoreText.Add(line);

        showInformation = SetInfoText(scoreText, 5);
        StartCoroutine(showInformation);
    }

    public void ShowInventory()
    {
        StopCoroutine(showInformation);
        
        List<string> inventoryText = new List<string>();

        string line = string.Format("Tu inventario de premios está vacío");
        inventoryText.Add(line);
        line = string.Format("Consigue puntos jugando y canjéalos en la caseta de premios");
        inventoryText.Add(line);
        line= "";
        inventoryText.Add(line);

        showInformation = SetInfoText(inventoryText, 5);
        StartCoroutine(showInformation);
    }

   private IEnumerator SetInfoText(List<string> lines, int iterations = 1)
   {
        int iteration = 0;
        while (iteration < iterations)
        {
            int counter = 0;        
            while(counter < lines.Count)
            {
                informationText.text = lines[counter];
                yield return new WaitForSeconds(timeBetweenLines);
                counter++;
            }
            iteration++;
        }
        
   }
}
