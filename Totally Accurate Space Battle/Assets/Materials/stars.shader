Shader "Converted/Template"
{
    Properties
    {
        _MainTex ("iChannel0", 2D) = "white" {}
        _SecondTex ("iChannel1", 2D) = "white" {}
        _ThirdTex ("iChannel2", 2D) = "white" {}
        _FourthTex ("iChannel3", 2D) = "white" {}
        _Mouse ("Mouse", Vector) = (0.5, 0.5, 0.5, 0.5)
        [ToggleUI] _GammaCorrect ("Gamma Correction", Float) = 1
        _Resolution ("Resolution (Change if AA is bad)", Float) = 1
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            // Built-in properties
            sampler2D _MainTex;   float4 _MainTex_TexelSize;
            sampler2D _SecondTex; float4 _SecondTex_TexelSize;
            sampler2D _ThirdTex;  float4 _ThirdTex_TexelSize;
            sampler2D _FourthTex; float4 _FourthTex_TexelSize;
            float4 _Mouse;
            float _GammaCorrect;
            float _Resolution;

            // GLSL Compatability macros
            #define glsl_mod(x,y) (((x)-(y)*floor((x)/(y))))
            #define texelFetch(ch, uv, lod) tex2Dlod(ch, float4((uv).xy * ch##_TexelSize.xy + ch##_TexelSize.xy * 0.5, 0, lod))
            #define textureLod(ch, uv, lod) tex2Dlod(ch, float4(uv, 0, lod))
            #define iResolution float3(_Resolution, _Resolution, _Resolution)
            #define iFrame (floor(_Time.y / 60))
            #define iChannelTime float4(_Time.y, _Time.y, _Time.y, _Time.y)
            #define iDate float4(2020, 6, 18, 30)
            #define iSampleRate (44100)
            #define iChannelResolution float4x4(                      \
                _MainTex_TexelSize.z,   _MainTex_TexelSize.w,   0, 0, \
                _SecondTex_TexelSize.z, _SecondTex_TexelSize.w, 0, 0, \
                _ThirdTex_TexelSize.z,  _ThirdTex_TexelSize.w,  0, 0, \
                _FourthTex_TexelSize.z, _FourthTex_TexelSize.w, 0, 0)

            // Global access to uv data
            static v2f vertex_output;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv =  v.uv;
                return o;
            }

            float Noise2d(in float2 x)
            {
                float xhash = cos(x.x*37.);
                float yhash = cos(x.y*57.);
                return frac(415.92654*(xhash+yhash));
            }

            float NoisyStarField(in float2 vSamplePos, float fThreshhold)
            {
                float StarVal = Noise2d(vSamplePos);
                if (StarVal>=fThreshhold)
                StarVal = pow((StarVal-fThreshhold)/(1.-fThreshhold), 6.);
                else StarVal = 0.;
                return StarVal;
            }

            float StableStarField(in float2 vSamplePos, float fThreshhold)
            {
                float fractX = frac(vSamplePos.x);
                float fractY = frac(vSamplePos.y);
                float2 floorSample = floor(vSamplePos);
                float v1 = NoisyStarField(floorSample, fThreshhold);
                float v2 = NoisyStarField(floorSample+float2(0., 1.), fThreshhold);
                float v3 = NoisyStarField(floorSample+float2(1., 0.), fThreshhold);
                float v4 = NoisyStarField(floorSample+float2(1., 1.), fThreshhold);
                float StarVal = v1*(1.-fractX)*(1.-fractY)+v2*(1.-fractX)*fractY+v3*fractX*(1.-fractY)+v4*fractX*fractY;
                return StarVal;
            }

            float4 frag (v2f __vertex_output) : SV_Target
            {
                vertex_output = __vertex_output;
                float4 fragColor = 0;
                float2 fragCoord = vertex_output.uv * _Resolution;
                float3 vColor = float3(0.0,0.0,0.0);//float3(0.1, 0.2, 0.4)*fragCoord.y/iResolution.y;
                float StarFieldThreshhold = 0.995;
                float xRate = 0.2;
                float yRate = -0.06;
                float2 vSamplePos = fragCoord.xy;
                float StarVal = StableStarField(vSamplePos, StarFieldThreshhold);
                vColor += ((float3)StarVal);
                fragColor = float4(vColor, 1.);
                //if (_GammaCorrect) fragColor.rgb = pow(fragColor.rgb, 2.2);
                return fragColor;
            }
            ENDCG
        }
    }
}
