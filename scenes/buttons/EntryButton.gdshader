shader_type canvas_item;

uniform vec4 color: source_color;

void fragment() {
	float length_to_center = distance(UV, vec2(0.5, 0.5));
	float alpha = 1.0 - step(0.5, length_to_center);
	float border_strength = smoothstep(0.3, 0.4, length_to_center);
	vec3 final_color = (1.0-border_strength) * vec3(1,1,1) + border_strength*color.rgb;
	COLOR = vec4(final_color, alpha);
}