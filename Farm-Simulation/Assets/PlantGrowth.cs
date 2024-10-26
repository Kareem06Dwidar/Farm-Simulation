using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    public GameObject mediumPlantPrefab; // Assign the medium plant prefab here
    public float growthTime = 5f; // Time in seconds for the plant to grow
    private GameManager gameManager;

    void Start()
    {
        // Find the GameManager in the scene
        gameManager = FindObjectOfType<GameManager>();
        Invoke("GrowToMedium", growthTime);
    }

    void GrowToMedium()
    {
        Instantiate(mediumPlantPrefab, transform.position, Quaternion.identity);
        
        // Increase score when the plant grows to medium size
        if (gameManager != null)
        {
            gameManager.AddScore(10); // Increase score by 10 points
        }
        
        //Destroy(gameObject); // Remove the small plant
    }
}
