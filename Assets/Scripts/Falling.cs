using UnityEngine;


public class Falling : MonoBehaviour
{
	public Transform player;
	public float zOffset = 0f;

	private void Start()
	{
		if (player == null)
		{
			Debug.LogError("Falling: player transform is not assigned.");
			enabled = false;
		}
	}

	private void LateUpdate()
	{
		if (player == null)
			return;

		Vector3 pos = transform.position;
		float targetZ = player.position.z + zOffset;

		pos.z = targetZ;

		transform.position = pos;
	}
}
