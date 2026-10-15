using UnityEngine;

public class MoleSpawner : MonoBehaviour
{
    public GameObject[] holes;
    public GameObject[] molePrefabs;
    public GameObject[] holeMasks;

    void Start()
    {
        InvokeRepeating("SpawnMole", 0f, 1f);
    }

    void SpawnMole()
    {
        GameManager gameManager = FindFirstObjectByType<GameManager>();

        if (gameManager.gameOver)
            return;

        bool[] usedHoles = new bool[holes.Length];

        int moleCount = Random.Range(1, 4);

        for (int i = 0; i < moleCount; i++)
        {
            int holeIndex;

            do
            {
                holeIndex = Random.Range(0, holes.Length);
            }
            while (usedHoles[holeIndex]);

            usedHoles[holeIndex] = true;

            int moleIndex = Random.Range(0, molePrefabs.Length);

            GameObject mole = Instantiate(
                molePrefabs[moleIndex],
                holeMasks[holeIndex].transform
            );

            RectTransform holeRect = holes[holeIndex].GetComponent<RectTransform>();
            RectTransform moleRect = mole.GetComponent<RectTransform>();

            moleRect.anchoredPosition = new Vector2(0f, 30f);

            Destroy(mole, 1f);
        }
    }
}