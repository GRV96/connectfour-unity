using UnityEngine;

public class TokenDropButton : MonoBehaviour
{
	private const string _NAME_BASE = "TokenDropButton ";

	[SerializeField]
	private GameObject _physicalButton;

	private int _index = -1;

	public float Diameter
	{
		// Initally, x and z are supposed to be equal.
		get { return _physicalButton.transform.localScale.x; }
		set
		{
			_physicalButton.transform.localScale = new Vector3(value, Thickness, value);
		}
	}

	public int Index
	{
		get { return _index; }
		set
		{
			_index = value;
			name = _NAME_BASE + _index;
		}
	}

	public Vector3 LocalPosition
	{
		get { return transform.localPosition; }
		set { transform.localPosition = value; }
	}

	public float Thickness
	{
		get { return _physicalButton.transform.localScale.y; }
	}
}
