shader_type canvas_item;

uniform float strength = 0.01;
uniform float black_radius = 0.65;

uniform sampler2D SCREEN_TEXTURE : hint_screen_texture, filter_linear_mipmap;

void fragment() {
	float angle = atan(UV.x - 0.5, UV.y - 0.5) * strength;
	float len = distance(UV, vec2(0.5, 0.5));
	
	vec3 color = vec3(sin(len*30.0 + angle*100.0));
	COLOR = vec4(color, 1.0);
}