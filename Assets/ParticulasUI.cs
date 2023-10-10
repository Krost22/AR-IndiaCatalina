using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ParticulasUI : MonoBehaviour
{
    RectTransform rect;
    float rectAltura;
    float rectBase;

    public GameObject prefab;

    public Sprite[] sprites;

    [Range(0.0f, 1.5f)]
    public float minSize;

    [Range(0.0f, 1.5f)]
    public float maxSize;

    public float marginX;

    public float marginY;

    [Range(0,100)]
    public int cantidadParticulas;
    private void Awake()
    {
        rect = this.GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {

        spawnearParticulas(sprites, prefab, rect, minSize, maxSize, marginX, marginY, cantidadParticulas);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnearParticulas(Sprite[] sprites,GameObject prefab, RectTransform rect, float minSize
        , float maxSize, float marginX, float marginY, int cantPart)
    {
        for (int i = 0; i < cantPart; i++)
        {
            float x = Random.Range(-363.99f + marginX, 363.99f - marginX);
            float y = Random.Range(-490f + marginY, 490f - marginY);
            Vector2 posicionRandom = new Vector2(x, y);

            GameObject particula = Instantiate(prefab, this.transform);

            RectTransform transformPart = particula.GetComponent<RectTransform>();

            transformPart.localPosition = posicionRandom;

            float randomScale = Random.Range(minSize, maxSize);

            transformPart.localScale = new Vector2(randomScale, randomScale);


            Image image = particula.GetComponent<Image>();

            image.sprite = sprites[Random.Range(0, sprites.Length-1)];


        }
    }
}
