Shader "Converted/Star Nest"
{
    Properties
    {
        _MainTex ("iChannel0", 2D) = "white" {}
        _SecondTex ("iChannel1", 2D) = "white" {}
        _ThirdTex ("iChannel2", 2D) = "white" {}
        _FourthTex ("iChannel3", 2D) = "white" {}
        _Mouse ("Mouse", Vector) = (0.5, 0.5, 0.5, 0.5)
        [ToggleUI] _GammaCorrect ("Gamma Correction", Float) = 1
        _Resolution ("Resolution (Change if AA is bad)", Range(1, 1024)) = 1
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

#define iterations 17
#define formuparam 0.53
#define volsteps 20
#define stepsize 0.1
#define zoom 0.8
#define tile 0.85
#define speed 0.01
#define brightness 0.0015
#define darkmatter 0.3
#define distfading 0.73
#define saturation 0.85
            float4 frag (v2f __vertex_output) : SV_Target
            {
                vertex_output = __vertex_output;
                float4 fragColor = 0;
                float2 fragCoord = vertex_output.uv * _Resolution;
                float2 uv = fragCoord.xy/iResolution.xy-0.5;
                uv.y *= iResolution.y/iResolution.x;
                float3 dir = float3(uv*zoom, 1.);
                float time = _Time.y*speed+0.25;
                float a1 = 0.5+_Mouse.x/iResolution.x*2.;
                float a2 = 0.8+_Mouse.y/iResolution.y*2.;
                float2x2 rot1 = transpose(float2x2(cos(a1), sin(a1), -sin(a1), cos(a1)));
                float2x2 rot2 = transpose(float2x2(cos(a2), sin(a2), -sin(a2), cos(a2)));
                dir.xz = mul(dir.xz,rot1);
                dir.xy = mul(dir.xy,rot2);
                float3 from = float3(1., 0.5, 0.5);
                from += float3(time*2., time, -2.);
                from.xz = mul(from.xz,rot1);
                from.xy = mul(from.xy,rot2);
                float s = 0.1, fade = 1.;
                float3 v = ((float3)0.);
                for (int r = 0;r<volsteps; r++)
                {
                    float3 p = from+s*dir*0.5;
                    p = abs(((float3)tile)-glsl_mod(p, ((float3)tile*2.)));
                    float pa, a = pa = 0.;
                    for (int i = 0;i<iterations; i++)
                    {
                        p = abs(p)/dot(p, p)-formuparam;
                        a += abs(length(p)-pa);
                        pa = length(p);
                    }
                    float dm = max(0., darkmatter-a*a*0.001);
                    a *= a*a;
                    if (r>6)
                        fade *= 1.-dm;

                    v += fade;
                    v += float3(s, s*s, s*s*s*s)*a*brightness*fade;
                    fade *= distfading;
                    s += stepsize;
                }
                v = lerp(((float3)length(v)), v, saturation);
                fragColor = float4(v*0.01, 1.);
                if (_GammaCorrect) fragColor.rgb = pow(fragColor.rgb, 2.2);
                return fragColor;
            }
            ENDCG
        }
    }
}
