using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnOnPlanet : MonoBehaviour
{

    public GameObject character;
    public GameObject planet;

    private void Update() {
        if (Input.GetKeyDown("q")) {
            Run();
        }
    }
    public void Run()
    {
        Vector3 spawnPosition = Random.onUnitSphere * ((planet.transform.localScale.x / 2) + character.transform.localScale.y * 0.5f) + planet.transform.position;
        Quaternion spawnRotation = Quaternion.identity;
        GameObject newCharacter = Instantiate(character, spawnPosition, spawnRotation) as GameObject;
        newCharacter.transform.LookAt(planet.transform);
        newCharacter.transform.Rotate(-90, 0, 0);
        newCharacter.AddComponent<FauxGravityBody>();
        newCharacter.GetComponent<FauxGravityBody>().attractor = planet.GetComponent<FauxGravityAttractor>();
    }
}
