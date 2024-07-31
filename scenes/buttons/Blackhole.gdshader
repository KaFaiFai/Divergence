shader_type canvas_item;

uniform float frequency : hint_range(1.0, 20.0, 1.0) = 11;
uniform vec4 color : source_color = vec4(1);
uniform bool rotate = false;

void fragment() {
	float angle = atan(UV.x - 0.5, UV.y - 0.5) * frequency 
		+ TIME * float(rotate) * 10.0;
	float len = distance(UV, vec2(0.5, 0.5));
	float swirl_strength = (sin(len*30.0 + angle) + 1.0) / 2.0;
	float inner_strength = 1.0 - smoothstep(0.2, 0.35, len);
	float strength = swirl_strength + inner_strength;
	
	float alpha = 1.0 - smoothstep(0.3, 0.5, len);
	alpha = min(alpha, strength);
	COLOR = vec4(color.rgb, alpha);
}