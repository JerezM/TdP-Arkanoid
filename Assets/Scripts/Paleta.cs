using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paleta : MonoBehaviour {

    //config parameters
    [SerializeField] float screenWidthInUnits = 4.8f;
    [SerializeField] float minX = 5.64f;
    [SerializeField] float maxX = 10.35f;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {

        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 posPaleta = new Vector2(transform.position.x, transform.position.y);
        posPaleta.x = Mathf.Clamp(mousePosInUnits, minX,maxX);
        transform.position = posPaleta;

    }



}
