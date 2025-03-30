using System.Collections.Generic;
using UnityEngine;

public class HolderTopPanel : MonoBehaviour
{
	[SerializeField]
	private GameObject _buttonPrefab;

	[SerializeField]
	private GameObject _background;

	public Vector3 BackgroundPosition
	{
		get { return _background.transform.localPosition; }
		//set { _background.transform.localScale = value; }
	}

	public Vector3 BackgroundScale
	{
		get { return _background.transform.localScale; }
		private set { _background.transform.localScale = value; }
	}

	public void Initialize(int pNbColumns, float pScaleX, float pScaleY, float pScaleZ)
	{
		BackgroundScale = new Vector3(pScaleX, pScaleY, pScaleZ);
		MakeButtons(pNbColumns);
	}

	private void MakeButtons(int pNbButtons)
	{
		float buttonPosY = BackgroundPosition.y / 2;
		float buttonPosZ = -0.05f;
		float halfWidth = BackgroundScale.x / 2;

		float buttonDiameter = 0.8f;
		float gap = (BackgroundScale.x - pNbButtons * buttonDiameter) / (pNbButtons + 1);

		for (int i=0; i<pNbButtons; i++)
		{
			GameObject button = Instantiate(_buttonPrefab, transform);
			float buttonPosX = (i + 1) * gap + (i + 0.5f) * buttonDiameter;
			button.transform.localPosition = new Vector3(buttonPosX-halfWidth, buttonPosY, buttonPosZ);
		}
	}
}
