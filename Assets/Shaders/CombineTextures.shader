Shader "CombineTextures" {
     Properties 
     {
        _Color ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {} 
        _BlendTex ("Blend (RGB)", 2D) = "white" {}
     }
     SubShader 
     {
        Tags { "Queue"="Geometry" "IgnoreProjector"="True" "RenderType"="Transparent" }
        Lighting On
        LOD 200
        Blend SrcAlpha OneMinusSrcAlpha

        Pass{
        	SetTexture [_MainTex] { combine texture }
        	SetTexture [_BlendTex] { combine texture lerp (texture) previous }
        }
  		
        CGPROGRAM
        #pragma surface surf Lambert
  
        fixed4 _Color;
        sampler2D _MainTex;
        sampler2D _BlendTex;
  
        struct Input {
          float2 uv_MainTex;
          float2 uv_BlendTex;
        };
  
        void surf (Input IN, inout SurfaceOutput o) {
			float4 mainTex = tex2D (_MainTex, IN.uv_MainTex);
			float4 overlayTex = tex2D (_BlendTex, IN.uv_MainTex);
			half3 mainTexVisible = mainTex.rgb * (1-overlayTex.a);
			half3 overlayTexVisible = overlayTex.rgb * (overlayTex.a);

			float3 finalColor = (mainTexVisible + overlayTexVisible) * _Color;
         	o.Albedo = finalColor.rgb * 1.0f;
        	o.Emission = fixed4(0.0f,0.0f,0.0f,0.0f);
          	o.Alpha = 0.5f * ( mainTex.a + overlayTex.a );
        }
        ENDCG
     }
  
     Fallback "Diffuse"
 }