using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIBar : MonoBehaviour {
    [SerializeField] Gradient colors;
    [SerializeField] float damping = .8f;

    float value, smooth, currentValue;
    Image img;

    void Start() {
        img = GetComponent<Image>();
    }

    void Update() {
        smooth = Mathf.SmoothDamp(img.fillAmount, value, ref currentValue, damping);
        img.fillAmount = smooth;
        img.color = colors.Evaluate(smooth);
    }

    public void SetNormalizedValue(float value) {
        this.value = value;
    }
}
