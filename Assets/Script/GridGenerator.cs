using UnityEngine;
using UnityEngine.UI;

public class GridGenerator : MonoBehaviour
{
    
    public GameObject captureCagePrefab; // Reference to the capture cage prefab
    public GameObject minePrefab; // Reference to the mine prefab

    public GameObject cellPrefab; // Reference to the cell prefab
    public float spacing = 0.1f; // Spacing between the cells

    public const int gridSize = 6; // Size of the grid

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int row = 0; row < gridSize; row++)
        {
            for (int col = 0; col < gridSize; col++)
            {
                Vector3 cellPosition = new Vector3(col * (spacing + 1), 0f, row * (spacing + 1)); // Calculate the position of the cell

                // Instantiate the cell prefab at the calculated position
                GameObject cell = Instantiate(cellPrefab, cellPosition, Quaternion.identity);

                cell.transform.SetParent(transform); // Set the cell as a child of the grid
            }
        }
    }

    public void AddCaptureCage(int row, int column)
    {
        // Calculate the position of the capture cage within the specified cell
        Vector3 cagePosition = new Vector3(column * (spacing + 1), 0.5f, row * (spacing + 1));

        // Instantiate the capture cage prefab at the calculated position
        GameObject captureCage = Instantiate(captureCagePrefab, cagePosition, Quaternion.identity);

        captureCage.transform.SetParent(transform); // Set the capture cage as a child of the grid
    }

    // Example method to add a mine at a specific grid position
    public void AddMine(int row, int column)
    {
        // Calculate the position of the mine within the specified cell
        Vector3 minePosition = new Vector3(column * (spacing + 1), 0.5f, row * (spacing + 1));

        // Instantiate the mine prefab at the calculated position
        GameObject mine = Instantiate(minePrefab, minePosition, Quaternion.identity);

        mine.transform.SetParent(transform); // Set the mine as a child of the grid
    }
}

