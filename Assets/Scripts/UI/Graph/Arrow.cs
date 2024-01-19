using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Arrow: MonoBehaviour {
	public Vector2 arrowDirection;

	private Image image;

	private void Awake() {
		image = GetComponent<Image>();
		arrowDirection.Normalize();
	}

	public void PlaceAt(Vector2 start, Vector2 end, float clip = 0f) {
		// calculate the actual start and end position
		var targetDirection = (end - start).normalized;
		var clipVector = clip * targetDirection;
		start = start + clipVector;
		end = end - clipVector;
		// another possible solution
		// start = Vector2.MoveTowards(start, end, clip);
		// end = Vector2.MoveTowards(end, start, clip);

		// calculate the rotation
		var arrowAngle
			= Mathf.Atan2(arrowDirection.y, arrowDirection.x) * Mathf.Rad2Deg;
		var directionAngle  
			= Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
		var rotationZ = directionAngle - arrowAngle;

		// get RectTransform component
		var rectTransform = GetComponent<RectTransform>();

		// set anchoredPosition
		rectTransform.anchoredPosition = start;
		
		// set sizeDelta 
		var sizeDelta = rectTransform.sizeDelta;
		rectTransform.sizeDelta 
			= new Vector2(sizeDelta.x, Vector2.Distance(start, end));
		
		// set localEulerAngles
		var eulerAngle = rectTransform.localEulerAngles;
		rectTransform.localEulerAngles 
			= new Vector3(eulerAngle.x, eulerAngle.y, rotationZ);
	}
}