using UnityEngine;
namespace Grid
{
    public class Cell : MonoBehaviour
    {
        public GridPosition position;

        private void Awake()
        {
            position = new GridPosition();
        }

        public void userClick()
        {
            print(position.x + ", " + position.y);
        }

    }
}