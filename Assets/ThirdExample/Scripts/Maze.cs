using UnityEngine;

public class Maze : MonoBehaviour
{
    public void Build(MazeFormFactory formFactory, int numberOfCells, MazeFormType mazeFormType)
    {
        MazeGridForm gridForm = formFactory.Get(mazeFormType);
        gridForm.GenerateGridCoordinates(numberOfCells);
    }
}
