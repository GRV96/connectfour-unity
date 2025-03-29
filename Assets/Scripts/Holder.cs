using UnityEngine;

public class Holder : MonoBehaviour
{
	[SerializeField]
	private int _nbRows;

	[SerializeField]
	private int _nbColumns;

	[SerializeField]
	private GameObject _backPanel;

	[SerializeField]
	private GameObject _separatorTemplate;

	[SerializeField]
	private float _panelThickness = 0.05f;

	[SerializeField]
	private float _tokenDiameter = 1.0f;

	[SerializeField]
	private float _tokenThickness = 0.1f;

	void Awake()
	{
		Build();
	}

	/*
	void Update()
	{
		//
	} //*/

	private void Build()
	{
		float panelThicknessHalf = _panelThickness / 2;
		float columnWidth = _tokenDiameter + _panelThickness;
		float separatorScaleZ = _tokenThickness + panelThicknessHalf;
		float separatorScaleZHalf = separatorScaleZ / 2;

		float backPanelScaleX = _nbColumns * _tokenDiameter + (_nbColumns + 1) * _panelThickness;
		float backPanelScaleY = _nbRows * _tokenDiameter + (_nbRows + 1) * _panelThickness;

		Transform backPanelTransform = _backPanel.transform;
		backPanelTransform.position = new Vector3(backPanelScaleX/2, 0, panelThicknessHalf);
		backPanelTransform.localScale = new Vector3(backPanelScaleX, backPanelScaleY, _panelThickness);

		int nbSeparators = _nbColumns + 1;
		for (int i=0; i<nbSeparators; i++)
		{
			GameObject separator = Instantiate(_separatorTemplate, transform);
			Transform separatorTransform = separator.transform;
			float sepPositionX = i * columnWidth + panelThicknessHalf;
			separatorTransform.position = new Vector3(sepPositionX, 0f, -separatorScaleZHalf);
			separatorTransform.localScale = new Vector3(_panelThickness, backPanelScaleY, separatorScaleZ);
		}
	}
}
