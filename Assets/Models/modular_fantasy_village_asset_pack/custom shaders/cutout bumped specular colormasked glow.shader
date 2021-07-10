// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "cutout bumped specular colormasked glow" {
Properties {
    _Color ("Red channel mask", Color) = (1,1,1,1)
	_Color2 ("Green Channel mask", Color) = (1,1,1,1)
	_Color3 ("Blue Channel mask", Color) = (1,1,1,1)
	_Color4 ("glow tint/intensity (A)", Color) = (1,1,1,1)
    _SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 0)
    _Shininess ("Shininess", Range (0.01, 1)) = 0.078125
    _MainTex ("Base (RGB) TransGloss (A)", 2D) = "white" {}
	_MaskTex ("Mask", 2D) = "white" {}
    _BumpMap ("Normalmap", 2D) = "bump" {}
    _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
	_Emission ("Emission (Lightmapper)", Float) = 1.0
}

SubShader {
    Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
    LOD 400

CGPROGRAM
#pragma surface surf BlinnPhong alphatest:_Cutoff
#pragma target 3.0

sampler2D _MainTex, _MaskTex;
sampler2D _BumpMap;
fixed4 _Color;
fixed4 _Color2;
fixed4 _Color3;
fixed4 _Color4;
half _Shininess;
sampler2D _Illum;
fixed _Emission;

struct Input {
    float2 uv_MainTex, uv_MaskTex;
    float2 uv_BumpMap;
	float2 uv_Illum;
};

void surf (Input IN, inout SurfaceOutput o) {
    fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
	fixed4 mask = tex2D(_MaskTex, IN.uv_MainTex);
	tex.rgb = lerp(tex.rgb, tex.rgb * _Color, mask.r);
	tex.rgb = lerp(tex.rgb, tex.rgb * _Color2, mask.g);
	tex.rgb = lerp(tex.rgb, tex.rgb * _Color3, mask.b);
	o.Emission = _Color4 * tex2D(_MaskTex, IN.uv_MaskTex).a;
#if defined (UNITY_PASS_META)
    o.Emission *= _Emission.rrr;
#endif
	
    o.Albedo = tex.rgb;
    o.Gloss = tex.a;
    o.Alpha = tex.a * _Color.a;
    o.Specular = _Shininess;
    o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
}
ENDCG
}

FallBack "Legacy Shaders/Transparent/Cutout/VertexLit"
}