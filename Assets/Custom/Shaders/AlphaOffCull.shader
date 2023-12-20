Shader "Custom/AlphaOffCull"{
    Properties
    {
        _Color("Main Color", Color) = (1,1,1,1)
        _MainTex("Base (RGB) Trans (A)", 2D) = "white" {}
        _Cutout("Cutout", Range(0,1)) = 0.9
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" "Queue" = "Geometry" }
            LOD 200
       Cull Off
            
               Tags { "RenderType" = "Opaque" }
               CGPROGRAM
               #pragma surface surf Standard fullforwardshadows alphatest:_Cutout
               sampler2D _Color;
               sampler2D _MainTex;

               struct Input
               {
                   half2 uv_MainTex;
               
               };

               void surf(Input IN, inout SurfaceOutputStandard o)
               {
                   // Grab the base color from the texture
                   fixed4 c = tex2D(_MainTex, IN.uv_MainTex);

                  
                   // Otherwise, apply the material properties
                   o.Albedo = c.rgb;
                   o.Alpha = c.a;
               }
               ENDCG
            
        }
            Fallback "Transparent/VertexLit"
}