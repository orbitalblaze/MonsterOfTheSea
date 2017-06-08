using UnityEngine;
using System.Collections.Generic;

//On créer automatiquement des composants sur notre GameObject
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexMesh : MonoBehaviour {
    //Le mesh d'affichage
	Mesh hexMesh;
    //Liste des arêtes
	List<Vector3> vertices;
    //Liste des triangles
	List<int> triangles;
    MeshCollider meshCollider;
    List<Color> colors;

	void Awake () {
	    //On récupère le composant MeshFilter auquel on lui attribue notre mesh que l'on instancie et que l'on nomme Hex Mesh.
		GetComponent<MeshFilter>().mesh = hexMesh = new Mesh();
	    meshCollider = gameObject.AddComponent<MeshCollider>();
		hexMesh.name = "Hex Mesh";

		vertices = new List<Vector3>();
	    colors = new List<Color>();
		triangles = new List<int>();
	}

    //Trianguler un ensemble de cellules
    public void Triangulate (HexCell[] cells) {
        //On nettoie les potentiels anciennes triangulations
        hexMesh.Clear();
        vertices.Clear();
        triangles.Clear();
        colors.Clear();
        //Pour chaque cellule, on fait une triangulisation
        for (int i = 0; i < cells.Length; i++) {
            Triangulate(cells[i]);
        }
        //On récupère les faces et les arêtes du Mesh dans les list.
        hexMesh.vertices = vertices.ToArray();
        hexMesh.colors = colors.ToArray();
        hexMesh.triangles = triangles.ToArray();
        //Recalcule les normales
        hexMesh.RecalculateNormals();
        meshCollider.sharedMesh = hexMesh;
        meshCollider.convex = true;
    }

    //Triangulise une cellule
    void Triangulate (HexCell cell) {
        //On considère la position de la cellule comme son centre.
        Vector3 center = cell.transform.localPosition;
        //On créer les faces triangulaires en utilisants le sommet et en décalant les coins de l'hexagone
        for (int i = 0; i < 6; i++) {
            AddTriangle(
                center,
                center + HexMetrics.corners[i],
                center + HexMetrics.corners[i + 1]
            );
            AddTriangleColor(cell.color);
        }
    }

    void AddTriangleColor (Color color) {
        colors.Add(color);
        colors.Add(color);
        colors.Add(color);
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
}