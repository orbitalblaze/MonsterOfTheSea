/////////////////////////
/// GRèVE GÉNÉRALE  /////
/////////////////////////

using UnityEngine;
using System.Collections.Generic;
using Grid;

//On créer automatiquement des composants sur notre GameObject
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexMesh : MonoBehaviour {
    //Le mesh d'affichage
	public Mesh hexMesh;
    //Liste des arêtes
	List<Vector3> vertices;
    //Liste des triangles
	List<int> triangles;

	void Awake () {
	    //On récupère le composant MeshFilter auquel on lui attribue notre mesh que l'on instancie et que l'on nomme Hex Mesh.
		GetComponent<MeshFilter>().mesh = hexMesh = new Mesh();
		hexMesh.name = "Hex Mesh";

		vertices = new List<Vector3>();
		triangles = new List<int>();
	}

	void Start()
	{
		Triangulate();
	}
    

    //Triangulise une cellule
	public void Triangulate () {
		hexMesh.Clear();
		vertices.Clear();
		triangles.Clear();
	    
    //On considère la position de la cellule comme son centre.
		Vector3 center = new Vector3(0f,0f,0f);
		
        //On créer les faces triangulaires en utilisants le sommet et en décalant les coins de l'hexagone
        for (int i = 0; i < 6; i++) {
            AddTriangle(
                center,
                center + HexMetrics.corners[i],
                center + HexMetrics.corners[i + 1]
            );
        }

		hexMesh.vertices = vertices.ToArray();
		hexMesh.triangles = triangles.ToArray();
		hexMesh.RecalculateNormals();
	}

    
    //Forme un triangle à partir de 3 points
    void AddTriangle (Vector3 v1, Vector3 v2, Vector3 v3) {
        //Index du premier sommet dans la list.
        int vertexIndex = vertices.Count;
        //On ajoute les sommet dans la list.
        vertices.Add(v1);
        vertices.Add(v2);
        vertices.Add(v3);
        //On réference les index des sommets dans la list pour les triangles.
        triangles.Add(vertexIndex);
        triangles.Add(vertexIndex + 1);
        triangles.Add(vertexIndex + 2);
    }
  
	private void OnMouseDown()
	{
		transform.parent.GetComponent<Cell>().userClick();
	}

	private void OnMouseEnter()
	{
		transform.parent.GetComponent<Cell>().mouseOver();
	}
}