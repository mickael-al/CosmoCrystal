// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:0,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:True,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.4878893,fgcg:0.6066579,fgcb:0.7058823,fgca:1,fgde:0.005,fgrn:20,fgrf:200,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:33282,y:32714,varname:node_4013,prsc:2|diff-375-OUT,spec-5363-RGB,normal-9168-RGB,clip-9095-OUT,voffset-4720-OUT;n:type:ShaderForge.SFN_Tex2d,id:911,x:32069,y:32392,ptovrint:False,ptlb:albedo,ptin:_albedo,varname:node_911,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:20b0078a151b8be4ab064ef4a4ece85f,ntxv:3,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5363,x:32404,y:32627,ptovrint:False,ptlb:specular,ptin:_specular,varname:node_5363,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2132a3970d8157d4c8f31b3941e6fccd,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9168,x:32404,y:32440,ptovrint:False,ptlb:normal,ptin:_normal,varname:node_9168,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d7a2592b5a55d0e48a9de0fae24bb2e9,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Color,id:566,x:32161,y:32152,ptovrint:False,ptlb:color,ptin:_color,varname:node_566,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:9095,x:32920,y:32307,varname:node_9095,prsc:2|A-1728-OUT,B-5637-OUT;n:type:ShaderForge.SFN_Normalize,id:7747,x:32393,y:33335,varname:node_7747,prsc:2|IN-2438-OUT;n:type:ShaderForge.SFN_NormalVector,id:4433,x:31677,y:33294,prsc:2,pt:True;n:type:ShaderForge.SFN_Vector4Property,id:9917,x:31929,y:33309,ptovrint:False,ptlb:wind direction,ptin:_winddirection,varname:node_9917,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1,v2:0.5,v3:0.5,v4:0;n:type:ShaderForge.SFN_Add,id:2438,x:32186,y:33313,varname:node_2438,prsc:2|A-9917-XYZ,B-4433-OUT;n:type:ShaderForge.SFN_Multiply,id:6631,x:32676,y:33136,varname:node_6631,prsc:2|A-7747-OUT,B-1382-R,C-9132-OUT,D-806-OUT;n:type:ShaderForge.SFN_VertexColor,id:7127,x:32135,y:32965,varname:node_7127,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:806,x:32393,y:33222,ptovrint:False,ptlb:wind amplitude,ptin:_windamplitude,varname:node_806,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.03;n:type:ShaderForge.SFN_VertexColor,id:1382,x:30823,y:33531,varname:node_1382,prsc:2;n:type:ShaderForge.SFN_Pi,id:611,x:30839,y:33670,varname:node_611,prsc:2;n:type:ShaderForge.SFN_Time,id:1990,x:30823,y:33777,varname:node_1990,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:4767,x:30823,y:33954,ptovrint:False,ptlb:wind power,ptin:_windpower,varname:node_4767,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.5;n:type:ShaderForge.SFN_Multiply,id:7380,x:31081,y:33777,varname:node_7380,prsc:2|A-1990-T,B-4767-OUT;n:type:ShaderForge.SFN_Multiply,id:8799,x:31081,y:33625,varname:node_8799,prsc:2|A-1382-R,B-611-OUT;n:type:ShaderForge.SFN_Add,id:9581,x:31320,y:33667,varname:node_9581,prsc:2|A-8799-OUT,B-7380-OUT;n:type:ShaderForge.SFN_Vector1,id:2982,x:31320,y:33811,varname:node_2982,prsc:2,v1:3;n:type:ShaderForge.SFN_Multiply,id:6182,x:31545,y:33746,varname:node_6182,prsc:2|A-9581-OUT,B-2982-OUT;n:type:ShaderForge.SFN_Sin,id:259,x:31719,y:33721,varname:node_259,prsc:2|IN-6182-OUT;n:type:ShaderForge.SFN_Multiply,id:3296,x:31910,y:33830,varname:node_3296,prsc:2|A-259-OUT,B-916-OUT;n:type:ShaderForge.SFN_Vector1,id:916,x:31713,y:33895,varname:node_916,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Add,id:6674,x:32134,y:33738,varname:node_6674,prsc:2|A-1865-OUT,B-3296-OUT;n:type:ShaderForge.SFN_Sin,id:1865,x:31910,y:33636,varname:node_1865,prsc:2|IN-9581-OUT;n:type:ShaderForge.SFN_Subtract,id:9132,x:32350,y:33691,varname:node_9132,prsc:2|A-6674-OUT,B-8980-OUT;n:type:ShaderForge.SFN_Cos,id:8980,x:32134,y:33935,varname:node_8980,prsc:2|IN-8810-OUT;n:type:ShaderForge.SFN_Multiply,id:8810,x:31934,y:34037,varname:node_8810,prsc:2|A-9581-OUT,B-6346-OUT;n:type:ShaderForge.SFN_Vector1,id:6346,x:31723,y:34071,varname:node_6346,prsc:2,v1:5;n:type:ShaderForge.SFN_Add,id:4720,x:32922,y:33063,varname:node_4720,prsc:2|A-7068-OUT,B-6631-OUT;n:type:ShaderForge.SFN_Time,id:7132,x:31128,y:32883,varname:node_7132,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:1894,x:31128,y:33068,ptovrint:False,ptlb:base wind power,ptin:_basewindpower,varname:_windpower_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:5453,x:31375,y:32941,varname:node_5453,prsc:2|A-7132-T,B-1894-OUT;n:type:ShaderForge.SFN_Sin,id:928,x:31700,y:32790,varname:node_928,prsc:2|IN-5453-OUT;n:type:ShaderForge.SFN_Cos,id:2595,x:31617,y:33075,varname:node_2595,prsc:2|IN-5453-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7116,x:31594,y:32975,ptovrint:False,ptlb:base wind amplitude,ptin:_basewindamplitude,varname:_basewindpower_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:8393,x:31617,y:33198,varname:node_8393,prsc:2,v1:0.15;n:type:ShaderForge.SFN_Multiply,id:5070,x:32121,y:32801,varname:node_5070,prsc:2|A-928-OUT,B-7116-OUT;n:type:ShaderForge.SFN_Multiply,id:7915,x:31844,y:33095,varname:node_7915,prsc:2|A-7116-OUT,B-8393-OUT;n:type:ShaderForge.SFN_Multiply,id:9552,x:32135,y:33114,varname:node_9552,prsc:2|A-2595-OUT,B-7915-OUT;n:type:ShaderForge.SFN_Multiply,id:2320,x:32393,y:33046,varname:node_2320,prsc:2|A-9552-OUT,B-7127-R;n:type:ShaderForge.SFN_Multiply,id:1897,x:32404,y:32831,varname:node_1897,prsc:2|A-5070-OUT,B-7127-R;n:type:ShaderForge.SFN_Vector1,id:4427,x:32404,y:32963,varname:node_4427,prsc:2,v1:0;n:type:ShaderForge.SFN_Append,id:7068,x:32609,y:32929,varname:node_7068,prsc:2|A-1897-OUT,B-4427-OUT,C-2320-OUT;n:type:ShaderForge.SFN_Add,id:1728,x:32920,y:32160,varname:node_1728,prsc:2|A-911-A,B-5637-OUT;n:type:ShaderForge.SFN_Slider,id:5637,x:32443,y:32056,ptovrint:False,ptlb:Cutoff,ptin:_Cutoff,varname:node_5637,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Multiply,id:375,x:32429,y:32235,varname:node_375,prsc:2|A-566-RGB,B-911-RGB;proporder:911-5363-9168-566-9917-806-4767-1894-7116-5637;pass:END;sub:END;*/

Shader "Shader Forge/animated_grass_shader2" {
    Properties {
        _albedo ("albedo", 2D) = "bump" {}
        _specular ("specular", 2D) = "white" {}
        _normal ("normal", 2D) = "bump" {}
        _color ("color", Color) = (1,1,1,1)
        _winddirection ("wind direction", Vector) = (1,0.5,0.5,0)
        _windamplitude ("wind amplitude", Float ) = 0.03
        _windpower ("wind power", Float ) = 1.5
        _basewindpower ("base wind power", Float ) = 0.5
        _basewindamplitude ("base wind amplitude", Float ) = 0.5
        _Cutoff ("Cutoff", Range(0, 1)) = 0.5
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _albedo; uniform float4 _albedo_ST;
            uniform sampler2D _specular; uniform float4 _specular_ST;
            uniform sampler2D _normal; uniform float4 _normal_ST;
            uniform float4 _color;
            uniform float4 _winddirection;
            uniform float _windamplitude;
            uniform float _windpower;
            uniform float _basewindpower;
            uniform float _basewindamplitude;
            uniform float _Cutoff;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_7132 = _Time;
                float node_5453 = (node_7132.g*_basewindpower);
                float4 node_1990 = _Time;
                float node_9581 = ((o.vertexColor.r*3.141592654)+(node_1990.g*_windpower));
                v.vertex.xyz += (float3(((sin(node_5453)*_basewindamplitude)*o.vertexColor.r),0.0,((cos(node_5453)*(_basewindamplitude*0.15))*o.vertexColor.r))+(normalize((_winddirection.rgb+v.normal))*o.vertexColor.r*((sin(node_9581)+(sin((node_9581*3.0))*0.2))-cos((node_9581*5.0)))*_windamplitude));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _normal_var = UnpackNormal(tex2D(_normal,TRANSFORM_TEX(i.uv0, _normal)));
                float3 normalLocal = _normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 _albedo_var = tex2D(_albedo,TRANSFORM_TEX(i.uv0, _albedo));
                clip(((_albedo_var.a+_Cutoff)*_Cutoff) - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation,i, i.posWorld.xyz);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = 0.5;
                float perceptualRoughness = 1.0 - 0.5;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float4 _specular_var = tex2D(_specular,TRANSFORM_TEX(i.uv0, _specular));
                float3 specularColor = _specular_var.rgb;
                float specularMonochrome;
                float3 diffuseColor = (_color.rgb*_albedo_var.rgb); // Need this for specular when using metallic
                diffuseColor = EnergyConservationBetweenDiffuseAndSpecular(diffuseColor, specularColor, specularMonochrome);
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                diffuseColor *= 1-specularMonochrome;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _albedo; uniform float4 _albedo_ST;
            uniform sampler2D _specular; uniform float4 _specular_ST;
            uniform sampler2D _normal; uniform float4 _normal_ST;
            uniform float4 _color;
            uniform float4 _winddirection;
            uniform float _windamplitude;
            uniform float _windpower;
            uniform float _basewindpower;
            uniform float _basewindamplitude;
            uniform float _Cutoff;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_7132 = _Time;
                float node_5453 = (node_7132.g*_basewindpower);
                float4 node_1990 = _Time;
                float node_9581 = ((o.vertexColor.r*3.141592654)+(node_1990.g*_windpower));
                v.vertex.xyz += (float3(((sin(node_5453)*_basewindamplitude)*o.vertexColor.r),0.0,((cos(node_5453)*(_basewindamplitude*0.15))*o.vertexColor.r))+(normalize((_winddirection.rgb+v.normal))*o.vertexColor.r*((sin(node_9581)+(sin((node_9581*3.0))*0.2))-cos((node_9581*5.0)))*_windamplitude));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _normal_var = UnpackNormal(tex2D(_normal,TRANSFORM_TEX(i.uv0, _normal)));
                float3 normalLocal = _normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _albedo_var = tex2D(_albedo,TRANSFORM_TEX(i.uv0, _albedo));
                clip(((_albedo_var.a+_Cutoff)*_Cutoff) - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation,i, i.posWorld.xyz);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = 0.5;
                float perceptualRoughness = 1.0 - 0.5;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float4 _specular_var = tex2D(_specular,TRANSFORM_TEX(i.uv0, _specular));
                float3 specularColor = _specular_var.rgb;
                float specularMonochrome;
                float3 diffuseColor = (_color.rgb*_albedo_var.rgb); // Need this for specular when using metallic
                diffuseColor = EnergyConservationBetweenDiffuseAndSpecular(diffuseColor, specularColor, specularMonochrome);
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                diffuseColor *= 1-specularMonochrome;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _albedo; uniform float4 _albedo_ST;
            uniform float4 _winddirection;
            uniform float _windamplitude;
            uniform float _windpower;
            uniform float _basewindpower;
            uniform float _basewindamplitude;
            uniform float _Cutoff;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float2 uv1 : TEXCOORD2;
                float2 uv2 : TEXCOORD3;
                float4 posWorld : TEXCOORD4;
                float3 normalDir : TEXCOORD5;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_7132 = _Time;
                float node_5453 = (node_7132.g*_basewindpower);
                float4 node_1990 = _Time;
                float node_9581 = ((o.vertexColor.r*3.141592654)+(node_1990.g*_windpower));
                v.vertex.xyz += (float3(((sin(node_5453)*_basewindamplitude)*o.vertexColor.r),0.0,((cos(node_5453)*(_basewindamplitude*0.15))*o.vertexColor.r))+(normalize((_winddirection.rgb+v.normal))*o.vertexColor.r*((sin(node_9581)+(sin((node_9581*3.0))*0.2))-cos((node_9581*5.0)))*_windamplitude));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _albedo_var = tex2D(_albedo,TRANSFORM_TEX(i.uv0, _albedo));
                clip(((_albedo_var.a+_Cutoff)*_Cutoff) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _albedo; uniform float4 _albedo_ST;
            uniform sampler2D _specular; uniform float4 _specular_ST;
            uniform float4 _color;
            uniform float4 _winddirection;
            uniform float _windamplitude;
            uniform float _windpower;
            uniform float _basewindpower;
            uniform float _basewindamplitude;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_7132 = _Time;
                float node_5453 = (node_7132.g*_basewindpower);
                float4 node_1990 = _Time;
                float node_9581 = ((o.vertexColor.r*3.141592654)+(node_1990.g*_windpower));
                v.vertex.xyz += (float3(((sin(node_5453)*_basewindamplitude)*o.vertexColor.r),0.0,((cos(node_5453)*(_basewindamplitude*0.15))*o.vertexColor.r))+(normalize((_winddirection.rgb+v.normal))*o.vertexColor.r*((sin(node_9581)+(sin((node_9581*3.0))*0.2))-cos((node_9581*5.0)))*_windamplitude));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float4 _albedo_var = tex2D(_albedo,TRANSFORM_TEX(i.uv0, _albedo));
                float3 diffColor = (_color.rgb*_albedo_var.rgb);
                float4 _specular_var = tex2D(_specular,TRANSFORM_TEX(i.uv0, _specular));
                float3 specColor = _specular_var.rgb;
                float specularMonochrome = max(max(specColor.r, specColor.g),specColor.b);
                diffColor *= (1.0-specularMonochrome);
                o.Albedo = diffColor + specColor * 0.125; // No gloss connected. Assume it's 0.5
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
