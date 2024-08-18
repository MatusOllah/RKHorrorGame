using UnityEngine;
using UnityEngine.Audio;

public class Flashlight : MonoBehaviour {
    public GameObject flashlight;

    public AudioSource sound;

    [HideInInspector]
    public bool active;

    void Start() {
        active = false;
        flashlight.SetActive(false);
    }

    void Update() {
        if (Input.GetButtonDown("Flashlight")) {
            active = !active;
            flashlight.SetActive(active);
            sound.Play();
        }
    }
}
