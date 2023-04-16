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

    private IEnumerator showMainInformation;

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
            showMainInformation = SetInfoText(mainStrings, mainInformationIterations);
            StartCoroutine(showMainInformation);
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
                informationText.text = lines[counter];
                yield return new WaitForSeconds(timeBetweenLines);
                counter++;
            }
            iteration++;
        }
        
   }
}
