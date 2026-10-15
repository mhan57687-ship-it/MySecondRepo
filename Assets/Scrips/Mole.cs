using UnityEngine;

public class Mole : MonoBehaviour
{
    public float riseDistance = 80f;
    public float riseSpeed = 300f;
    public float stayTime = 0.5f;
    public float sinkSpeed = 300f;
    public int score = 1;

    RectTransform moleRect;
    Vector2 targetPosition;
    bool isRising = true;
    bool isSinking = false;

    void Start()
    {
        moleRect = GetComponent<RectTransform>();

        targetPosition = moleRect.anchoredPosition;

        moleRect.anchoredPosition = targetPosition - new Vector2(0f, riseDistance);
    }

    void Update()
    {
        if (isRising)
        {
            moleRect.anchoredPosition += new Vector2(0f, riseSpeed * Time.deltaTime);

            if (moleRect.anchoredPosition.y >= targetPosition.y)
            {
                moleRect.anchoredPosition = targetPosition;
                isRising = false;
                Invoke("StartSink", stayTime);
            }
        }

        if (isSinking)
        {
            moleRect.anchoredPosition -= new Vector2(0f, sinkSpeed * Time.deltaTime);

            if (moleRect.anchoredPosition.y <= targetPosition.y - riseDistance)
            {
                Destroy(gameObject);
            }
        }
    }

    void StartSink()
    {
        isSinking = true;
    }

    public void Hit()
    {
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AddScore(score);
        Destroy(gameObject);
    }
}