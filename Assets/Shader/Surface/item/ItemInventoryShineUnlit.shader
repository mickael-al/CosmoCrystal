Shader "Sprite Lit Master Shine"
{
    Properties
    {
        [NoScaleOffset]_MainTex("Texture", 2D) = "white" {}
        _Shine("Shine", Float) = 1
        [HDR]_OutlineColor("ColorShine", Color) = (1, 1, 1, 1)
        _StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _ColorMask ("Color Mask", Float) = 15
        [NonModifiableTextureData][NoScaleOffset]_Shine_8B5AAE53_Texture2D501E3F16_762259893("Texture2D", 2D) = "white" {}

    }
    SubShader
    {
        Tags
        {
            "RenderPipeline"="UniversalPipeline"
            "RenderType"="Transparent"
            "Queue"="Transparent+0"
        }
        
        Pass
        {
            Name "Sprite Lit"
            Tags 
            { 
                "LightMode" = "Universal2D"
            }
           
            // Render State
            Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
            Cull Off
            ZTest [unity_GUIZTestMode]
            ZWrite Off
            // ColorMask: <None>
            Stencil
            {
                Ref [_Stencil]
                Comp [_StencilComp]
                Pass [_StencilOp]
                ReadMask [_StencilReadMask]
                WriteMask [_StencilWriteMask]
            }
            ColorMask [_ColorMask]
        
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
        
            // Debug
            // <None>
        
            // --------------------------------------------------
            // Pass
        
            // Pragmas
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x
            #pragma target 2.0
        
            // Keywords
            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
            #pragma multi_compile _ USE_SHAPE_LIGHT_TYPE_0
            #pragma multi_compile _ USE_SHAPE_LIGHT_TYPE_1
            #pragma multi_compile _ USE_SHAPE_LIGHT_TYPE_2
            #pragma multi_compile _ USE_SHAPE_LIGHT_TYPE_3
            #pragma shader_feature_local _ _USEUIALPHACLIP
            
            #if defined(_USEUIALPHACLIP)
                #define KEYWORD_PERMUTATION_0
            #else
                #define KEYWORD_PERMUTATION_1
            #endif
            
            
            // Defines
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define _SURFACE_TYPE_TRANSPARENT 1
        #endif
        
        
        
        
        
        
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define ATTRIBUTES_NEED_NORMAL
        #endif
        
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define ATTRIBUTES_NEED_TANGENT
        #endif
        
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define ATTRIBUTES_NEED_TEXCOORD0
        #endif
        
        
        
        
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define ATTRIBUTES_NEED_COLOR
        #endif
        
        
        
        
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define VARYINGS_NEED_TEXCOORD0
        #endif
        
        
        
        
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define VARYINGS_NEED_COLOR
        #endif
        
        
        
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define VARYINGS_NEED_SCREENPOSITION
        #endif
        
        
        
            #pragma multi_compile_instancing
            #define SHADERPASS_SPRITELIT
            
        
            // Includes
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/Shaders/2D/Include/LightingUtility.hlsl"
        
            // --------------------------------------------------
            // Graph
        
            // Graph Properties
            CBUFFER_START(UnityPerMaterial)
            float _Shine;
            float4 _OutlineColor;
            float _Stencil;
            float _StencilOp;
            float _StencilComp;
            float _StencilReadMask;
            float _StencilWriteMask;
            float _ColorMask;
            CBUFFER_END
            TEXTURE2D(_MainTex); SAMPLER(sampler_MainTex); float4 _MainTex_TexelSize;
            TEXTURE2D(_Shine_8B5AAE53_Texture2D501E3F16_762259893); SAMPLER(sampler_Shine_8B5AAE53_Texture2D501E3F16_762259893); float4 _Shine_8B5AAE53_Texture2D501E3F16_762259893_TexelSize;
            SAMPLER(_SampleTexture2D_5AE23317_Sampler_3_Linear_Repeat);
            SAMPLER(_SampleTexture2D_1BCBBEB9_Sampler_3_Linear_Repeat);
        
            // Graph Functions
            
            void Unity_Rotate_Degrees_float(float2 UV, float2 Center, float Rotation, out float2 Out)
            {
                //rotation matrix
                Rotation = Rotation * (3.1415926f/180.0f);
                UV -= Center;
                float s = sin(Rotation);
                float c = cos(Rotation);
            
                //center rotation matrix
                float2x2 rMatrix = float2x2(c, -s, s, c);
                rMatrix *= 0.5;
                rMatrix += 0.5;
                rMatrix = rMatrix*2 - 1;
            
                //multiply the UVs by the rotation matrix
                UV.xy = mul(UV.xy, rMatrix);
                UV += Center;
            
                Out = UV;
            }
            
            void Unity_Multiply_float(float2 A, float2 B, out float2 Out)
            {
                Out = A * B;
            }
            
            void Unity_TilingAndOffset_float(float2 UV, float2 Tiling, float2 Offset, out float2 Out)
            {
                Out = UV * Tiling + Offset;
            }
            
            void Unity_Multiply_float(float4 A, float4 B, out float4 Out)
            {
                Out = A * B;
            }
            
            struct Bindings_Shine_f126d40ee23ac4349a37b9f5be3a22ed
            {
                half4 uv0;
                float3 TimeParameters;
            };
            
            void SG_Shine_f126d40ee23ac4349a37b9f5be3a22ed(float2 Vector2_19BD6250, TEXTURE2D_PARAM(Texture2D_501E3F16, samplerTexture2D_501E3F16), float4 Texture2D_501E3F16_TexelSize, Bindings_Shine_f126d40ee23ac4349a37b9f5be3a22ed IN, out float4 OutVector4_1)
            {
                float2 _Rotate_3D5C03C8_Out_3;
                Unity_Rotate_Degrees_float(IN.uv0.xy, float2 (0.5, 0.5), 15, _Rotate_3D5C03C8_Out_3);
                float2 _Property_83E371EB_Out_0 = Vector2_19BD6250;
                float2 _Multiply_73A249D1_Out_2;
                Unity_Multiply_float(_Property_83E371EB_Out_0, (IN.TimeParameters.x.xx), _Multiply_73A249D1_Out_2);
                float2 _TilingAndOffset_2F281D2B_Out_3;
                Unity_TilingAndOffset_float(_Rotate_3D5C03C8_Out_3, float2 (1, 1), _Multiply_73A249D1_Out_2, _TilingAndOffset_2F281D2B_Out_3);
                float4 _SampleTexture2D_5AE23317_RGBA_0 = SAMPLE_TEXTURE2D(Texture2D_501E3F16, samplerTexture2D_501E3F16, _TilingAndOffset_2F281D2B_Out_3);
                float _SampleTexture2D_5AE23317_R_4 = _SampleTexture2D_5AE23317_RGBA_0.r;
                float _SampleTexture2D_5AE23317_G_5 = _SampleTexture2D_5AE23317_RGBA_0.g;
                float _SampleTexture2D_5AE23317_B_6 = _SampleTexture2D_5AE23317_RGBA_0.b;
                float _SampleTexture2D_5AE23317_A_7 = _SampleTexture2D_5AE23317_RGBA_0.a;
                float4 _Multiply_4819CC4B_Out_2;
                Unity_Multiply_float(_SampleTexture2D_5AE23317_RGBA_0, (_SampleTexture2D_5AE23317_A_7.xxxx), _Multiply_4819CC4B_Out_2);
                OutVector4_1 = _Multiply_4819CC4B_Out_2;
            }
            
            void Unity_Add_float4(float4 A, float4 B, out float4 Out)
            {
                Out = A + B;
            }
        
            // Graph Vertex
            // GraphVertex: <None>
            
            // Graph Pixel
            struct SurfaceDescriptionInputs
            {
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 uv0;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float3 TimeParameters;
                #endif
            };
            
            struct SurfaceDescription
            {
                float4 Color;
                float4 Mask;
            };
            
            SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
            {
                SurfaceDescription surface = (SurfaceDescription)0;
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float _Property_31754C63_Out_0 = _Shine;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                Bindings_Shine_f126d40ee23ac4349a37b9f5be3a22ed _Shine_8B5AAE53;
                _Shine_8B5AAE53.uv0 = IN.uv0;
                _Shine_8B5AAE53.TimeParameters = IN.TimeParameters;
                float4 _Shine_8B5AAE53_OutVector4_1;
                SG_Shine_f126d40ee23ac4349a37b9f5be3a22ed(float2 (0.3, -0.6), TEXTURE2D_ARGS(_Shine_8B5AAE53_Texture2D501E3F16_762259893, sampler_Shine_8B5AAE53_Texture2D501E3F16_762259893), _Shine_8B5AAE53_Texture2D501E3F16_762259893_TexelSize, _Shine_8B5AAE53, _Shine_8B5AAE53_OutVector4_1);
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 _Multiply_DCA2973B_Out_2;
                Unity_Multiply_float((_Property_31754C63_Out_0.xxxx), _Shine_8B5AAE53_OutVector4_1, _Multiply_DCA2973B_Out_2);
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 _Property_DD69E8DB_Out_0 = _OutlineColor;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 _Multiply_3D5BE7A2_Out_2;
                Unity_Multiply_float(_Multiply_DCA2973B_Out_2, _Property_DD69E8DB_Out_0, _Multiply_3D5BE7A2_Out_2);
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 _SampleTexture2D_1BCBBEB9_RGBA_0 = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv0.xy);
                float _SampleTexture2D_1BCBBEB9_R_4 = _SampleTexture2D_1BCBBEB9_RGBA_0.r;
                float _SampleTexture2D_1BCBBEB9_G_5 = _SampleTexture2D_1BCBBEB9_RGBA_0.g;
                float _SampleTexture2D_1BCBBEB9_B_6 = _SampleTexture2D_1BCBBEB9_RGBA_0.b;
                float _SampleTexture2D_1BCBBEB9_A_7 = _SampleTexture2D_1BCBBEB9_RGBA_0.a;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 _Add_A8123270_Out_2;
                Unity_Add_float4(_Multiply_3D5BE7A2_Out_2, _SampleTexture2D_1BCBBEB9_RGBA_0, _Add_A8123270_Out_2);
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float _Split_11D452BB_R_1 = _Add_A8123270_Out_2[0];
                float _Split_11D452BB_G_2 = _Add_A8123270_Out_2[1];
                float _Split_11D452BB_B_3 = _Add_A8123270_Out_2[2];
                float _Split_11D452BB_A_4 = _Add_A8123270_Out_2[3];
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 _Vector4_49F86CCE_Out_0 = float4(_Split_11D452BB_R_1, _Split_11D452BB_G_2, _Split_11D452BB_B_3, _SampleTexture2D_1BCBBEB9_A_7);
                #endif
                surface.Color = _Vector4_49F86CCE_Out_0;
                surface.Mask = IsGammaSpace() ? float4(1, 1, 1, 1) : float4 (SRGBToLinear(float3(1, 1, 1)), 1);
                return surface;
            }
        
            // --------------------------------------------------
            // Structs and Packing
        
            // Generated Type: Attributes
            struct Attributes
            {
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float3 positionOS : POSITION;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float3 normalOS : NORMAL;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 tangentOS : TANGENT;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 uv0 : TEXCOORD0;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 color : COLOR;
                #endif
                #if UNITY_ANY_INSTANCING_ENABLED
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                uint instanceID : INSTANCEID_SEMANTIC;
                #endif
                #endif
            };
        
            // Generated Type: Varyings
            struct Varyings
            {
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 positionCS : SV_POSITION;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 texCoord0;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 color;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 screenPosition;
                #endif
                #if UNITY_ANY_INSTANCING_ENABLED
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                uint instanceID : CUSTOM_INSTANCE_ID;
                #endif
                #endif
                #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex;
                #endif
                #endif
                #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0;
                #endif
                #endif
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
                #endif
                #endif
            };
            
            #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
            // Generated Type: PackedVaryings
            struct PackedVaryings
            {
                float4 positionCS : SV_POSITION;
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID;
                #endif
                float4 interp00 : TEXCOORD0;
                float4 interp01 : TEXCOORD1;
                float4 interp02 : TEXCOORD2;
                #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
                uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex;
                #endif
                #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
                uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0;
                #endif
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
                #endif
            };
            
            // Packed Type: Varyings
            PackedVaryings PackVaryings(Varyings input)
            {
                PackedVaryings output = (PackedVaryings)0;
                output.positionCS = input.positionCS;
                output.interp00.xyzw = input.texCoord0;
                output.interp01.xyzw = input.color;
                output.interp02.xyzw = input.screenPosition;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif
                #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
                output.stereoTargetEyeIndexAsRTArrayIdx = input.stereoTargetEyeIndexAsRTArrayIdx;
                #endif
                #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
                output.stereoTargetEyeIndexAsBlendIdx0 = input.stereoTargetEyeIndexAsBlendIdx0;
                #endif
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif
                return output;
            }
            
            // Unpacked Type: Varyings
            Varyings UnpackVaryings(PackedVaryings input)
            {
                Varyings output = (Varyings)0;
                output.positionCS = input.positionCS;
                output.texCoord0 = input.interp00.xyzw;
                output.color = input.interp01.xyzw;
                output.screenPosition = input.interp02.xyzw;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif
                #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
                output.stereoTargetEyeIndexAsRTArrayIdx = input.stereoTargetEyeIndexAsRTArrayIdx;
                #endif
                #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
                output.stereoTargetEyeIndexAsBlendIdx0 = input.stereoTargetEyeIndexAsBlendIdx0;
                #endif
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif
                return output;
            }
            #endif
        
            // --------------------------------------------------
            // Build Graph Inputs
        
            SurfaceDescriptionInputs BuildSurfaceDescriptionInputs(Varyings input)
            {
                SurfaceDescriptionInputs output;
                ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
            output.uv0 =                         input.texCoord0;
            #endif
            
            
            
            
            
            #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
            output.TimeParameters =              _TimeParameters.xyz; // This is mainly for LW as HD overwrite this value
            #endif
            
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN output.FaceSign =                    IS_FRONT_VFACE(input.cullFace, true, false);
            #else
            #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
            #endif
            
            #undef BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
            
                return output;
            }
            
        
            // --------------------------------------------------
            // Main
        
            #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/SpriteLitPass.hlsl"
        
            ENDHLSL
        }
        
        Pass
        {
            Name "Sprite Normal"
            Tags 
            { 
                "LightMode" = "NormalsRendering"
            }
           
            // Render State
            Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
            Cull Off
            ZTest LEqual
            ZWrite Off
            // ColorMask: <None>
            
        
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
        
            // Debug
            // <None>
        
            // --------------------------------------------------
            // Pass
        
            // Pragmas
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x
            #pragma target 2.0
        
            // Keywords
            // PassKeywords: <None>
            #pragma shader_feature_local _ _USEUIALPHACLIP
            
            #if defined(_USEUIALPHACLIP)
                #define KEYWORD_PERMUTATION_0
            #else
                #define KEYWORD_PERMUTATION_1
            #endif
            
            
            // Defines
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define _SURFACE_TYPE_TRANSPARENT 1
        #endif
        
        
        
        
        
        
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define ATTRIBUTES_NEED_NORMAL
        #endif
        
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define ATTRIBUTES_NEED_TANGENT
        #endif
        
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define ATTRIBUTES_NEED_TEXCOORD0
        #endif
        
        
        
        
        
        
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define VARYINGS_NEED_NORMAL_WS
        #endif
        
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define VARYINGS_NEED_TANGENT_WS
        #endif
        
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define VARYINGS_NEED_TEXCOORD0
        #endif
        
        
        
        
        
        
        
        
        
        
            #pragma multi_compile_instancing
            #define SHADERPASS_SPRITENORMAL
            
        
            // Includes
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/Shaders/2D/Include/NormalsRenderingShared.hlsl"
        
            // --------------------------------------------------
            // Graph
        
            // Graph Properties
            CBUFFER_START(UnityPerMaterial)
            float _Shine;
            float4 _OutlineColor;
            float _Stencil;
            float _StencilOp;
            float _StencilComp;
            float _StencilReadMask;
            float _StencilWriteMask;
            float _ColorMask;
            CBUFFER_END
            TEXTURE2D(_MainTex); SAMPLER(sampler_MainTex); float4 _MainTex_TexelSize;
            TEXTURE2D(_Shine_8B5AAE53_Texture2D501E3F16_762259893); SAMPLER(sampler_Shine_8B5AAE53_Texture2D501E3F16_762259893); float4 _Shine_8B5AAE53_Texture2D501E3F16_762259893_TexelSize;
            SAMPLER(_SampleTexture2D_5AE23317_Sampler_3_Linear_Repeat);
            SAMPLER(_SampleTexture2D_1BCBBEB9_Sampler_3_Linear_Repeat);
        
            // Graph Functions
            
            void Unity_Rotate_Degrees_float(float2 UV, float2 Center, float Rotation, out float2 Out)
            {
                //rotation matrix
                Rotation = Rotation * (3.1415926f/180.0f);
                UV -= Center;
                float s = sin(Rotation);
                float c = cos(Rotation);
            
                //center rotation matrix
                float2x2 rMatrix = float2x2(c, -s, s, c);
                rMatrix *= 0.5;
                rMatrix += 0.5;
                rMatrix = rMatrix*2 - 1;
            
                //multiply the UVs by the rotation matrix
                UV.xy = mul(UV.xy, rMatrix);
                UV += Center;
            
                Out = UV;
            }
            
            void Unity_Multiply_float(float2 A, float2 B, out float2 Out)
            {
                Out = A * B;
            }
            
            void Unity_TilingAndOffset_float(float2 UV, float2 Tiling, float2 Offset, out float2 Out)
            {
                Out = UV * Tiling + Offset;
            }
            
            void Unity_Multiply_float(float4 A, float4 B, out float4 Out)
            {
                Out = A * B;
            }
            
            struct Bindings_Shine_f126d40ee23ac4349a37b9f5be3a22ed
            {
                half4 uv0;
                float3 TimeParameters;
            };
            
            void SG_Shine_f126d40ee23ac4349a37b9f5be3a22ed(float2 Vector2_19BD6250, TEXTURE2D_PARAM(Texture2D_501E3F16, samplerTexture2D_501E3F16), float4 Texture2D_501E3F16_TexelSize, Bindings_Shine_f126d40ee23ac4349a37b9f5be3a22ed IN, out float4 OutVector4_1)
            {
                float2 _Rotate_3D5C03C8_Out_3;
                Unity_Rotate_Degrees_float(IN.uv0.xy, float2 (0.5, 0.5), 15, _Rotate_3D5C03C8_Out_3);
                float2 _Property_83E371EB_Out_0 = Vector2_19BD6250;
                float2 _Multiply_73A249D1_Out_2;
                Unity_Multiply_float(_Property_83E371EB_Out_0, (IN.TimeParameters.x.xx), _Multiply_73A249D1_Out_2);
                float2 _TilingAndOffset_2F281D2B_Out_3;
                Unity_TilingAndOffset_float(_Rotate_3D5C03C8_Out_3, float2 (1, 1), _Multiply_73A249D1_Out_2, _TilingAndOffset_2F281D2B_Out_3);
                float4 _SampleTexture2D_5AE23317_RGBA_0 = SAMPLE_TEXTURE2D(Texture2D_501E3F16, samplerTexture2D_501E3F16, _TilingAndOffset_2F281D2B_Out_3);
                float _SampleTexture2D_5AE23317_R_4 = _SampleTexture2D_5AE23317_RGBA_0.r;
                float _SampleTexture2D_5AE23317_G_5 = _SampleTexture2D_5AE23317_RGBA_0.g;
                float _SampleTexture2D_5AE23317_B_6 = _SampleTexture2D_5AE23317_RGBA_0.b;
                float _SampleTexture2D_5AE23317_A_7 = _SampleTexture2D_5AE23317_RGBA_0.a;
                float4 _Multiply_4819CC4B_Out_2;
                Unity_Multiply_float(_SampleTexture2D_5AE23317_RGBA_0, (_SampleTexture2D_5AE23317_A_7.xxxx), _Multiply_4819CC4B_Out_2);
                OutVector4_1 = _Multiply_4819CC4B_Out_2;
            }
            
            void Unity_Add_float4(float4 A, float4 B, out float4 Out)
            {
                Out = A + B;
            }
        
            // Graph Vertex
            // GraphVertex: <None>
            
            // Graph Pixel
            struct SurfaceDescriptionInputs
            {
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 uv0;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float3 TimeParameters;
                #endif
            };
            
            struct SurfaceDescription
            {
                float4 Color;
                float3 Normal;
            };
            
            SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
            {
                SurfaceDescription surface = (SurfaceDescription)0;
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float _Property_31754C63_Out_0 = _Shine;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                Bindings_Shine_f126d40ee23ac4349a37b9f5be3a22ed _Shine_8B5AAE53;
                _Shine_8B5AAE53.uv0 = IN.uv0;
                _Shine_8B5AAE53.TimeParameters = IN.TimeParameters;
                float4 _Shine_8B5AAE53_OutVector4_1;
                SG_Shine_f126d40ee23ac4349a37b9f5be3a22ed(float2 (0.3, -0.6), TEXTURE2D_ARGS(_Shine_8B5AAE53_Texture2D501E3F16_762259893, sampler_Shine_8B5AAE53_Texture2D501E3F16_762259893), _Shine_8B5AAE53_Texture2D501E3F16_762259893_TexelSize, _Shine_8B5AAE53, _Shine_8B5AAE53_OutVector4_1);
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 _Multiply_DCA2973B_Out_2;
                Unity_Multiply_float((_Property_31754C63_Out_0.xxxx), _Shine_8B5AAE53_OutVector4_1, _Multiply_DCA2973B_Out_2);
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 _Property_DD69E8DB_Out_0 = _OutlineColor;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 _Multiply_3D5BE7A2_Out_2;
                Unity_Multiply_float(_Multiply_DCA2973B_Out_2, _Property_DD69E8DB_Out_0, _Multiply_3D5BE7A2_Out_2);
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 _SampleTexture2D_1BCBBEB9_RGBA_0 = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv0.xy);
                float _SampleTexture2D_1BCBBEB9_R_4 = _SampleTexture2D_1BCBBEB9_RGBA_0.r;
                float _SampleTexture2D_1BCBBEB9_G_5 = _SampleTexture2D_1BCBBEB9_RGBA_0.g;
                float _SampleTexture2D_1BCBBEB9_B_6 = _SampleTexture2D_1BCBBEB9_RGBA_0.b;
                float _SampleTexture2D_1BCBBEB9_A_7 = _SampleTexture2D_1BCBBEB9_RGBA_0.a;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 _Add_A8123270_Out_2;
                Unity_Add_float4(_Multiply_3D5BE7A2_Out_2, _SampleTexture2D_1BCBBEB9_RGBA_0, _Add_A8123270_Out_2);
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float _Split_11D452BB_R_1 = _Add_A8123270_Out_2[0];
                float _Split_11D452BB_G_2 = _Add_A8123270_Out_2[1];
                float _Split_11D452BB_B_3 = _Add_A8123270_Out_2[2];
                float _Split_11D452BB_A_4 = _Add_A8123270_Out_2[3];
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 _Vector4_49F86CCE_Out_0 = float4(_Split_11D452BB_R_1, _Split_11D452BB_G_2, _Split_11D452BB_B_3, _SampleTexture2D_1BCBBEB9_A_7);
                #endif
                surface.Color = _Vector4_49F86CCE_Out_0;
                surface.Normal = float3 (0, 0, 1);
                return surface;
            }
        
            // --------------------------------------------------
            // Structs and Packing
        
            // Generated Type: Attributes
            struct Attributes
            {
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float3 positionOS : POSITION;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float3 normalOS : NORMAL;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 tangentOS : TANGENT;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 uv0 : TEXCOORD0;
                #endif
                #if UNITY_ANY_INSTANCING_ENABLED
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                uint instanceID : INSTANCEID_SEMANTIC;
                #endif
                #endif
            };
        
            // Generated Type: Varyings
            struct Varyings
            {
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 positionCS : SV_POSITION;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float3 normalWS;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 tangentWS;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 texCoord0;
                #endif
                #if UNITY_ANY_INSTANCING_ENABLED
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                uint instanceID : CUSTOM_INSTANCE_ID;
                #endif
                #endif
                #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex;
                #endif
                #endif
                #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0;
                #endif
                #endif
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
                #endif
                #endif
            };
            
            #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
            // Generated Type: PackedVaryings
            struct PackedVaryings
            {
                float4 positionCS : SV_POSITION;
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID;
                #endif
                float3 interp00 : TEXCOORD0;
                float4 interp01 : TEXCOORD1;
                float4 interp02 : TEXCOORD2;
                #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
                uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex;
                #endif
                #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
                uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0;
                #endif
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
                #endif
            };
            
            // Packed Type: Varyings
            PackedVaryings PackVaryings(Varyings input)
            {
                PackedVaryings output = (PackedVaryings)0;
                output.positionCS = input.positionCS;
                output.interp00.xyz = input.normalWS;
                output.interp01.xyzw = input.tangentWS;
                output.interp02.xyzw = input.texCoord0;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif
                #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
                output.stereoTargetEyeIndexAsRTArrayIdx = input.stereoTargetEyeIndexAsRTArrayIdx;
                #endif
                #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
                output.stereoTargetEyeIndexAsBlendIdx0 = input.stereoTargetEyeIndexAsBlendIdx0;
                #endif
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif
                return output;
            }
            
            // Unpacked Type: Varyings
            Varyings UnpackVaryings(PackedVaryings input)
            {
                Varyings output = (Varyings)0;
                output.positionCS = input.positionCS;
                output.normalWS = input.interp00.xyz;
                output.tangentWS = input.interp01.xyzw;
                output.texCoord0 = input.interp02.xyzw;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif
                #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
                output.stereoTargetEyeIndexAsRTArrayIdx = input.stereoTargetEyeIndexAsRTArrayIdx;
                #endif
                #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
                output.stereoTargetEyeIndexAsBlendIdx0 = input.stereoTargetEyeIndexAsBlendIdx0;
                #endif
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif
                return output;
            }
            #endif
        
            // --------------------------------------------------
            // Build Graph Inputs
        
            SurfaceDescriptionInputs BuildSurfaceDescriptionInputs(Varyings input)
            {
                SurfaceDescriptionInputs output;
                ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
            output.uv0 =                         input.texCoord0;
            #endif
            
            
            
            
            
            #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
            output.TimeParameters =              _TimeParameters.xyz; // This is mainly for LW as HD overwrite this value
            #endif
            
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN output.FaceSign =                    IS_FRONT_VFACE(input.cullFace, true, false);
            #else
            #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
            #endif
            
            #undef BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
            
                return output;
            }
            
        
            // --------------------------------------------------
            // Main
        
            #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/SpriteNormalPass.hlsl"
        
            ENDHLSL
        }
        
        Pass
        {
            Name "Sprite Forward"
            Tags 
            { 
                "LightMode" = "UniversalForward"
            }
           
            // Render State
            Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
            Cull Off
            ZTest LEqual
            ZWrite Off
            // ColorMask: <None>
            
        
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
        
            // Debug
            // <None>
        
            // --------------------------------------------------
            // Pass
        
            // Pragmas
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x
            #pragma target 2.0
        
            // Keywords
            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
            #pragma shader_feature_local _ _USEUIALPHACLIP
            
            #if defined(_USEUIALPHACLIP)
                #define KEYWORD_PERMUTATION_0
            #else
                #define KEYWORD_PERMUTATION_1
            #endif
            
            
            // Defines
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define _SURFACE_TYPE_TRANSPARENT 1
        #endif
        
        
        
        
        
        
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define ATTRIBUTES_NEED_NORMAL
        #endif
        
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define ATTRIBUTES_NEED_TANGENT
        #endif
        
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define ATTRIBUTES_NEED_TEXCOORD0
        #endif
        
        
        
        
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define ATTRIBUTES_NEED_COLOR
        #endif
        
        
        
        
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define VARYINGS_NEED_TEXCOORD0
        #endif
        
        
        
        
        #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
        #define VARYINGS_NEED_COLOR
        #endif
        
        
        
        
        
        
            #pragma multi_compile_instancing
            #define SHADERPASS_SPRITEFORWARD
            
        
            // Includes
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
        
            // --------------------------------------------------
            // Graph
        
            // Graph Properties
            CBUFFER_START(UnityPerMaterial)
            float _Shine;
            float4 _OutlineColor;
            float _Stencil;
            float _StencilOp;
            float _StencilComp;
            float _StencilReadMask;
            float _StencilWriteMask;
            float _ColorMask;
            CBUFFER_END
            TEXTURE2D(_MainTex); SAMPLER(sampler_MainTex); float4 _MainTex_TexelSize;
            TEXTURE2D(_Shine_8B5AAE53_Texture2D501E3F16_762259893); SAMPLER(sampler_Shine_8B5AAE53_Texture2D501E3F16_762259893); float4 _Shine_8B5AAE53_Texture2D501E3F16_762259893_TexelSize;
            SAMPLER(_SampleTexture2D_5AE23317_Sampler_3_Linear_Repeat);
            SAMPLER(_SampleTexture2D_1BCBBEB9_Sampler_3_Linear_Repeat);
        
            // Graph Functions
            
            void Unity_Rotate_Degrees_float(float2 UV, float2 Center, float Rotation, out float2 Out)
            {
                //rotation matrix
                Rotation = Rotation * (3.1415926f/180.0f);
                UV -= Center;
                float s = sin(Rotation);
                float c = cos(Rotation);
            
                //center rotation matrix
                float2x2 rMatrix = float2x2(c, -s, s, c);
                rMatrix *= 0.5;
                rMatrix += 0.5;
                rMatrix = rMatrix*2 - 1;
            
                //multiply the UVs by the rotation matrix
                UV.xy = mul(UV.xy, rMatrix);
                UV += Center;
            
                Out = UV;
            }
            
            void Unity_Multiply_float(float2 A, float2 B, out float2 Out)
            {
                Out = A * B;
            }
            
            void Unity_TilingAndOffset_float(float2 UV, float2 Tiling, float2 Offset, out float2 Out)
            {
                Out = UV * Tiling + Offset;
            }
            
            void Unity_Multiply_float(float4 A, float4 B, out float4 Out)
            {
                Out = A * B;
            }
            
            struct Bindings_Shine_f126d40ee23ac4349a37b9f5be3a22ed
            {
                half4 uv0;
                float3 TimeParameters;
            };
            
            void SG_Shine_f126d40ee23ac4349a37b9f5be3a22ed(float2 Vector2_19BD6250, TEXTURE2D_PARAM(Texture2D_501E3F16, samplerTexture2D_501E3F16), float4 Texture2D_501E3F16_TexelSize, Bindings_Shine_f126d40ee23ac4349a37b9f5be3a22ed IN, out float4 OutVector4_1)
            {
                float2 _Rotate_3D5C03C8_Out_3;
                Unity_Rotate_Degrees_float(IN.uv0.xy, float2 (0.5, 0.5), 15, _Rotate_3D5C03C8_Out_3);
                float2 _Property_83E371EB_Out_0 = Vector2_19BD6250;
                float2 _Multiply_73A249D1_Out_2;
                Unity_Multiply_float(_Property_83E371EB_Out_0, (IN.TimeParameters.x.xx), _Multiply_73A249D1_Out_2);
                float2 _TilingAndOffset_2F281D2B_Out_3;
                Unity_TilingAndOffset_float(_Rotate_3D5C03C8_Out_3, float2 (1, 1), _Multiply_73A249D1_Out_2, _TilingAndOffset_2F281D2B_Out_3);
                float4 _SampleTexture2D_5AE23317_RGBA_0 = SAMPLE_TEXTURE2D(Texture2D_501E3F16, samplerTexture2D_501E3F16, _TilingAndOffset_2F281D2B_Out_3);
                float _SampleTexture2D_5AE23317_R_4 = _SampleTexture2D_5AE23317_RGBA_0.r;
                float _SampleTexture2D_5AE23317_G_5 = _SampleTexture2D_5AE23317_RGBA_0.g;
                float _SampleTexture2D_5AE23317_B_6 = _SampleTexture2D_5AE23317_RGBA_0.b;
                float _SampleTexture2D_5AE23317_A_7 = _SampleTexture2D_5AE23317_RGBA_0.a;
                float4 _Multiply_4819CC4B_Out_2;
                Unity_Multiply_float(_SampleTexture2D_5AE23317_RGBA_0, (_SampleTexture2D_5AE23317_A_7.xxxx), _Multiply_4819CC4B_Out_2);
                OutVector4_1 = _Multiply_4819CC4B_Out_2;
            }
            
            void Unity_Add_float4(float4 A, float4 B, out float4 Out)
            {
                Out = A + B;
            }
        
            // Graph Vertex
            // GraphVertex: <None>
            
            // Graph Pixel
            struct SurfaceDescriptionInputs
            {
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 uv0;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float3 TimeParameters;
                #endif
            };
            
            struct SurfaceDescription
            {
                float4 Color;
                float3 Normal;
            };
            
            SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
            {
                SurfaceDescription surface = (SurfaceDescription)0;
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float _Property_31754C63_Out_0 = _Shine;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                Bindings_Shine_f126d40ee23ac4349a37b9f5be3a22ed _Shine_8B5AAE53;
                _Shine_8B5AAE53.uv0 = IN.uv0;
                _Shine_8B5AAE53.TimeParameters = IN.TimeParameters;
                float4 _Shine_8B5AAE53_OutVector4_1;
                SG_Shine_f126d40ee23ac4349a37b9f5be3a22ed(float2 (0.3, -0.6), TEXTURE2D_ARGS(_Shine_8B5AAE53_Texture2D501E3F16_762259893, sampler_Shine_8B5AAE53_Texture2D501E3F16_762259893), _Shine_8B5AAE53_Texture2D501E3F16_762259893_TexelSize, _Shine_8B5AAE53, _Shine_8B5AAE53_OutVector4_1);
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 _Multiply_DCA2973B_Out_2;
                Unity_Multiply_float((_Property_31754C63_Out_0.xxxx), _Shine_8B5AAE53_OutVector4_1, _Multiply_DCA2973B_Out_2);
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 _Property_DD69E8DB_Out_0 = _OutlineColor;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 _Multiply_3D5BE7A2_Out_2;
                Unity_Multiply_float(_Multiply_DCA2973B_Out_2, _Property_DD69E8DB_Out_0, _Multiply_3D5BE7A2_Out_2);
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 _SampleTexture2D_1BCBBEB9_RGBA_0 = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv0.xy);
                float _SampleTexture2D_1BCBBEB9_R_4 = _SampleTexture2D_1BCBBEB9_RGBA_0.r;
                float _SampleTexture2D_1BCBBEB9_G_5 = _SampleTexture2D_1BCBBEB9_RGBA_0.g;
                float _SampleTexture2D_1BCBBEB9_B_6 = _SampleTexture2D_1BCBBEB9_RGBA_0.b;
                float _SampleTexture2D_1BCBBEB9_A_7 = _SampleTexture2D_1BCBBEB9_RGBA_0.a;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 _Add_A8123270_Out_2;
                Unity_Add_float4(_Multiply_3D5BE7A2_Out_2, _SampleTexture2D_1BCBBEB9_RGBA_0, _Add_A8123270_Out_2);
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float _Split_11D452BB_R_1 = _Add_A8123270_Out_2[0];
                float _Split_11D452BB_G_2 = _Add_A8123270_Out_2[1];
                float _Split_11D452BB_B_3 = _Add_A8123270_Out_2[2];
                float _Split_11D452BB_A_4 = _Add_A8123270_Out_2[3];
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 _Vector4_49F86CCE_Out_0 = float4(_Split_11D452BB_R_1, _Split_11D452BB_G_2, _Split_11D452BB_B_3, _SampleTexture2D_1BCBBEB9_A_7);
                #endif
                surface.Color = _Vector4_49F86CCE_Out_0;
                surface.Normal = float3 (0, 0, 1);
                return surface;
            }
        
            // --------------------------------------------------
            // Structs and Packing
        
            // Generated Type: Attributes
            struct Attributes
            {
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float3 positionOS : POSITION;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float3 normalOS : NORMAL;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 tangentOS : TANGENT;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 uv0 : TEXCOORD0;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 color : COLOR;
                #endif
                #if UNITY_ANY_INSTANCING_ENABLED
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                uint instanceID : INSTANCEID_SEMANTIC;
                #endif
                #endif
            };
        
            // Generated Type: Varyings
            struct Varyings
            {
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 positionCS : SV_POSITION;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 texCoord0;
                #endif
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                float4 color;
                #endif
                #if UNITY_ANY_INSTANCING_ENABLED
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                uint instanceID : CUSTOM_INSTANCE_ID;
                #endif
                #endif
                #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex;
                #endif
                #endif
                #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0;
                #endif
                #endif
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
                FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
                #endif
                #endif
            };
            
            #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
            // Generated Type: PackedVaryings
            struct PackedVaryings
            {
                float4 positionCS : SV_POSITION;
                #if UNITY_ANY_INSTANCING_ENABLED
                uint instanceID : CUSTOM_INSTANCE_ID;
                #endif
                float4 interp00 : TEXCOORD0;
                float4 interp01 : TEXCOORD1;
                #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
                uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex;
                #endif
                #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
                uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0;
                #endif
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
                #endif
            };
            
            // Packed Type: Varyings
            PackedVaryings PackVaryings(Varyings input)
            {
                PackedVaryings output = (PackedVaryings)0;
                output.positionCS = input.positionCS;
                output.interp00.xyzw = input.texCoord0;
                output.interp01.xyzw = input.color;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif
                #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
                output.stereoTargetEyeIndexAsRTArrayIdx = input.stereoTargetEyeIndexAsRTArrayIdx;
                #endif
                #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
                output.stereoTargetEyeIndexAsBlendIdx0 = input.stereoTargetEyeIndexAsBlendIdx0;
                #endif
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif
                return output;
            }
            
            // Unpacked Type: Varyings
            Varyings UnpackVaryings(PackedVaryings input)
            {
                Varyings output = (Varyings)0;
                output.positionCS = input.positionCS;
                output.texCoord0 = input.interp00.xyzw;
                output.color = input.interp01.xyzw;
                #if UNITY_ANY_INSTANCING_ENABLED
                output.instanceID = input.instanceID;
                #endif
                #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
                output.stereoTargetEyeIndexAsRTArrayIdx = input.stereoTargetEyeIndexAsRTArrayIdx;
                #endif
                #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
                output.stereoTargetEyeIndexAsBlendIdx0 = input.stereoTargetEyeIndexAsBlendIdx0;
                #endif
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                output.cullFace = input.cullFace;
                #endif
                return output;
            }
            #endif
        
            // --------------------------------------------------
            // Build Graph Inputs
        
            SurfaceDescriptionInputs BuildSurfaceDescriptionInputs(Varyings input)
            {
                SurfaceDescriptionInputs output;
                ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
            output.uv0 =                         input.texCoord0;
            #endif
            
            
            
            
            
            #if defined(KEYWORD_PERMUTATION_0) || defined(KEYWORD_PERMUTATION_1)
            output.TimeParameters =              _TimeParameters.xyz; // This is mainly for LW as HD overwrite this value
            #endif
            
            #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
            #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN output.FaceSign =                    IS_FRONT_VFACE(input.cullFace, true, false);
            #else
            #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
            #endif
            
            #undef BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
            
                return output;
            }
            
        
            // --------------------------------------------------
            // Main
        
            #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/SpriteForwardPass.hlsl"
        
            ENDHLSL
        }
        
    }
    FallBack "Hidden/Shader Graph/FallbackError"
}
