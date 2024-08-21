using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject player;
    public GameObject arrowPrefab;
    float elapsedTime; //경과 시간
    public static float maxElapsedTime = 0.5f;
    void Update()
    {
        if (GameLauncher.gameState != GameLauncher.GameState.GameOver)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= maxElapsedTime)
            {
                SpawnArrow();
                elapsedTime = 0f;

            }
        }
    }

    void SpawnArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab);
        arrow.transform.position = new Vector3(Random.Range(-8f,8f), 4.88f, 0);
        
    }
}
