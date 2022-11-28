using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class RawImageWaterWave : MonoBehaviour
{
    //��ʼ���˸߶�(ƫ��)
    [SerializeField, Range(0, 1)] float heightPercent = 0.5f;
    //���˸߶�(ֵԽ�ӽ���0,����Խ��)(���)
    [SerializeField] float waveHeightParame = 0.1f;
    //���˿��(ֵԽ�ӽ���0,����Խ��)(���ٶ�)
    [SerializeField] float waveWidthParame = 7;
    //�����ٶ�(����)
    [SerializeField] float speed = 1;
    //Ĭ����ɫ
    [SerializeField] Color32 defaultColor;

    //RawImage���
    RawImage waveImage;
    //����ʾͼƬ
    Texture2D showTexture;
    //���ص�
    Color32[] pixelsBaseArr;
    Color32[] pixelsDrawArr;

    void Start()
    {
        //��ȡ���
        waveImage = GetComponent<RawImage>();
        //������ͼ
        showTexture = waveImage.texture as Texture2D;
        showTexture = Instantiate(showTexture);
        waveImage.texture = showTexture;
        //��ʼ���ص�
        pixelsBaseArr = showTexture.GetPixels32();
        //�仯���ص�
        pixelsDrawArr = new Color32[pixelsBaseArr.Length];
    }

    void Update()
    {
        Wave();
    }

    public void Wave()
    {
        //������ʼ���ص�
        System.Array.Copy(pixelsBaseArr, pixelsDrawArr, pixelsBaseArr.Length);
        //��������Texture���ص�
        for (int x = 0; x < showTexture.width; x++)
        {
            //ƫ��ϵ��
            float tmpOffectParame = waveHeightParame * Mathf.Sin(waveWidthParame * x / showTexture.width + Time.time * speed);
            //���Ƽ�ֵ
            float tmpHeightParame = Mathf.Clamp(heightPercent + tmpOffectParame, 0, 1);
            //����߶�
            int tmpHeight = (int)(tmpHeightParame * showTexture.height);
            //�߶ȴ���ָ���߶ȵ����ص�,��ʾĬ��ɫֵ
            for (int y = tmpHeight; y < showTexture.height; y++)
            {
                //��showTexture��width��heightת��ΪpixelsDrawArr���ص�������±�
                pixelsDrawArr[y * showTexture.width + x] = defaultColor;
            }
        }
        //Texture��ֵ
        showTexture.SetPixels32(pixelsDrawArr);
        showTexture.Apply();
    }

}