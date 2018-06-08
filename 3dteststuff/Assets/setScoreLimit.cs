using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setScoreLimit : MonoBehaviour {
    public Text input;


	public void setLimit()
    {
        int a = 0;
        int.TryParse(input.text, out a);
        Debug.Log(input.text);
        PlayerPrefs.SetInt("scoreLimit", a);
    }


}
