using UnityEngine;
namespace Grid
{
    public class Cell : MonoBehaviour
    {
        public GridPosition position;
        public HexMesh mesh;
        
        private void Awake()
        {
            mesh = GetComponentInChildren<HexMesh>();
            mesh.Triangulate();
            
        }
    }
}