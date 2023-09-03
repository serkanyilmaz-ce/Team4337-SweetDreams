using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Player
{
    public class SwordManager : MonoBehaviour
    {
        public GameObject swordPrefab;
        [SerializeField] private float swordCount;
        private void Start()
        {
            SwordBuild();
        }
        void SwordBuild()
        {
            float angleRad = 360f / swordCount; 

            for (int i = 0; i < swordCount; i++)
            {
                GameObject sword = Instantiate(swordPrefab, Vector3.zero, Quaternion.identity);
                float angle = (i + 1) * angleRad * Mathf.Deg2Rad;
                Vector3 Pos = transform.position; /*+ new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle));*/
                sword.transform.position = Pos + new Vector3(0,0,0.2f);
                sword.transform.RotateAround(transform.localPosition, Vector3.up, angle * Mathf.Rad2Deg);
                sword.transform.parent = transform;
            }
        }
        private void Update()
        {
            transform.Rotate(Vector3.up, 100f* Time.deltaTime,Space.Self);
        }
    }
}