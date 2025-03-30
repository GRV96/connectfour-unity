using UnityEngine;

public class TokenDropButton : CoinLike
{
	private const string _NAME_BASE = "TokenDropButton ";

	private int _index = -1;

	public int Index
	{
		get { return _index; }
		set
		{
			_index = value;
			name = _NAME_BASE + _index;
		}
	}
}
