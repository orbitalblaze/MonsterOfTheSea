using UnityEngine;

public static class HexMetrics
{
    //Rayon externe de l'hexagone (cercle fait à partir des sommets de l'hexagone)
    public const float outerRadius = 10f;
    //Rayon interne de l'hexagone (cercle fait à partir des milieux de arêtes de l'hexagone).
    //Il équivaut à √3/2 le rayon externe. Ici, il vaut 5√3.
    //Permet de calculer la distance entre deux centre de cases voisines qui équivaut à deux fois cette distance
    public const float innerRadius = outerRadius * 0.866025404f;

    //Les différentes positions des sommets. L'hexagone est positionné avec un sommet vers le haut.
    //Schéma : https://drive.google.com/open?id=0B63W_aPVMvgqQlZnQzJ3QkQ3MlU
    public static Vector3[] corners = {
        //A1. Sommet pointant vers le haut.
        new Vector3(0f, 0f, outerRadius),
        //A2
        new Vector3(innerRadius, 0f, 0.5f * outerRadius),
        //A3
        new Vector3(innerRadius, 0f, -0.5f * outerRadius),
        //A4
        new Vector3(0f, 0f, -outerRadius),
        //A5
        new Vector3(-innerRadius, 0f, -0.5f * outerRadius),
        //A6
        new Vector3(-innerRadius, 0f, 0.5f * outerRadius)
    };
}