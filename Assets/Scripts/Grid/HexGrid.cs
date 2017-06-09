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

    public HexMesh hexMesh;

    public Color defaultColor = Color.white;
    public Color touchedColor = Color.magenta;

    void Awake () {
        //On récupère le mesh des cases
        hexMesh = GetComponentInChildren<HexMesh>();
		//On récupère le canvas
        gridCanvas = GetComponentInChildren<Canvas>();
		//On initialise l'array contenant les cases en fonction de la hauteur et de la largeur
        cells = new HexCell[width * height];
		//On instantie les cases du plateau
        for (int y = 0, i = 0; y < width; y++) {
            for (int x = 0; x < height; x++) {
                CreateCell(x, y, i++);
            }
        }
    }

    void Start () {
        hexMesh.Triangulate(cells);
    }

    void Update () {
        if (Input.GetMouseButton(0)) {
            HandleInput();
        }
    }

    void HandleInput () {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit)) {
            TouchCell(hit.point);
            
        }
    }

    public void TouchCell (Vector3 position) {
        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        print("click at " + coordinates.ToString());
        int index = coordinates.Z * height + coordinates.X;
        HexCell cell = cells[index];
        cell.color = touchedColor;
        hexMesh.Triangulate(cells);
        print(coordinates.ToString() + index);
        
    }
	
    void CreateCell (int x, int y, int i) {
        Vector3 position;
        //y*0.5 est le décalage pour aligner les centres avec les arêtes des lignes inférieures.
        //Le y / 2 sert à enlever l'unité du résultat de y*0.5 pour permettre que sur les lignes impaires,
        //il y ait un décalage de la moitié du double du rayon interne
        position.y = (x + y * 0.5f - y / 2) * (HexMetrics.innerRadius * 2f) /*Décalage entre les centres pour les colonnes*/;
        position.x     = y * (HexMetrics.outerRadius * 1.5f) /*Décalage entre les centres pour les lignes*/;
        position.z = 0f;

        //On instancie un prefab de cellule à l'endroit calculé, en lui désactivant son postionnement vis à vis du parent.
        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, y);
        cell.color = defaultColor;

        //On instancie du texte pour labeliser les cellules. On place
        Text label = Instantiate<Text>(cellLabelPrefab);
        label.rectTransform.SetParent(gridCanvas.transform, false);
        label.rectTransform.anchoredPosition =
            new Vector2(position.x, position.y);
        label.text = cell.coordinates.ToStringOnSeparateLines();
    }

}