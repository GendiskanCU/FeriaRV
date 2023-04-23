using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using FeriaVirtual;

public class GameInfoCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameInformationText;

    [SerializeField] private float timeBetweenLines = 4.0f;

    [SerializeField] private int numberOfIterations = 25;

    private IEnumerator showInformation;

    private List<UIStrings> uIStrings = new List<UIStrings>();
    private List<string> informationStrings = new List<string>();
    private List<string> instructionsStrings = new List<string>();

    private FeriaVirtualJSONDataProvider jSONDataProvider = new FeriaVirtualJSONDataProvider();


    // Start is called before the first frame update
    void Start()
    {
        uIStrings = jSONDataProvider.GetUIStrings();

        foreach(UIStrings str in uIStrings)
        {
            if(str.Id == "GameInformation")
                informationStrings.Add(str.Line);
        }

        string currentGame = SceneManager.GetActiveScene().name;
        foreach(UIStrings str in uIStrings)
        {
            if(str.Id == currentGame)
                instructionsStrings.Add(str.Line);
        }

        if(informationStrings.Count > 0)
        {
            showInformation = SetInfoText(informationStrings, numberOfIterations);
            StartCoroutine(showInformation);
        }
    }

    private IEnumerator SetInfoText(List<string> lines, int iterations = 1)
   {
        int iteration = 0;
        while (iteration < iterations)
        {
            int counter = 0;        
            while(counter < lines.Count)
            {
                gameInformationText.text = lines[counter];
                yield return new WaitForSeconds(timeBetweenLines);
                counter++;
            }
            iteration++;
        }        
   }
}
