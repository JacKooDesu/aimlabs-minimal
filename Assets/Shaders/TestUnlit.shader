Shader "Unlit/TestUnlit"
{
    Properties
    {
        _BaseMap ("Base Texture", 2D) = "white" {}
        _BaseColor ("Base Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags 
        {
            "RenderPipline" = "UniversalPipeline"
            "Queue"="Geometry"
            "RenderType"="Opaque" 
        }
        HLSLINCLUDE
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

        CBUFFER_START(UnityPerMaterial)
        float4 _BaseMap_ST;
        half4 _BaseColor;
        CBUFFER_END
        ENDHLSL

        Pass
        {
            Tags { "LightMode" = "UniversalForward" }
            CULL OFF

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD;
            };

            struct Varings
            {
                float4 postionCS : SV_POSITION;
                float2 uv : TEXCOORD;
            };

            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);

            Varings vert (Attributes i)
            {
                Varings o;
                VertexPositionInputs positionInputs = GetVertexPositionInputs(i.positionOS); 
                o.postionCS = positionInputs.positionCS;

                o.uv = TRANSFORM_TEX(i.uv, _BaseMap);
                return o;
            }

            float4 frag (Varings i) : SV_Target
            {
                half4 baseMap = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, i.uv);
                return baseMap * _BaseColor;
            }
            
            ENDHLSL
        }
    }
}
