using UnityEngine;

public class Holder : MonoBehaviour
{
	private const float _PANEL_THICKNESS = 0.05f;
	private const float _PANEL_THICKNESS_HALF = _PANEL_THICKNESS / 2;
	private const float _TOKEN_DIAMETER = 1.0f;
	private const float _TOKEN_THICKNESS = 0.1f;
	private const float _COLUMN_WIDTH = _TOKEN_DIAMETER + _PANEL_THICKNESS;
	private const float _SEPARATOR_SCALE_Z = _TOKEN_THICKNESS + _PANEL_THICKNESS_HALF;
	private const float _SEPARATOR_SCALE_Z_HALF = _SEPARATOR_SCALE_Z / 2;

	[SerializeField]
	private int _nbRows;

	[SerializeField]
	private int _nbColumns;

	[SerializeField]
	private GameObject _backPanel;

	[SerializeField]
	private GameObject _separatorTemplate;

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
		float backPanelScaleX = _nbColumns * _TOKEN_DIAMETER + (_nbColumns + 1) * _PANEL_THICKNESS;
		float backPanelScaleY = _nbRows * _TOKEN_DIAMETER + (_nbRows + 1) * _PANEL_THICKNESS;

		Transform backPanelTransform = _backPanel.transform;
		backPanelTransform.position = new Vector3(backPanelScaleX/2, 0, _PANEL_THICKNESS_HALF);
		backPanelTransform.localScale = new Vector3(backPanelScaleX, backPanelScaleY, _PANEL_THICKNESS);

		int nbSeparators = _nbColumns + 1;
		for (int i=0; i<nbSeparators; i++)
		{
			GameObject separator = Instantiate(_separatorTemplate, transform);
			Transform separatorTransform = separator.transform;
			float xPosition = i * _COLUMN_WIDTH + _PANEL_THICKNESS_HALF;
			separatorTransform.position = new Vector3(xPosition, 0f, -_SEPARATOR_SCALE_Z_HALF);
			separatorTransform.localScale = new Vector3(_PANEL_THICKNESS, backPanelScaleY, _SEPARATOR_SCALE_Z);
		}
	}
}
