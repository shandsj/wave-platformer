using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteFlashEffect : MonoBehaviour
{
    /// <summary>
    /// The material used to flash the sprite.
    /// </summary>
    public Material FlashMaterial;

    /// <summary>
    /// The amount of time a flash will last.
    /// </summary>
    public float LengthOfFlash = .05f;

    /// <summary>
    /// The number of times the flash will happen.
    /// </summary>
    public int Repeat = 3;

    private SpriteRenderer spriteRenderer;
    private Material defaultSpriteMaterial;
    private float startFlashTime;
    private bool needsFlash;

    /// <summary>
    /// Flashes the sprite.
    /// </summary>
    public void Flash()
    {
        this.needsFlash = true;
    }

    // Start is called before the first frame update
    private void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.defaultSpriteMaterial = this.spriteRenderer.material;
    }

    // Update is called once per frame
    private void Update()
    {
        if (this.needsFlash)
        {            
            this.needsFlash = false;
            StartCoroutine(FlashCoroutine());
        }
    }

    private IEnumerator FlashCoroutine()
    {
        for (int i = 0; i < this.Repeat; ++i)
        {
            this.spriteRenderer.material = this.FlashMaterial;
            yield return new WaitForSeconds(this.LengthOfFlash);
            this.spriteRenderer.material = this.defaultSpriteMaterial;
            yield return new WaitForSeconds(this.LengthOfFlash);
        }
    }
}
