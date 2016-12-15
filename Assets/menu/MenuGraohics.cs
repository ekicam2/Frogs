using UnityEngine;
using System.Collections;

public class MenuGraohics : MonoBehaviour {

    public Light areaLight;
    public Light spotLight;

    private float incrementer = 0;
	// Update is called once per frame
	void Update () {
        var intensity = Mathf.Abs(Mathf.Cos(incrementer / 5f)) - 0.3f;

        areaLight.intensity = intensity;
        spotLight.intensity = intensity * 8.3f;

        incrementer += 0.06f;
	}
}
