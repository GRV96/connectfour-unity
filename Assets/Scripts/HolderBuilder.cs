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

	void Awake()
	{
		_panelThicknessHalf = _panelThickness / 2;
		_holderScaleX = _nbColumns * _columnWidth + (_nbColumns + 1) * _panelThickness;
		_columnHeight = _nbRows * _columnWidth;

		Build();
	}

	private void Build()
	{
		Transform backPanelTransform = _backPanel.transform;
		backPanelTransform.position = new Vector3(0, 0, _panelThicknessHalf);
		backPanelTransform.localScale = new Vector3(_holderScaleX, _columnHeight, _panelThickness);

		// The vertical separators
		float columnWidth = _columnWidth + _panelThickness;
		float holderScaleXHalf = _holderScaleX / 2;
		int nbSeparators = _nbColumns + 1;
		for (int i=0; i<nbSeparators; i++)
		{
			GameObject separator = Instantiate(_separatorPrefab, transform);
			separator.name = _NAME_BASE_SEPARATOR + i;
			Transform separatorTransform = separator.transform;
			float sepPositionX = i * columnWidth + _panelThicknessHalf - holderScaleXHalf;
			separatorTransform.position = new Vector3(sepPositionX, 0f, -_columnDepth/2);
			separatorTransform.localScale = new Vector3(_panelThickness, _columnHeight, _columnDepth);
		}

		// The bottom panel
		GameObject bottomPanel = Instantiate(_separatorPrefab, transform);
		bottomPanel.name = _NAME_BOTTOM_PANEL;
		Transform bottomPanelTransform = bottomPanel.transform;
		bottomPanelTransform.position = new Vector3(
			0, -_columnHeight/2-_panelThicknessHalf, -_columnDepth/2+_panelThicknessHalf);
		bottomPanelTransform.localScale = new Vector3(
			_holderScaleX, _panelThickness, _columnDepth+_panelThickness);

		// The top panel
		_topPanel.Initialize(_nbColumns, _buttonDiameter,
			_holderScaleX, _columnWidth, _panelThickness);
		_topPanel.transform.position = new Vector3(
			0, (_columnHeight+_columnWidth)/2, _panelThicknessHalf);
	}
}
