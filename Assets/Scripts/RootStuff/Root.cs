using BeatStuff;
using PlayerImplementations;
using Pooling;
using UnityEngine;

namespace RootStuff
{
    public class Root : MonoBehaviour, IPoolable<Root>
    {
        private MoveToTheBeat m_MoveToTheBeat;

        private void Awake()
        {
            m_MoveToTheBeat = GetComponent<MoveToTheBeat>();
        }

        public Root Return(Transform parent = null)
        {
            m_MoveToTheBeat.ResetData();
            gameObject.SetActive(false);
            return this;
        }

        public Root Get()
        {
            return this;
        }

        public void Init()
        {
            m_MoveToTheBeat.Initialize();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.TryGetComponent(out PlayerBehaviour playerBehaviour))
            {
                RootManager.RootPool.ReleasePoolable(this);
                
                playerBehaviour.GetDamage(15f);
            }
        }
    }
}