using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HA {
    public class SceneLoader : MonoBehaviour
    {
        GameState parent;
        private void Start()
        {

            parent = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>();
        }

        public void LoadStartScene()
        {
            parent.hasStarted = false;
            parent.ChangeUI();
            SceneManager.LoadScene(0);
            

        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void LoadCore(int level)
        {
            parent.hasStarted = true;
            parent.ChangeUI();
            if (level == 1)
            {
                GameType.gameType = 1;
                SceneManager.LoadScene(1);

            }
            else if(level == 2)
            {
                GameType.gameType = 2;
                SceneManager.LoadScene(1);

            }
            else if(level == 3)
            {
                GameType.gameType = 3;
                SceneManager.LoadScene(1);

            }

        }

    }
}
