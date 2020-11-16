using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    [SerializeField]
    private SceneLoader sceneLoader;
    [SerializeField]
    private CircleCollider2D ballCollider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        sceneLoader.LoadSpecificScene("Game Over");
    }
}
