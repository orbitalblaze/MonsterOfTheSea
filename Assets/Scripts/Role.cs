using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Role", menuName = "Role")]
public class Role : ScriptableObject {

    public new string name;
    public enum RoleType { BALEINE = 0, CHASSEUR = 1};
    public RoleType roleType;
    public const int BALEINE = 0; 
    public const int CHASSEUR = 1; 
    public Token token;
}
