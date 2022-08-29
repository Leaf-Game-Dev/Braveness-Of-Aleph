using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDebugObject : MonoBehaviour
{
    GridObject gridObject;
    TMPro.TMP_Text displayText;

    public void SetGridObject(GridObject gridObject)
    {
        this.gridObject = gridObject;
        displayText = GetComponentInChildren<TMPro.TMP_Text>();
    }

    private void Update()
    {
        displayText.text = this.gridObject.ToString();

    }



}
