Shader "URP/14_OpaqueTexture_01"
{
    Properties
    {
        _NormalTex("_NormalTex",2D) = "bump" {}
        _NormalScale("_NormalScale",range(0,0.05)) = 0.01
    }
    HLSLINCLUDE
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

        CBUFFER_START(UnityPerMaterial)
            float4 _NormalTex_ST;
            float _NormalScale;
        CBUFFER_END


        struct appdata
        {
            float4 positionOS : POSITION;
            float2 texcoord : TEXCOORD0;
            float4 vertexColor : COLOR;
        };

        struct v2f
        {
            float2 uv : TEXCOORD0;
            float4 positionOS : SV_POSITION;
            float4 vertexColor : COLOR;
        };

        TEXTURE2D (_NormalTex);
        SAMPLER(sampler_NormalTex);

        SAMPLER(_AfterPostProcessTexture);                   //定义贴图

    ENDHLSL

    SubShader
    {
        Tags { "RenderPipeline"="UniversalPipeline" "RenderType"="Transparent"  "Queue" = "Transparent" "IgnoreProjector" = " True"}
        LOD 100

        Pass
        {
            Tags{ "LightMode"= "Grab" }
            Blend SrcAlpha OneMinusSrcAlpha

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            v2f vert (appdata v)
            {
                v2f o;
                o.positionOS = TransformObjectToHClip(v.positionOS.xyz);
                o.uv = TRANSFORM_TEX(v.texcoord, _NormalTex);
                o.vertexColor = v.vertexColor;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                half3 normal = UnpackNormalScale(SAMPLE_TEXTURE2D(_NormalTex,sampler_NormalTex,i.uv),_NormalScale);

                half2 screenUV = (i.positionOS.xy / _ScreenParams.xy) + half2(normal.rg  * i.vertexColor.a);
                half4 col = tex2D(_AfterPostProcessTexture, screenUV);
                return col;
            }
            ENDHLSL
        }
    }
}