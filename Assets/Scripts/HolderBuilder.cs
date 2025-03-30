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
	private float _tokenDiameter = 1.0f;

	[SerializeField]
	private float _tokenThickness = 0.1f;

	void Awake()
	{
		Build();
	}

	private void Build()
	{
		float panelThicknessHalf = _panelThickness / 2;
		float columnWidth = _tokenDiameter + _panelThickness;

		// The separators' scale
		float sepScaleZ = _tokenThickness + panelThicknessHalf;
		float sepScaleZHalf = sepScaleZ / 2;

		// The back panel
		float backPanelScaleX = _nbColumns * _tokenDiameter + (_nbColumns + 1) * _panelThickness;
		float backPanelScaleXHalf = backPanelScaleX / 2;
		float backPanelScaleY = _nbRows * _tokenDiameter;

		Transform backPanelTransform = _backPanel.transform;
		backPanelTransform.position = new Vector3(backPanelScaleXHalf, 0, panelThicknessHalf);
		backPanelTransform.localScale = new Vector3(backPanelScaleX, backPanelScaleY, _panelThickness);

		// The vertical separators
		int nbSeparators = _nbColumns + 1;
		for (int i=0; i<nbSeparators; i++)
		{
			GameObject separator = Instantiate(_separatorPrefab, transform);
			separator.name = _NAME_BASE_SEPARATOR + i;
			Transform separatorTransform = separator.transform;
			float sepPositionX = i * columnWidth + panelThicknessHalf;
			separatorTransform.position = new Vector3(sepPositionX, 0f, -sepScaleZHalf);
			separatorTransform.localScale = new Vector3(_panelThickness, backPanelScaleY, sepScaleZ);
		}

		// The bottom panel
		GameObject bottomPanel = Instantiate(_separatorPrefab, transform);
		bottomPanel.name = _NAME_BOTTOM_PANEL;
		Transform bottomPanelTransform = bottomPanel.transform;
		bottomPanelTransform.position = new Vector3(
			backPanelScaleXHalf, -backPanelScaleY/2-panelThicknessHalf, -sepScaleZHalf+panelThicknessHalf);
		bottomPanelTransform.localScale = new Vector3(
			backPanelScaleX, _panelThickness, sepScaleZ+_panelThickness);

		// The top panel
		_topPanel.Initialize(_nbColumns, _buttonDiameter,
			backPanelScaleX, _tokenDiameter, _panelThickness);
		_topPanel.transform.position = new Vector3(
			backPanelScaleXHalf, (backPanelScaleY+_tokenDiameter)/2, panelThicknessHalf);
	}
}
