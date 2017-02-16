using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {
	
	public InputField Field;
	public Text TextBox;

	//myText = vModel.searchField.text;        // drag your text object on here

	public void CopyText() {
		TextBox.text = Field.text;
	}

	public void ClickLetter(string letterClicked)
	{
		//string tempCurString = myText.text;
		Field.text = letterClicked + Field.text;
		TextBox.text = letterClicked + TextBox.text;


		//string tempNewString = letterClicked + tempCurString;
		//myText.text = tempNewString;

	//	myinput.text = letterClicked + myinput.text;
}


}
