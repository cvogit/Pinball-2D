using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupFadeController : MonoBehaviour {

	public Animator popupFadeAnimator;
	private Text mPopupText;

	void Start() {
		AnimatorClipInfo[] animatorInfo = popupFadeAnimator.GetCurrentAnimatorClipInfo(0);
		Destroy (gameObject, animatorInfo [0].clip.length - 0.05f);
		mPopupText = popupFadeAnimator.GetComponent<Text> ();

	}

	public void SetText (string pText) {
		if( mPopupText == null )
			mPopupText = popupFadeAnimator.GetComponent<Text> ();

		mPopupText.text = pText;
	}
}
