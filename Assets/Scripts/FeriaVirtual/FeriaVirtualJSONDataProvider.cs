using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FeriaVirtual{

    public class FeriaVirtualJSONDataProvider : FeriaVirtualDataProvider{

        public List<UIStrings> GetUIStrings()
        {
            TextAsset fileWithUIStrings = Resources.Load<TextAsset>("UI/UIStrings");
            string fileContent = fileWithUIStrings.text;

            Debug.Log(fileWithUIStrings);

            UIStrings [] jsonInf = JsonHelper.GetJsonArray<UIStrings>(fileContent);

            foreach(UIStrings str in jsonInf)
            {
                Debug.Log(str.Line);
            }

            return jsonInf.ToList();
        }
    }
}