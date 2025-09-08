using UnityEngine;

public static class VectorExtensions
{
	public static Vector2 Flatten(this Vector3 v, bool modifyXY = false)
	{
		if (modifyXY)
		{
			float mag = v.magnitude;
			v.z = 0;
			v.Normalize();
			v *= mag;
		}
		else
		{
			v.z = 0;
		}
		return v;
	}
}
