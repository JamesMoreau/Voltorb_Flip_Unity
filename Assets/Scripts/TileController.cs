using UnityEngine;
using UnityEngine.UI;

public class TileController : MonoBehaviour
{
    [Header("Component References")]
    public GameStateController gameController;                       // Reference to game controller
    public Button interactiveButton;                                 // Reference to this button

    [Header("GameData")]
    public int column;
    public int row;

    public void updateTile() {
        /*int[] coords = { column, row };*/
        interactiveButton.image.sprite = gameController.getTileSprite(column, row);
        gameController.moveCount++;
    }

    public void resetTile() {
        interactiveButton.image.sprite = gameController.defaultTile;
        interactiveButton.interactable = true;
    }
}
