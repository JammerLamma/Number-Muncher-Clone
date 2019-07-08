using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HA
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] GameObject vfx;
        SpriteRenderer rend;

        private int tileNumber;
        [SerializeField] bool isCorrect;
        bool isWrong = false;
        bool isCollected = false;

        public int _TileNumber
        {
            get { return tileNumber; }
            set { tileNumber = value; }
        }

        public bool _IsCorrect
        {
            get { return isCorrect; }
            set { isCorrect = value; }
        }
        public bool _IsWrong
        {
            get { return isWrong; }
            set { isWrong = value; }
        }
        public bool _IsCollected
        {
            get { return isCollected; }
            set { isCollected = value; }
        }


        void Start()
        {
            rend = GetComponent<SpriteRenderer>();
            tileNumber = 0;

        }

        public void TriggerVFX()
        {
            GameObject sparkles = Instantiate(vfx, transform.position, transform.rotation);
            rend.sprite = null;
            Destroy(sparkles, 1f);
            isCollected = true;

        }
    }
}



