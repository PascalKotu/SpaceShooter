using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {
	public bool tap, swipeLeft, swipeRight, swipeUp, swipeDown, isDragging;
	public Vector2 startTouch, swipeDelta;

	private void Update(){
		tap = swipeUp = swipeRight = swipeLeft = swipeDown = false;

		if (Input.touches.Length > 0) {
			if (Input.touches [0].phase == TouchPhase.Began) {
				isDragging = true;
				tap = true;
				startTouch = Input.touches [0].position;
			}
			else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled){
				isDragging = false;
				Reset ();
			}
		}

		swipeDelta = Vector2.zero;
		if (isDragging) {
			if (Input.touches.Length >0){
				swipeDelta = (Vector2)Input.mousePosition - startTouch;
			}else if(Input.GetMouseButton(0)){
				swipeDelta = (Vector2)Input.mousePosition - startTouch;
			}
		}

		if (swipeDelta.magnitude > 3) {
			float x = swipeDelta.x;
			if (x < 0)
				swipeLeft = true;
			else
				swipeRight=true;
		}

	}

	private void Reset(){
		startTouch =swipeDelta = Vector2.zero;

	}

}
