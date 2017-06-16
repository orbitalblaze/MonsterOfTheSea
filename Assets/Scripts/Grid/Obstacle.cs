using UnityEngine;

namespace Grid
{
	public class Obstacle : MonoBehaviour
	{
		private Cell parent;

		// Use this for initialization
		void Awake()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		public void SetParentCell(Cell cell)
		{
			if (parent == null)
			{
				parent = cell;
				transform.SetParent(cell.transform);
				transform.localPosition = new Vector3(0f, 0f, 0f);
			}
		}
	}
}
