using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    #region Singletone
    private static EffectManager instance = null;

    public static EffectManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@EffectManager");
            instance = go.AddComponent<EffectManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    Stack<ParticleSystem> effectPool = new Stack<ParticleSystem>();
    
     public void InitEffectPool(int size)
    {
        for(int i = 0; i <size; i++)
        {
            var effect = ObjectManager.GetInstance().CreateHitEffect();
            effect.gameObject.SetActive(false);
            effectPool.Push(effect);
        }
    }

    public void ReleasPool()
    {
        effectPool.Clear();
    }

    public void UseEffect()
    {
        ParticleSystem effect = null;

        if (effectPool.Count > 0)
        {
            effect = effectPool.Pop();
            effect.gameObject.SetActive(true);
        }
        else
        {
            effect = ObjectManager.GetInstance().CreateHitEffect();
        }

        effect.Play();

        float randX = Random.Range(-0.8f, 0.8f);
        float randY = Random.Range(-0.8f, 0.8f);

        effect.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        effect.transform.localPosition = new Vector3(1.1f + randX, 0.8f + randY, 0);

    }

    public void ReturnEffect(ParticleSystem particle)
    {
        particle.gameObject.SetActive(false);
        effectPool.Push(particle);
    }
}
