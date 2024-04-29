using System;
using UnityEngine;

public class MazeExample : MonoBehaviour
{
    [SerializeField] private CellType _cellType;
    [SerializeField] private MazeFormType _formType;
    [SerializeField] private int _numberOfCells;

    [SerializeField] private Maze _maze;

    [ContextMenu("BuildMaze")]
    public void BuildMaze()
    {
        MazeFormFactory formFactory;

        switch (_cellType)
        {
            case CellType.Hex:
                formFactory = new HexMazeFormFactory();
                break;

            case CellType.Square:
                formFactory = new SquareMazeFormFactory();
                break;

            default:
                throw new InvalidOperationException("Œÿ»¡ ¿ “»œ¿  À≈“ »");
        }

        _maze.Build(formFactory, _numberOfCells, _formType);
    }
}
