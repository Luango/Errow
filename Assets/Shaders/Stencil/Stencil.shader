Shader "Unlit/Stencil"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {} 
		_Cutoff("Alpha Cutoff", Float) = 0.5

		_Color("Tint", Color) = (0,0,0,1)
		[MaterialToggle] PixelSnap("Pixel snap", Float) = 0
		_AlphaCutoff("Alpha Cutoff", Range(0.01, 1.0)) = 0.01

	}
		SubShader
	{
		Tags{ 
			"Queue" = "Transparent" 
			"IgnoreProjector" = "True" 
			"RenderType" = "Transparent"
			"PreviewType" = "Plane"
			"CanUseSpriteAtlas" = "True"
		}
		LOD 100
			Cull Off
			Lighting Off
			ZWrite Off
			Blend One OneMinusSrcAlpha

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
		/*
		Pass
	{
		Stencil
	{
		Ref 5
		Comp Always
		Pass Replace
	}
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma multi_compile _ PIXELSNAP_ON
#include "UnityCG.cginc"

		struct appdata_t
	{
		float4 vertex   : POSITION;
		float4 color    : COLOR;
		float2 texcoord : TEXCOORD0;
	};

	struct v2f
	{
		float4 vertex   : SV_POSITION;
		fixed4 color : COLOR;
		half2 texcoord  : TEXCOORD0;
	};

	fixed4 _Color;
	fixed _AlphaCutoff;

	v2f vert(appdata_t IN)
	{
		v2f OUT;
		OUT.vertex = UnityObjectToClipPos(IN.vertex);
		OUT.texcoord = IN.texcoord;
		OUT.color = IN.color * _Color;
#ifdef PIXELSNAP_ON
		OUT.vertex = UnityPixelSnap(OUT.vertex);
#endif

		return OUT;
	}

	sampler2D _MainTex;
	sampler2D _AlphaTex;
	float _AlphaSplitEnabled;

	fixed4 SampleSpriteTexture(float2 uv)
	{
		fixed4 color = tex2D(_MainTex, uv);
		if (_AlphaSplitEnabled)
			color.a = tex2D(_AlphaTex, uv).r;

		return color;
	}

	fixed4 frag(v2f IN) : SV_Target
	{
		fixed4 c = SampleSpriteTexture(IN.texcoord) * IN.color;
	c.rgb *= c.a;

	// Discard pixels below cutoff so that stencil is only updated for visible pixels.
	clip(c.a - _AlphaCutoff);

	return c;
	}
		ENDCG
	}*/
	}
} 