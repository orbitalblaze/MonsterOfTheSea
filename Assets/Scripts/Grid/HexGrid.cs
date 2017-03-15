using UnityEngine;
using UnityEngine.UI;

//Classe du plateau de jeu
public class HexGrid : MonoBehaviour {

	//Largeur du plateau
    public int width = 6;
	//Hauteur du plateau
    public int height = 6;
	//Un préfab d'une case du plateau
	public HexCell cellPrefab;
	//L'ensemble des cases générées
    HexCell[] cells;
	//Le label des cases
    public Text cellLabelPrefab;
	//Le canvas où sera stocké le plateau
    public Canvas gridCanvas;

    void Awake () {
		//On récupère le canvas
        gridCanvas = GetComponentInChildren<Canvas>();
		//On initialise l'array contenant les cases en fonction de la hauteur et de la largeur
        cells = new HexCell[height * width];
		//On instantie les cases du plateau
        for (int y = 0, i = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                CreateCell(x, y, i++);
            }
        }
    }
	
    void CreateCell (int x, int y, int i) {
        Vector3 position;
        position.x = (x + y * 0.5f - y / 2) * (HexMetrics.innerRadius * 2f);
        position.y = y * (HexMetrics.outerRadius * 1.5f);;
        position.z = 0f;

        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;

        Text label = Instantiate<Text>(cellLabelPrefab);
        label.rectTransform.SetParent(gridCanvas.transform, false);
        label.rectTransform.anchoredPosition =
            new Vector2(position.x, position.z);
        label.text = x.ToString() + "\n" + y.ToString();
    }

}