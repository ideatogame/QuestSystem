using System.Collections;
using UnityEngine;

namespace Miscellaneous
{
    [RequireComponent(typeof(MeshRenderer))]
    public class DamageEffect : MonoBehaviour
    {
        [SerializeField] private Material damageMaterial;
        [SerializeField] private float animationSpeed = 0.5f;

        private Material defaultMaterial;
        private MeshRenderer meshRenderer;
        private Coroutine damageCoroutine;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            defaultMaterial = meshRenderer.material;
        }

        public void PlayDamageAnimation()
        {
            if (damageCoroutine != null)
                StopCoroutine(damageCoroutine);
            
            damageCoroutine = StartCoroutine(DamageAnimation());
        }

        private IEnumerator DamageAnimation()
        {
            meshRenderer.material = damageMaterial;
            yield return new WaitForSeconds(animationSpeed);
            meshRenderer.material = defaultMaterial;
        }
    }
}
