using UnityEngine;
using System.Collections;

public class EnemyWrapper : MonoBehaviour {

    public enum EnemyType
    {
        Basic,
        Flying,
        Tank,
        Fast
    }

        public GameObject enemy;
        public EnemyType type;
        public bool active;

        public void SetActive(bool isActive)
        {
            active = isActive;
            enemy.SetActive(isActive);
        
        }

   
    
}
