using UnityEngine;

public class TokenDropButton : CoinLike
{
	private const string _NAME_BASE = "TokenDropButton ";

	public delegate void EventClicked(int pIndex);
	public event EventClicked clicked;

	[SerializeField]
	private CoinLike _redTokenPrefab;

	[SerializeField]
	private CoinLike _yellowTokenPrefab;

	private int _index = -1;

	private Transform _tokenParent;

	public int Index
	{
		get { return _index; }
		set
		{
			_index = value;
			name = _NAME_BASE + _index;
		}
	}

	void Awake()
	{
		// The holder is the tokens' parent.
		_tokenParent = transform.parent.parent;
	}

	private void SetTokenPosition(CoinLike pToken)
	{
		float tokenPositionY = - Diameter / 2 - 0.01f;
		float tokenPositionZ = Thickness - pToken.Thickness / 2 - 0.01f;
		Vector3 myPosition = transform.position;
		pToken.transform.position = myPosition
			+ new Vector3(0, tokenPositionY, tokenPositionZ);
	}

	void OnMouseDown()
	{
		SpawnToken();
		TriggerClicked();
	}

	private void SpawnToken()
	{
		CoinLike token = Instantiate(_yellowTokenPrefab, _tokenParent);
		SetTokenPosition(token);
	}

	private void TriggerClicked()
	{
		if (clicked != null)
		{
			clicked(_index);
		}
	}
}
