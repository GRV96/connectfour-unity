using System.Collections.Generic;
using UnityEngine;

public class HolderTopPanel : MonoBehaviour
{
	[SerializeField]
	private TokenDropButton _buttonPrefab;

	[SerializeField]
	private GameObject _background;

	public Vector3 BackgroundPosition
	{
		get { return _background.transform.localPosition; }
	}

	public Vector3 BackgroundScale
	{
		get { return _background.transform.localScale; }
		set { _background.transform.localScale = value; }
	}

	public float BackgroundThickness
	{
		get { return _background.transform.localScale.z; }
	}

	public void MakeButtons(int pNbButtons, float pButtonDiameter)
	{
		float buttonPosY = BackgroundPosition.y / 2;
		float buttonPosZ = - BackgroundThickness - _buttonPrefab.Thickness / 2;
		float halfWidth = BackgroundScale.x / 2;
		float gap = (BackgroundScale.x - pNbButtons * pButtonDiameter) / (pNbButtons + 1);

		for (int i=0; i<pNbButtons; i++)
		{
			TokenDropButton button = Instantiate(_buttonPrefab, transform);
			button.Diameter = pButtonDiameter;
			button.Index = i;
			float buttonPosX = (i + 1) * gap + (i + 0.5f) * pButtonDiameter;
			button.LocalPosition = new Vector3(buttonPosX-halfWidth, buttonPosY, buttonPosZ);
		}
	}
}
