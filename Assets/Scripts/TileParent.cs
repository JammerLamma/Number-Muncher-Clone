using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HA
{
    public class TileParent : MonoBehaviour
    {
        [SerializeField] int maxCorrect;
        [SerializeField] int remainingNumbers;
        [SerializeField] List<GameObject> children = new List<GameObject>();

        [SerializeField] GameObject randomChild;

        [SerializeField] List<int> evenNumbers;
        [SerializeField] List<int> oddNumbers;
        [SerializeField] List<int> oneToHundred;
        [SerializeField] List<int> allOthers;
        [SerializeField] List<int> primeNumbers;
        [SerializeField] int correctOnBoard = 0;
        [SerializeField] int totalTiles = 25;
        [SerializeField] public Sprite[] numberSprite;
        [SerializeField] GameState gameState;
        [SerializeField] public bool hasStarted = false;

        // [SerializeField] GameObject smasherPF;

        public Sprite[] _NumberSprite
        {
            get { return numberSprite; }
            set { numberSprite = value; }
        }
        public List<int> _EvenNumbers
        {
            get { return evenNumbers; }

        }
        public int _maxCorrect
        {
            get { return maxCorrect; }
            set { maxCorrect = value; }
        }
        public bool _HasStarted
        {
            get { return hasStarted; }
        }



        // Start is called before the first frame update
        void Start()
        {
            gameState = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();

            if (GameType.gameType == 1)
            {
                GenerateEven();
            }
            else if(GameType.gameType == 2)
            {
                GenerateOdd();
            }
            else if (GameType.gameType == 3)
            {
                GeneratePrime();
            }

        }

        private void GenerateOdd()
        {
           // GameObject smasher = Instantiate(smasherPF, transform.position, transform.rotation);
            remainingNumbers = totalTiles - maxCorrect;
            GetLists();
            GetTiles();
            AssignOdd();
            RemoveDuplicates(oddNumbers);
            AssignRest();
        }

        public void GenerateEven()
        {
            //GameObject smasher = Instantiate(smasherPF, transform.position, transform.rotation);
            remainingNumbers = totalTiles - maxCorrect;
            GetLists();
            GetTiles();
            AssignEven();
            RemoveDuplicates(evenNumbers);
            AssignRest();
        }
        public void GeneratePrime()
        {
            //GameObject smasher = Instantiate(smasherPF, transform.position, transform.rotation);
            remainingNumbers = totalTiles - maxCorrect;
            GetLists();
            GetTiles();
            AssignPrime();
            RemoveDuplicates(primeNumbers);
            AssignRest();
        }

        private void AssignRest()
        {
            foreach (GameObject thisObject in children)
            {
                if (thisObject.GetComponent<Tile>()._TileNumber == 0)
                {
                    int tempTileNum = allOthers[UnityEngine.Random.Range(0, allOthers.Count)];
                    thisObject.GetComponent<Tile>()._TileNumber = tempTileNum;
                    thisObject.GetComponent<Tile>()._IsCorrect = false;
                    randomChild.GetComponent<Tile>()._IsWrong = true;
                    thisObject.GetComponent<SpriteRenderer>().sprite = numberSprite[tempTileNum - 1];
                }
            }
        }


        private void AssignPrime()
        {
            int maxCorrect = 5;
            for (int i = 1; i <= maxCorrect;)
            {
                randomChild = children[UnityEngine.Random.Range(0, children.Count)];

                {
                    if (randomChild.GetComponent<Tile>()._IsCorrect == false)
                    {
                        int maxLength = primeNumbers.Count;
                        int tempTileNum = primeNumbers[UnityEngine.Random.Range(0, maxLength)];
                        randomChild.GetComponent<Tile>()._TileNumber = tempTileNum;
                        randomChild.GetComponent<Tile>()._IsCorrect = true;
                        correctOnBoard++;
                        randomChild.GetComponent<SpriteRenderer>().sprite = numberSprite[tempTileNum - 1];
                        i++;
                    }
                }
            }
        }

        private void AssignEven()
        {
            for (int i = 1; i <= maxCorrect;)
            {
                 randomChild = children[UnityEngine.Random.Range(0, children.Count)];

                if(randomChild.GetComponent<Tile>()._IsCorrect == false)
                {
                    int maxLength = evenNumbers.Count;
                    int tempTileNum = evenNumbers[UnityEngine.Random.Range(0, maxLength)];
                    randomChild.GetComponent<Tile>()._TileNumber = tempTileNum;
                    randomChild.GetComponent<Tile>()._IsCorrect = true;
                    correctOnBoard++;
                    randomChild.GetComponent<SpriteRenderer>().sprite = numberSprite[tempTileNum - 1];
                    Debug.Log(tempTileNum);
                    i++;
                }

            }
        }

        private void AssignOdd()
        {
            randomChild = children[UnityEngine.Random.Range(0, children.Count)];

            for (int i = 1; i <= maxCorrect;)
            {
                if (randomChild.GetComponent<Tile>()._IsCorrect == false)
                {
                    int maxLength = oddNumbers.Count;
                    int tempTileNum = oddNumbers[UnityEngine.Random.Range(0, maxLength)];
                    randomChild.GetComponent<Tile>()._TileNumber = tempTileNum;
                    randomChild.GetComponent<Tile>()._IsCorrect = true;
                    correctOnBoard++;
                    randomChild.GetComponent<SpriteRenderer>().sprite = numberSprite[tempTileNum - 1];
                    i++;
                }
            }
        }

        private void GetTiles()
        {
            foreach (Transform child in this.gameObject.transform)
            {
                child.GetComponent<Tile>()._IsCorrect = false;
                children.Add(child.gameObject);
            }
        }

        private void GetLists()
        {
            PrimeList();
            for (int i = 1; i < 101; i++)
            {
                if (i % 2 == 0)
                {
                    evenNumbers.Add(i);
                }
                else
                {
                    oddNumbers.Add(i);
                }

            }
            for (int i = 1; i < 101; i++)
            {
                oneToHundred.Add(i);
            }      
        }

        private void PrimeList()
        {
            for (int i = 0; i < 100; i++)
            {
                bool prime = PrimeTool.IsPrime(i);
                if (prime)
                {
                    primeNumbers.Add(i);
                }
            }
        }

        public void RemoveDuplicates(List<int> list)
        {
            allOthers = new List<int>(oneToHundred);
            foreach (int i in list)
            {

                if (oneToHundred.Contains(i))
                {

                    allOthers.Remove(i);
                
                }

            }

        }
    }
}
