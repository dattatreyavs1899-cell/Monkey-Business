using UnityEngine;
using System.Collections.Generic;

public class Trajectory : MonoBehaviour
{
    public GameObject dotPrefab;
    public int numberOfDots = 20;
    public float spacing = 0.1f;

    private List<GameObject> dots = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < numberOfDots; i++)
        {
            GameObject dot = Instantiate(dotPrefab, transform);
            dot.SetActive(false);
            dots.Add(dot);
        }
    }

    public void Show(Vector2 startPos, Vector2 velocity)
    {
        for (int i = 0; i < dots.Count; i++)
        {
            float t = i * spacing;

            Vector2 pos = startPos + velocity * t + 0.5f * Physics2D.gravity * t * t;

            dots[i].transform.position = pos;
            dots[i].SetActive(true);
        }
    }

    public void Hide()
    {
        foreach (GameObject dot in dots)
        {
            dot.SetActive(false);
        }
    }
}