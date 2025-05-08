Shader "Universal Render Pipeline/Custom/ShineEffect"
{
    Properties
    {
        _ShineColor("Shine Color", Color) = (1,1,1,1)
        _CycleInterval("Cycle Interval", Range(0.5, 5.0)) = 1.0
        _ShineSpeed("Shine Speed", Range(1.0, 5.0)) = 3.0
        _ShineWidth("Shine Width", Range(1.0, 100.0)) = 3.0
    }

    SubShader
    {
        Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Cull Off

        Pass
        {
            Name "ShinePass"
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float3 viewNormal : TEXCOORD0;
                float3 viewPos : TEXCOORD1;
            };

            float4 _ShineColor;
            float _CycleInterval;
            float _ShineSpeed;
            float _ShineWidth;

            Varyings vert(Attributes input)
            {
                Varyings output;
                float4 worldPos = mul(GetObjectToWorldMatrix(), input.positionOS);
                float4 viewPos = mul(UNITY_MATRIX_V, worldPos);
                output.viewPos = viewPos.xyz;

                float3 worldNormal = normalize(mul((float3x3)GetObjectToWorldMatrix(), input.normalOS));
                output.viewNormal = mul((float3x3)UNITY_MATRIX_V, worldNormal);

                output.positionHCS = TransformObjectToHClip(input.positionOS);
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                float width = _ShineWidth * 0.001 * _CycleInterval;
                float freq = floor(sin(input.viewPos.z * _CycleInterval + _Time.y * _ShineSpeed * _CycleInterval) + width);
                float viewDot = 1.0 - dot(normalize(input.viewNormal), float3(0, 0, 1));
                float alpha = clamp(viewDot * freq * _ShineColor.a, 0.0, 1.0);
                return float4(_ShineColor.rgb, alpha);
            }
            ENDHLSL
        }
    }
}
