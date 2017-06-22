using UnityEngine;

public class CardBehaviour : MonoBehaviour
{

	public GameObject dropTarget;
	public int actionRange;
	public GameObject effectApplicationTarget;

	public CardBehaviorScript behaviorScript;

	public void LauchEffect()
	{
		behaviorScript = Instantiate(behaviorScript);
		behaviorScript.Effect();
	}
}