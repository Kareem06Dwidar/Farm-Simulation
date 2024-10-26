using UnityEngine;

public class Pouring : MonoBehaviour
{
    public Transform WaterCan; // Assign the watering can object in the Inspector
    public float rotationAngle = 45f; // Angle to rotate when pouring
    public float rotationSpeed = 2f; // Speed of rotation
    public GameObject plantPrefab; // Small plant prefab
    public GameObject mediumPlantPrefab; // Assign the `Plant_Tomato_Medium` prefab here
    public float wateringRange = 1.5f; // Range to detect seeds
    public float growthTime = 5f; // Time for the plant to grow
    public Scoring scoring;
    void Update()
    {
        RotateCan();

        if (Input.GetMouseButton(0)) // Check if left mouse button is held
        {
            WaterSeeds();
        }
    }

    void RotateCan()
    {
        // Check if the left mouse button is held down
        bool isPouring = Input.GetMouseButton(0);
        float targetAngle = isPouring ? rotationAngle : 0;
        Quaternion targetRotation = Quaternion.Euler(targetAngle, 0, 0);

        WaterCan.localRotation = Quaternion.Lerp(WaterCan.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    void WaterSeeds()
    {
        GameObject[] seeds = GameObject.FindGameObjectsWithTag("Seed");

        foreach (GameObject seed in seeds)
        {
            if (Vector3.Distance(transform.position, seed.transform.position) < wateringRange)
            {
                // Replace the seed with a small plant
                GameObject smallPlant = Instantiate(plantPrefab, seed.transform.position, Quaternion.identity);
                Destroy(seed);

                // Add growth functionality to the small plant
                PlantGrowth growth = smallPlant.AddComponent<PlantGrowth>();
                growth.mediumPlantPrefab = mediumPlantPrefab; // Assign medium plant prefab
                growth.growthTime = growthTime; // Set growth time
                scoring.AddScore(1);
                break;
            }
        }
    }
}
