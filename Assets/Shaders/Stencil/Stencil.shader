Shader "Unlit/Stencil"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {} 
		_Cutoff("Alpha Cutoff", Float) = 0.5
	}
		SubShader
	{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		LOD 100

		Pass
	{
		Stencil{
		Ref 0
		Comp Equal
		Pass IncrSat
		Fail IncrSat
	}
		Blend SrcAlpha OneMinusSrcAlpha
		Cull Off

		CGPROGRAM 

#pragma vertex vert
#pragma fragment frag
		
#include "UnityCG.cginc"
	sampler2D _MainTex; 
	half4 _Color;
	uniform float _Cutoff;

		struct appdata
	{
		float4 vertex : POSITION;
		float4 texcoord : TEXCOORD0;
	};

	struct v2f
	{
		float4 vertex : SV_POSITION;
		half4 color : COLOR;
		float4 tex : TEXCOORD0;
	};

	v2f vert(appdata v)
	{
		v2f o;
		o.tex = v.texcoord;
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.color = _Color;
		return o;
	}

	fixed4 frag(v2f i) : SV_Target
	{
		fixed4 col = fixed4(0.0, 0.0, 0.0, 1.0);
	col.a = tex2D(_MainTex, i.tex.xy).a;
	if (col.a < _Cutoff)
		// alpha value less than user-specified threshold?
	{
		discard; // yes: discard this fragment
	}
	return col;
	}
		ENDCG
	}

		Pass
	{
		Stencil{
		Ref 1
		Comp Less
	}

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

		struct appdata
	{
		float4 vertex : POSITION;
	};

	struct v2f
	{
		float4 vertex : SV_POSITION;
		half4 color : COLOR;
	};

	v2f vert(appdata v)
	{
		v2f o;
		o.vertex = UnityObjectToClipPos(v.vertex);
		return o;
	}

	fixed4 frag(v2f i) : SV_Target
	{
		fixed4 col = fixed4(1.0, 1.0, 1.0, 1.0); 

	return col;
	}
		ENDCG
	}

		Pass
	{
		Stencil{
		Ref 2
		Comp Less
	}

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

		struct appdata
	{
		float4 vertex : POSITION;
	};

	struct v2f
	{
		float4 vertex : SV_POSITION;
	};

	v2f vert(appdata v)
	{
		v2f o;
		o.vertex = UnityObjectToClipPos(v.vertex);
		return o;
	} 
	fixed4 frag(v2f i) : SV_Target
	{ 
		fixed4 col = fixed4(0.0, 0.0, 0.0, 1.0); 
	return col;
	}
		ENDCG
	}
	}
} 