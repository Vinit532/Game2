using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    // Reference to the GridGenerator script
    public GridGenerator gridGenerator;

    // Example method to save the grid layout with capture cages and mines
    public void SaveLevel()
    {
        // Create a string to store the grid layout data
        string gridLayoutData = "";

        // Iterate through each cell of the grid
        for (int row = 0; row < GridGenerator.gridSize; row++) // Use the type name instead of an instance reference
        {
            for (int col = 0; col < GridGenerator.gridSize; col++) // Use the type name instead of an instance reference
            {
                // Check if the current cell has a capture cage or mine
                bool hasCaptureCage = CheckCaptureCage(row, col); // Call the method to check if the cell has a capture cage
                bool hasMine = CheckMine(row, col); // Call the method to check if the cell has a mine

                // Append the grid layout data for the current cell
                gridLayoutData += hasCaptureCage ? "C" : "N";
                gridLayoutData += hasMine ? "M" : "N";
            }
        }

        // Save the grid layout data using PlayerPrefs
        PlayerPrefs.SetString("GridLayoutData", gridLayoutData);
        PlayerPrefs.Save();
    }

    // Example method to check if a cell has a capture cage
    private bool CheckCaptureCage(int row, int col)
    {
        // Check if the row is an odd number (starting from the second row) and the column is an even number
        return row % 2 == 1 && col % 2 == 0;
    }

    // Example method to check if a cell has a mine
    private bool CheckMine(int row, int col)
    {
        // Check if the column is an odd number (starting from the second column) and the row is an even number
        return col % 2 == 1 && row % 2 == 0;
    }
}
