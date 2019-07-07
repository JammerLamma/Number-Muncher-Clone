using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HA {
    public class Smasher : MonoBehaviour
    {

        [SerializeField]GameObject tileParent;

        Rigidbody2D rb2D;
        RaycastHit2D hit;
        [SerializeField] Vector2 destination;
        [SerializeField] GameObject selectedTile;
        [SerializeField] int correntAnswers;
        [SerializeField]GameState gameState;


        void Start()
        {

            tileParent = GameObject.FindGameObjectWithTag("TileParent");
            correntAnswers = tileParent.GetComponent<TileParent>()._maxCorrect;
            rb2D = GetComponent<Rigidbody2D>();
            gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();


        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && gameState.hasStarted == true)
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10;

                Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);

                hit = Physics2D.Raycast(screenPos, Vector2.zero);
                destination = new Vector2(hit.transform.position.x, hit.transform.position.y);
                selectedTile = hit.collider.gameObject;

                int tileNum = hit.collider.gameObject.GetComponent<Tile>()._TileNumber;

                rb2D.MovePosition(destination);

                if (transform.position == selectedTile.transform.position)
                {
                    Debug.Log(selectedTile);
                    if (selectedTile.GetComponent<Tile>()._IsCorrect == true && selectedTile.GetComponent<Tile>()._IsCollected == false)
                    {
                        hit.collider.gameObject.GetComponent<Tile>().TriggerVFX();
                        correntAnswers--;
                        gameState.AddToScore();
                        selectedTile.GetComponent<Tile>()._IsWrong = false;
                        CheckWin();

                    }
                    else
                    {
                        Debug.Log("Error");
                    }

                }

            }

        }

        private void CheckWin()
        {
            if (correntAnswers <= 0)
            {
                gameState.Win();
                Debug.Log("WIN");
                this.gameObject.SetActive(false);
            }
        }

    }
}