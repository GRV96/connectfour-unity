using System.Collections.Generic;
using UnityEngine;

public class HolderBuilder : MonoBehaviour
{
	private const string _NAME_BASE_SEPARATOR = "Separator ";
	private const string _NAME_BOTTOM_PANEL = "BottomPanel";

	[SerializeField]
	private int _nbRows;

	[SerializeField]
	private int _nbColumns;

	[SerializeField]
	private HolderTopPanel _topPanel;

	[SerializeField]
	private float _buttonDiameter;

	[SerializeField]
	private GameObject _backPanel;

	[SerializeField]
	private GameObject _separatorPrefab;

	[SerializeField]
	private float _panelThickness = 0.05f;

	[SerializeField]
	private float _columnWidth = 1.0f;

	[SerializeField]
	private float _columnDepth = 0.1f;

	// Calculated fields
	private float _panelThicknessHalf;
	private float _holderScaleX;
	private float _columnHeight;

	private List<float> _columnMiddleXs;

	void Awake()
	{
		_panelThicknessHalf = _panelThickness / 2;
		_holderScaleX = _nbColumns * _columnWidth + (_nbColumns + 1) * _panelThickness;
		_columnHeight = _nbRows * _columnWidth;

		BuildBackPanel();
		BuildBottomPanel();
		BuildSeparators();
		BuildTopPanel();
	}

	private void BuildBackPanel()
	{
		Transform backPanelTransform = _backPanel.transform;
		backPanelTransform.position = new Vector3(0, 0, _panelThicknessHalf);
		backPanelTransform.localScale = new Vector3(_holderScaleX, _columnHeight, _panelThickness);
	}

	private void BuildBottomPanel()
	{
		GameObject bottomPanel = Instantiate(_separatorPrefab, transform);
		bottomPanel.name = _NAME_BOTTOM_PANEL;
		Transform bottomPanelTransform = bottomPanel.transform;
		bottomPanelTransform.position = new Vector3(
			0, -_columnHeight/2-_panelThicknessHalf, -_columnDepth/2+_panelThicknessHalf);
		bottomPanelTransform.localScale = new Vector3(
			_holderScaleX, _panelThickness, _columnDepth+_panelThickness);
	}

	private void BuildSeparators()
	{
		float holderScaleXHalf = _holderScaleX / 2;
		float columnWidthHalf = _columnWidth / 2;
		float columnWidthPlus = _columnWidth + _panelThickness;

		_columnMiddleXs = new();

		int nbSeparators = _nbColumns + 1;
		for (int i=0; i<nbSeparators; i++)
		{
			GameObject separator = Instantiate(_separatorPrefab, transform);
			separator.name = _NAME_BASE_SEPARATOR + i;

			float iWidthPlus = i * columnWidthPlus;
			float sepPositionX = iWidthPlus + _panelThicknessHalf - holderScaleXHalf;

			if (i < _nbColumns)
			{
				float columnMiddleX = iWidthPlus + _panelThickness + columnWidthHalf;
				_columnMiddleXs.Add(columnMiddleX);
			}

			Transform separatorTransform = separator.transform;
			separatorTransform.position = new Vector3(sepPositionX, 0f, -_columnDepth/2);
			separatorTransform.localScale = new Vector3(_panelThickness, _columnHeight, _columnDepth);
		}
	}

	private void BuildTopPanel()
	{
		// Build the separators before the top panel.
		_topPanel.transform.position = new Vector3(
			0, (_columnHeight+_columnWidth)/2, _panelThicknessHalf);
		_topPanel.BackgroundScale = new Vector3(_holderScaleX, _columnWidth, _panelThickness);
		_topPanel.MakeButtons(_buttonDiameter, _columnMiddleXs);
	}
}
