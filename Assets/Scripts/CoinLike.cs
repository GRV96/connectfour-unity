using UnityEngine;

public class CoinLike : MonoBehaviour
{
	[SerializeField]
	private GameObject _cylinder;

	public float Diameter
	{
		// x and z are supposed to always be equal.
		get { return _cylinder.transform.localScale.x; }
		set
		{
			_cylinder.transform.localScale = new Vector3(value, Thickness, value);
		}
	}

	public Vector3 LocalPosition
	{
		get { return transform.localPosition; }
		set { transform.localPosition = value; }
	}

	public float Thickness
	{
		get { return _cylinder.transform.localScale.y; }
		set
		{
			float diameter = Diameter;
			_cylinder.transform.localScale = new Vector3(diameter, value, diameter);
		}
	}
}
