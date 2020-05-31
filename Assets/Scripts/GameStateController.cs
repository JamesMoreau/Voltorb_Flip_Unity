using UnityEngine;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour
{
    [Header("Tile references")]
    public GridLayoutGroup TileGridContainer;
    public TileController[] Tiles;
    public Button PlayButton;

    [Header("Indicators references")]
    public IndicatorsController IndicatorsControl;

    [Header("Sprite references")]
    public Sprite defaultTile;
    public Sprite tile_0;
    public Sprite tile_1;
    public Sprite tile_2;
    public Sprite tile_3;

    [Header("Game board data")]
    public const int board_length = 5;
    public int[,] board = new int[5, 5];

    [Header("Player Data")]
    public int moveCount;
    public int currentCoins;
    public int totalCoins;

    void Start() {
        resetBoard();
    }

    public Sprite getTileSprite(int row, int column) {
        int valueOfTile = board[row, column];

        if (valueOfTile == 0) {
            return tile_0;
        } else if (valueOfTile == 1) {
            return tile_1;
        } else if(valueOfTile == 2) {
            return tile_2;
        } else if (valueOfTile == 3) {
            return tile_3;
        } else {
            return defaultTile;
        }
    }

    public void resetBoard() {
        foreach (TileController t in Tiles) {
            t.interactiveButton.interactable = false;
        }

        for (int x = 0; x < board_length; x++) {
            for (int y = 0; y < board_length; y++) {
                board[x, y] = 0;
            }
        }

        PlayButton.interactable = true;

        //clear the indicators as well...
    }

    //TODO: change difficulty by passing a var to setupBoard()
    public void setupBoard() {
        //fill in board with random values
        for (int x = 0; x < board_length; x++) {
            for (int y = 0; y < board_length; y++) {
                board[x, y] = UnityEngine.Random.Range(0, 4);
            }
        }

        foreach (TileController t in Tiles) {
            t.resetTile();
        }

        IndicatorsControl.UpdateValues();

        //fill in indicators with corresponding data
        /*for (int i = 0; i < board_length; i++) { //should be based on random value generated
            horizontal_indicators[i] = 0;
        }*/

        /*for (int i = 0; i < board_length; i++) {
            vertical_indicators[i] = 0;
        }*/

        moveCount = 0;
        currentCoins = 0;

        //PlayButton.interactable = false;
    }
}
