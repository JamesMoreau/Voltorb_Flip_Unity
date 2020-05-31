using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IndicatorsController : MonoBehaviour {
    
    public GameStateController game;
    public Tilemap digitsTilemap;
    public Tile[] digitTiles;

    public struct indicator {
        public int value_first_digit;
        public int value_second_digit;
        public int voltorb_count;
    }

    public const int INDICATOR_LENGTH = 5;

    public indicator[] horizontalValues = new indicator[INDICATOR_LENGTH];
    public indicator[] verticalValues = new indicator[INDICATOR_LENGTH];

    public Vector3Int[] horizontalTilePositions;
    public Vector3Int[] verticalTilePositions;

    void Start() {
        resetIndicators();
    }

    void Update() {

        for (int i = 0; i < INDICATOR_LENGTH; i++) {
            //setting horizontal tiles
            digitsTilemap.SetTile(horizontalTilePositions[i], digitTiles[horizontalValues[i].value_second_digit]);
            digitsTilemap.SetTile(horizontalTilePositions[i] + new Vector3Int(-8, 0, 0), digitTiles[horizontalValues[i].value_first_digit]);
            digitsTilemap.SetTile(horizontalTilePositions[i] + new Vector3Int(0, -13, 0), digitTiles[horizontalValues[i].voltorb_count]);

            //setting vertical tiles
            digitsTilemap.SetTile(verticalTilePositions[i], digitTiles[verticalValues[i].value_second_digit]);
            digitsTilemap.SetTile(verticalTilePositions[i] + new Vector3Int(-8, 0, 0), digitTiles[verticalValues[i].value_first_digit]);
            digitsTilemap.SetTile(verticalTilePositions[i] + new Vector3Int(0, -13, 0), digitTiles[verticalValues[i].voltorb_count]);
        }
    }

    public void UpdateValues() {
        resetIndicators();

        for (int i = 0; i < INDICATOR_LENGTH; i++) {
            int totalValue = 0;

            for (int j = 0; j < INDICATOR_LENGTH; j++) {
                int value = game.board[j, i];
                if (value == 0) {
                    horizontalValues[i].voltorb_count++;
                } else {
                    totalValue += value;
                }
            }

            horizontalValues[i].value_first_digit = totalValue / 10;
            horizontalValues[i].value_second_digit = totalValue % 10;
        }

        for (int i = 0; i < INDICATOR_LENGTH; i++) {
            int totalValue = 0;

            for (int j = 0; j < INDICATOR_LENGTH; j++) {
                int value = game.board[i, j];
                if (value == 0) {
                    verticalValues[i].voltorb_count++;
                } else {
                    totalValue += value;
                }
            }

            verticalValues[i].value_first_digit = totalValue / 10;
            verticalValues[i].value_second_digit = totalValue % 10;
        }
    }

    public void resetIndicators() {
        for (int i = 0; i < INDICATOR_LENGTH; i++) {
            horizontalValues[i].value_first_digit = 0;
            horizontalValues[i].value_second_digit = 0;
            horizontalValues[i].voltorb_count = 0;
            
            verticalValues[i].value_first_digit = 0;
            verticalValues[i].value_second_digit = 0;
            verticalValues[i].voltorb_count = 0;
        }
    }
}
