using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{   
    private MeshRenderer meshRenderer;
    public Texture2D brush;

    [Space]
    [SerializeField]
    private Vector2Int textureArea = new Vector2Int(64, 64);
    
    public int brushSize = 8;

    Color32[] textureC32;
    Color32[] brushC32;
    Vector2Int halfBrush;

    int xPos, yPos, tPos;
    int redPixels;
    public float percentagePainting = 0;
    public bool isPaint = false;
    Texture2D texture;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        texture = new Texture2D(textureArea.x, textureArea.y, TextureFormat.ARGB32, false);
        
        meshRenderer.material.mainTexture = texture;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaint == true)
        {
            GetPaintPoint();
            CalculatePercentagePainting();
        }
        
    }

    void GetPaintPoint()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {

                Painting(hitInfo.textureCoord);
            }
        }
    }

    void Painting(Vector2 coordinate)
    {
        coordinate.x *= texture.width;//0-1 değerini tam nokta piksellere çevirdik
        coordinate.y *= texture.height;//Yani 0-64 yaptık
        textureC32 = texture.GetPixels32();
        brushC32 = brush.GetPixels32();
        
        //Fırçanın ortasının koordinatlarını ayarladık
        halfBrush = new Vector2Int(brushSize / 2, brushSize / 2);
       
        for (int x = 0; x < brushSize; x++)
        {
            xPos = x - halfBrush.x + (int)coordinate.x;
            

            if (xPos < 0 || xPos >= texture.width)
            {                
                continue;
            }   
            for (int y = 0; y < brushSize; y++)
            {
                yPos = y - halfBrush.y + (int)coordinate.y;
                
                if (yPos < 0 || yPos >= texture.height)
                {
                    continue;
                }
                    
                    tPos = xPos + (texture.width * yPos);
                    
                    if (brushC32[x + (y * brushSize)].r > textureC32[tPos].r)
                    {
                        textureC32[tPos] = brushC32[x + (y * brushSize)];
                        redPixels++;
                    }

            }
        }
        
        texture.SetPixels32(textureC32);
        texture.Apply();
        
        /*
        coordinate.x *= texture.width;
        coordinate.y *= texture.height;

        Vector2Int halfBrush = new Vector2Int(brush.width / 2, brush.height / 2);

        for(int x = 0; x < brush.width * brushSize; x++)
        {
            for(int y = 0; y < brush.height * brushSize; y++)
            {
                if (brush.GetPixel(x, y).a > 0f)
                {
                    textureColor = texture.GetPixel(
                        (int)coordinate.x + (halfBrush.x - x),
                        (int)coordinate.y + (halfBrush.y - y));

                    if (brush.GetPixel(x, y).r != textureColor.r)
                    {
                        texture.SetPixel(
                            (int)coordinate.x + (halfBrush.x - x),//x koordinatı
                            (int)coordinate.y + (halfBrush.y - y),//y koordinatı
                            Color.red);
                        //paintingPercentage.redNum++;
                        //Debug.Log(paintingPercentage.redNum);
                    }
                }
            }
        }
        texture.Apply();//Değişiklikleri uygula*/
    }

    void CalculatePercentagePainting()
    {
        percentagePainting = (int)(((float)redPixels / (textureArea.x * textureArea.y)) * 100);
    }
    
}
